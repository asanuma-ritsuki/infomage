using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Sample.備忘録
{
	class _13_is_as演算子とキャスト式
	{
		static void Main(string[] args)
		{
			var b = new B();
			var c = new C();

			var f0 = b is B;    //true
			var f1 = b is A;    //true
			var f2 = c is A;    //false

			//A型の変数として宣言
			A a = new B();

			//isで型チェック後、cast式でキャストする
			if (a is B)
			{
				((B)a).Test();	//I'm B
			}

			//上記のis＋キャストはas＋nullチェックで代用可能
			var b2 = a as B;
			if (b2 != null)
			{
				b2.Test();	//I'm B
			}

			//nullチェックはnull条件演算子で置き換えることも可能
			(a as B)?.Test();	//I'm B
		}
	}

	class A { }
	class B : A { public void Test() { Console.WriteLine("I'm B."); } }
	class C { }

	//is演算子を使うと、「オブジェクトの実行時の型」が「指定した型」と互換性があるかどうかを動的にチェックできる。
	//as演算子もしくはcast（キャスト）式を使うと、式を特定の型にキャストできる。cast式は、指定した型に式を明示的に変換し、
	//その変換が存在しない場合は例外をスローする。as演算子は、指定した参照型もしくはnull許容型に式を明示的に変換するが、
	//キャストできないときは例外をスローせずnullを返す。
	//as演算子は、is演算子とcast式の組み合わせることでほぼ同値なコードに置き換え可能だが
	//（式 as 型 ＝ 式 is 型? (型) 式 : (型)null）、as演算子を使えば、動的な型チェックが1回だけ実行されるように
	//コンパイラーによって最適化される。as演算子で書けるときはas演算子を優先的に使うのがよいだろう。
}
