using System.Windows.Controls;
using GameFramework.Weapons;

namespace KraakjeRot.Weapons
{
	public class Flowers : ThrowWeapon
	{
		private static ResourceFramework.UserControls.Weapon.Flowers2 _weapon;

		public Flowers() : base(_weapon = new ResourceFramework.UserControls.Weapon.Flowers2())
		{
			ImpactDamage = 10;
			ttLive = 3000;

			SoundOnFire = "silencershot";
			SecondsIntercept = 300;
		}

		public override UserControl Bullet()
		{
			 return new ResourceFramework.UserControls.Weapon.Flowers2();
		}
	}
}
