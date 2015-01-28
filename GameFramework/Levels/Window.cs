using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using GameFramework.NPCs;

namespace GameFramework.Levels
{
	public class Window : UserControl
	{
		private Point _position;

		public Window(UserControl window, Rect positionAndSize)
		{
			this.Content = window;

			Active = true;
			Position = new Point(positionAndSize.X, positionAndSize.Y);
			Size = new Size(positionAndSize.Width, positionAndSize.Height);
		}

		public Boolean Active { get; set; }

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

		public Size Size
		{
			set
			{
				Double w = value.Width;
				Double h = value.Height;
				((UserControl)this.Content).Width = this.Width = w;
				((UserControl)this.Content).Height = this.Height = h;
				this.Content.Clip = new RectangleGeometry()
				{
					Rect = new Rect(0, 0, w, h)
				};
			}
			get
			{
				return new Size(this.Width, this.Height);
			}
		}

		public ArmedNPC NPC { get; protected set; }
	}
}
