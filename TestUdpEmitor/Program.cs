using System;
using System.Text;
using System.Threading;
using log4net;
using log4net.Config;
using System.IO;

namespace TestUdpEmitor
{
	class Program
	{
		static ILog logger = LogManager.GetLogger("abclogger");
		static Random rand = new Random();

		static void Main(string[] args)
		{
			XmlConfigurator.Configure();

			if (args.Length > 0)
			{
				RandomLogs();
				return;
			}

			Random r = new Random();
			while (true)
			{
				int count = 10 + r.Next(40);
				for (int i = 0; i<count; i++)
					logger.DebugFormat("#{0} item, time: {1}", i, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
				Console.WriteLine("debugovaci: ");
				Console.ReadLine();
				logger.Debug("debugovaci zaznam, tak aby byl pekne dlouhejhejejhejelejehejej l;kadsf;lkjasd flkja hej asdlkj a ---- uz bude konec");
				Console.WriteLine("info: ");
				Console.ReadLine();
				logger.Info("info");
				Console.WriteLine("warn:");
				Console.ReadLine();
				logger.Warn("warn  123456789 123456789 123456789 123456789 123456789");
				Console.WriteLine("error: ");
				Console.ReadLine();
				logger.Error("error");
				Console.WriteLine("error s exc: ");
				Console.ReadLine();
				logger.Error("error s exc", new ApplicationException("vyjimka"));
				Console.WriteLine("fatal: aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa konec");
				Console.ReadLine();
				logger.Fatal("fatal s exc", new ApplicationException("vyjimka"));
			}
		}

		private static void RandomLogs()
		{
			while (true)
			{
				Thread.Sleep(rand.Next(300));
				int num = rand.Next(100);
				if (num < 60)
					continue;
				if (num < 85)
					logger.Debug("debug: " + RandString());
				else if (num < 92)
					logger.Info("info: " + RandString());
				else if (num < 96)
					logger.Warn("warn: " + RandString());
				else if (num < 98)
					logger.Error("error: " + RandString(), RandExc());
				else
					logger.Fatal("fatal: " + RandString(), RandExc());
			}
		}

		private static string RandString()
		{
			StringBuilder sb = new StringBuilder();
			for(int i = 0; i < rand.Next(50); i++)
				sb.Append((char)rand.Next(32, 150)+ (rand.Next(8)==0?"\r\n":""));
			return sb.ToString();
		}

		private static Exception RandExc()
		{
			if (rand.Next(4) < 3)
				return null;
			return new ApplicationException(RandString());
		}
	}
}
