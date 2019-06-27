using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Sample.備忘録
{
	class _34_省略可能なパラメーター
	{
		static void Main(string[] args)
		{
			// x = 1 y = a
			Test(1);
			// x = 2 y = b
			Test(2, "b");
		}

		static void Test(int x, string y = "a")
		{
			Console.WriteLine($"x={x} y={y}");
		}
	}
}
