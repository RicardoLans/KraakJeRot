using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using GameFramework.Additional;
using GameFramework.Audio;
using HelperFramework;
using ResourceFramework.UserControls.Menus;

namespace ResourceFramework.UserControls.Additional
{
	public partial class FishMenu
	{
		private static double margin = 30;
		private static double imgWidth = 80;
		private static double imgHeight = 80;
		private static double scale = 3;
		private static double multiplier = 60;

		public List<CreditsHolder> CreditsHolders = new List<CreditsHolder>();

		public FishMenu(List<CreditsHolder> holders)
		{
			InitializeComponent();
			CreditsHolders = holders;
			AddImages();
			MouseMove += FishEyeMenuMouseMove;
		}

		void btn_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			var creditsScreen = this.FindAncestor<CreditsScreen>();
			creditsScreen.SetCreditHolder((CreditsHolder)((Button)sender).Tag);
			SoundPlayer.PlaySound("button4");
		}

		void FishEyeMenuMouseMove(object sender, MouseEventArgs e)
		{
			int counter = 0;
			foreach (var creditsHolder in CreditsHolders)
			{
				Button btn = creditsHolder.CreditButton;
				btn.Cursor = Cursors.Hand;
				// compute the scale of each image according to the mouse position
				double imageScale = scale - Math.Min(scale - 1, Math.Abs(e.GetPosition(this).Y - ((double)btn.GetValue(Canvas.TopProperty) + btn.Height / 2)) / multiplier);
				// resize the image
				ResizeImage(btn, imgWidth * imageScale, imgHeight * imageScale, counter, CreditsHolders.Count);
				counter++;
				// sort the children according to the scale
				btn.SetValue(Canvas.ZIndexProperty, (int)Math.Round(imgWidth * imageScale));
			}
		}

		private void AddImages()
		{
			int counter = 0;
			foreach (var creditsHolder in CreditsHolders)
			{
				var btn = new Button {Tag = creditsHolder, Style = (Style) Resources.MergedDictionaries[0]["btn"]};
				var source = new ImageSourceConverter().ConvertFromString(creditsHolder.ImgSmallString) as ImageSource;
				var sourceBig = new ImageSourceConverter().ConvertFromString(creditsHolder.ImgBigString) as ImageSource;
				creditsHolder.ImgBrush = new ImageBrush { ImageSource = source };
				creditsHolder.ImgBrushBig = new ImageBrush { ImageSource = sourceBig };
				btn.Background = creditsHolder.ImgBrush;
				btn.Click += (btn_Click);

				// resize the image
				ResizeImage(btn, imgWidth, imgHeight, counter, CreditsHolders.Count);
				counter++;

				LayoutRoot.Children.Add(btn);
				creditsHolder.CreditButton = btn;
			}
		}

		private void ResizeImage(Button btn, double imageWidth, double imageHeight, int index, int total)
		{
			btn.Width = imageWidth;
			btn.Height = imageHeight;
			btn.SetValue(Canvas.LeftProperty, Width / 2 - btn.Width / 2);
			btn.SetValue(Canvas.TopProperty, Height / 2 + (index - (total - 1) / 2) * (margin + imgHeight) - btn.Height / 2);
		}
	}
}