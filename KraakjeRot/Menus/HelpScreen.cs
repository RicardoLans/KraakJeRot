using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using GameFramework.Additional;
using GameFramework.Audio;
using GameFramework.Menus;
using GameFramework.Weapons.Bullets;
using ResourceFramework.UserControls.Additional;

namespace KraakjeRot.Menus
{
	public class HelpScreen : Menu
	{
		private static ResourceFramework.UserControls.Menus.HelpScreen _menu = new ResourceFramework.UserControls.Menus.HelpScreen();
		public List<HelpControlHolder> Controls = new List<HelpControlHolder>();
		private Grid _btnGrid;
		private Canvas _cnvsMe;
		private TextBlock _txtKeyName;
		private ME _meer;
		private ResourceDictionary _btnResource;
		private SignPost _signPost;
		private BulletEngine _bulletEngine;

		public HelpScreen()
			: base(_menu)
		{
			Controls.Add(new HelpControlHolder { Name = "Q", Key = Key.Q, KeyName = "Shuffle Weapon Down", ImgString = @"/ResourceFramework;component/Images/Buttons/Control/q.png", GridCol = 0, GridRow = 0 });
			Controls.Add(new HelpControlHolder { Name = "W", Key = Key.W, KeyName = "Jump", ImgString = @"/ResourceFramework;component/Images/Buttons/Control/w.png", GridCol = 1, GridRow = 0 });
			Controls.Add(new HelpControlHolder { Name = "E", Key = Key.E, KeyName = "Shuffle Weapon Up", ImgString = @"/ResourceFramework;component/Images/Buttons/Control/e.png", GridCol = 2, GridRow = 0 });

			Controls.Add(new HelpControlHolder { Name = "A", Key = Key.A, KeyName = "Move to Left", ImgString = @"/ResourceFramework;component/Images/Buttons/Control/a.png", GridCol = 0, GridRow = 1 });
			Controls.Add(new HelpControlHolder { Name = "D", Key = Key.D, KeyName = "Move to Right", ImgString = @"/ResourceFramework;component/Images/Buttons/Control/d.png", GridCol = 2, GridRow = 1 });

			Controls.Add(new HelpControlHolder { Name = "Left", Key = Key.Left, KeyName = "Aim Weapon to Left", ImgString = @"/ResourceFramework;component/Images/Buttons/Control/left.png", GridCol = 0, GridRow = 3 });
			Controls.Add(new HelpControlHolder { Name = "Up", Key = Key.Up, KeyName = "Shuffle Weapon Up", ImgString = @"/ResourceFramework;component/Images/Buttons/Control/up.png", GridCol = 1, GridRow = 2 });
			Controls.Add(new HelpControlHolder { Name = "Right", Key = Key.Right, KeyName = "Aim Weapon to Right", ImgString = @"/ResourceFramework;component/Images/Buttons/Control/right.png", GridCol = 2, GridRow = 3 });
			Controls.Add(new HelpControlHolder { Name = "Down", Key = Key.Down, KeyName = "Shuffle Weapon Down", ImgString = @"/ResourceFramework;component/Images/Buttons/Control/down.png", GridCol = 1, GridRow = 3 });

			Controls.Add(new HelpControlHolder { Name = "Control", Key = Key.Ctrl, KeyName = "Jump", ImgString = @"/ResourceFramework;component/Images/Buttons/Control/control.png", GridCol = 0, GridRow = 4 });
			Controls.Add(new HelpControlHolder { Name = "Space", Key = Key.Space, KeyName = "Shoot Weapon", ImgString = @"/ResourceFramework;component/Images/Buttons/Control/space.png", GridCol = 1, GridRow = 4, Width = 350, Height = 100, GridColWidth = 3 });

			_bulletEngine = new BulletEngine(new Canvas());

			_meer = new ME { Name = "testMEer", Position = new Point(800, 650) };
			_meer.WeaponEngine.SetBulletEngine(_bulletEngine);

			_btnResource = _menu.Resources.MergedDictionaries[0];

			_cnvsMe = _menu.FindName("cnvsMe") as Canvas;
			if (_cnvsMe == null) throw new NotImplementedException("ME not implemented");
			_cnvsMe.Children.Add(_bulletEngine.Container);
			_cnvsMe.Children.Add(_meer);

			_txtKeyName = _menu.FindName("txtKeyName") as TextBlock;
			if (_txtKeyName == null) throw new NotImplementedException("txtKeyName not implemented");

			_btnGrid = _menu.FindName("btnGrid") as Grid;
			if (_btnGrid == null) throw new NotImplementedException("btnGrid not implemented");
			CreateButtons();

			_signPost = _menu.FindName("SignPost") as SignPost;
			if (_signPost == null) throw new NotImplementedException("SignPost not implemented");
			_signPost.SignText = "Naar Home";
			(_signPost.FindName("canvasSignpost") as Canvas).MouseLeftButtonDown += SignPostMouseLeftButtonDown;

			Updated += HelpScreenUpdated;
			Shown += HelpScreenShown;
		}

		void SignPostMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			MenuEngineReference.Show<IntroductionScreen>();
		}

		void HelpScreenUpdated(object sender, TimeSpan elapsed)
		{
			_meer.WeaponEngine.Update(elapsed);
			_bulletEngine.Update(elapsed);
		}

		void HelpScreenShown(object sender)
		{
			_meer.ShuffleWeapon<Weapons.StunGun>();
			if (_meer.WeaponEngine.CurrentWeapon == null) _meer.ShuffleWeaponDown();
		}

		public void GotoBack()
		{
			SoundPlayer.PlaySound("button4");
			MenuEngineReference.Show<IntroductionScreen>();
		}

		private void CreateButtons()
		{
			foreach (var control in Controls)
			{
				control.Background = control.ImgBrushBig;
				control.Style = (Style)_btnResource["btn"];
				control.Click += ControlClick;
				control.MouseEnter += ControlMouseEnter;
				Grid.SetColumn(control, control.GridCol);
				Grid.SetRow(control, control.GridRow);
				Grid.SetColumnSpan(control, control.GridColWidth);
				_btnGrid.Children.Add(control);
			}
		}

		private Int32 _mover;

		void ControlClick(object sender, RoutedEventArgs e)
		{
			var key = ((HelpControlHolder)sender).Key;

			switch (key)
			{
				case Key.W:
				case Key.Ctrl:
					_meer.MoveJump(this);
					break;

				case Key.Left:
					_meer.WeaponEngine.CurrentWeapon.ProjectoryAngle = _meer.WeaponEngine.CurrentWeapon.ProjectoryAngle - 10;
					break;
				case Key.Right:
					_meer.WeaponEngine.CurrentWeapon.ProjectoryAngle = _meer.WeaponEngine.CurrentWeapon.ProjectoryAngle + 10;
					break;

				case Key.Q:
				case Key.Down:
					_meer.ShuffleWeaponDown();
					break;
				case Key.E:
				case Key.Up:
					_meer.ShuffleWeaponUp();
					break;

				case Key.A:
					if (_mover > -2)
					{
						for (int i = 0; i < 30; i++)
							_meer.MoveLeft(this);
						_mover--;
					}
					break;
				case Key.D:
					if (_mover < 2)
					{
						for (int i = 0; i < 30; i++)
							_meer.MoveRight(this);
						_mover++;
					}
					break;

				case Key.Space:
					_meer.Fire();
					break;
			}
		}

		void ControlMouseEnter(object sender, MouseEventArgs e)
		{
			var controlHolder = (HelpControlHolder)sender;
			_txtKeyName.Text = controlHolder.Name + ": " + controlHolder.KeyName;
		}
	}
}