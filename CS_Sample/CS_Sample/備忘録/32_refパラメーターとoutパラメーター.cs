using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Sample.備忘録
{
	class _32_refパラメーターとoutパラメーター
	{
		static void Main(string[] args)
		{
			var i = 1;
			var j = 2;
			Swap(ref i, ref j);
			// i = 2
			// j = 1
			var k = 0;
			int l;
			//初期化済みの値、未初期化の値両方利用できる
			Out(out k, out l);
			// k = 1
			// l = 2
		}

		static void Swap(ref int x, ref int y)
		{
			var temp = x;
			x = y;
			y = temp;
		}

		static void Out(out int x, out int y)
		{
			x = 1;
			y = 2;
		}
	}
}
