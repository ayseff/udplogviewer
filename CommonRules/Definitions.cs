using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using stej.Tools.UdpLogViewer.Core;

namespace stej.Tools.UdpLogViewer.CommonRules
{
	public class Show : LogItemProcessor, IColoredProcessor
	{
		public Show(string regex, Color? c = null, Color? b = null, bool regexOnLogger = false) :
			base(regex, c, b, regexOnLogger)
		{
		}

		public override ProcessingResult Process(LogItem item, object[] parms)
		{
			if (Matches(item))
				return ProcessingResult.Matches(Color, BackColor);
			return ProcessingResult.ContinueWithProcessing();
		}
	}

	public class Swallow : LogItemProcessor
	{
		public Swallow(string regex, bool regexOnLogger = false) :
			base(regex, null, null, regexOnLogger)
		{
			DetailsInfo = string.Format("{0} - {1}", Name, regex);
		}

		public override ProcessingResult Process(LogItem item, object[] parms)
		{
			if (Matches(item))
				return ProcessingResult.StopSilently();
			return ProcessingResult.ContinueWithProcessing();
		}
	}
}