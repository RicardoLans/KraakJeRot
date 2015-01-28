using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using GameFramework.Audio;
using GameFramework.NPCs;
using HelperFramework;

namespace KraakjeRot
{
	public class Kraker : ArmedNPC
	{
		private static ResourceFramework.UserControls.NPC.Kraker _kraker;
		private Storyboard _stbDead;
		private Storyboard _stbDead1;
		private Storyboard _stbDead2;
		private List<Storyboard> _ondiedAnimations = new List<Storyboard>();
		private Random _rand = new Random((int)DateTime.Now.Ticks);

		public Kraker()
			: base(_kraker = new ResourceFramework.UserControls.NPC.Kraker())
		{
			Grid root = (Grid)_kraker.FindName("LayoutRoot");
			if (root == null) throw new ArgumentNullException("No LayoutRoot implemented!");
			CollisionRoot = root;

			HealthPoints = 100;
			_stbDead = (Storyboard)_kraker.FindName("stb_dead");
			_stbDead1 = (Storyboard)_kraker.FindName("stb_dead1");
			_stbDead2 = (Storyboard)_kraker.FindName("stb_dead2");

			_ondiedAnimations.Add(_stbDead);
			_ondiedAnimations.Add(_stbDead1);
			_ondiedAnimations.Add(_stbDead2);

			AddWeapon(new Weapons.Bin(),
					  new Weapons.Brick(),
					  new Weapons.Cannabis(),
				//new Weapons.Chair(),
					  new Weapons.Eggs(),
				//new Weapons.KitchenEquipment(),
					  new Weapons.WaterBalloon(),
					  new Weapons.Table()
					 );

			IsHit += KrakerIsHit;
			Died += KrakerDied;

			PointValue = 30;
		}

		#region Events;
		private void KrakerIsHit(object sender)
		{
			Opacity = 0.9;
			TimeOut.SetTimeout(100, () => { Opacity = 1; });
		}

		private void KrakerDied(object sender)
		{
			SoundPlayer.PlaySound("scream");
			Storyboard board = _ondiedAnimations[_rand.Next(0, 2)];
			board.Begin();
		}

		public override void MoveRight(object sender)
		{
			this.Position += new Vector(20, 0);
			base.MoveRight(sender);
		}

		public override void MoveLeft(object sender)
		{
			this.Position += new Vector(-20, 0);
			base.MoveLeft(sender);
		}
		#endregion Events;

		public override void Die()
		{
			base.Die();
			if (HealthPoints < 1)
			{
				AI.Destroy();
				WeaponEngine.Empty();
			}
		}

		public override void Update(TimeSpan elapsed)
		{
			WeaponEngine.Update(elapsed);
			if (AI != null) AI.Update(elapsed);
		}
	}
}