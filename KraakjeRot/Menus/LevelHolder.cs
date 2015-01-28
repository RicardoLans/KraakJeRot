using System;
using System.Windows.Controls;
using GameFramework.Audio;
using GameFramework.HUD;
using GameFramework.Levels;
using GameFramework.Menus;
using GameFramework.PointSystem;
using HelperFramework;

namespace KraakjeRot.Menus
{
	public class LevelHolder : Menu
	{
		private static ResourceFramework.UserControls.Menus.LevelHolder _menu = new ResourceFramework.UserControls.Menus.LevelHolder();

		private LevelEngine _levelEngine;
		private HudEngine _hudEngine;
		private ScoreEngine _scoreEngine;

		private Canvas _levelSurface;
		private Canvas _hudSurface;

		public LevelHolder(LevelEngine levelEngine, HudEngine hudEngine, ScoreEngine scoreEngine)
			: base(_menu)
		{
			if (levelEngine == null) throw new ArgumentNullException("No LevelEngine defined!");
			_levelEngine = levelEngine;
			_levelEngine.Started += LevelEngineStarted;
			_levelEngine.BeforeNextLevel += LevelEngineBeforeNextLevel;
			_levelEngine.Finished += LevelEngineFinished;

			if (hudEngine == null) throw new ArgumentNullException("No HudEngine defined!");
			_hudEngine = hudEngine;
			_hudEngine.TimesUp += TimesUp;

			if (scoreEngine == null) throw new ArgumentNullException("No ScoreEngine defined!");
			_scoreEngine = scoreEngine;

			ConnectPlayer();

			_levelSurface = _menu.FindName("levelSurface") as Canvas;
			if (_levelSurface == null) throw new NotImplementedException("levelSurface canvas not implemented");
			_levelSurface.Children.Add(_levelEngine.Container);

			_hudSurface = _menu.FindName("hudSurface") as Canvas;
			if (_hudSurface == null) throw new NotImplementedException("hudSurface canvas not implemented");
			_hudSurface.Children.Add(_hudEngine.Container);

			this.Shown += LevelHolderShown;
		}

		public void ConnectPlayer()
		{
			Level.Player.WeaponShuffle += PlayerWeaponShuffle;
			Level.Player.IsHit += PlayerIsHit;
			Level.Player.Died += PlayerDied;
			Level.Player.Revived += PlayerRevived;
		}


		private void LevelHolderShown(object sender)
		{
			_levelEngine.Renew();
			_levelEngine.Show(0);
		}

		private void LevelEngineStarted(object sender)
		{
			UpdateHudOnNextLevel();
			_scoreEngine.CurrentLevel = _levelEngine.GetCurrentLevel();
		}
		private void LevelEngineBeforeNextLevel(object sender)
		{
			UpdateScoreOnNextLevel();
			UpdateHudOnNextLevel();
			SoundPlayer.PlaySound("applause");
		}
		private void LevelEngineFinished(object sender)
		{
			Win();
		}


		private void TimesUp(object sender)
		{
			// This will only work when the page has focus....
			// Else the update function will not be triggered, because the countdowntimer works with a timer not update function 
			Lose();
		}


		private void UpdateHudOnNextLevel()
		{
			var gauge = _hudEngine.GetElement<LifeGauge>();
			gauge.ResetLife();

			_hudEngine.Timert.StopTimer();
			_hudEngine.Timert.CountDownDate = DateTime.Now.AddSeconds(_levelEngine.GetCurrentLevel().PlayTime);
			_hudEngine.Timert.StartTimer();
		}
		private void UpdateScoreOnNextLevel()
		{
			_scoreEngine.CreatePointsBasedOnTimeLeft(_hudEngine.GetElement<CountDownTimer>().SecondsLeft);
			_scoreEngine.ToNextLevel(_levelEngine.GetCurrentLevel(), Level.Player, Level.Player.HealthPoints);
		}


		private void PlayerWeaponShuffle(object sender)
		{
			var weapon = _hudEngine.GetElement<CurrentWeapon>();
			weapon.Weapon = Level.Player.WeaponEngine.CurrentWeapon;
		}
		private void PlayerIsHit(object sender)
		{
			var gauge = _hudEngine.GetElement<LifeGauge>();
			gauge.CurrentLife = Level.Player.HealthPoints;
			gauge.Update();
		}
		private void PlayerDied(object sender)
		{
			Lose();
		}
		private void PlayerRevived(object sender)
		{
			var gauge = _hudEngine.GetElement<LifeGauge>();
			gauge.CurrentLife = Level.Player.HealthPoints;
			gauge.Update();
		}



		private void Win()
		{
			var score = _scoreEngine.CurrentPoints;
			var endScreen = MenuEngineReference.GetElement<EndScreen>();
			endScreen.SetWinScore(score);
			MenuEngineReference.Show<EndScreen>();
			_scoreEngine.CurrentPoints = 0;
		}
		private void Lose()
		{
			UpdateScoreOnNextLevel();

			SoundPlayer.PlaySound("failure");
			var score = _scoreEngine.CurrentPoints;
			var endScreen = MenuEngineReference.GetElement<EndScreen>();
			endScreen.SetLoseScore(score);
			TimeOut.SetTimeout(3000, () =>
			{
				MenuEngineReference.Show<EndScreen>();
				_scoreEngine.CurrentPoints = 0;
			});
		}
	}
}