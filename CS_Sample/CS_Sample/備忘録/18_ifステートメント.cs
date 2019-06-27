using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Sample.備忘録
{
	class _18_ifステートメント
	{
		static void Main(string[] args)
		{
			var flg = true;
			//true
			if (flg)
				Console.WriteLine("true");
			//else if
			if (Check())
			{
				Console.WriteLine("if");
			}
			else if (flg)
			{
				Console.WriteLine("else if");
			}
			else
			{
				Console.WriteLine("else");
			}
		}

		static bool Check()
		{
			return false;
		}
	}
}
