using System.Windows.Controls;
using GameFramework.Weapons;
using ResourceFramework.UserControls.Weapons.Bullets;

namespace KraakjeRot.Weapons
{
	public class StunGun : ShootWeapon
	{
		private static ResourceFramework.UserControls.Weapon.StunGun _weapon;

		public StunGun()
			: base(_weapon = new ResourceFramework.UserControls.Weapon.StunGun())
		{
			ImpactDamage = 40;
			ttLive = 1500;
			SoundOnFire = "silencershot";
			SecondsIntercept = 300;
		}

		public override UserControl Bullet()
		{
			return new Bullet1();
		}
	}
}