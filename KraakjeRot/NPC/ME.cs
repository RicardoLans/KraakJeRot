using System;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using GameFramework.Audio;
using GameFramework.NPCs;
using HelperFramework;

namespace KraakjeRot
{
	public class ME : ArmedNPC
	{
		private static ResourceFramework.UserControls.NPC.ME _me;

		private Storyboard _stbJump;

		private Storyboard _stbLeft;
		private Storyboard _stbTurnLeft;

		private Storyboard _stbRight;
		private Storyboard _stbTurnRight;

		private Storyboard _stbDeadRight;
		private Storyboard _stbDeadLeft;


		public ME()
			: base(_me = new ResourceFramework.UserControls.NPC.ME())
		{
			Grid root = (Grid)_me.FindName("LayoutRoot");
			if (root == null) throw new ArgumentNullException("No LayoutRoot implemented!");
			CollisionBound = this;
			CollisionRoot = root;

			_stbJump = (Storyboard)_me.FindName("stb_jump");
			if (_stbJump == null) throw new ArgumentNullException("No stb_jump storyboard implemented!");
			_stbJump.Completed += StbJumpCompleted;

			_stbRight = (Storyboard)_me.FindName("stb_right");
			if (_stbRight == null) throw new ArgumentNullException("No stb_right storyboard implemented!");
			_stbRight.Completed += StbRightCompleted;

			_stbLeft = (Storyboard)_me.FindName("stb_left");
			if (_stbLeft == null) throw new ArgumentNullException("No stb_left storyboard implemented!");
			_stbLeft.Completed += StbRightCompleted;

			_stbDeadLeft = (Storyboard)_me.FindName("stb_deadLeft");
			if (_stbDeadLeft == null) throw new ArgumentNullException("No stb_deadLeft storyboard implemented!");
			_stbDeadLeft.Completed += StbRightCompleted;

			_stbDeadRight = (Storyboard)_me.FindName("stb_deadRight");
			if (_stbDeadRight == null) throw new ArgumentNullException("No stb_deadRight storyboard implemented!");
			_stbDeadRight.Completed += StbRightCompleted;

			_stbTurnRight = (Storyboard)_me.FindName("stb_turnRight");
			if (_stbTurnRight == null) throw new ArgumentNullException("No stb_turnRight storyboard implemented!");
			_stbTurnRight.Completed += StbRightCompleted;

			_stbTurnLeft = (Storyboard)_me.FindName("stb_turnLeft");
			if (_stbTurnLeft == null) throw new ArgumentNullException("No stb_turnLeft storyboard implemented!");
			_stbTurnLeft.Completed += StbRightCompleted;

			Died += MeDied;

			AddWeapon(new Weapons.DummyGun(),
					  new Weapons.Flowers(),
					  new Weapons.StunGun(),
					  new Weapons.TearGas(),
					  new Weapons.WaterCanon()
					 );
		}

		private void MeDied(object sender)
		{
			SoundPlayer.PlaySound("scream");
			WeaponEngine.SetWeapon<Weapons.Flowers>();
			Random rnd = new Random((int)DateTime.Now.Ticks);
			Storyboard board = rnd.Next(0, 1) == 1 ? _stbDeadLeft : _stbDeadRight;
			board.Begin();
		}

		private void StbRightCompleted(object sender, EventArgs e)
		{
			Movement.StartedRight = false;
		}

		#region Events;

		public override void MoveRight(object sender)
		{
			this.Position += new Vector(5, 0);
			base.MoveRight(sender);
			//_stbRight.Begin();  //! uncommit this line and comment the others to use the storyboard;
		}

		public override void MoveLeft(object sender)
		{
			this.Position += new Vector(-5, 0);
			base.MoveLeft(sender);
			//_stbLeft.Begin();
		}

		public override void MoveJump(object sender)
		{
			_stbJump.Begin();
			//base.MoveJump(sender);  // IMPORTANT: can't use base(), because storyboard isn't finished yet;
		}

		private void StbJumpCompleted(object sender, EventArgs e)
		{
			Movement.StartedJump = false;
		}
		#endregion Events;
	}
}
