using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Sample.備忘録
{
	class _14_論理演算子
	{
		static void Main(string[] args)
		{
			var f1 = True() || False(); //True is called:True
			var f2 = True() | False();  //True is called: False is called: True

			var f3 = False() && True(); //False is called: False
			var f4 = False() & True();	//False is called: True is called: False
		}

		static bool True()
		{
			Console.WriteLine("True is called:");
			return true;
		}

		static bool False()
		{
			Console.WriteLine("False is called:");
			return false;
		}

	}
}
