using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Sample.備忘録
{
	class _33_パラメーター配列
	{
		static void Main(string[] args)
		{
			var array = new[] { 1, 2, 3 };
			// 3個の引数が指定されました
			Param(array);
			// 2個の引数が指定されました
			Param(array);
			// 0個の引数が指定されました
			Param();
		}

		static void Param(params int[] array)
		{
			Console.WriteLine($"{array.Length}個の引数が指定されました");
		}
	}
}
