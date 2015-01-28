using System;

namespace GameFramework.NPCs.AI
{
	public class Action
	{
		private readonly Random _rand = new Random();
		private DateTime _timer;
		private Boolean _destroyed = false;
		private Boolean _started = false;

		public Int32 StartTime { get; set; }
		public Int32 EndTime { get; set; }

		public Action(Int32 start, Int32 end)
		{
			StartTime = start;
			EndTime = end;
		}
		public Action(Int32 end)
		{
			StartTime = 999;
			EndTime = end;
			_timer = DateTime.Now.AddMilliseconds(_rand.Next(end));
		}

		public void Start()
		{
			_timer = DateTime.Now.AddMilliseconds(_rand.Next(StartTime, EndTime));
			_started = true;
		}

		public delegate void OnAction(object sender);
		public event OnAction onAction;

		public virtual void Update(TimeSpan elapsed)
		{
			if (!_destroyed && _started)
			{
				if (_timer < DateTime.Now)
				{
					if (onAction != null)
					{
						onAction(this);
						_timer = DateTime.Now.AddMilliseconds(_rand.Next(StartTime, EndTime));
					}
				}
			}
		}

		public virtual void Destroy()
		{
			_destroyed = true;
		}
	}
}
