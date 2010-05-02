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
			else
			{
				Console.WriteLine("Press enter to start..");
				Console.WriteLine("(in case you would like to send some random messages, just pass any argument. E.g. > TestUdpEmitor.exe something)");
				Console.ReadLine();
			}

			Random r = new Random();
			while (true)
			{
				int count = 10 + r.Next(40);
				for (int i = 0; i<count; i++)
					logger.DebugFormat("#{0} item, time: {1}", i, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
				Console.WriteLine("debugovaci: ");
				Console.ReadLine();
				logger.Debug("debug message, veeery veeeeeeeeery long; something more here, veeeery long message and .. some more words here... ");
				Console.WriteLine("info: ");
				Console.ReadLine();
				logger.Info("info message");
				Console.WriteLine("warn:");
				Console.ReadLine();
				logger.Warn("warn with some numbers 123456789 123456789 123456789 123456789 123456789");
				Console.WriteLine("error: ");
				Console.ReadLine();
				logger.Error("error");
				Console.WriteLine("error with exception:");
				Console.ReadLine();
				logger.Error("error with exception", new ApplicationException("something wrong happened"));
				Console.WriteLine("fatal: error.. and end of loop");
				Console.ReadLine();
				logger.Fatal("fatal with exception", new ApplicationException("fatal error"));
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
