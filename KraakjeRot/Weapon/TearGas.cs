using System.Windows.Controls;
using GameFramework.Weapons;

namespace KraakjeRot.Weapons
{
	public class TearGas : ThrowWeapon
	{
		private static ResourceFramework.UserControls.Weapon.TearGas _weapon;

		public TearGas()
			: base(_weapon = new ResourceFramework.UserControls.Weapon.TearGas())
		{
			SecondsIntercept = 1000;
			ImpactDamage = 40;
			ttLive = 3000;
		}

		public override UserControl Bullet()
		{
			return new ResourceFramework.UserControls.Weapon.TearGas();
		}
	}
}
