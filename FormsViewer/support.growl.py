import clr
clr.AddReferenceToFile('Growl.Connector.dll')
clr.AddReferenceToFile('Growl.CoreLibrary.dll')

import System
import Growl.Connector

def send(caption, message):
	connector = Growl.Connector.GrowlConnector()
	notification = Growl.Connector.Notification('PowerGrowler', 'Default', System.DateTime.Now.Ticks.ToString(), caption, message)
	connector.Notify(notification)
	
def registerApp(appName, name, displayName, iconPath=None):
	from System import Array
	connector = Growl.Connector.GrowlConnector()
	type = Growl.Connector.NotificationType(name, displayName)
	if iconPath != None:
		type.Icon =  iconPath
	connector.Register(Growl.Connector.Application(appName), Array[Growl.Connector.NotificationType]([type])) 
# registerApp('UdpLogViewer', 'lv', 'Message from ipy')