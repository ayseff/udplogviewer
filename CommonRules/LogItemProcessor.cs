using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using stej.Tools.UdpLogViewer.Core;
using System.Drawing;
using System.Text.RegularExpressions;

namespace stej.Tools.UdpLogViewer.CommonRules
{
	public abstract class LogItemProcessor : IProcessor 
	{
		// I had some problems with default parameters - IronPython could not call it, it was always
		// complaining something about null
		public LogItemProcessor(string regex, Color? color, Color? backColor, bool regexOnLogger)
		{
			Enabled       = true;
			Regex         = new Regex(regex, RegexOptions.Compiled | RegexOptions.IgnoreCase);
			Color         = color;
			BackColor     = backColor;
			RegexOnLogger = regexOnLogger;
			Name          = GetType().Name;
			DetailsInfo   = string.Format("{0} - {1}. {2}/{3}", Name, Regex, Color, BackColor);
		}
		public LogItemProcessor(string regex) : this(regex, null, null, false) 
		{
		}

		public Regex Regex { get; set; }
		public Color? Color { get; set; }
		public Color? BackColor { get; set; }
		public bool RegexOnLogger { get; set; }

		protected bool Matches(LogItem item)
		{
			return RegexOnLogger 
				? IsMatch(item.Logger)
				: IsMatch(item.Message);
		}

		public bool IsMatch(string s)
		{
			return Regex.IsMatch(s);
		}

		public abstract ProcessingResult Process(LogItem item, object[] parms);

		public virtual void Close()
		{
		}

		public bool Enabled { get; set; }

		public string Name { get; set; }

		public string DetailsInfo { get; set; }

		public override string ToString()
		{
			if (string.IsNullOrEmpty(DetailsInfo))
				return string.Format("{0} - {1}. {2}/{3}", GetType().Name, Regex, Color, BackColor);
			return DetailsInfo;
		}
	}
}