using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Sample.備忘録
{
	class _35_拡張メソッド
	{
		static void Main(string[] args)
		{
			var s = "abcd";
			var text = "CD";
			// true
			var flg = s.ContainsIgnoreCase(text);
		}
	}

	public static class MyExtensions
	{
		public static bool ContainsIgnoreCase(this string s, string text)
		{
			return s.ToLower().Contains(text.ToLower());
		}
	}
}
