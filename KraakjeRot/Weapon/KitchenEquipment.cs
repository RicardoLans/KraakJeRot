using GameFramework.Weapons;

namespace KraakjeRot.Weapons
{
	public class KitchenEquipment : ThrowWeapon
	{
		private static ResourceFramework.UserControls.Weapon.KitchenEquipment _weapon;

		public KitchenEquipment() : base(_weapon = new ResourceFramework.UserControls.Weapon.KitchenEquipment()) { }
	}
}
