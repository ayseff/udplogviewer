using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace stej.Tools.UdpLogViewer.Core
{
	public class Configuration
	{
		ApplicationSettings _settings;
		Dictionary<Level, ColorPair> _colors = new Dictionary<Level, ColorPair>();

		public ApplicationSettings Settings
		{
			get { return _settings; }
		}

		public ColorPair GetColor(Level l)
		{
			return _colors[l];
		}

		public void Read()
		{
			_settings = new ApplicationSettings();
			_colors = new Dictionary<Level, ColorPair>();

			Ipy.ExecuteFile(new[] { "config.py" }, new Dictionary<string, object> { { "settings", _settings }, { "colors", _colors } });
		}
	}
}
