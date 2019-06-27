using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Sample.備忘録
{
	class _31_メソッドの宣言とアクセス修飾子
	{
		static void Main(string[] args)
		{
			var my = new MyClass();
			my.Run("text");
			MyClass.InternalRun();
		}
	}

	public partial class MyClass
	{
		static internal void InternalRun()
		{
			Console.WriteLine("static internal Run");
		}

		public void Run(string text)
		{
			Console.WriteLine(text);
		}

		protected void ProtectedRun()
		{
			Console.WriteLine("ProtectedRun");
		}

		private void PrivateRun()
		{
			Console.WriteLine("Internal Run");
		}
	}
}
