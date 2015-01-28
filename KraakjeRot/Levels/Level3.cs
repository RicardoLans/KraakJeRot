using System.Windows;
using GameFramework.Levels;
using Window = KraakjeRot.NPC.Window;

namespace KraakjeRot.Levels
{
	public class Level3 : Level
	{
		public Level3()
			: base(3, new ResourceFramework.UserControls.Levels.Level3())
		{
			this.PlayTime = 150;

			base.AddWindow(new Window(new Rect(0, 0, 100, 100)));
		}
	}
}
