using System.Windows.Controls;
using GameFramework.Weapons;

namespace KraakjeRot.Weapons
{
	public class WaterBalloon : ThrowWeapon
	{
		private static ResourceFramework.UserControls.Weapon.WaterBalloon _weapon;

		public WaterBalloon()
			: base(_weapon = new ResourceFramework.UserControls.Weapon.WaterBalloon())
		{
			SecondsIntercept = 300;
			ImpactDamage = 15;
			ttLive = 1400;

			RandomItems = new[] { "WaterBalloon1", "WaterBalloon2", "WaterBalloon3", 
								  "WaterBalloon4", "WaterBalloon5", "WaterBalloon6", 
								  "WaterBalloon7", "WaterBalloon8", "WaterBalloon9" };
			RandomNr = Randomize(RandomItems);
		}

		public override UserControl Bullet()
		{
			ResourceFramework.UserControls.Weapon.WaterBalloon bullet = new ResourceFramework.UserControls.Weapon.WaterBalloon();
			Weapon.Randomize(bullet, RandomItems, RandomNr);
			return bullet;
		}
	}
}
