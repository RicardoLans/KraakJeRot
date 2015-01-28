using GameFramework.Weapons;

namespace KraakjeRot.Weapons
{
	public class DummyGun : ShootWeapon
	{
		private static ResourceFramework.UserControls.Weapon.DummyGun _weapon;

		public DummyGun()
			: base(_weapon = new ResourceFramework.UserControls.Weapon.DummyGun())
		{
			SecondsIntercept = 300;
			ImpactDamage = 30;
			ttLive = 2000;

			RandomItems = new[] { "M16", "Tranquilizer" };
			RandomNr = Randomize(RandomItems);
		}
	}
}