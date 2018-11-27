using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace WPFStart02
{
	/// <summary>
	/// MainWindow.xaml の相互作用ロジック
	/// </summary>
	public partial class MainWindow : Window
	{
		/// <summary>
		/// 時刻表示用タイマー
		/// </summary>
		private DispatcherTimer timer;

		public MainWindow()
		{
			InitializeComponent();

			timer = CreateTimer();
		}

		/// <summary>
		/// タイマー生成処理
		/// </summary>
		/// <returns>生成したタイマー</returns>
		private DispatcherTimer CreateTimer()
		{
			//タイマー生成（有制度はアイドル時に設定
			var t = new DispatcherTimer(DispatcherPriority.SystemIdle);

			//タイマーイベントの発生感覚を300ミリ秒に設定
			t.Interval = TimeSpan.FromMilliseconds(300);

			//タイマーイベントの定義
			t.Tick += (sender, e) =>
			{
				//タイマーイベント発生時の処理をここに書く

				//現在の時分秒をテキストに設定
				textBlock.Text = DateTime.Now.ToString("HH:mm:ss");
			};

			//生成したタイマーを返す
			return t;
		}

		private void textBlock_MouseDown(object sender, MouseButtonEventArgs e)
		{
			timer.Start();
		}
	}
}
