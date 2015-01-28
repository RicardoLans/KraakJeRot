using System.Linq;
using System.Windows.Controls;
using System.Windows.Input;
using GameFramework.Menus;
using ResourceFramework.UserControls.Additional;

namespace KraakjeRot.Menus
{
	public class HighScoresScreen : Menu
	{
		private static ResourceFramework.UserControls.Menus.HighScoresScreen _menu = new ResourceFramework.UserControls.Menus.HighScoresScreen();
		private SignPost _signPost;

		public HighScoresScreen()
			: base(_menu)
		{
			_signPost = _menu.FindName("SignPost") as SignPost;
			_signPost.SignText = "Naar Home";
			(_signPost.FindName("canvasSignpost") as Canvas).MouseLeftButtonDown += SignPost_MouseLeftButtonDown;
		}

		void SignPost_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			MenuEngineReference.Show<IntroductionScreen>();
		}
	}
}