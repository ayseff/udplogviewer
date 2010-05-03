import Growl.Connector
from stej.Tools.UdpLogViewer.CommonRules import Show, Swallow
connector = Growl.Connector.GrowlConnector()
cond = [
	#ToFile('.'),
	#ToGrowl('#25|#35', connector),
	Swallow('warn'),
	Show('debug', Color.Cyan, Color.Black),
	Show('info', Color.Magenta, Color.Black),
	Show('10', Color.BlueViolet, Color.Black),
	Show('11', Color.Brown, Color.Black),
	Show('error', Color.BurlyWood, Color.Black)
]

for c in cond: processor.Add(c)