using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using GameFramework.NPCs;
using GameFramework.Weapons.Bullets;
using HelperFramework;

namespace GameFramework.Levels
{
	public class Level : UserControl
	{
		private Canvas _levelSurfaceME;
		private Canvas _levelSurfaceKraker;

		private NPCEngine _playerEngine;
		private NPCEngine _krakerEngine;
		private Engine _windowEngine;
		private BulletEngine _bulletEngine;

		public Boolean Done;

		public Int32 Number { get; set; }
		public Int32 PlayTime { get; set; }

		public static ArmedNPC Player { get; set; }
		public List<ArmedNPC> Krakers
		{
			get
			{
				return _krakerEngine.GetList().Cast<ArmedNPC>().ToList();
			}
		}

		public Level(Int32 number, UserControl level)
		{
			Number = number;
			this.Content = level;

			this.Visibility = Visibility.Collapsed;

			_levelSurfaceME = level.FindName("levelSurfaceME") as Canvas;
			if (_levelSurfaceME == null) throw new NotImplementedException("No levelSurfaceME implemented");
			_playerEngine = new NPCEngine(new Canvas());
			_levelSurfaceME.Children.Add(_playerEngine.Container);

			_levelSurfaceKraker = level.FindName("levelSurfaceKraker") as Canvas;
			if (_levelSurfaceKraker == null) throw new NotImplementedException("No levelSurfaceKraker implemented");
			_krakerEngine = new NPCEngine();
			_windowEngine = new Engine(new Canvas());
			_levelSurfaceKraker.Children.Add(_windowEngine.Container);

			_bulletEngine = new BulletEngine(_windowEngine.Container);
		}

		public virtual void Show()
		{
			if (Player != null)
			{
				Player.WeaponEngine.SetBulletEngine(_bulletEngine);
				Player.WeaponEngine.SetCollisionTargets(_krakerEngine.GetList());
				_playerEngine.Add(Player);
			}
			foreach (ArmedNPC kraker in Krakers)
			{
				kraker.WeaponEngine.SetBulletEngine(_bulletEngine);
				kraker.WeaponEngine.SetCollisionTargets(new List<NPC> { Player });
				ArmedNPC kraker1 = kraker;
				TimeOut.SetTimeout(3000, () => kraker1.AI.Start());
			}

			this.Visibility = Visibility.Visible;
			this.Focus();

			if (Started != null)
			{
				Started(this);
			}
		}

		public virtual void Hide()
		{
			this.Visibility = Visibility.Collapsed;

			if (Player != null)
			{
				_playerEngine.Remove(Player);
			}

			Krakers.ForEach(kraker => kraker.AI.Destroy());

			if (Finished != null)
			{
				Finished(this);
			}
		}

		public void AddWindow(Window window)
		{
			_windowEngine.Add(window);
			_krakerEngine.Add(window.NPC, false);
		}
		public void AddWindow(params Window[] windows)
		{
			Array.ForEach(windows, AddWindow);
		}

		public void Update(TimeSpan elapsed)
		{
			if (Done) return;
			_playerEngine.Update(elapsed);
			_bulletEngine.Update(elapsed);
			_windowEngine.Update(elapsed);
			_krakerEngine.GetList().ForEach(kraker => kraker.Update(elapsed));

			Done = _krakerEngine.GetList().Count(kraker => !kraker.Dead) == 0;//|| Player.Dead;

			if (Updated != null)
			{
				Updated(this);
			}
		}

		#region Events;
		public delegate void OnStarted(object sender);
		public event OnStarted Started;

		public delegate void OnFinished(object sender);
		public event OnFinished Finished;

		public delegate void OnUpdate(object sender);
		public event OnUpdate Updated;
		#endregion Events;

	}
}