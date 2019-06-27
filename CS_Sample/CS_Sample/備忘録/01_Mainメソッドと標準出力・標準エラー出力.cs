using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Sample.備忘録
{
	class _01_Mainメソッドと標準出力_標準エラー出力
	{
		static void Main(string[] args)
		{
			//標準出力。Console.Out.WriteLineも同じ
			Console.WriteLine("こんにちは、C#!");
			//標準エラー出力
			Console.Error.WriteLine("こんにちは、C#!");
			//Visual Studioからデバッグ実行するときなどは、コンソールウィンドウがすぐ閉じるのを
			//防ぐために入力を待つと良い
			Console.ReadLine();
		}
	}
}
