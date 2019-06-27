using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Sample.備忘録
{
	class _09_算術演算子
	{
		static void Main(string[] args)
		{
			//加算
			var x0 = 1 + 4; //5
			//int + doubleはdouble + doubleとして加算。結果もdouble
			var x1 = 1 + 2.5d;  //3.5
			//int - longはlong - long
			var x2 = int.MinValue - 1L; //-2147483649
			//乗算
			var x3 = 2 * 4;	//= 8
			//uncheckedコンテキストではオーバーフローしても処理が続行される
			//int.MaxValue * 2Lだと4294967294L
			unchecked
			{
				var x4 = int.MaxValue * 2;	// = -2
			}
			//整数の除算は演算結果も整数
			var x5 = 7 / 2; // = 3
			//割られる数がdoubleであれば演算結果もdoubleになる
			var x6 = 7f / 2;    // = 3.5
			//割る数がdoubleの場合もdouble型の除算が行われる
			var x7 = 7 / 2.0;   // = 3.5
			//剰余
			var x8 = 7 % 2; // = 1
			//浮動小数点
			var x9 = 7f % 2.1;	// = 0.7
		}
	}
}
