using System;
using System.Windows;
using System.Windows.Controls;

namespace GameFramework.NPCs
{
	public class NPC : UserControl
	{
		private Boolean _dead;
		private Point _position;

		public NPC(UserControl content, int pointValue = 25)
		{
			this.Content = content;
			PointValue = pointValue;

			Movement = new Movements(this);
			Movement.onRight += Move_GoRight;
			Movement.onLeft += Move_GoLeft;
			Movement.onJump += Move_GoJump;
			Movement.onDuck += Move_GoDuck;
		}

		#region Events;
		private void Move_GoRight(object sender) { MoveRight(sender); }
		public virtual void MoveRight(Object sender) { Movement.StartedRight = false; }

		private void Move_GoLeft(object sender) { MoveLeft(sender); }
		public virtual void MoveLeft(Object sender) { Movement.StartedLeft = false; }

		private void Move_GoJump(object sender) { MoveJump(sender); }
		public virtual void MoveJump(Object sender) { Movement.StartedJump = false; }

		private void Move_GoDuck(object sender) { MoveDuck(sender); }
		public virtual void MoveDuck(Object sender) { Movement.StartedDuck = false; }

		public delegate void OnHit(object sender);
		public virtual event OnHit IsHit;

		public delegate void OnDied(object sender);
		public virtual event OnDied Died;

		public delegate void OnRevived(object sender);
		public virtual event OnRevived Revived;
		#endregion Events;

		public Int32 PointValue { get; set; }

		private Int32 _health;
		public Int32 HealthPoints
		{
			get { return _health; }
			set
			{
				if (value > 100) _health = 100;
				else if (value < 0) _health = 0;
				else _health = value;
			}
		}

		public virtual Boolean Dead
		{
			get
			{
				return _dead;
			}
			private set
			{
				_dead = value;
				if (_dead)
				{
					if (Died != null)
					{
						Died(this);
					}
				}
			}
		}

		public virtual Point Origin { get; set; }

		public virtual Point Position
		{
			set
			{
				_position = value;
				this.SetValue(Canvas.LeftProperty, value.X - Origin.X);
				this.SetValue(Canvas.TopProperty, value.Y - Origin.Y);
			}
			get
			{
				return _position;
			}
		}

		public Movements Movement { private set; get; }

		public FrameworkElement CollisionRoot { get; set; }
		public FrameworkElement CollisionBound { get; set; }

		public virtual void Die()
		{
			if (IsHit != null) IsHit(this);
			if (HealthPoints < 1) Dead = true;
		}

		public virtual void Revive()
		{
			Dead = false;
			HealthPoints = 100;
			if (Revived != null) Revived(this);
		}

		public virtual void Update(TimeSpan elapsed) { }
	}
}