using System;

namespace stej.Tools.UdpLogViewer.Core.Exceptions
{
	class ConditionException : ApplicationException
	{
		public ConditionException(string str)
			: base(str)
		{
		}

		public ConditionException(string str, Exception e)
			: base(str, e)
		{
		}
	}
}
