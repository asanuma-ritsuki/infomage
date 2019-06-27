using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Sample.備忘録
{
	class _08_配列
	{
		static void Main(string[] args)
		{
			//要素数を指定して配列を初期化
			var array1 = new int[2];
			//要素数を指定して配列を初期化
			var array2 = new[] { 1, 2, 3 };
			//プロパティ、フィールドなど左辺に型を記述する場合、new[]は不要
			double[] array3 = { 1d, 2.3d };
			//配列はIList<T>を実装している
			IList<string> list3 = new[] { "A", "B" };
			//2次元配列
			var array5 = new[,] { { 1, 2 }, { 3, 4 } };
			//配列の配列
			var array6 = new[] { new[] { 1, 3, 5 }, new[] { 2, 4, 6, 8 } };
		}
		
	}
}
