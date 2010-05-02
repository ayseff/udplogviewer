using System;
using System.Windows.Forms;

namespace stej.Tools.UdpLogViewer.Forms
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Form1 frm = new Form1();
			if (frm.IsDisposed)
				return;
			Application.Run(frm);
		}
	}
}