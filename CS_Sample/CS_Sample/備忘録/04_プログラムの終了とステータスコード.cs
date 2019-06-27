using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Sample.備忘録
{
	class _04_プログラムの終了とステータスコード
	{
		//Environment.Exitメソッドによるステータスコードを指定した終了
		static void Main(string[] args)
		{
			Environment.Exit(1);
		}
	}

	class _04_02_プログラムの終了とステータスコード
	{
		//Mainメソッドの返り値でステータスコードを指定
		static int Main(string[] args)
		{
			return 1;
		}
	}
}
