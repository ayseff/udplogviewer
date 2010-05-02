using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using stej.Tools.UdpLogViewer.Core;
using Microsoft.Scripting.Hosting;
using System.IO;
using System.Drawing;
using System.Globalization;

namespace stej.Tools.UdpLogViewer.Forms.UIConfig
{
	public class UIConfiguration
	{
		ColumnsWidth _widths = new ColumnsWidth();
		FontInfo _font = new FontInfo();
		ProcessorsForm _processorsForm = new ProcessorsForm();

		public UIConfiguration()
		{
			Treshold = Level.DEBUG;
			FormWidth = 600;
			FormHeight = 400;
		}

		public ColumnsWidth ColumnsWidths 
		{ 
			get { return _widths; } 
		}

		public Level Treshold { get; set; }

		public int FormWidth { get; set; }
		public int FormHeight { get; set; }

		public ProcessorsForm ProcessorsForm
		{
			get { return _processorsForm; }
		}

		public Font Font 
		{ 
			get { return new Font(FontInfo.Name, FontInfo.Size); }
			set { _font = new FontInfo() { Name = value.Name, Size = value.Size };}
		}
		public FontInfo FontInfo 
		{
			get { return _font; }
		}

		public void Load()
		{
			ScriptScope sc = Ipy.CreateScope(new Dictionary<string,object>{
				{"widths", _widths}, 
				{"font", FontInfo},
				{"processorsForm", _processorsForm } });
			Ipy.ExecuteFile(new string[] { "uiconfig.py"}, scope: sc);
			string treshold = sc.GetVariable<string>("treshold");
			Treshold = (Level)Level.Parse(typeof(Level), treshold);
			FormWidth = sc.GetVariable<int>("width");
			FormHeight = sc.GetVariable<int>("height");
		}

		public void Save()
		{
			using (StreamWriter sw = new StreamWriter("uiconfig.py"))
			{
				sw.WriteLine("width = {0}", FormWidth);
				sw.WriteLine("height = {0}", FormHeight);
				sw.WriteLine("widths.Logger = {0}", _widths.Logger);
				sw.WriteLine("widths.Domain = {0}", _widths.Domain);
				sw.WriteLine("widths.Thread = {0}", _widths.Thread);
				sw.WriteLine("widths.UserName = {0}", _widths.UserName);
				sw.WriteLine("widths.Date = {0}", _widths.Date);
				sw.WriteLine("widths.Time = {0}", _widths.Time);
				sw.WriteLine("widths.Exc = {0}", _widths.Exc);
				sw.WriteLine("widths.Message = {0}", _widths.Message);
				sw.WriteLine("treshold = '{0}'", Treshold);
				sw.WriteLine("font.Name = '{0}'", FontInfo.Name);
				sw.WriteLine("font.Size = {0}", FontInfo.Size.ToString(CultureInfo.InvariantCulture));
				sw.WriteLine("processorsForm.Width = {0}", _processorsForm.Width);
				sw.WriteLine("processorsForm.Height = {0}", _processorsForm.Height);
			}
		}
	}
}
