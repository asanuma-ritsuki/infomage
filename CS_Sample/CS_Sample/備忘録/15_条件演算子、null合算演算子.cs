using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Sample.備忘録
{
	class _15_条件演算子_null合算演算子
	{
		static void Main(string[] args)
		{
			var f1 = true;
			var t1 = f1 ? "true" : "false"; //"true"

			var f2 = false;
			var t2 = f2 ? "true" : "false"; //"false"

			string v1 = null;
			var t3 = v1 ?? "default";   //"default"

			string v2 = "text";
			var t4 = v2 ?? "default";	//"text"
		}
	}
}
