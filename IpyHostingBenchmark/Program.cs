using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using stej.Tools.UdpLogViewer.Core;
using System.Reflection;
using System.Diagnostics;

namespace IpyHostingBenchmark
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("----------- forms classes --------------");
			new FormsClases().Run();

			Console.WriteLine("----------- simple classes --------------");
			new SimpleClasses().Run();
		}
	}
}
