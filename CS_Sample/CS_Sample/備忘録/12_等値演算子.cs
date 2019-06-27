using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Sample.備忘録
{
	class _12_等値演算子
	{
		static void Main(string[] args)
		{
			var f1 = 1 == 2;    //false
			var f2 = 1 != 1;    //false
			var f3 = new object() == new object();  //false
			var f4 = "abc" == string.Copy("a") + "bc";	//true
		}
	}
}
