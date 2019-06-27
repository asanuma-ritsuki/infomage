using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Sample.備忘録
{
	class _28_ジェネリクスの型パラメーター
	{
		static void Main(string[] args)
		{
			var c1 = new MyClass<string>();
			c1.Value = "a";
			c1.DefaultValue();

			var c2 = new MyClass<DateTime>();
			c2.Value = DateTime.Now;
			c2.DefaultValue();

			var c3 = new MyClass2<object>();
			c3.DefaultValue();

			var c4 = new MyClass3<Printable>();
			c4.Execute();

			var c5 = new MyClass4<string, DateTime>();
		}
	}

	//ジェネリック(＝汎用的な)クラス。Tが型パラメータ
	public class MyClass<T>
	{
		public T Value { get; set; }
		public T DefaultValue()
		{
			return default(T);
		}
	}

	public class MyClass2<T> where T : new()
	{
		public T DefaultValue()
		{
			//new () 成約があるため、Tのデフォルトコンストラクタ呼び出しによるインスタンス化が可能
			return new T();
		}
	}

	public class MyClass3<T> where T : IPrintable, new()
	{
		public void Execute()
		{
			//TはIPrintableインターフェースを実装している
			new T().Print();
		}
	}

	public interface IPrintable
	{
		void Print();
	}

	public class Printable : IPrintable
	{
		public void Print()
		{
			Console.WriteLine("Printable Prints");
		}
	}

	public class MyClass4<K,V>
		where K : class
		where V : struct
	{ }
}
