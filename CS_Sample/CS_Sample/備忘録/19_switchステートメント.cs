using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Sample.備忘録
{
	class _19_switchステートメント
	{
		static void Main(string[] args)
		{
			var dayOfWeek = DayOfWeek.Thursday;
			string text;
			switch (dayOfWeek)
			{
				case DayOfWeek.Monday:
					text = "月";
					break;
				case DayOfWeek.Tuesday:
					text = "火";
					break;
				case DayOfWeek.Wednesday:
					text = "水";
					break;
				case DayOfWeek.Thursday:
					text = "木";
					break;
				case DayOfWeek.Friday:
					text = "金";
					break;
				case DayOfWeek.Saturday:
					text = "土";
					break;
				case DayOfWeek.Sunday:
					text = "日";
					break;
				default:
					throw new ArgumentOutOfRangeException();
			}
			//なお、日付を表すDateTime型のインスタンスからカレントカルチャの曜日の
			//省略名を得る場合はこのように書ける
			var s1 = $"{DateTime.Now:ddd}";
		}
	}
}
