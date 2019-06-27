using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Sample.備忘録
{
	class _27_部分クラス
	{
		static void Main(string[] args)
		{
			var my = new MyClass();
			my.Test();
			my.Test2();
		}
	}

	//部分クラス(1つ目)
	public partial class MyClass
	{
		public void Test()
		{
			Console.WriteLine("Test");
		}
	}

	//部分クラス(2つ目)
	public partial class MyClass
	{
		public void Test2()
		{
			Console.WriteLine("Test2");
		}
	}
}
