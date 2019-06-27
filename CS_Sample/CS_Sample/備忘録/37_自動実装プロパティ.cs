using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Sample.備忘録
{
	class _37_自動実装プロパティ
	{
		static void Main(string[] args)
		{
			var my = new MyClass();
			my.UpdateValue1();
			my.Value2 = 12;
		}
	}

	public partial class MyClass
	{
		public int Value1 { get; private set; }

		public int Value2 { get; set; } = 2;	//自動実装プロパティの初期化

		public int Value3 { get; }

		public MyClass()
		{
			//getter only プロパティはコンストラクタでも代入可能
			Value3 = 3;
		}

		public void UpdateValue1()
		{
			//privateなsetterなのでインスタンス内から変更可能
			//Value3は更新できない
			Value1 = 1;
		}
	}
}
