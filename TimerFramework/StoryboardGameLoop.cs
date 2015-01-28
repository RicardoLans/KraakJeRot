using System;
using System.Windows;
using System.Windows.Media.Animation;

namespace TimerFramework
{
	public class StoryboardGameLoop : GameLoop
	{
		private Boolean _stopped = true;
		private Storyboard _gameLoop = new Storyboard();

		public StoryboardGameLoop(FrameworkElement parent) : this(parent, 0) { }

		public StoryboardGameLoop(FrameworkElement parent, Double milliseconds)
		{
			_gameLoop.Duration = TimeSpan.FromMilliseconds(milliseconds);
			_gameLoop.SetValue(FrameworkElement.NameProperty, "gameloop");
			parent.Resources.Add("mainLoop", _gameLoop);
			_gameLoop.Completed += new EventHandler(GameLoopCompleted);
		}

		public override void Start()
		{
			_stopped = false;
			_gameLoop.Begin();
			base.Start();
		}

		public override void Stop()
		{
			_stopped = true;
			base.Stop();
		}

		void GameLoopCompleted(object sender, EventArgs e)
		{
			if (_stopped) return;
			base.Tick();
			Storyboard storyboard = sender as Storyboard;
			if (storyboard != null) storyboard.Begin();
		}
	}
}