using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Test
{
	public class XAssert
	{
		public static void Eq(object o, object o2)
		{
			if (o.Equals(o2))
				return;
			throw new ApplicationException(string.Format("Objects are different: {0} / {1}", o, o2));
		}
	}
}
