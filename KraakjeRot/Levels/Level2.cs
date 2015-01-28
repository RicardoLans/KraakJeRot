using System.Windows;
using GameFramework.Levels;
using Window = KraakjeRot.NPC.Window;

namespace KraakjeRot.Levels
{
	public class Level2 : Level
	{
		public Level2()
			: base(2, new ResourceFramework.UserControls.Levels.Level2())
		{
			this.PlayTime = 50;

			this.AddWindow(new Window(new Rect(0, 0, 100, 100)));

			this.Started += Level_Started;
		}

		void Level_Started(object sender)
		{
			Player.Position = new Point(0, 600);
		}
	}
}
