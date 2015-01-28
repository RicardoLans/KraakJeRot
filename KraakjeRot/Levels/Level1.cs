using System.Windows;
using GameFramework.Levels;
using Window = KraakjeRot.NPC.Window;

namespace KraakjeRot.Levels
{
	public class Level1 : Level
	{
		public Level1()
			: base(1, new ResourceFramework.UserControls.Levels.Level1())
		{
			this.PlayTime = 120;

			this.AddWindow(new Window(new Rect(94, 265, 175, 231)),
						   new Window(new Rect(520, 265, 171, 231)),
						   new Window(new Rect(908, 266, 194, 236)),
						   new Window(new Rect(1298, 266, 234, 237)),
						   new Window(new Rect(1220, 635, 210, 208)),
						   new Window(new Rect(1005, 634, 209, 208)),
						   new Window(new Rect(186, 627, 206, 175)));

			this.Started += LevelStarted;
		}

		void LevelStarted(object sender)
		{
			Player.Position = new Point(0, 800);
			Player.ShuffleWeaponUp();
			Krakers.ForEach(kraker => kraker.ShuffleWeaponUp());
		}
	}
}