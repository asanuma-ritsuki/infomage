using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Sample.備忘録
{
	class _39_インデクサーの定義
	{
	}

	public partial class MyClass
	{
		private int[] array = new int[100];
		private Dictionary<string, int> dict = new Dictionary<string, int>();

		// int型インデクサー
		public int this[int i]
		{
			get
			{
				return array[i];
			}
			set
			{
				array[i] = value;
			}
		}

		//getterのみの場合は、式形式で記述可能
		public int this[string s] => dict.ContainsKey(s) ? dict[s] : 0;
	}
}
