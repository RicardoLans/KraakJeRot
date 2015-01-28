using System.Windows.Controls;
using GameFramework.Weapons;

namespace KraakjeRot.Weapons
{
	public class Table : ThrowWeapon
	{
		private static ResourceFramework.UserControls.Weapon.Table _weapon;

		public Table()
			: base(_weapon = new ResourceFramework.UserControls.Weapon.Table())
		{
			SecondsIntercept = 3000;
			ttLive = 2000;
			ImpactDamage = 80;
		}
		public override UserControl Bullet()
		{
			return new ResourceFramework.UserControls.Weapon.Table();
		}
	}
}
