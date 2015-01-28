using System;

namespace GameFramework.NPCs
{
	public class Movements
	{
		private NPC _npc;


		public Movements(NPC npc)
		{
			_npc = npc;
		}


		#region Events;
		public delegate void OnRight(object sender);
		public event OnRight onRight;

		public delegate void OnLeft(object sender);
		public event OnLeft onLeft;

		public delegate void OnJump(object sender);
		public event OnJump onJump;

		public delegate void OnDuck(object sender);
		public event OnDuck onDuck;
		#endregion Events;


		#region Getters/Setters;
		public Boolean StartedRight { get; set; }

		public Boolean StartedLeft { get; set; }

		public Boolean StartedJump { get; set; }

		public Boolean StartedDuck { get; set; }
		#endregion Getters/Setters;


		#region Methods;
		public void Right()
		{
			if (!StartedRight)
			{
				if (onRight != null)
				{
					StartedRight = true;
					onRight(_npc);
				}
			}
		}

		public void Left()
		{
			if (!StartedLeft)
			{
				if (onLeft != null)
				{
					StartedLeft = true;
					onLeft(_npc);
				}
			}
		}

		public void Jump()
		{
			if (!StartedJump)
			{
				if (onJump != null)
				{
					StartedJump = true;
					onJump(_npc);
				}
			}
		}

		public void Duck()
		{
			if (!StartedDuck)
			{
				if (onDuck != null)
				{
					StartedDuck = true;
					onDuck(_npc);
				}
			}
		}
		#endregion Methods;

	}
}
