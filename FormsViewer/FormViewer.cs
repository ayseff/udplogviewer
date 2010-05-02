using stej.Tools.UdpLogViewer.Core;
using System.Collections.Generic;
using System.Windows.Forms;
using System;
using System.Drawing;
using Microsoft.Win32;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Diagnostics;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Linq;
using System.Text;
using stej.Tools.UdpLogViewer.Forms.UIConfig;

namespace stej.Tools.UdpLogViewer.Forms
{
	public partial class Form1 : Form
	{
		//[DllImport("kernel32.dll")]
		//public static extern bool Beep(int frequency, int duration);

		Configuration _config = new Configuration();
		MessageProcessors _processors = new MessageProcessors();
		LogItemDispatcher _dispatcher = new LogItemDispatcher();
		UIConfiguration _uiConfig = new UIConfiguration();
		
		public Form1()
		{
			InitializeComponent();
			//todo lepe
			try { _config.Read(); }
			catch (Exception ex) { ShowError(exception : ex); }

			_processors.RereadProcessors();
			try
			{
				if (!_dispatcher.Start(_config.Settings))
				{
					this.Close();
					return;
				}
			}
			catch (ApplicationException e)
			{
				ShowError(message : e.Message);
				this.Close();
				return;
			}

			logGrid.SelectionMode     = DataGridViewSelectionMode.FullRowSelect;
			logGrid.MultiSelect       = false;
			logGrid.RowHeadersVisible = false;
			logGrid.MaxRows           = _config.Settings.BufferHeight;
			logGrid.Font              = new Font(logGrid.Font, FontStyle.Bold);
			logGrid.RowsAdded += new DataGridViewRowsAddedEventHandler(RowsAddedHandler);
			logGrid.RowsRemoved += new DataGridViewRowsRemovedEventHandler(RowsRemovedHandler);
			levelsLB.SelectedIndex = 0;

			this.FormClosing += (s,e) =>
			{
				SaveUIConfig();
				_dispatcher.Close();
				try { _processors.CloseProcessors(); }
                catch (ApplicationException ex) { ShowError(message: ex.Message); }
			};
			this.KeyDown += new KeyEventHandler(KeyDownHandler);
			this.KeyPreview = true;
			this.SizeChanged += (o, e) => {
				if (this.WindowState != FormWindowState.Minimized)
				{
					_uiConfig.FormWidth  = Size.Width; 
					_uiConfig.FormHeight = Size.Height; 
				}
			};

			sleepCheck.CheckedChanged += (s, e) => _dispatcher.Sleeping = sleepCheck.Checked; 

			LoadUIConfig();

			LogSettings(string.Format("IP: {0}", _config.Settings.IP));
			LogSettings(string.Format("Port: {0}", _config.Settings.Port));
			LogSettings(string.Format("Treshold: {0}", _config.Settings.Treshold));
			LogSettings(string.Format("Width: {0}", _config.Settings.Width));
			LogSettings(string.Format("Height: {0}", _config.Settings.Height));
			LogSettings(string.Format("Buffer height: {0}", _config.Settings.BufferHeight));

			Array.ForEach(LogItemDispatcher.Levels, LogDefaultColors);

			System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
			timer.Interval = 50;
			timer.Tick += TimerTicked;
			timer.Start();

			lbProcessors.DataSource = new List<string>(_processors.Files);
			lbProcessors.SelectedIndexChanged += (o, a) => _processors.ChangeProcessors(lbProcessors.SelectedValue.ToString());
		}

        private void ShowError(string message = null, Exception exception = null)
        {
            StringBuilder sb = new StringBuilder();
            if (message != null)
                sb.AppendLine(message);
            if (exception != null)
                sb.AppendLine(exception.ToString());
            MessageBox.Show(sb.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        }

		void LogSettings(string message)
		{
			logGrid.AddLogRow(new LogItem("settings", Level.INFO, "0", "", "", message), Color.White, Color.Black);
		}

		void LogDefaultColors(Level level)
		{
			ColorPair p = _config.GetColor(level);
			logGrid.AddLogRow(new LogItem("colors", Level.INFO, "0", "", "", level.ToString()),	p.Fore, p.Back);
		}

		void AddError(string err, Exception ex)
		{
			logGrid.AddLogRow(
				new LogItem{Message=err,Date=DateTime.Now,LogLevel=Level.ERROR, Exception = ex != null ? ex.ToString() : "" }, 
				Color.Red, 
				Color.Black);
		}
		void AddInfo(string mess)
		{
			logGrid.AddLogRow(new LogItem { Message = mess, Date = DateTime.Now, LogLevel = Level.ERROR}, Color.Yellow, Color.Black);
		}

		void KeyDownHandler(object sender, KeyEventArgs e)
		{
			if (e.Alt || e.Control || e.Shift)
				return;
			switch (e.KeyCode)
			{
				//case Keys.O:
				//    OpenCfgClick(this, EventArgs.Empty);
				//    e.Handled = true;
				//    break;
				//case Keys.R:
					//ReadCfgClick(this, EventArgs.Empty);
					//e.Handled = true;
					//break;
				case Keys.C:
					ClearClick(this, EventArgs.Empty);
					e.Handled = true;
					break;
				case Keys.S:
					sleepCheck.Checked = !sleepCheck.Checked;
					_dispatcher.Sleeping = sleepCheck.Checked;
					e.Handled = true;
					break;
				case Keys.L:
					scrollCheck.Checked = !scrollCheck.Checked;
					e.Handled = true;
					break;
				case Keys.Add:
					if (levelsLB.SelectedIndex < levelsLB.Items.Count-1)
						levelsLB.SelectedIndex++;
					break;
				case Keys.Subtract:
					if (levelsLB.SelectedIndex > 0)
						levelsLB.SelectedIndex--;
					break;
			}
		}

		void RowsAddedHandler(object sender, DataGridViewRowsAddedEventArgs e)
		{
			rowsCountLab.Text = logGrid.Rows.Count.ToString();
		}

		void RowsRemovedHandler(object sender, DataGridViewRowsRemovedEventArgs e)
		{
			rowsCountLab.Text = logGrid.Rows.Count.ToString();
		}

		private void RowSelectedHandler(object sender, EventArgs e)
		{
			if (logGrid.SelectedRows.Count > 0)
			{
				Debug.Assert(logGrid.SelectedRows[0] is LogGridRow);
				LogItem item = ((LogGridRow)logGrid.SelectedRows[0]).LogItem;
				string exc = item.Exception;

				string str = string.Format("{0} {1}({2}), {3}, {4} {5} {6}",
					item.Logger, item.Domain, item.Thread, item.Username, item.Date.ToShortDateString(), item.Date.ToString("HH:mm:ss.fff"), item.Message);
				if (exc != null)
					str = string.Concat(str, "\r\n", exc);
				concreteItemTB.Text = str;
			}
		}
		
		private void SelectedLevelChanged(object sender, EventArgs e)
		{
			try
			{
				_dispatcher.Treshold = (Level)Enum.Parse(typeof(Level), levelsLB.SelectedItem.ToString());
			}
			catch
			{
				ShowError(message:"Please specify correct level value. Current: "+levelsLB.SelectedItem);
				return;
			}
		}

		private void ClearClick(object sender, EventArgs e)
		{
			logGrid.Rows.Clear();
		}

		//private void ReadCfgClick(object sender, EventArgs e)
		//{
		//    ReadConfig();
		//}

		//private void OpenCfgClick(object sender, EventArgs e)
		//{
		//    string cfgFile = "\""+AppDomain.CurrentDomain.SetupInformation.ConfigurationFile+"\"";
		//    Thread thread = new Thread(delegate()
		//    {
		//        Process convertorProcess = new Process();
		//        convertorProcess.StartInfo = new ProcessStartInfo("notepad", cfgFile);
		//        convertorProcess.Start();
		//    });
		//    // backgroud thread - neblokuje ukonceni procesu (kdyz konci proces, ukonci se i vsechny bezici background vlakna)
		//    thread.IsBackground = true;
		//    thread.Start();
		//}

		private void FontClick(object sender, EventArgs e)
		{
			FontDialog dia = new FontDialog();
			dia.FontMustExist = true;
			dia.ShowColor = false;
			dia.ShowEffects = false;
			dia.Font = logGrid.Font;
			if (dia.ShowDialog() == DialogResult.OK)
			{
				float rat = (float)dia.Font.Height / logGrid.Font.Height;
				logGrid.RowTemplate.Height = (int)Math.Round(logGrid.RowTemplate.Height*rat);
				logGrid.Font.Dispose();
				logGrid.Font = dia.Font;
			}
			dia.Dispose();
		}

		void TimerTicked(object sender, EventArgs e)
		{
			IEnumerable<LogItem> logs = _dispatcher.FreshLogs;

			foreach (LogItem item in logs)
			{
				_processors.ProcessMessage(
					item,
					(proc, res) =>
					{
						ColorPair cp = _config.GetColor(item.LogLevel);	// getting default
						if (res != null)
							cp = new ColorPair(res.Color ?? cp.Fore, res.BackColor ?? cp.Back);
						logGrid.AddLogRow(item, cp.Fore, cp.Back);

						if (scrollCheck.Checked && logGrid.Rows.Count > 0)
						{
							logGrid.CurrentCell = logGrid[0, logGrid.Rows.Count - 1];
						}
					});
			}
		}

		#region HELPERS

		private void SaveUIConfig()
		{
			try
			{
				_uiConfig.ColumnsWidths.Logger  = loggerTypeCol.Width;
				_uiConfig.ColumnsWidths.Date    = dateCol.Width;
				_uiConfig.ColumnsWidths.Time    = timeCol.Width;
				_uiConfig.ColumnsWidths.Exc     = excColumn.Width;
				_uiConfig.ColumnsWidths.Domain  = DomainCol.Width;
				_uiConfig.ColumnsWidths.Thread   = ThreadCol.Width;
				_uiConfig.ColumnsWidths.UserName = UserCol.Width;
				_uiConfig.ColumnsWidths.Message = msgCol.Width;
				_uiConfig.Treshold              = (Level)Enum.Parse(typeof(Level),levelsLB.SelectedItem.ToString());
				_uiConfig.Font                  = logGrid.Font;
				_uiConfig.Save();
			}
			catch (Exception ex)
			{
				ShowError("Error when saving settings to ui config", ex);
			}
		}

		private void LoadUIConfig()
		{
			try
			{
				_uiConfig.Load();
				loggerTypeCol.Width = _uiConfig.ColumnsWidths.Logger;
				dateCol.Width       = _uiConfig.ColumnsWidths.Date;
				timeCol.Width       = _uiConfig.ColumnsWidths.Time;
				excColumn.Width     = _uiConfig.ColumnsWidths.Exc;
				msgCol.Width        = _uiConfig.ColumnsWidths.Message;
				DomainCol.Width     = _uiConfig.ColumnsWidths.Domain;
				ThreadCol.Width     = _uiConfig.ColumnsWidths.Thread;
				UserCol.Width       = _uiConfig.ColumnsWidths.UserName;

				logGrid.Font.Dispose();
				logGrid.Font          = _uiConfig.Font;
				levelsLB.SelectedItem = _uiConfig.Treshold.ToString();

				Size = new Size(_uiConfig.FormWidth, _uiConfig.FormHeight);
			}
			catch (Exception ex)
			{
				AddError("Unable to read ui config settings. Defaults will be used.", ex);
			}
		}

		#endregion

		private void bRules_Click(object sender, EventArgs e)
		{
			Processors p = new Processors(_processors.Items, _uiConfig.ProcessorsForm);
			p.ShowDialog();
		}

		private void bReload_Click(object sender, EventArgs e)
		{
			try { _processors.CloseProcessors(); }
			catch (ApplicationException ex) { ShowError(message:ex.Message); }
			_processors.RereadProcessors();
			lbProcessors.DataSource = new List<string>(_processors.Files);
		}

		private void bShowMatches_Click(object sender, EventArgs e)
		{
			if (logGrid.SelectedRows.Count == 0)
			{
				AddInfo("There is no text that can be tested");
				return;
			}
			LogItem item = ((LogGridRow)logGrid.SelectedRows[0]).LogItem;
			Processors p = new Processors(_processors.Items, _uiConfig.ProcessorsForm);
			p.TestLogItem(item);
			p.ShowDialog();
		}
	}
}