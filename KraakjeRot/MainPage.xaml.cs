using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using GameFramework.Audio;
using GameFramework.HUD;
using GameFramework.Levels;
using GameFramework.Menus;
using GameFramework.PointSystem;
using GameFramework.Text;
using HelperFramework;
using TimerFramework;

namespace KraakjeRot
{
	public partial class MainPage : UserControl
	{
		private KeyHandler _keyHandler;

		private MenuEngine _menuEngine;
		private LevelEngine _levelEngine;
		private HudEngine _hudEngine;
		private ScoreEngine _scoreEngine;

		public static Player Player;
		public static List<GameFramework.NPCs.NPC> Npcs;

		private RenderNotifier _renderNotifier;
		private CompositionTargetGameLoop _mainLoop;

		public MainPage()
		{
			InitializeComponent();

			SoundPlayer.FillDictionary(App.Current.Resources.MergedDictionaries[0]);
			SoundPlayer.BackgroundMusic.FillBgDictionary(App.Current.Resources.MergedDictionaries[1]);
			TextHandler.FillDictionary(App.Current.Resources.MergedDictionaries[2]);

			this.GotFocus += MainPageGotFocus;
			this.LostFocus += MainPageLostFocus;

			_keyHandler = new KeyHandler(this);

			_menuEngine = new MenuEngine(this.gameSurface);
			_menuEngine.Updated += MenuEngineUpdated;
			_levelEngine = new LevelEngine(new Canvas());
			_levelEngine.Renewed += LevelEngineRenewed;
			_hudEngine = new HudEngine(new Canvas());
			_scoreEngine = new ScoreEngine(new Canvas(), 10);

			Level.Player = Player = new Player();

			_renderNotifier = new RenderNotifier(this);
			_renderNotifier.AddObservedChild(this.gameSurface);
			_renderNotifier.RenderComplete += RenderNotifierRenderComplete;

			_mainLoop = new CompositionTargetGameLoop();
			_mainLoop.Update += MainLoopUpdate;
		}


		#region Events;
		void RenderNotifierRenderComplete(object sender)
		{
			_hudEngine.Add<HudElement>(new HUD.LifeGauge(100),
									   new HUD.CurrentWeapon(),
									   new HUD.CountDownTimer());

			_levelEngine.Add<Level>(new Levels.Level1()/*,
								   new Levels.Level2(),
								   new Levels.Level3()*/);

			_levelEngine.Container.Clip = new RectangleGeometry { Rect = new Rect(0, 0, 1600, 1200) };

			_menuEngine.Add<Menu>(new Menus.IntroductionScreen(),
								  new Menus.ChooseSideScreen(),
								  new Menus.CreditsScreen(),
								  new Menus.HelpScreen(),
								  new Menus.LevelHolder(_levelEngine, _hudEngine, _scoreEngine),
								  new Menus.HighScoresScreen(),
								  new Menus.EndScreen());

			_menuEngine.Show();
		}

		void LevelEngineRenewed(object sender)
		{
			_levelEngine.Renew<Level>(new Levels.Level1()/*,
									 //new Levels.Level2(),
									// new Levels.Level3()*/);

			_levelEngine.CurrentIndex = 0;

			Level.Player.Revive();
			Level.Player = Player = new Player();

			_menuEngine.GetElement<Menus.LevelHolder>().ConnectPlayer();
		}

		void MenuEngineUpdated(object sender, Menu menu)
		{
			if (menu.GetType() == typeof(Menus.IntroductionScreen))  // IntroductionScreen;
			{
				if (_keyHandler.IsKeyPressed(Key.S) || _keyHandler.IsKeyPressed(Key.D1))
				{
					((Menus.IntroductionScreen)menu).GotoChooseSideScreen();
				}
				else if (_keyHandler.IsKeyPressed(Key.H) || _keyHandler.IsKeyPressed(Key.D2))
				{
					((Menus.IntroductionScreen)menu).GotoHelpScreen();
				}
				else if (_keyHandler.IsKeyPressed(Key.C) || _keyHandler.IsKeyPressed(Key.D3))
				{
					((Menus.IntroductionScreen)menu).GotoCreditsScreen();
				}
				_keyHandler.ClearKeyPresses();
			}
			else if (menu.GetType() == typeof(Menus.ChooseSideScreen))  // ChooseSideScreen;
			{
				if (_keyHandler.IsKeyPressed(Key.M) || _keyHandler.IsKeyPressed(Key.D1))
				{
					((Menus.ChooseSideScreen)menu).GotoMe();
				}
				else if (_keyHandler.IsKeyPressed(Key.K) || _keyHandler.IsKeyPressed(Key.D2))
				{
					((Menus.ChooseSideScreen)menu).GotoKraker();
				}
				_keyHandler.ClearKeyPresses();
			}
			else if (menu.GetType() == typeof(Menus.HelpScreen))  // HelpMenu;
			{
				if (_keyHandler.IsKeyPressed(Key.Home) || _keyHandler.IsKeyPressed(Key.D1))
				{
					((Menus.HelpScreen)menu).GotoBack();
				}
			}
			else if (menu.GetType() == typeof(Menus.CreditsScreen))  // CreditsScreen;
			{
			}
			else if (menu.GetType() == typeof(Menus.LevelHolder))  // LevelHolder;
			{
				if (Player.Dead) return;  // there's no need to use the keys when player is dead;

				Boolean left = _keyHandler.IsKeyPressed(Key.A),
						right = _keyHandler.IsKeyPressed(Key.D);
				if (!(left && right))
				{
					if (left)  // move left;
						Player.Movement.Left();
					else if (right)  // move right;
						Player.Movement.Right();
				}

				Boolean jump = _keyHandler.IsKeyPressed(Key.W) || _keyHandler.IsKeyPressed(Key.Ctrl),
						duck = _keyHandler.IsKeyPressed(Key.S) || _keyHandler.IsKeyPressed(Key.Shift);
				if (!(jump && duck))
				{
					if (jump)  // jump;
						Player.Movement.Jump();
					else if (duck)  // duck;
						Player.Movement.Duck();
				}

				Boolean aimleft = _keyHandler.IsKeyPressed(Key.Left),
						aimright = _keyHandler.IsKeyPressed(Key.Right);
				if (!(aimleft && aimright))
				{
					if (aimleft)  // aim left;
						Player.WeaponEngine.CurrentWeapon.ProjectoryAngle -= 2;
					else if (aimright)  // aim right;
						Player.WeaponEngine.CurrentWeapon.ProjectoryAngle += 2;
				}

				Boolean next = _keyHandler.IsKeyPressed(Key.Down) || _keyHandler.IsKeyPressed(Key.Q),
						prev = _keyHandler.IsKeyPressed(Key.Up) || _keyHandler.IsKeyPressed(Key.E);
				if (!(next && prev))
				{
					if (next)  // change next weapon;
					{
						Player.ShuffleWeaponDown();
						_keyHandler.ClearKeyPresses(Key.Down);
						_keyHandler.ClearKeyPresses(Key.Q);
					}
					else if (prev)  // change previous weapon;
					{
						Player.ShuffleWeaponUp();
						_keyHandler.ClearKeyPresses(Key.Up);
						_keyHandler.ClearKeyPresses(Key.E);
					}
				}

				if (_keyHandler.IsKeyPressed(Key.Space))  // shoot;
				{  // todo: remove key.z and fix space commit;
					Player.Fire();
					//_keyHandler.ClearKeyPresses(Key.Space);
				}
			}
			else if (menu.GetType() == typeof(Menus.HighScoresScreen))  // HighScoresScreen;
			{

			}
			else if (menu.GetType() == typeof(Menus.EndScreen))  // EndScreen;
			{
				_keyHandler.ClearKeyPresses();
			}
		}

		void MainPageGotFocus(object sender, RoutedEventArgs e)
		{
			_mainLoop.Start();
			SoundPlayer.BackgroundMusic.Start();
		}

		void MainPageLostFocus(object sender, RoutedEventArgs e)
		{
			_mainLoop.Stop();
			SoundPlayer.BackgroundMusic.Pauze();
		}
		#endregion Events;

		#region Loops;
		void MainLoopUpdate(object sender, TimeSpan elapsed)
		{
			_levelEngine.Update(elapsed);

			_menuEngine.Update(elapsed);

			_hudEngine.Update(elapsed);
		}
		#endregion Loops;

	}
}