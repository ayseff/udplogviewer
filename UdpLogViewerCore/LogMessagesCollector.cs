using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace stej.Tools.UdpLogViewer.Core
{
	public class NewLogEventArgs : EventArgs
	{
		public LogItem Item;
		public NewLogEventArgs(LogItem item)
		{
			Item = item;
		}
	}
	public class ErrorOccuredEventArgs : EventArgs
	{
		public Exception Exception;
		public ErrorOccuredEventArgs(Exception e)
		{
			Exception = e;
		}
	}
	public delegate void NewLogArrivedDelegate(object sender, NewLogEventArgs args);
	public delegate void ErrorOccuredDelegate(object sender, ErrorOccuredEventArgs args);

	public class LogMessagesCollector
	{
		public event NewLogArrivedDelegate NewLog;
		public event NewLogArrivedDelegate UninterestingLog;
		public event ErrorOccuredDelegate ErrorOccured;

		private object _membersLock = new object();

		private bool _stop = false;

		private UdpClient _client;
		private IPEndPoint _ipe;

		private Level _treshold;

		private Thread _running = null;

		public LogMessagesCollector(UdpClient client, IPEndPoint ipe, Level treshold)
		{
			_client = client;
			_ipe = ipe;
			_treshold = treshold;
		}

		public Level Treshold
		{
			get	{	return _treshold; }	
		}

		public void Go()
		{
			_running = new Thread(Runner);
			_running.Start();
		}

		public void Stop()
		{
			_stop = true;
			_running.Interrupt();
		}

		public void Runner()
		{
			while(true)
			{
				if (_stop)
					break;
				try
				{
					byte[] sent = _client.Receive(ref _ipe);
					LogItem newItem = new LogItem(Encoding.ASCII.GetString(sent));
					if (newItem.LogLevel >= Treshold)
					{
						if (NewLog != null)
							NewLog(this, new NewLogEventArgs(newItem));
					}
					else
					{
						if (UninterestingLog != null)	
							UninterestingLog(this, new NewLogEventArgs(newItem));
					}
				}
				catch (SocketException e)
				{
					if (!_stop)
						ProcessError(e);
				}
				catch (Exception e)
				{
					ProcessError(e);
				}
			}
		}

		private void ProcessError(Exception e)
		{
			if (ErrorOccured != null)
				ErrorOccured(this, new ErrorOccuredEventArgs(e));
		}

		public void IncreaseLevel()
		{
			lock(_membersLock)
			{
				if (_treshold == Level.FATAL)
					return;
				_treshold++;
			}
		}

		public void DecreaseLevel()
		{
			lock (_membersLock)
			{
				if (_treshold == Level.DEBUG)
					return;
				_treshold--;
			}
		}
	}
}
