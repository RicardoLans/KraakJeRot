using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using GameFramework.NPCs;
using GameFramework.Weapons.Bullets;
using HelperFramework;

namespace GameFramework.Weapons
{
	public class ShootWeapon : Weapon
	{
		private DateTime _bulletLastFired;

		public ShootWeapon(UserControl content, Int32 pointValue = 25)
			: base(content, pointValue)
		{
			Canvas bulletOrigin = (Canvas)content.FindName("weaponBulletOrigin");
			if (bulletOrigin == null) throw new ArgumentNullException("No weaponBulletOrigin implemented!");
			BulletOrigin = bulletOrigin;
		}

		public Canvas BulletOrigin { get; set; }
		public BulletEngine BulletEngine { get; set; }
		public virtual UserControl Bullet()
		{
			UserControl uc = new UserControl
			{
				Width = 7,
				Height = 7,
				Content = new Ellipse
				{
					Width = 7,
					Height = 7,
					Fill = new SolidColorBrush(Colors.Red),
					Stroke = new SolidColorBrush(Colors.DarkGray),
					StrokeThickness = 1
				}
			};
			return uc;
		}
		public virtual Vector BulletProjectory()
		{
			return new Vector();
		}

		public List<NPC> CollisionTargets { get; set; }

		public override void Fire()
		{
			if (BulletEngine == null) return;  // there's no need to fire when there's no bulletengine;

			if (_bulletLastFired < DateTime.Now.AddMilliseconds(-SecondsIntercept))  // we don't want to fire to fast;
			{
				Shoot();
				base.Fire();
			}
		}

		private void Shoot()
		{
			GeneralTransform objGeneralTransform = BulletOrigin.TransformToVisual(Application.Current.RootVisual);

			Bullet bullet = new Bullet(Bullet(), 180 - ProjectoryAngle, objGeneralTransform.Transform(new Point(0, 0)), this.ImpactDamage, ttLive);
			bullet.Position += BulletProjectory();
			if (CollisionTargets != null) bullet.AddCollisionTargets(CollisionTargets);
			BulletEngine.Add<Bullet>(bullet);

			_bulletLastFired = DateTime.Now;
		}
	}
}