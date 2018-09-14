using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDF_Shiori
{
	public class CElement
	{
		private string m_ID;    //内部ID
		private string m_Name;  //表示用文字列

		/// <summary>
		/// 表示用文字列はToStringをオーバーライドして取得する
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			return NAME;
		}

		/// <summary>
		/// 実際の値
		/// (ValueMemberに設定する文字列と同名にする)
		/// </summary>
		public string ID
		{
			get
			{
				return m_ID;
			}
			set
			{
				m_ID = value;
			}
		}

		/// <summary>
		/// 表示名称
		/// (DisplayMemberに設定する文字列と同名にする
		/// </summary>
		public string NAME
		{
			get
			{
				return m_Name;
			}
			set
			{
				m_Name = value;
			}
		}
	}


}
