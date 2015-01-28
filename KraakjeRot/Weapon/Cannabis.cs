using System.Windows.Controls;
using GameFramework.Weapons;

namespace KraakjeRot.Weapons
{
	public class Cannabis : ThrowWeapon
	{
		private static ResourceFramework.UserControls.Weapon.Cannabis _weapon;

		public Cannabis()
			: base(_weapon = new ResourceFramework.UserControls.Weapon.Cannabis())
		{
			SecondsIntercept = 1000;
			ImpactDamage = 30;
			ttLive = 1500;
		}
		public override UserControl Bullet()
		{
			return new ResourceFramework.UserControls.Weapon.Cannabis();
		}
	}
}
