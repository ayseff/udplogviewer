import clr
import System
from System.Text.RegularExpressions import Regex
from IpyHostingBenchmark import ITestProcessor

class IpyMatchProcessor(ITestProcessor):
	def __init__(self, regex):
		self.regex = regex
	def Match(self, s):
		return Regex.IsMatch(s, self.regex)

for c in [IpyMatchProcessor(i.ToString()) for i in range(100,500)]:
	processor.Add(c)
#