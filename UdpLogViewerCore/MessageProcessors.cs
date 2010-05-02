using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace stej.Tools.UdpLogViewer.Core
{
	public class MessageProcessors
	{
		Dictionary<string, List<IProcessor>> _messageProcessors = new Dictionary<string, List<IProcessor>>();
		string _currentProcessorsFile = null;
		object _processorsLock = new object();

		/// <summary>
		/// Returns all current processor. Thread safe.
		/// </summary>
		public IEnumerable<IProcessor> Items
		{
			get
			{
				IProcessor[] processors;
				lock (_processorsLock)
					processors = CurrentProcessors.ToArray();
				return processors;
			}
		}

		List<IProcessor> CurrentProcessors
		{
			get 
			{
				return _currentProcessorsFile == null 
						? new List<IProcessor>()
						: _messageProcessors[_currentProcessorsFile]; 
			}
		}

		/// <summary>
		/// Returns list of available files with defined processors.
		/// </summary>
		public IEnumerable<string> Files
		{
			get { return _messageProcessors.Keys; }
		}

		/// <summary>
		/// Sets new active set of processors. The sets are identified by the file name where they are defined.
		/// </summary>
		/// <param name="file">Nane of file.</param>
		public void ChangeProcessors(string file)
		{
			lock (_processorsLock)
			{
				if (!_messageProcessors.ContainsKey(file))
					throw new InvalidOperationException(string.Format("File {0} is not known. Processors from this file weren't loaded."));
				_currentProcessorsFile = file;
			}
		}

		/// <summary>
		/// Called to notify the processors that they will not be used any more.
		/// </summary>
		public void CloseProcessors()
		{
			lock (_processorsLock)
			{
				List<string> _errors = new List<string>();
				CurrentProcessors.ForEach(
					p =>
					{
						try { p.Close(); }
						catch (Exception ex) { _errors.Add(string.Format("Unable to close {0}. {1}", p.ToString(), ex)); }
					});
				if (_errors.Count > 0)
					throw new ApplicationException(string.Join("\n", _errors));
			}
		}

		/// <summary>
		/// Read the files with processors again.
		/// </summary>
		public void RereadProcessors()
		{
			lock (_processorsLock)
			{
				_messageProcessors = new Dictionary<string, List<IProcessor>>();

				foreach (var f in Directory.GetFiles(".", "rules*.py"))
				{
					string file = Path.GetFileName(f);
					List<IProcessor> processors = new List<IProcessor>();
					Ipy.ExecuteFile(
						new[] { "definitions.py", file },
						new Dictionary<string, object> { { "processor", processors } });
					if (_currentProcessorsFile == null)
						_currentProcessorsFile = file;
					_messageProcessors[file] = processors;
				}
			}
		}

		/// <summary>
		/// Process udp log message by the current processors and optionally perform the <paramref name="action"/>.
		/// </summary>
		/// <param name="item">Log item.</param>
		/// <param name="action">Action to perform if the processors allow it (see 
		///		<see cref="ProcessingResult.ShowToUser"/>.
		///	</param>
		public void ProcessMessage(LogItem item, Action<IProcessor, ProcessingResult> action)
		{
			IProcessor[] processors;
			lock (_processorsLock)
			{
				processors = CurrentProcessors.Where(a => a.Enabled).ToArray();
			}

			ProcessingResult res = null;
			IProcessor stopping = null;
			foreach (var p in processors)
			{
				ProcessingResult r = p.Process(item, null);
				if (r.Stop)
				{
					res = r;
					stopping = p;
					break;
				}
			}

			if (res != null && !res.ShowToUser)
				return;

			action(stopping, res);

		}
	}
}
