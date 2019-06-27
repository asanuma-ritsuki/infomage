using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Sample.備忘録
{
	class _06_文字列リテラルと逐語的リテラル文字列
	{
		static void Main(string[] args)
		{
			var str01 = "Hello World";  //文字列リテラル
			var str02 = @"Hello World"; //逐語的リテラル文字

			var str03 = "Hello \t World";   //Hello	World
			var str04 = @"Hello \t World";	//Hello \t World

			var str05 = "\"Hello\" World";  //"Hello" World
			var str06 = @"""Hello"" World"; //"Hello" World

			var str07 = "C:\\tmp\\log.txt"; //C:\tmp\log.txt
			var str08 = @"C:\tmp\log.txt";  //C:\tmp\log.txt

			var str09 = "Hello\r\nWorld";	//改行
			var str10 = @"Hello
World";	//改行
		}
	}
}
