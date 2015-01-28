using System;
using System.Collections.Generic;
using System.Windows.Controls;

namespace GameFramework.Weapons.Bullets
{
	public class BulletEngine : Engine
	{
		public BulletEngine(Canvas canvas) : base(canvas) { }

		public override void Update(TimeSpan elapsed)
		{
			base.Update(elapsed);

			List<Bullet> bullets = GetList<Bullet>();

			foreach (Bullet bullet in bullets)
			{
				bullet.Update(elapsed);
				if (bullet.Dead)
				{
					base.Remove(bullet);
					bullet.Destory();
				}
			}
		}
	}
}