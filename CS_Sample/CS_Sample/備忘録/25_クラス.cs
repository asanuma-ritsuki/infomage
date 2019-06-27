using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Sample.備忘録
{
	class MyClass
	{
		//フィールド
		public static readonly int DefaultLimit = 10;

		private int term;

		//コンストラクタ
		public MyClass() : this(DefaultLimit)
		{ }

		public MyClass(int limit)
		{
			Limit = limit;
		}

		//プロパティ
		public int Limit { get; }

		//メソッド
		public void Try()
		{
			term = 0;
			while (term < Limit)
			{
				Console.WriteLine($"{term}回目");
				++term;
			}
		}
	}
}
