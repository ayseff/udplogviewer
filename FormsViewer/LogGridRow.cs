using System.Windows.Forms;
using stej.Tools.UdpLogViewer.Core;

namespace stej.Tools.UdpLogViewer.Forms
{
	public class LogGridRow : DataGridViewRow
	{
		private readonly LogItem _item;

		public LogGridRow(LogItem item)
		{
			_item = item;
		}

		public LogItem LogItem
		{
			get {	return _item; }
		}
	}
}
