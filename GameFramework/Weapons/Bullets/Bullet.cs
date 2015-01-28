using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using GameFramework.NPCs;
using HelperFramework;

namespace GameFramework.Weapons.Bullets
{
	public class Bullet : UserControl
	{
		private TimeSpan _lifeSoFar = TimeSpan.Zero;
		private Boolean _dead;
		private Point _position;
		private Int32 _impactDamage;
		private List<NPC> _collisionTargets = new List<NPC>();
		private int ttLive;
		
		public delegate void OnDied(Object sender);
		public event OnDied Died;

		public Bullet(UserControl content, Int32 angle, Point position, Int32 impactDamage = 10, int time2Live = 1000)
		{
			this.Content = content;
			_impactDamage = impactDamage;
			ttLive = time2Live;

			this.Width = Convert.ToDouble(this.Content.GetValue(Canvas.WidthProperty));
			if (Double.IsNaN(this.Width)) this.Width = Convert.ToDouble(this.Content.GetValue(Canvas.ActualWidthProperty));
			if (Double.IsNaN(this.Width) || this.Width <= 0) this.Width = Convert.ToDouble(((UserControl)this.Content).Content.GetValue(Canvas.ActualWidthProperty));
			this.Height = Convert.ToDouble(this.Content.GetValue(Canvas.HeightProperty));
			if (Double.IsNaN(this.Height)) this.Height = Convert.ToDouble(this.Content.GetValue(Canvas.ActualHeightProperty));
			if (Double.IsNaN(this.Height) || this.Height <= 0) this.Height = Convert.ToDouble(((UserControl)this.Content).Content.GetValue(Canvas.ActualHeightProperty));

			content.Width = this.Width;
			content.Height = this.Height;

			CollisionRoot = content;

			TimeToLive = TimeSpan.FromMilliseconds(time2Live);

			Velocity = MathHelpers.CreateVectorFromAngle(angle, 1) * 300;

			Origin = new Point(this.Width / 2, this.Height / 2);

			Position = position;
		}


		#region Getters/Setters;
		public TimeSpan TimeToLive { get; set; }

		public Vector Velocity { get; set; }

		public Point Origin { get; set; }

		public Boolean Dead
		{
			get
			{
				return _dead;
			}
			set
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

		public Point Position
		{
			get
			{
				return _position;
			}
			set
			{
				_position = value;
				this.SetValue(Canvas.LeftProperty, value.X - Origin.X);
				this.SetValue(Canvas.TopProperty, value.Y - Origin.Y);
			}
		}
		#endregion Getters/Setters;


		public void Update(TimeSpan elapsed)
		{
			foreach (NPC collisionTarget in _collisionTargets)
			{
				if (!collisionTarget.Dead)
				{
					if (CheckCollision(
						this, this, this.CollisionRoot,
						collisionTarget, collisionTarget.CollisionBound, collisionTarget.CollisionRoot))
					{
						collisionTarget.HealthPoints -= this._impactDamage;
						collisionTarget.Die();  // npc;
						this.Dead = true;  // bullet;
					}
				}
			}

			if (Velocity != Vector.Zero)
			{
				Position += Velocity * elapsed.TotalSeconds;
			}

			_lifeSoFar += elapsed;
			if (_lifeSoFar > this.TimeToLive)
			{
				Dead = true;
			}
		}

		public void Destory()
		{
			this.Content = null;
			this.Width = 0;
			this.Height = 0;
			//this.Destory();  // crashes SilverLight;
		}

		public FrameworkElement CollisionRoot { get; set; }

		public void AddCollisionTargets(List<NPC> elems)
		{
			_collisionTargets.AddRange(elems);
		}

		#region Collision fn;
		private static Boolean CheckCollision(FrameworkElement control1, FrameworkElement controlBound1, FrameworkElement controlElem1, FrameworkElement control2, FrameworkElement controlBound2, FrameworkElement controlElem2)
		{
			// first see if rectangles collide;
			Rect rect1 = UserControlBounds(controlBound1);
			Rect rect2 = UserControlBounds(controlBound2);

			rect1.Intersect(rect2);

			if (rect1 == Rect.Empty) { return false; }  // no collision;

			Boolean collision = false;

			// now we do a more accurate pixel hit test;
			for (Double x = rect1.X; x < rect1.X + rect1.Width; x++)
			{
				for (Double y = rect1.Y; y < rect1.Y + rect1.Height; y++)
				{
					if (CheckCollisionPoint(new Point(x, y), control1, controlElem1))
						if (CheckCollisionPoint(new Point(x, y), control2, controlElem2))
						{
							collision = true;
							break;
						}
				}
				if (collision) break;
			}
			return collision;
		}

		private static Boolean CheckCollisionPoint(Point point, FrameworkElement control, FrameworkElement controlElem)
		{
			List<UIElement> hits = VisualTreeHelper.FindElementsInHostCoordinates(point, control) as List<UIElement>;
			return (hits.Contains(controlElem));
		}

		private static Rect UserControlBounds(FrameworkElement control)
		{
			return new Rect(Convert.ToDouble(control.GetValue(Canvas.LeftProperty)),
							Convert.ToDouble(control.GetValue(Canvas.TopProperty)),
							control.ActualWidth,
							control.ActualHeight);
		}
		#endregion Collision fn;

	}
}