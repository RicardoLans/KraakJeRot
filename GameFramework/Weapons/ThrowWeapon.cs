using System;
using System.Windows.Controls;

namespace GameFramework.Weapons
{
	public class ThrowWeapon : ShootWeapon
	{
		public ThrowWeapon(UserControl content, Int32 pointValue = 30) : base(content, pointValue) { }
	}
}