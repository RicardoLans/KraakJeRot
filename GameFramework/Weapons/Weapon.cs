using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using GameFramework.Audio;

namespace GameFramework.Weapons
{
	public class Weapon : UserControl
	{
		public Int32 PointValue { get; set; }

		public String SoundOnFire { get; set; }
		public String SoundOnInpact { get; set; }
		public Int32 SecondsIntercept { get; set; }
		public Int32 ImpactDamage { get; set; }
		public Int32 ttLive { get; set; }

		private RotateTransform _rotateTransform = new RotateTransform();
		private Canvas _weaponOriginn;

		public Weapon(UserControl content, Int32 pointValue = 20)
		{
			this.Content = content;
			PointValue = pointValue;

			Grid layoutRoot = content.FindName("LayoutRoot") as Grid;
			if (layoutRoot == null) throw new NotImplementedException("No LayoutRoot implemented");
			layoutRoot.RenderTransform = _rotateTransform;

			_weaponOriginn = content.FindName("weaponOrigin") as Canvas;
			if (_weaponOriginn == null) throw new NotImplementedException("No weaponOrigin implemented");

			this.Visibility = Visibility.Collapsed;
		}

		private Int32 _projectoryAngle;
		public Int32 ProjectoryAngle
		{
			get { return _projectoryAngle; }
			set
			{
				_projectoryAngle = value;
				//if (_projectoryAngle < -90) _projectoryAngle = -90;
				//if (_projectoryAngle > 90) _projectoryAngle = 90;
			}
		}

		private Point _weaponOrigin;
		public Point WeaponOrigin
		{
			get
			{
				return _weaponOrigin;
			}
			set
			{
				_weaponOrigin = value;
				if (_weaponOrigin.X < 0)
				{
					_weaponOrigin.X -= this.ActualWidth + _weaponOrigin.X + Math.Abs(_weaponOrigin.X);
				}
				if (_weaponOrigin.Y < 0)
				{
					_weaponOrigin.Y -= this.ActualHeight + _weaponOrigin.Y + Math.Abs(_weaponOrigin.Y);
				}
				_rotateTransform.CenterX = _weaponOrigin.X;
				_rotateTransform.CenterY = _weaponOrigin.Y;
				this.SetValue(Canvas.LeftProperty, -_weaponOrigin.X);
				this.SetValue(Canvas.TopProperty, -_weaponOrigin.Y);
			}
		}

		public virtual void Update(TimeSpan elapsed)
		{
			_rotateTransform.Angle = ProjectoryAngle - 90;
		}

		public virtual void Fire()
		{
			if (!String.IsNullOrWhiteSpace(SoundOnFire))
			{
				SoundPlayer.PlaySound(SoundOnFire);
			}
		}

		public virtual void Show()
		{
			if (Shown != null)
			{
				Shown(this);
			}
			_rotateTransform.Angle = ProjectoryAngle = 0;
			this.Visibility = Visibility.Visible;
			GeneralTransform objGeneralTransform = _weaponOriginn.TransformToVisual(this);
			WeaponOrigin = objGeneralTransform.Transform(new Point(0, 0));
			_rotateTransform.Angle = ProjectoryAngle = 90;
		}

		public virtual void Hide()
		{
			if (Hidden != null)
			{
				Hidden(this);
			}
			this.Visibility = Visibility.Collapsed;
		}

		public Int32 RandomNr = -1;
		public String[] RandomItems;
		public Int32 Randomize(String[] items, Int32 nr = -1)
		{
			UserControl control = this.Content as UserControl;
			return control == null ? -1 : Weapon.Randomize(control, items, nr);
		}

		#region Events;
		public delegate void OnShown(object sender);
		public event OnShown Shown;

		public delegate void OnHidden(object sender);
		public event OnHidden Hidden;
		#endregion Events;


		private static Random _rand = new Random();
		public static Int32 Randomize(UserControl control, String[] items, Int32 nr = -1)
		{
			if (control == null || items == null || items.Length == 0) return -1;

			nr = (nr == -1) ? _rand.Next(0, items.Length) : nr;

			List<UIElement> list = new List<UIElement>();
			list.AddRange(items.Select(control.FindName).OfType<Viewbox>().Cast<UIElement>());
			list.ForEach(item => item.Visibility = Visibility.Collapsed);
			list[nr].Visibility = Visibility.Visible;

			return nr;
		}
	}
}