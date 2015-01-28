using System.Windows.Controls;
using GameFramework.Weapons;

namespace KraakjeRot.Weapons
{
	public class Eggs : ThrowWeapon
	{
		private static ResourceFramework.UserControls.Weapon.Eggs _weapon;

		public Eggs()
			: base(_weapon = new ResourceFramework.UserControls.Weapon.Eggs())
		{
			SecondsIntercept = 300;
			ImpactDamage = 20;
			ttLive = 1500;

			RandomItems = new[] { "Egg1", "Egg2", "Egg3" };
			RandomNr = Randomize(RandomItems);
		}

		public override UserControl Bullet()
		{
			ResourceFramework.UserControls.Weapon.Eggs bullet = new ResourceFramework.UserControls.Weapon.Eggs();
			Weapon.Randomize(bullet, RandomItems, RandomNr);
			return bullet;
		}

	}
}