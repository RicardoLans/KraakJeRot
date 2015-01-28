using System.Windows.Controls;
using HelperFramework;

namespace KraakjeRot.HUD
{
	public class CurrentWeapon : GameFramework.HUD.CurrentWeapon
	{
		private static ResourceFramework.UserControls.HUD.CurrentWeapon _currentWeapon = new ResourceFramework.UserControls.HUD.CurrentWeapon { Width = 100, Height = 100 };

		public CurrentWeapon()
			: base(_currentWeapon)
		{
			ContentHolder = _currentWeapon.FindChild<Button>("WeaponContentHolder");
		}
	}
}
