using System;
using System.Windows;
using System.Windows.Controls;

namespace ResourceFramework.UserControls.Weapon
{
	public partial class WaterCanon : UserControl
	{
		public WaterCanon()
		{
			InitializeComponent();
			Application.Current.Host.Content.Resized += Content_Resized;
		}

		void Content_Resized(object sender, EventArgs e)
		{
			double height = Application.Current.Host.Content.ActualHeight;
			double width = Application.Current.Host.Content.ActualWidth;
			//CanvasScale.ScaleX = 250 / 1600;
			//CanvasScale.ScaleY = 160 / 1200;
		}
	}
}
