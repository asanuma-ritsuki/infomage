using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Sample.備忘録
{
	class _21_forとforeachステートメント
	{
		static void Main(string[] args)
		{
			var array = new[] { 1, 3, 5 };

			Console.WriteLine("for文");
			var length = array.Length;
			for (int i = 0; i < length; i++)
			{
				Console.WriteLine(array[i]);
			}

			Console.WriteLine("foreach文：配列");
			foreach (var e in array)
			{
				Console.WriteLine(e);
			}

			Console.WriteLine("foreach文：Enumerator");
			var enumerable = Enumerable.Range(1, 5);
			foreach (var e in enumerable)
			{
				Console.WriteLine(e);
			}

			Console.WriteLine("foreach文：cast");
			//int型とdouble型を混ぜた配列をobject[]型として宣言
			var objects = new object[] { 1, 3, 4.5f };
			//int型はvarだとobject型になるが、以下のようにint型で宣言するとキャストされるため、
			//要素がdouble型のときにキャストに失敗して実行時例外がスローされる
			foreach (int e in objects)
			{
				Console.WriteLine(e);
			}
		}
	}
}
