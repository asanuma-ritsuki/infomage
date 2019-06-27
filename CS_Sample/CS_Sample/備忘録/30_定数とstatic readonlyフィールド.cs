using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
	public class Utility
	{
		public const int X = 1; //定数
		public static readonly int Y = 1;   //静的な読み取り専用
											//コンパイル時に値が決まらない場合はstatic readonlyフィールドが利用できる
		public static readonly DateTime DefaultDate = new DateTime(2016, 4, 1);
	}
}

//ConsoleApp.exe
using Library;

namespace CSharpCheatSheet
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine(Utility.X);
			Console.WriteLine(Utility.Y);
		}
	}
}