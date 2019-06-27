using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Sample.備忘録
{
	class _07_文字列補間
	{
		static void Main(string[] args)
		{
			var name = "テスト";
			var s1 = $@"名前は
{name}";
			var s2 = $"Now: {DateTime.Now:f}";
		}
	}
}
