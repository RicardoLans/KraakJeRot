using System.Windows.Controls;
using GameFramework.Weapons;

namespace KraakjeRot.Weapons
{
	public class Bin : ThrowWeapon
	{
		private static ResourceFramework.UserControls.Weapon.Bin _weapon;

		public Bin()
			: base(_weapon = new ResourceFramework.UserControls.Weapon.Bin())
		{
			SecondsIntercept = 3000;
			ImpactDamage = 65;
			ttLive = 1200;

			RandomItems = new[] { "TrashCan1", "TrashCan2" };
			RandomNr = Randomize(RandomItems);
		}

		public override UserControl Bullet()
		{
			ResourceFramework.UserControls.Weapon.Bin bullet = new ResourceFramework.UserControls.Weapon.Bin();
			Weapon.Randomize(bullet, RandomItems, RandomNr);
			return bullet;
		}
	}
}