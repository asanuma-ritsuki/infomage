using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Sample.備忘録
{
	class _05_組み込み型とリテラル表記
	{
		static void Main(string[] args)
		{
			//bool型
			var flg1 = true;
			var flg2 = false;

			//int／uint／long／ulongのうち表現できる最初の型。この場合はint型
			var int1 = 1;
			//uまたはUサフィックスをつけた場合はuintもしくはulongのうち表現できる最初の型。
			//この場合はuint型
			var int2 = 1U;
			//lまたはLサフィックスをつけた場合はlongもしくはulongのうち表現できる最初の型。
			//この場合はlong型
			var int3 = 1L;
			//ulもしくはULサフィックスをつけた場合はulong型
			var int4 = 1UL;

			//単精度浮動小数点
			var number1 = 1f;
			//指数表記
			var number2 = 1.2e-3f;
			//倍精度浮動小数点
			var number3 = 1.2d;
			//指数表記
			var number4 = 1.2e-3d;
			//高精度少数
			var number5 = 0.1m;

			//char型
			var char1 = '1';
			var char2 = '\'';
			//\xでエスケープすることで、Unicodeのコード値でリテラル表記できる。
			var char3 = '\xFFFF';
		}
	}
}
