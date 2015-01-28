using System;
using System.Windows.Controls;
using System.Windows.Input;
using GameFramework.Audio;
using GameFramework.Menus;
using ResourceFramework.UserControls.Additional;

namespace KraakjeRot.Menus
{
	public class ChooseSideScreen : Menu
	{
		private static ResourceFramework.UserControls.Menus.ChooseSideScreen _menu = new ResourceFramework.UserControls.Menus.ChooseSideScreen();

		private SignPost _signPost;

		public ChooseSideScreen()
			: base(_menu)
		{
			Canvas npcMe = _menu.FindName("npcME") as Canvas;
			if (npcMe == null) throw new NotImplementedException("MEer not implemented");
			ME me = new ME();
			me.SetValue(Canvas.TopProperty, 140.0);
			me.SetValue(Canvas.LeftProperty, 60.0);
			npcMe.Children.Add(me);
			npcMe.MouseLeftButtonUp += ButtonMeMouseLeftButtonUp;
			npcMe.MouseEnter += ButtonMouseEnter;
			
			Canvas npcKraker = _menu.FindName("npcKraker") as Canvas;
			if (npcKraker == null) throw new NotImplementedException("Kraker not implemented");
			Kraker kraker = new Kraker();
			kraker.SetValue(Canvas.TopProperty, 200.0);
			kraker.SetValue(Canvas.LeftProperty, 100.0);
			npcKraker.Children.Add(kraker);
			npcKraker.MouseLeftButtonUp += ButtonKrakerMouseLeftButtonUp;
			npcKraker.MouseEnter += ButtonMouseEnter;

			// todo: implement kraker and remove the 3 lines below;
			kraker.Opacity = 0.5;
			npcKraker.Cursor = Cursors.Wait;
			ToolTipService.SetToolTip(npcKraker, "Kraker is momenteel in de huidige versie niet beschikbaar.");

			_signPost = _menu.FindName("SignPost") as SignPost;
			_signPost.SignText = "Naar Home";
			(_signPost.FindName("canvasSignpost") as Canvas).MouseLeftButtonDown += SignPost_MouseLeftButtonDown;
		}

		void SignPost_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			MenuEngineReference.Show<IntroductionScreen>();
		}

		void ButtonMouseEnter(object sender, MouseEventArgs e)
		{
			SoundPlayer.PlaySound("button3");
		}
		void ButtonMeMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
		{
			GotoMe();
		}
		public void GotoMe()
		{
			MenuEngineReference.Show<LevelHolder>();
		}
	
		void ButtonKrakerMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
		{
			GotoKraker();
		}
		public void GotoKraker()
		{
		}
	}
}