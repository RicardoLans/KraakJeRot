using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using GameFramework.Levels;
using GameFramework.NPCs;

namespace GameFramework.PointSystem
{
	public class ScoreEngine : Engine
	{
		public ScoreEngine(Canvas canvas, int handicap, int highScoreMax = 20)
			: base(canvas)
		{
			Handicap = handicap;
			HighScoreRankingMax = highScoreMax;
		}

		public Level CurrentLevel { get; set; }
		public NPC Player { get; set; }
		public int Handicap { get; set; }
		public Score Score { get; set; }
		public int HighScoreRankingMax { get; set; }

		private int _points;
		public int CurrentPoints
		{
			get { return _points; }
			set
			{
				if ((_points + value) >= int.MaxValue) return;
				_points = value;
				if (_points < 0) _points = 0;
			}
		}

		public void AddPoints(int pointvalue)
		{
			CurrentPoints += pointvalue - Handicap;
		}

		public void DecreasePoints(int pointvalue)
		{
			CurrentPoints -= pointvalue;
		}

		public void CreateCollisionPoints(Weapons.Weapon weapon) { }

		public void CreatePointsBasedOnTimeLeft(int secondsLeft)
		{
			AddPoints(secondsLeft * CurrentLevel.Number * 3681);
		}

		public void CreatePointsBasedOnLifeLeft(int lifeLeft)
		{
			AddPoints(lifeLeft + 10 * CurrentLevel.Number * 52);
		}

		public void CreatePointsBasedOnLivesLeft(int lives)
		{
			AddPoints(lives * CurrentLevel.Number * 7854);
		}

		public void CreatePointsKillEnemy(NPC enemy, Weapons.Weapon weapon)
		{
			AddPoints(enemy.PointValue * CurrentLevel.Number * 525);
		}

		public void PlayersDeath()
		{
			DecreasePoints(Player.PointValue);
		}

		public void ToNextLevel(Level nextLevel, NPC newPlayer, int lifeLeft, int livesLeft = 3)
		{
			CreatePointsBasedOnLifeLeft(lifeLeft);
			CreatePointsBasedOnLivesLeft(livesLeft);

			CurrentLevel = nextLevel;
			Player = newPlayer;
		}

		public Score SetScore(string name, string country = "Unkown")
		{
			Score = new Score { Date = DateTime.Now, Country = country, IsHighScore = false, Name = name, TotalPoints = CurrentPoints };
			CheckHighScore(Score);
			return Score;
		}

		public void CheckHighScore(Score score)
		{
			List<Score> allScores = GetAllScores();
			allScores.Add(Score);
			allScores.OrderBy(s => s.TotalPoints);
			int currentPlace = allScores.IndexOf(Score);

			if (currentPlace <= HighScoreRankingMax)
				score.IsHighScore = true;
		}

		public void SaveScore(Score score)
		{
			var scores = GetAllScores();
			scores.Add(score);
			//Todo: serialize back into something.....
		}


		public List<Score> GetAllScores()
		{
			//Todo: serialize from somewhere.....
			return new List<Score>();
		}

	}
}
