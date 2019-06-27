using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Sample.備忘録
{
	class _20_whileとdoステートメント
	{
		static void Main(string[] args)
		{
			int term = 0;
			while (term <= 3)
			{
				Console.WriteLine(term);
				++term;
			}

			term = 0;
			do
			{
				Console.WriteLine(term);
				++term;
			} while (term == 0);
		}
	}
}
