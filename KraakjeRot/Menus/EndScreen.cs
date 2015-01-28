using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using GameFramework.Audio;
using GameFramework.Menus;
using GameFramework.Text;
using ResourceFramework.UserControls.Additional;

namespace KraakjeRot.Menus
{
	public class EndScreen : Menu
	{
		private static ResourceFramework.UserControls.Menus.EndScreen _menu = new ResourceFramework.UserControls.Menus.EndScreen();
		private SignPost _signPost;
		private TextBlock txtScore;
		private Image _highscores;

		public EndScreen()
			: base(_menu)
		{
			txtScore = _menu.FindName("txtTotalPoints") as TextBlock;
			_highscores = _menu.FindName("imgHighscoresPressed") as Image;
			_highscores.MouseEnter += ImgMouseEnter;
			_highscores.MouseLeave += ImgMouseLeave;
			_highscores.MouseLeftButtonDown += ImgHighscoresClick;

			_signPost = _menu.FindName("SignPost") as SignPost;
			_signPost.SignText = "Naar Home";
			(_signPost.FindName("canvasSignpost") as Canvas).MouseLeftButtonDown += SignPost_MouseLeftButtonDown;
			SetLoseScore(500);
		}

		public void SetWinScore(int score)
		{
			txtScore.Text = string.Format(TextHandler.GetText("WinText"), score);
		}

		public void SetLoseScore(int score)
		{
			txtScore.Text = string.Format(TextHandler.GetText("LoseText"), score);
		}

		void SignPost_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			MenuEngineReference.Show<IntroductionScreen>();
		}

		private void ImgHighscoresClick(object sender, MouseButtonEventArgs e)
		{
			SoundPlayer.PlaySound("button4");
			this.MenuEngineReference.Show<HighScoresScreen>();
		}

		private void ImgMouseLeave(object sender, MouseEventArgs e)
		{
			((Image)sender).Source = (ImageSource)new ImageSourceConverter().ConvertFromString("../../Images/Buttons/stoneNotSet.png");
		}

		private void ImgMouseEnter(object sender, MouseEventArgs e)
		{
			SoundPlayer.PlaySound("button3");
			((Image)sender).Source = (ImageSource)new ImageSourceConverter().ConvertFromString("../../Images/Buttons/stone.png");
		}


	}
}
