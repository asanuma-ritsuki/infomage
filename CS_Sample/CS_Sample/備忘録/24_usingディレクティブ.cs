using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Sample.備忘録
{
	using MyDateTime = N2.DateTime;
	class _24_usingディレクティブ
	{
		static void Main(string[] args)
		{
			//usingによりSystem.Text.StringBuilderを参照
			var sb = new StringBuilder();
			//System.DateTimeを参照
			var now = DateTime.Now;
			//namespace aliasによりCSharpCheatSheet.N2.MyDateTimeを参照
			var dateTime = new MyDateTime();
			//namespace aliasがない場合はこのように全ての参照箇所で完全修飾子が必要になる
			var dateTime2 = new N2.DateTime();
		}
	}
}

namespace N2
{
	public class DateTime { }
}