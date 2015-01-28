using GameFramework.Weapons;

namespace KraakjeRot.Weapons
{
	public class Chair : ThrowWeapon
	{
		private static ResourceFramework.UserControls.Weapon.Chair _weapon;

		public Chair() : base(_weapon = new ResourceFramework.UserControls.Weapon.Chair()) { }
	}
}
