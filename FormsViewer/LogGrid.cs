using System.Drawing;
using System.Windows.Forms;
using stej.Tools.UdpLogViewer.Core;

namespace stej.Tools.UdpLogViewer.Forms
{
	public class LogGrid : DataGridView
	{
		private int _maxRows;

		public LogGrid()
		{
			this.BorderStyle = BorderStyle.None;
		}

		public int MaxRows
		{
			get	{	return _maxRows;	}
			set	{	_maxRows = value;	}
		}

		public void AddLogRow(LogItem item, Color foreColor, Color backColor)
		{
			if (Rows.Count > MaxRows && Rows.Count > 0)
				Rows.RemoveAt(0);

			bool nonEmptyFoundAlready = false;
			string message = item.Message;
			if (item.Exception != null)
				message = string.Concat(message, "\n", item.Exception);

			string[] messageParts = message.Split('\r', '\n');
			for (int i = 0; i < messageParts.Length; i++)
			{
				// pokud mam zpravu, kde je "abc\r\n12", pak mi to rozdeli na "abc","","","12", proto test na delku 0
				if (messageParts[i].Length == 0)
					continue;

				LogGridRow row = new LogGridRow(item);

				if (nonEmptyFoundAlready)
					row.CreateCells(this, "", "", "", "", messageParts[i]);
				else
					row.CreateCells(
						this,
						item.Logger, item.Date.ToShortDateString(), item.Date.ToString("HH:mm:ss.fff"), item.Exception!=null?"(x)":"", messageParts[i]);

				DataGridViewCellStyle style = new DataGridViewCellStyle();
				style.ForeColor = foreColor;
				style.BackColor = backColor;
				style.Padding = new Padding(0);
				row.DefaultCellStyle = style;
				row.Height = (int)(Font.GetHeight()*1.3);
				Rows.Add(row);

				nonEmptyFoundAlready = true;
			}
		}

	//	private void 
	}
}
