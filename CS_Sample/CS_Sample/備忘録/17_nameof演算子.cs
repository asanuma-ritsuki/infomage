using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Sample.備忘録
{
	class _17_nameof演算子
	{
		static void Main(string[] args)
		{
			var s1 = nameof(args);  //args
			var s2 = nameof(DateTime.Now);  //Now
			var s3 = nameof(System.Linq);	//Linq
		}
	}
}
