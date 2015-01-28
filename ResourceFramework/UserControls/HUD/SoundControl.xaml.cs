using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using GameFramework.Audio;

namespace ResourceFramework.UserControls.HUD
{
	public partial class SoundControl : UserControl
	{
		public SoundControl()
		{
			InitializeComponent();
			Application.Current.Host.Content.Resized += Content_Resized;
		}

		void Content_Resized(object sender, EventArgs e)
		{
			//TODO: Fix this soundcontroller
			// scaleTransform.ScaleX = Screen.ScreenWidth / Screen.ScreenResolutionWidth;
			// scaleTransform.ScaleY = Screen.ScreenHeight / Screen.ScreenResolutionHeight;
		}

		private void btnSoundStop_Click(object sender, RoutedEventArgs e)
		{
			SoundPlayer.BackgroundMusic.Stop();
		}

		private void btnSoundPauze_Click(object sender, RoutedEventArgs e)
		{
			SoundPlayer.BackgroundMusic.Pauze();
		}

		private void btnSoundPrevious_Click(object sender, RoutedEventArgs e)
		{
			SoundPlayer.BackgroundMusic.Previous();
		}

		private void btnSoundNext_Click(object sender, RoutedEventArgs e)
		{
			SoundPlayer.BackgroundMusic.Next();
		}

		private void btnSoundPlay_Click(object sender, RoutedEventArgs e)
		{
			SoundPlayer.BackgroundMusic.Start();
		}

		private void btnMute_Click(object sender, RoutedEventArgs e)
		{
			string path = SoundPlayer.IsMuted ? "../../Images/Buttons/Mute.png" : "../../Images/Buttons/UnMute.png";
			((Button)sender).Content = new Image { Source = (ImageSource)new ImageSourceConverter().ConvertFromString(path) };
			SoundPlayer.ShuffleMute();
		}
	}
}
