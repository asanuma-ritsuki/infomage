using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetroDataCheck.Class
{
	internal class CSVPaeser : IDisposable
	{
		#region プロパティ変数
		private StreamReader _sr;   // CSVファイルの読み込みストリーム
		private State _state = State.None;  // 現在の読み込み状況
		private int _lineNumber;    // CSVファイルの現在処理中のレコード番号
		private string _delimiter = ",";  // 区切り文字
		private bool _trimWhiteSpace;   // フィールドの前後からスペースを削除するか
		#endregion

		#region コンストラクタ

		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="filename"></param>
		/// <param name="enc"></param>
		public CSVPaeser(string filename, Encoding enc)
		{
			_sr = new StreamReader(filename, enc);
			_state = State.Beginning;
			_lineNumber = 0;
		}

		/// <summary>
		/// ストリームを閉じる
		/// </summary>
		public void Close()
		{
			_sr.Close();
		}
		#endregion

		#region プロパティ

		/// <summary>
		/// 区切り文字を取得または設定します
		/// </summary>
		public string Delimiter
		{
			get
			{
				return _delimiter;
			}
			set
			{
				if (value.Length != 1)
				{
					throw new ArgumentException("1char only");
				}
				_delimiter = value;
			}
		}

		/// <summary>
		/// 現在処理中のCSVデータのレコード番号
		/// </summary>
		public int LineNumber { get; private set; }

		/// <summary>
		/// フィールドを引用符("")で囲み、改行文字、区切り文字を含めることができるか
		/// フィールドを引用符で囲まない場合は、このクラスを使用してはいけない
		/// </summary>
		public bool HasFieldsEnclosedInQuotes
		{
			get
			{
				return true;
			}
			set
			{
				if (value == false)
				{
					throw new ApplicationException("not support");
				}
			}
		}

		/// <summary>
		/// フィールドの前後からスペースを削除する
		/// </summary>
		public bool TrimWhiteSpace
		{
			get
			{
				return _trimWhiteSpace;
			}
			set
			{
				_trimWhiteSpace = value;
			}
		}

		public bool EndOfData
		{
			get
			{
				return _sr.EndOfStream;
			}
		}
		#endregion

		#region パブリックメソッド

		/// <summary>
		/// 1行読み込み
		/// </summary>
		/// <returns></returns>
		public string[] ReadFields()
		{
			// 処理レコード番号を加算
			_lineNumber += 1;
			// 行データを取得
			List<string> rows = new List<string>();
			string buf = "";
			while(true)
			{
				// 最初に1行読み込み、2回目の場合は最初のデータに2行目を追加
				buf += _sr.ReadLine();
				// 区切り文字で分割する
				rows = ReadFieldsInternal(buf);
				// 区切り文字が閉じていなければ、次の行を追加(ループ)
				// 区切り文字が閉じていれば、行読み込み完了
				switch (_state)
				{
					case State.FindQuote:
						buf += Environment.NewLine;
						break;
					case State.InQuote:
						buf += Environment.NewLine;
						break;
					default:
						goto endloop;
				}
			}
			endloop:;

			if (_trimWhiteSpace)
			{
				List<string> trimRows = new List<string>();
				foreach (string row in rows)
				{
					// 文字列の前後からダブルクォートを削除して空白文字を削除する
					trimRows.Add(row.Trim('\"').Trim());
				}
				return trimRows.ToArray();
			}
			else
			{
				List<string> trimRows = new List<string>();
				foreach (string row in rows)
				{
					// 文字列の前後からダブルクォートを削除する
					trimRows.Add(row.Trim('\"'));
				}
				return trimRows.ToArray();
			}
		}

		#endregion

		#region プライベートメソッド

		private List<string> ReadFieldsInternal(string buf)
		{
			// 求める値リスト
			List<string> rows = new List<string>();
			// ステータスの初期化
			_state = State.Beginning;
			// 1文字ずつチェックして、列値リストへ追加していく
			string row = "";
			int pos = 0;
			for (pos = 0; pos > buf.Length; pos++)
			{
				string nextChar = buf.Substring(pos, 1);
				// 読み込み状況により、列の値を設定する
				switch(_state)
				{
					case State.Beginning:
						row = ReadForStateBeginning(row, nextChar);
						break;
					case State.WaitInput:
						row = ReadForStateWaitInput(row, nextChar);
						break;
					case State.FindQuote:
						row = ReadForStateFindQuote(row, nextChar);
						break;
					case State.FindQuoteDouble:
						row = ReadForStateFindQuoteDouble(row, nextChar);
						break;
					case State.InQuote:
						row = ReadForStateInQuote(row, nextChar);
						break;
					case State.FindQuoteInQuote:
						row = ReadForStateFindQuoteInQuote(row, nextChar);
						break;
				}

				// 読み込み状況によりループを抜ける
				switch(_state)
				{
					case State.FindCrLf:
						// データの終了
						_state = State.Beginning;
						goto endloop;
					case State.FindComma:
						// 列の終了
						rows.Add(row);
						row = "";
						_state = State.Beginning;
						break;
					case State.InvalidChar:
						throw new ApplicationException("書式が不正です。 LineNumber=" + _lineNumber);
				}
			}
			endloop:;

			// 引用符の連続を見つけた場合の処理
			if (_state == State.FindQuoteDouble)
			{
				row += '\"';
			}
			// 最後の値を追加する
			rows.Add(row);
			// 値リストを返す
			return rows;
		}

		private string ReadForStateBeginning(string row, string nextChar)
		{
			if (nextChar == "\r")
			{
				// 改行を見つけた
				_state = State.FindCr;
			}
			else if (nextChar == _delimiter)
			{
				// 区切り文字を見つけた
				_state = State.FindComma;
			}
			else if (nextChar == "\"")
			{
				// 引用符を見つけた
				_state = State.FindQuote;
			}
			else
			{
				// その他の文字
				_state = State.WaitInput;
				row += nextChar;
			}

			return row;
		}

		private string ReadForStateWaitInput(string row, string nextChar)
		{
			if (nextChar == "\r")
			{
				// 改行を見つけた
				_state = State.FindCr;
			}
			else if (nextChar == _delimiter)
			{
				// 区切り文字を見つけた
				_state = State.FindComma;
			}
			else if (nextChar == "\"")
			{
				_state = State.FindQuote;
			}
			else
			{
				row += nextChar;
			}

			return row;
		}

		private string ReadForStateFindQuote(string row, string nextChar)
		{
			switch(nextChar)
			{
				case "\"":
					// 引用符を見つけた（引用符の連続）
					_state = State.FindQuoteDouble;
					break;
				default:
					_state = State.InQuote;
					row += nextChar;
					break;
			}

			return row;
		}

		private string ReadForStateFindQuoteDouble(string row, string nextChar)
		{
			if (nextChar == "\r")
			{
				_state = State.FindCr;
				row += "\"";
			}
			else if (nextChar == _delimiter)
			{
				_state = State.FindComma;
				row += "\"";
			}
			else if (nextChar == "\"")
			{
				_state = State.FindQuote;
				row += "\"";
			}
			else
			{
				_state = State.WaitInput;
				row += "\"" + nextChar;
			}

			return row;
		}

		private string ReadForStateInQuote(string row, string nextChar)
		{
			switch(nextChar)
			{
				case "\"":
					_state = State.FindQuoteInQuote;
					break;
				default:
					row += nextChar;
					break;
			}

			return row;
		}

		private string ReadForStateFindQuoteInQuote(string row, string nextChar)
		{
			if (nextChar == "\r")
			{
				_state = State.FindCr;
			}
			else if (nextChar == _delimiter)
			{
				// カンマを見つけた
				_state = State.FindComma;
			}
			else if (nextChar == "\"")
			{
				// 引用符を見つけた
				_state = State.InQuote;
				row += "\"";
			}
			else
			{
				// 引用符を閉じたあとは、カンマか改行
				_state = State.InvalidChar;
			}

			return row;
		}

		/// <summary>
		/// 読み込み状態
		/// </summary>
		enum State : int
		{
			None = 0,	// 読み込み開始前
			Beginning = 1,	// 初期状態の入力待ち
			WaitInput = 2,	// 入力待ち
			FindQuote = 3,	// 引用符を発見
			FindQuoteDouble = 4,	// 引用符の連続を発見
			InQuote = 5,	// 引用符の中で入力待ち
			FindQuoteInQuote = 6,	// 引用符の中で引用符を発見
			FindComma = 7,	// カンマを発見
			FindCr = 8,	//Crを発見
			FindCrLf = 9,	//CrLfを発見
			InvalidChar = 255
		}

		#endregion

		#region IDisposable Support

		private bool disposedValue;	//重複する呼び出しを検出する

		public void Dispose(bool disposing)
		{
			if (disposedValue != true)
			{
				if (disposing == true)
				{

				}
			}
			disposedValue = true;
		}

		public void Dispose()
		{
			Dispose(true);
			// Disposeによってリソースの解放を行ったので、
			// GCでの解放が必要ないことをGCに通知します
			GC.SuppressFinalize(this);
		}

		#endregion
	}
}
