using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace stej.Tools.UdpLogViewer.Core
{
	public class ColorPair
	{
		public Color Fore { get; set; }
		public Color Back { get; set; }
		public ColorPair(Color fore, Color back)
		{
			Fore = fore;
			Back = back;
		}
	}
}
