using System;
using System.Windows.Media;

namespace TimerFramework
{
	public class CompositionTargetGameLoop : GameLoop
	{
		public CompositionTargetGameLoop() { }

		void CompositionTargetRendering(object sender, EventArgs e)
		{
			base.Tick();
		}

		public override void Start()
		{
			CompositionTarget.Rendering += CompositionTargetRendering;
			base.Start();
		}

		public override void Stop()
		{
			CompositionTarget.Rendering -= CompositionTargetRendering;
			base.Stop();
		}
	}
}