using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace stej.Tools.UdpLogViewer.Forms.UIConfig
{
	public class ProcessorsForm
	{
		public int Width { get; set; }
		public int Height { get; set; }

		public ProcessorsForm()
		{
			Height = 200;
			Width = 150;
		}

		/// <summary>Updates form width and height from current <see cref="Width"/> and <see cref="Height"/>.</summary>
		public void Use(Form p)
		{
			p.Width = Width;
			p.Height = Height;
		}

		/// <summary>Updates current <see cref="Width"/> and <see cref="Height"/> from passed form <paramref name="p"/>.</summary>
		public void Update(Form p)
		{
			Width = p.Width;
			Height = p.Height;
		}
	}
}
