using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace stej.Tools.UdpLogViewer.Forms.UIConfig
{
	public class ColumnsWidth
	{
		public int Logger { get; set; }
		public int Date { get; set; }
		public int Time { get; set; }
		public int Exc { get; set; }
		public int Message { get; set; }

		public ColumnsWidth()
		{
			Logger = 50;
			Date = 50;
			Time = 50;
			Exc = 20;
			Message = 300;
		}
	}
}
