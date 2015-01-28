using System.Windows.Controls;
using System.Windows.Input;
using GameFramework.Menus;
using ResourceFramework.UserControls.Additional;

namespace KraakjeRot.Menus
{
	public class CreditsScreen : Menu
	{
		private static ResourceFramework.UserControls.Menus.CreditsScreen _menu = new ResourceFramework.UserControls.Menus.CreditsScreen();
		private SignPost _signPost;

		public CreditsScreen()
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