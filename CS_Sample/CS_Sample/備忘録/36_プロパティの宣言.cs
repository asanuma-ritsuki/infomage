using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Sample.備忘録
{
	class _36_プロパティの宣言
	{
		static void Main(string[] args)
		{
			var my = new MyClass();
			my.Value1 = 3;
		}
	}

	public partial class MyClass
	{
		private int value1;
		public int Value1
		{
			get
			{
				return value1;
			}
			set
			{
				if (value != value1)
				{
					value1 = value;
					ValueChanged();
				}
			}
		}

		private void ValueChanged()
		{
			Console.WriteLine("ValueChanged");
		}
	}
}
