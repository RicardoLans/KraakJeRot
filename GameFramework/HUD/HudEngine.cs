using System;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Media;
using HelperFramework;

namespace GameFramework.HUD
{
	public class HudEngine : Engine
	{
		private ScaleTransform _scaleTransform = new ScaleTransform();

		private CountDownTimer _timer;
		public CountDownTimer Timert
		{
			get { return _timer ?? (_timer = GetList<HudElement>().OfType<CountDownTimer>().FirstOrDefault()); }
		}

		public HudEngine(Canvas canvas)
			: base(canvas, new StackPanel { Orientation = Orientation.Horizontal })
		{
			canvas.RenderTransform = _scaleTransform;
		}

		public override void OnResize()
		{
			//base.OnResize();  // can't use base.OnResize() here, as it will size the stackpanel !!!
			_scaleTransform.ScaleX = Screen.ScreenWidth / Screen.ScreenResolutionWidth;
			_scaleTransform.ScaleY = Screen.ScreenHeight / Screen.ScreenResolutionHeight;
		}

		public override void Update(TimeSpan elapsed)
		{
			if (Timert.TimeIsUp)
			{
				TimesUp(this);
				Timert.TimeIsUp = false;
			}
			GetList<HudElement>().ForEach(hud => hud.Update());
		}

		public delegate void TimeUp(object sender);
		public event TimeUp TimesUp;
	}
}