import System.Net
from System.Drawing import Color
from stej.Tools.UdpLogViewer.Core import Level,ColorPair

settings.IP   = System.Net.IPAddress.Parse('127.0.0.1')
settings.Port = 8080
settings.Treshold = Level.ALL

settings.Width        = 100
settings.Height       = 40
# count of rows that are visible in the grid
settings.BufferHeight = 9000

colors.Add(Level.DEBUG, ColorPair(Color.Silver, Color.Black))
colors.Add(Level.INFO, ColorPair(Color.Black, Color.White))
colors.Add(Level.WARN, ColorPair(Color.Black, Color.DarkRed))
colors.Add(Level.ERROR, ColorPair(Color.Black, Color.Red))
colors.Add(Level.FATAL, ColorPair(Color.Black, Color.Yellow))