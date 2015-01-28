using System;
using System.Collections.Generic;

namespace GameFramework.NPCs.AI
{
	public class AIEngine
	{
		private Boolean _started = false;
		private Boolean _destroyed = false;

		public List<Action> Actions = new List<Action>();

		public AIEngine() { }

		public virtual void Update(TimeSpan elapsed)
		{
			if (_started && !_destroyed)
			{
				Actions.ForEach(action => action.Update(elapsed));
			}
		}

		public virtual void Start()
		{
			_started = true;
			Actions.ForEach(action => action.Start());
		}

		public virtual void Destroy()
		{
			_destroyed = true;
			Actions.ForEach(action => action.Destroy());
		}
	}
}
