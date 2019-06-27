using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Sample.備忘録
{
	class _23_名前空間宣言と完全修飾子
	{
		static void Main(string[] args)
		{
			var a = new N1.A();
			var b = new N1.N2.B();
			var c = new N1.N2.C();
		}
	}
}

namespace N1
{
	class A { }

	namespace N2
	{
		class C { }
	}
}

namespace N1.N2
{
	class B { }
}
