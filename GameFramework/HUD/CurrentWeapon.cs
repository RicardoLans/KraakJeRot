using System;
using System.Windows.Controls;
using System.Windows.Media;
using GameFramework.Weapons;
using HelperFramework;

namespace GameFramework.HUD
{
	public class CurrentWeapon : HudElement
	{
		public Button ContentHolder { get; set; }

		public Weapon Weapon { private get; set; }
		private Weapon WeaponThatIsSet { get; set; }
		private Int32 WeaponNrThatIsSet { get; set; }

		public CurrentWeapon(UserControl control) : base(control) { }

		public override void Update()
		{
			if ((Weapon != null && Weapon != WeaponThatIsSet)
			|| (Weapon != null && Weapon.RandomItems != null && Weapon.RandomNr != -1 && Weapon.RandomNr != WeaponNrThatIsSet))  // else this heavy function is called every frame!
			{
				WeaponThatIsSet = Weapon;
				UserControl holderWeapon = Weapon.Content.GetType().CreateANewInstance() as UserControl;
				if (holderWeapon == null) throw new ArgumentNullException("No valid weapon conten!");

				if (Weapon.RandomItems != null && Weapon.RandomNr != -1)
				{
					WeaponNrThatIsSet = Weapon.RandomNr;
					Weapon.Randomize(holderWeapon, Weapon.RandomItems, Weapon.RandomNr);
				}

				Double maxWidth = ContentHolder.ActualWidth;
				Double maxHeight = ContentHolder.ActualHeight;

				ScaleTransform transform = new ScaleTransform
											{
												ScaleX =
													(Double)holderWeapon.Content.GetValue(WidthProperty) > maxWidth
														? holderWeapon.Width / maxWidth
														: 1,
												ScaleY =
													(Double)holderWeapon.Content.GetValue(HeightProperty) > maxHeight
														? holderWeapon.Height / maxHeight
														: 1
											};
				holderWeapon.RenderTransform = transform;

				ContentHolder.Content = holderWeapon;
			}
		}
	}
}