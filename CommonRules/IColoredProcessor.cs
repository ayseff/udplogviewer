using System.Drawing;

namespace stej.Tools.UdpLogViewer.CommonRules
{
	public interface IColoredProcessor
	{
		Color? Color { get; set; }

		Color? BackColor { get; set; }
	}
}
