using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Sample.備忘録
{
	class _02_コマンドライン引数
	{
		static void Main(string[] args)
		{
			foreach (var arg in args)
			{
				Console.WriteLine(arg);
			}
			Console.ReadLine();
		}
	}
}
