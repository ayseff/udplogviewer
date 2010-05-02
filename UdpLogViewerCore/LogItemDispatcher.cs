using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace stej.Tools.UdpLogViewer.Core
{
	public class LogItemDispatcher
	{
		LogMessagesCollector _collector;
		
		private IPEndPoint _ipe;
		private UdpClient _udpCli;
		private Level _currentTreshold = Level.DEBUG;

		private object _itemsToDisplayLock = new object();
		private List<LogItem> _itemsToDisplay = new List<LogItem>();

		public Level Treshold
		{
			get { return _currentTreshold; }
			set { _currentTreshold = value; }
		}

		public static Level[] Levels = new Level[] { Level.DEBUG, Level.INFO, Level.WARN, Level.ERROR, Level.FATAL };

		public bool Start(ApplicationSettings settings)
		{
			try
			{
				_ipe = new IPEndPoint(settings.IP, settings.Port);
				_udpCli = new UdpClient(settings.Port);
			}
			catch (Exception ex)
			{
				throw new ApplicationException("Error when opening socked: " + ex.ToString());
			}

			_collector = new LogMessagesCollector(_udpCli, _ipe, settings.Treshold);
			_collector.NewLog += NewLogHandler;
			_collector.Go();

			Sleeping = false;

			return true;
		}

		public bool Sleeping { get; set; }

		public void Close()
		{
			_collector.Stop();
			_udpCli.Close();
		}

		void NewLogHandler(object sender, NewLogEventArgs args)
		{
			if (Sleeping)
				return;
			lock (_itemsToDisplayLock)
			{
				if (args.Item.LogLevel >= Treshold)
					_itemsToDisplay.Add(args.Item);
			}
		}

		public IEnumerable<LogItem> FreshLogs
		{
			get
			{
				List<LogItem> ret = new List<LogItem>();
				lock (_itemsToDisplayLock)
				{
					ret.AddRange(_itemsToDisplay);
					_itemsToDisplay.Clear();
				}
				return ret;
			}
		}
	}
}
