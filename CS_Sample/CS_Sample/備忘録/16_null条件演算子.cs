using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Sample.備忘録
{
	class _16_null条件演算子
	{
		static void Main(string[] args)
		{
			int[] array = null;
			var length = array?.Length; //null
			var i1 = array?[1]; //null。i1はint?型

			Func<int> func = null;
			var i2 = func?.Invoke();	//null。i2はint?型
		}
	}
}
