using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using C1.WPF.Tile;

namespace Tile_WPF_CS
{
	/// <summary>
	/// MainWindow.xaml の相互作用ロジック
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
			C1TileService.UpdateInterval = TimeSpan.FromSeconds(1);
		}
		private void Image_MouseDown(object sender, MouseButtonEventArgs e)
		{
			var window = new Window();
			var image = new Image();
			image.Source = (sender as Image).Source;
			window.Content = image;
			window.Show();
		}
	}
}
