using System;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using GameFramework.Weapons;
using HelperFramework;

namespace KraakjeRot.Weapons
{
	public class WaterCanon : ShootWeapon
	{
		private static ResourceFramework.UserControls.Weapon.WaterCanon _weapon;
		private static Random _random = new Random();

		public WaterCanon() : base(_weapon = new ResourceFramework.UserControls.Weapon.WaterCanon())
		{
			ImpactDamage = 10;
			SoundOnFire = "silencershot";
			SecondsIntercept = 100;
			ttLive = 1100;
		}
		public override UserControl Bullet()
		{
			UserControl uc = new UserControl { Width = 10, Height = 7 };
			Ellipse ellipse = new Ellipse { Width = 10, Height = 7 };
			ellipse.Fill = new SolidColorBrush(Colors.Blue);
			ellipse.Stroke = new SolidColorBrush(Colors.Cyan);
			ellipse.StrokeThickness = 1;
			uc.Content = ellipse;
			
			return uc;
		}
		public override Vector BulletProjectory()
		{
			return MathHelpers.CreateVectorFromAngle(_random.Next(0, 360), _random.Next(10, 50) / 10d);
		}
	}
}
