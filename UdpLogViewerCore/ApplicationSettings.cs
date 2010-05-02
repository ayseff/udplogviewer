using System;
using System.Collections.Specialized;
using System.Configuration;
using System.Net;
using System.Xml;

namespace stej.Tools.UdpLogViewer.Core
{
	public class ApplicationSettings
	{
		public IPAddress IP;
		public int Port;
		public int Width;
		public int Height;
		public int BufferHeight;
		public bool Beep = true;
		public Level Treshold;
	}
}
