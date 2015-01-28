using System.Windows.Controls;
using HelperFramework;

namespace KraakjeRot.HUD
{
	public class LifeGauge : GameFramework.HUD.LifeGauge
	{
		private static ResourceFramework.UserControls.HUD.LifeGauge menu = new ResourceFramework.UserControls.HUD.LifeGauge();

		public LifeGauge(int maxLife)
			: base(menu)
		{
			LifeIndicator = menu.FindChild<Border>("LifeIndicator");
			Maxwidth = LifeIndicator.Width;
			MaxLife = CurrentLife = maxLife;
		}
	}
}