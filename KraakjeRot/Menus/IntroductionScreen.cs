using System;
using System.Windows.Controls;
using System.Windows.Media;
using GameFramework.Audio;
using GameFramework.Menus;

namespace KraakjeRot.Menus
{
	public class IntroductionScreen : Menu
	{
		private static ResourceFramework.UserControls.Menus.IntroScreen _menu = new ResourceFramework.UserControls.Menus.IntroScreen();

		private Image _imgHelpPressed;
		private Image _imgStartGamePressed;
		private Image _imgCreditsPressed;

		public IntroductionScreen()
			: base(_menu)
		{
			_imgStartGamePressed = _menu.FindName("imgStartGamePressed") as Image;

			if (_imgStartGamePressed == null) throw new NotImplementedException("imgStartGamePressed not implemented");
			_imgStartGamePressed.MouseLeftButtonUp += ImgStartGamePressedMouseLeftButtonUp;
			_imgStartGamePressed.MouseEnter += ImgMouseEnter;
			_imgStartGamePressed.MouseLeave += ImgMouseLeave;

			_imgHelpPressed = _menu.FindName("imgHelpPressed") as Image;
			if (_imgHelpPressed == null) throw new NotImplementedException("imgHelpPressed not implemented");
			_imgHelpPressed.MouseLeftButtonUp += ImgHelpPressedMouseLeftButtonUp;
			_imgHelpPressed.MouseEnter += ImgMouseEnter;
			_imgHelpPressed.MouseLeave += ImgMouseLeave;
			
			_imgCreditsPressed = _menu.FindName("imgCreditsPressed") as Image;
			if (_imgCreditsPressed == null) throw new NotImplementedException("imgCreditsPressed not implemented");
			_imgCreditsPressed.MouseLeftButtonUp += ImgCreditsPressedMouseLeftButtonUp;
			_imgCreditsPressed.MouseEnter += ImgMouseEnter;
			_imgCreditsPressed.MouseLeave += ImgMouseLeave;
		}

		private void ImgMouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
		{
			((Image)sender).Source = (ImageSource)new ImageSourceConverter().ConvertFromString("../../Images/Buttons/stoneNotSet.png");
		}

		private void ImgMouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
		{
			SoundPlayer.PlaySound("button3");
			((Image)sender).Source = (ImageSource)new ImageSourceConverter().ConvertFromString("../../Images/Buttons/stone.png");
		}

		private void ImgCreditsPressedMouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
		{
			GotoCreditsScreen();
		}
		public void GotoCreditsScreen()
		{
			SoundPlayer.PlaySound("button4");
			this.MenuEngineReference.Show<CreditsScreen>();
		}

		private void ImgHelpPressedMouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
		{
			GotoHelpScreen();
		}
		public void GotoHelpScreen()
		{
			SoundPlayer.PlaySound("button4");
			this.MenuEngineReference.Show<HelpScreen>();
		}

		private void ImgStartGamePressedMouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
		{
			GotoChooseSideScreen();
		}
		public void GotoChooseSideScreen()
		{
			SoundPlayer.PlaySound("button4");
			this.MenuEngineReference.Show<ChooseSideScreen>();
		}
	}
}
