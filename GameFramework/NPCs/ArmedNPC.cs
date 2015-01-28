using System;
using System.Windows;
using System.Windows.Controls;
using GameFramework.Audio;
using GameFramework.NPCs.AI;
using GameFramework.Weapons;

namespace GameFramework.NPCs
{
	public class ArmedNPC : NPC
	{
		public ArmedNPC(UserControl content)
			: base(content)
		{
			Canvas weaponSurface = (Canvas)content.FindName("cnv_weaponSurface");
			if (weaponSurface == null) throw new ArgumentNullException("No cnv_weaponSurface implemented!");
			WeaponEngine = new WeaponEngine(weaponSurface);

			AI = new AIEngine();
		}

		public AIEngine AI { get; set; }

		public WeaponEngine WeaponEngine { get; set; }

		public void ShuffleWeapon<T>() where T : Weapon
		{
			WeaponEngine.SetWeapon<T>();
			SoundPlayer.PlaySound("bullet");
		}
		public void ShuffleWeaponUp()
		{
			WeaponEngine.SetNextWeapon(true);
			SoundPlayer.PlaySound("bullet");
			if (WeaponShuffle != null)
			{
				WeaponShuffle(this);
			}
		}
		public void ShuffleWeaponDown()
		{
			WeaponEngine.SetNextWeapon(false);
			SoundPlayer.PlaySound("bullet");
			if (WeaponShuffle != null)
			{
				WeaponShuffle(this);
			}
		}

		public virtual void AddWeapon(Weapon weapon)
		{
			WeaponEngine.Add(weapon);
		}
		public virtual void AddWeapon(params Weapon[] items)
		{
			Array.ForEach(items, AddWeapon);
		}

		public void Fire()
		{
			WeaponEngine.CurrentWeapon.Fire();
		}

		public override void Update(TimeSpan elapsed)
		{
			base.Update(elapsed);
			WeaponEngine.Update(elapsed);
			if (AI != null)
			{
				AI.Update(elapsed);
			}
		}

		public delegate void OnWeaponShuffle(object sender);
		public event OnWeaponShuffle WeaponShuffle;
	}
}