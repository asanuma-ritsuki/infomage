using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Sample.備忘録
{
	class _38_イベントの定義と呼び出し
	{
		static void Main(string[] args)
		{

		}

		void Execute()
		{
			//EventHandlerのインスタンスを追加する、もしくは直接追加可能。
			//意味合いとしては同じだが、別のインスタンスとして追加される
			Changed += new EventHandler(OnChanged);
			Changed += OnChanged;
			//EventHandlerに1つも購読のハンドラーが登録されていないとnullであるため、
			//null条件演算子経由でイベントを発火させている
			Changed?.Invoke(this, new EventArgs());
			//イベントの購読を解除できる
			Changed -= OnChanged;
			Changed?.Invoke(this, new EventArgs());

			ValueChanged += OnValueChanged;
			ValueChanged.Invoke(this, new MyEventArgs(3));
		}
		void OnChanged(object sender, EventArgs ea)
		{
			Console.WriteLine("OnChanged");
		}

		void OnValueChanged(object sender, MyEventArgs ea)
		{
			Console.WriteLine($"OnValueChanged {ea.Value}");
		}

		event EventHandler Changed;
		event EventHandler<MyEventArgs> ValueChanged;

		class MyEventArgs : EventArgs
		{
			public int Value { get; }
			public MyEventArgs(int value)
			{
				Value = value;
			}
		}

		//event構文はaddとremove処理を明示的に記述できる。
		//省略した場合のコードは意味合い的には下記のコードと同様だが、
		//実際にはスレッドセーフなコードが生成されている
		private EventHandler customHandler;
		event EventHandler CustomHandler
		{
			add
			{
				customHandler += value;
			}
			remove
			{
				customHandler -= value;
			}
		}

		//自前で定義したdelegateをイベントの型として利用することもできる
		public delegate void MyEventHandler();
		public event MyEventHandler MyChanged;
	}
}
