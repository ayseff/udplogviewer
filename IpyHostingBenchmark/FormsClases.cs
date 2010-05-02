using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using stej.Tools.UdpLogViewer.Core;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace IpyHostingBenchmark
{
	class FormsClases
	{
		public void Run()
		{
			Console.WriteLine("Loading csharp classes");
			List<ITestProcessor> processorcsharp = new List<ITestProcessor>();
			processorcsharp.AddRange(Enumerable.Range(100, 400) .Select(i => new MatchProcessor(i.ToString())));

			Console.WriteLine("Loading Ipy classes");
			List<ITestProcessor> processorIpy = new List<ITestProcessor>();
			Ipy.ExecuteFile(new[] { "formsRules.py" }, new Dictionary<string, object> { { "processor", processorIpy } });

			Console.WriteLine("Loading csharp classes from Ipy");
			List<ITestProcessor> processorIpyCSharp = new List<ITestProcessor>();
			Ipy.ExecuteFile(new[] { "formsRulescsharp.py" }, new Dictionary<string, object> { { "processor", processorIpyCSharp } });

			Console.WriteLine("Generating strings");
			var randomStrings = Enumerable.Range(0, 500).Select(r => DateTime.Now.AddSeconds(r).ToString());

			Console.WriteLine("Counts: {0}, {1}, {2}", processorcsharp.Count, processorIpy.Count, processorIpyCSharp.Count);

			Compute(processorcsharp, randomStrings, "Counting via csharp classes");
			Compute(processorIpyCSharp, randomStrings, "Counting via csharp classes loaded by ipy");
			Compute(processorIpy, randomStrings, "Counting via ipy classes");
		}

		private static void Compute(List<ITestProcessor> processor, IEnumerable<string> randomStrings, string message)
		{
			Console.WriteLine(message);
			Stopwatch sw = new Stopwatch();
			sw.Start();
			foreach (string str in randomStrings)
			{
				bool result = false;
				foreach (ITestProcessor p in processor)
					result = p.Match("this is test");
			}
			sw.Stop();
			Console.WriteLine("{0}ms", sw.ElapsedMilliseconds);
		}
	}

	public interface ITestProcessor
	{
		bool Match(string s);
	}

	public class MatchProcessor : ITestProcessor
	{
		string _r;
		public MatchProcessor(string r) { _r = r; }
		public bool Match(string s)
		{
			return Regex.IsMatch(s, _r);
		}
	}
}
