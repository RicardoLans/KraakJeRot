using System;
using System.Windows.Controls;
using System.Windows.Threading;

namespace GameFramework.HUD
{
	public class CountDownTimer : HudElement
	{
		public bool IsFinished { get; set; }

		public Grid LayoutRoot;
		public Flipper FlipSeconds;
		public Flipper FlipMinutes;
		public Boolean TimeIsUp { get; set; }

		public const string formatStringHMS = "00";

		public DispatcherTimer _timer = new DispatcherTimer();
		public int _tellerS = 3;
		public int _tellerM = 1;

		public int _direction;
		public DateTime _countDownDate;

		public int SecondsLeft
		{
			get
			{
				TimeSpan span = _countDownDate - DateTime.Now;
				return (span.Seconds + (span.Minutes * 60));
			}
		}

		public CountDownTimer(UserControl control)
			: base(control)
		{
			LayoutRoot = (Grid)control.FindName("LayoutRoot");
		}


		public void StartTimer()
		{
			IsFinished = TimeIsUp = false; //todo: is this gooowd?
			if (!System.ComponentModel.DesignerProperties.GetIsInDesignMode(this))
			{
				_timer.Start();
			}
		}

		public void StopTimer()
		{
			_timer.Stop();
		}

		private int Direction
		{
			get { return _direction; }
			set { _direction = value; }
		}

		public DateTime CountDownDate
		{
			get { return _countDownDate; }
			set
			{
				_countDownDate = value;
				Direction = -1;

				if (CountDownDate > DateTime.Now)
				{
					var ts = CountDownDate - DateTime.Now;
					_tellerS = ts.Seconds;
					_tellerM = ts.Minutes;
				}
				else
				{
					_tellerS = 0;
					_tellerM = 0;
					_timer.Stop();
				}
				UpdateClock();
			}
		}

		public void UpdateClock()
		{
			LayoutRoot.ColumnDefinitions[1].Width = LayoutRoot.ColumnDefinitions[2].Width;

			FlipSeconds.Text1 = _tellerS.ToString(formatStringHMS);
			FlipMinutes.Text1 = _tellerM.ToString(formatStringHMS);
		}

		private int Top(int v)
		{
			return Direction > 0 ? v : 0;
		}

		private int Bottom(int v)
		{
			return Direction < 0 ? v : 0;
		}

		public void TimerTick(object sender, EventArgs e)
		{
			if (_tellerS == Top(59))
			{
				if (Direction == -1 && _tellerM == 0)
				{
					TimeIsUp = true;
					IsFinished = true;
					StopTimer();
					return;
				}
				FlipSeconds.Flip(_tellerS.ToString(formatStringHMS), Bottom(59).ToString(formatStringHMS));
				_tellerS = Bottom(59);

				if (_tellerM == Top(59))
				{
					FlipMinutes.Flip(_tellerM.ToString(formatStringHMS), Bottom(59).ToString(formatStringHMS));
					_tellerM = 0;
				}
				else
				{
					FlipMinutes.Flip(_tellerM.ToString(formatStringHMS), (_tellerM + Direction).ToString(formatStringHMS));
					_tellerM += Direction;
				}
			}
			else
			{
				FlipSeconds.Flip(_tellerS.ToString(formatStringHMS), (_tellerS + Direction).ToString(formatStringHMS));
				_tellerS += Direction;
			}
		}

	}
}
