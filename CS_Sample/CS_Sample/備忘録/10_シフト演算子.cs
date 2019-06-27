using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Sample.備忘録
{
	class _10_シフト演算子
	{
		static void Main(string[] args)
		{
			//0001 << 00001 (1bit左シフト) = 0010
			var x0 = 1 << 1;    //2
								//intまたはuintのときは下位5bitをシフトカウントとして使う(要するに32bitの数値なので
								//0～31bitのシフトが可能ということ)
								//33 = 0010 0001 だが、下位5bitの 0 0001 でシフトすることになる
								//0001 << 00001 (1bit左シフト) = 0010
			var x1 = 1 << 33;   //2
								//longまたはulongのときは下位6bitでシフトする(要するに64bitの数値なので
								//0～63bitのシフトが可能ということ)
								//0001 << 00001 (33bit左シフト) = 0010 0000 0000 0000 0000 0000 0000 0000 0000
			var x2 = 1L << 33;  //2
								//97 = 0110 0001の下位6bitの 10 0001 でシフトする
								// 0001 << 100001 (33bit左シフト) = 同上
			var x3 = 1L << 97;  //8589934592

			//0011 1110 1000 >> 3 (3bit右シフト) = 125 (0111 1101)
			var x4 = 1000 >> 3;	//125
		}
	}
}
