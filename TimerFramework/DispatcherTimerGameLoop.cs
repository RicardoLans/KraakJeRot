using System;
using System.Windows.Threading;

namespace TimerFramework
{
	public class DispatcherTimerGameLoop : GameLoop
	{
		private DispatcherTimer _timer;

		public DispatcherTimerGameLoop() : this(0) { }

		public DispatcherTimerGameLoop(double milliseconds)
		{
			_timer = new DispatcherTimer
						{
							Interval = TimeSpan.FromMilliseconds(milliseconds)
						};
			_timer.Tick += Tick;
		}

		public override void Start()
		{
			_timer.Start();
			base.Start();
		}

		public override void Stop()
		{
			_timer.Stop();
			base.Stop();
		}

		void Tick(object sender, EventArgs e)
		{
			base.Tick();
		}
	}
}