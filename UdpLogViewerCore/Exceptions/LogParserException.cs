using System;

namespace stej.Tools.UdpLogViewer.Core.Exceptions
{
	class LogParserException : ApplicationException
	{
		public LogParserException(string str)
			: base(str)
		{
		}

		public LogParserException(string str, Exception e)
			: base(str, e)
		{
		}
	}
}
