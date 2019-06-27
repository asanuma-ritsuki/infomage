using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Sample.備忘録
{
	class _26_静的クラス
	{
		static void Main(string[] args)
		{
			var mile = MileConverter.MileToKm(1);
		}
	}

	//静的クラス
	public static class MileConverter
	{
		//静的メンバ(フィールド)
		public static readonly double MilePerKm = 0.62137;
		//静的メンバ(メソッド)
		public static double KmToMile(double km)
		{
			return km * MilePerKm;
		}

		public static double MileToKm(double mile)
		{
			return mile / MilePerKm;
		}
	}
}
