using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Sample.備忘録
{
	class _29_アクセス修飾子と入れ子クラス
	{
		static void Main(string[] args)
		{
			//protected internalなOuter1.Inner3クラスにはアクセスできるが、
			//privateなOuter1.Inner2クラスにはアクセスできない
			var inner = new Outer1.Inner3();
			inner.Execute();
		}
	}

	public class Outer1
	{
		private static void Run()
		{
			Console.WriteLine("Run");
		}

		public void Execute()
		{
			//包含する型からなのでprivateなInner2にアクセスできる
			var inner = new Inner2();
			inner.Execute();
		}

		public class Inner1
		{
			public void Execute()
			{
				//入れ子になったクラスから包含する型のprivateメソッドにアクセスできる
				Run();
			}
		}
		private class Inner2 : Inner1
		{ }

		protected internal class Inner3 : Inner1
		{ }
	}
}
