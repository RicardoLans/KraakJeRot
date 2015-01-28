using System;

namespace TimerFramework
{
	public abstract class GameLoop
	{
		protected DateTime LastTick;

		public delegate void UpdateHandler(object sender, TimeSpan elapsed);
		public event UpdateHandler Update;

		public void Tick()
		{
			if (Active)
			{
				DateTime now = DateTime.Now;
				TimeSpan elapsed = now - LastTick;
				LastTick = now;
				if (Update != null) Update(this, elapsed);
			}
		}

		public Boolean FirstTickToo { get; set; }

		public Boolean Active { get; set; }

		public virtual void Start()
		{
			Active = true;
			LastTick = DateTime.Now;
			if (FirstTickToo) Tick();
		}

		public virtual void Stop()
		{
			Active = false;
		}
	}
}