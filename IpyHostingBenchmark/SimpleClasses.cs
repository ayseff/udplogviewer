using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using stej.Tools.UdpLogViewer.Core;
using System.Diagnostics;

namespace IpyHostingBenchmark
{
	public class SimpleClasses
	{
		public void Run()
		{
			Console.WriteLine("Loading csharp classes");
			List<ISimple> processorcsharp = new List<ISimple>();
			processorcsharp.AddRange(Enumerable.Range(0, 2000).Select(i => new Simple()));

			Console.WriteLine("Loading Ipy classes");
			List<ISimple> processorIpy = new List<ISimple>();
			Ipy.ExecuteFile(new[] { "simpleRulesIpy.py" }, new Dictionary<string, object> { { "processor", processorIpy } });

			Console.WriteLine("Loading csharp classes from Ipy");
			List<ISimple> processorIpyCSharp = new List<ISimple>();
			Ipy.ExecuteFile(new[] { "simpleRulescsharp.py" }, new Dictionary<string, object> { { "processor", processorIpyCSharp } });

			Console.WriteLine("Counts: {0}, {1}, {2}", processorcsharp.Count, processorIpy.Count, processorIpyCSharp.Count);

			Compute(processorcsharp, "Counting via csharp classes");
			Compute(processorIpyCSharp, "Counting via csharp classes loaded by ipy");
			Compute(processorIpy, "Counting via ipy classes");
		}

		private static void Compute(List<ISimple> processor, string message)
		{
			Console.WriteLine(message);
			Stopwatch sw = new Stopwatch();
			sw.Start();
			for (int i = 0; i< 10000; i++) 
			{
				foreach (ISimple p in processor)
				{
					var n = p.GetNumber("");
				}
			}
			sw.Stop();
			Console.WriteLine("{0}ms", sw.ElapsedMilliseconds);
		}
	}

	public interface ISimple
	{
		int GetNumber(string s);
	}

	public class Simple : ISimple
	{
		public int GetNumber(string s)
		{
			return 100;
		}
	}
}
