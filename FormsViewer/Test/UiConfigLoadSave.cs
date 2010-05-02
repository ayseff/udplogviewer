using stej.Tools.UdpLogViewer.Forms.UIConfig;
using stej.Tools.UdpLogViewer.Core;
using System;
using NUnit.Framework;
using System.Windows.Forms;
namespace Test
{
	[TestFixture]
	//public class Program
	public class UiConfigLoadSave
	{
		//static void Main(string[] args)
		//{
		//    TestUiConfigLoadSave();
		//}

		[Test]
		public void TestUiConfigLoadSave() 
		{
			UIConfiguration c = new UIConfiguration();
			c.Treshold = Level.INFO;
			c.ColumnsWidths.Logger = 1;
			c.ColumnsWidths.Domain = 2;
			c.ColumnsWidths.Thread = 3;
			c.ColumnsWidths.UserName = 4;
			c.ColumnsWidths.Date = 20;
			c.ColumnsWidths.Time = 30;
			c.ColumnsWidths.Exc = 40;
			c.ColumnsWidths.Message = 50;
			c.Save();

			UIConfiguration c2 = new UIConfiguration();
			c2.Load();

			Assert.AreEqual(c.Treshold, c2.Treshold);
			Assert.AreEqual(c.ColumnsWidths.Logger, c2.ColumnsWidths.Logger);
			Assert.AreEqual(c.ColumnsWidths.Domain, c2.ColumnsWidths.Domain);
			Assert.AreEqual(c.ColumnsWidths.Thread, c2.ColumnsWidths.Thread);
			Assert.AreEqual(c.ColumnsWidths.UserName, c2.ColumnsWidths.UserName);
			Assert.AreEqual(c.ColumnsWidths.Date, c2.ColumnsWidths.Date);
			Assert.AreEqual(c.ColumnsWidths.Time, c2.ColumnsWidths.Time);
			Assert.AreEqual(c.ColumnsWidths.Exc, c2.ColumnsWidths.Exc);
			Assert.AreEqual(c.ColumnsWidths.Message, c2.ColumnsWidths.Message);
			
			Console.WriteLine("Tests succeeded");
		}

		[Test]
		public void UpdateProcessorsForm_Success()
		{
			ProcessorsForm c = new ProcessorsForm();
			Form f = new Form() { Width=100, Height = 200 };
			c.Update(f);
			Assert.AreEqual(c.Width, f.Width);
			Assert.AreEqual(c.Height, f.Height);
		}
	}
}
