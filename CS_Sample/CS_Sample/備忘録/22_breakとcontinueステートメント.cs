using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Sample.備忘録
{
	class _22_breakとcontinueステートメント
	{
		static void Main(string[] args)
		{
			var array = new[] { 1, 2, 3, 4, 5 };

			foreach (var e in array)
			{
				if (e % 2 == 1)
					continue;   //奇数のときは次の繰り返しへ制御を移す(=以下のコードはスキップされる)

				if (e == 4)
					break;  //4のときにforeachを終了させる

				Console.WriteLine(e);	//出力されるのは「2」のみ
			}
		}
	}
}
