using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using GameFramework.NPCs;
using GameFramework.Weapons.Bullets;
using HelperFramework;

namespace GameFramework.Weapons
{
	public class WeaponEngine : Engine
	{
		public Int32 CurrentWeaponIndex;

		public WeaponEngine(Canvas canvas) : base(canvas) { }

		public Weapon CurrentWeapon { get; set; }

		public void SetBulletEngine(BulletEngine bulletEngine)
		{
			foreach (ShootWeapon weapon in GetWeapons().Cast<ShootWeapon>())
			{
				weapon.BulletEngine = bulletEngine;
			}
		}
		public void SetCollisionTargets(List<NPC> collisionTargets)
		{
			foreach (ShootWeapon weapon in GetWeapons().Cast<ShootWeapon>())
			{
				weapon.CollisionTargets = collisionTargets;
			}
		}

		public List<Weapon> GetWeapons()
		{
			return GetList<Weapon>();
		}

		public void SetWeapon(Weapon weapon)
		{
			List<Weapon> weapons = GetWeapons();
			weapons.ForEach(w => w.Hide());
			CurrentWeapon = weapons.Where(w => w == weapon).FirstOrDefault();
			if (CurrentWeapon != null)
			{
				if (weapon.RandomItems != null)
					weapon.RandomNr = weapon.Randomize(weapon.RandomItems);
				CurrentWeapon.Show();
			}
		}
		public void SetWeapon<T>() where T : Weapon
		{
			Weapon selected = GetWeapons().OfType<T>().FirstOrDefault();
			SetWeapon(selected);
		}
		public void SetNextWeapon(Boolean next)
		{
			List<Weapon> weapons = GetWeapons();
			Weapon weapon = next ? weapons.Next(ref CurrentWeaponIndex) : weapons.Previous(ref CurrentWeaponIndex);
			SetWeapon(weapon);
		}

		public override void Update(TimeSpan elapsed)
		{
			base.Update(elapsed);
			GetWeapons().ForEach(item => item.Update(elapsed));
		}
	}
}