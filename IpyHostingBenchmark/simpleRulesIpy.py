import clr
import System
import IpyHostingBenchmark

class SimpleIpy(IpyHostingBenchmark.ISimple):
	def GetNumber(self, s):
		return 100

for c in [SimpleIpy() for i in range(0, 2000)]:
	processor.Add(c)