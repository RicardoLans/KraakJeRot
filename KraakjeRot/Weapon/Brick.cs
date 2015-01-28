using System.Windows.Controls;
using GameFramework.Weapons;

namespace KraakjeRot.Weapons
{
	public class Brick : ThrowWeapon
	{
		private static ResourceFramework.UserControls.Weapon.Brick _weapon;

		public Brick() : base(_weapon = new ResourceFramework.UserControls.Weapon.Brick())
		{
			ImpactDamage = 40;
			ttLive = 1200;

		}

		public override UserControl Bullet()
		{
			return new ResourceFramework.UserControls.Weapon.Brick();
		}
	}
}
