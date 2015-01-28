using System;
using System.Windows.Controls;

namespace GameFramework.HUD
{
	public class LifeGauge : HudElement
	{
		public double Maxwidth { get; set; }
		public int MaxLife { get; set; }

		private int _currentLife;
		public int CurrentLife
		{
			get
			{
				if (_currentLife < 1)
				{
					_currentLife = 0;
					IsDead = true;
				}

				if (_currentLife >= MaxLife)
				{
					_currentLife = MaxLife;
				}
				return _currentLife;
			}
			set { _currentLife = value; }
		}

		public bool IsDead { get; set; }

		public Border LifeIndicator;

		public LifeGauge(UserControl control)
			: base(control)
		{
		}

		public override void Update()
		{
			LifeIndicator.Width = Maxwidth * CurrentLife / 100.0;
		}

		public void AddLife(int number)
		{
			CurrentLife = CurrentLife + number;
			Update();
		}

		public void SubstractLife(int number)
		{
			CurrentLife = CurrentLife - number;
			Update();
		}

		public void ResetLife()
		{
			CurrentLife = MaxLife;
			Update();
		}


	}
}
