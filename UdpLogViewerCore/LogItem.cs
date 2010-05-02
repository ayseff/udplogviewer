using System;
using System.IO;
using System.Xml;
using stej.Tools.UdpLogViewer.Core.Exceptions;
using System.Diagnostics;

namespace stej.Tools.UdpLogViewer.Core
{
    [DebuggerDisplay("Logger = {Logger}, Message = {Message}, Date = {Date}")]
	public class LogItem
	{
		public string Logger = "";
		public DateTime Date;
		public Level LogLevel;
		public string Thread = "";
		public string Domain = "";
		public string Username = "";
		public string Message = "";
		public string Exception = null;

		public LogItem()
		{
		}

		public LogItem(string logger, Level level, string thread, string domain, string username, string message)
		{
			Logger = logger;
			Date = DateTime.Now;
			LogLevel = level;
			Thread = thread;
			Domain = domain;
			Username = username;
			Message = message;
		}

		public LogItem(string evnt)
		{
			XmlTextReader reader = new XmlTextReader(new StringReader(evnt));
			try
			{
				reader.MoveToContent();
				if (reader.Name != "event")
				{
					reader.Close();
				}
				Logger = reader.GetAttribute("logger");
				string timeStampe = reader.GetAttribute("timestamp");
				string level = reader.GetAttribute("level");
				Thread = reader.GetAttribute("thread");
				Domain = reader.GetAttribute("domain");
				Username = reader.GetAttribute("username");
				reader.Read();
				Message = reader.ReadElementString("message");
				reader.Skip();	// preskoci "global-properties"

				Date = DateTime.Parse(timeStampe);
				try
				{
					LogLevel = (Level)Level.Parse(typeof(Level), level, true);
				}
				catch (Exception e)
				{
					throw new LogParserException("Unknown level: " + level, e);
				}
				if (LogLevel >= Level.ERROR && reader.Name == "exception")
				{
					Exception = reader.ReadElementString("exception");
				}

				reader.Close();
			}
			catch (Exception e)
			{
				throw new LogParserException("Unexpected error", e);
			}
		}
	}
}
