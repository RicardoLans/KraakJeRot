using System;
using System.Windows;
using System.Windows.Controls;

namespace KraakjeRot.HUD
{
	public class CountDownTimer : GameFramework.HUD.CountDownTimer
	{
		private static ResourceFramework.UserControls.HUD.CountDownTimer timer = new ResourceFramework.UserControls.HUD.CountDownTimer();

		public CountDownTimer()
			: base(timer)
		{
			LayoutRoot = (Grid)timer.FindName("LayoutRoot");

			FlipMinutes = new Flipper { Text1 = "00", Text2 = "01", Name = "FlipMinutes", Margin = new Thickness(0, 0, 0, 0) };
			FlipSeconds = new Flipper { Text1 = "00", Text2 = "01", Name = "FlipSeconds", Margin = new Thickness(1, 0, 0, 0) };

			Grid.SetColumn(FlipSeconds, 2);
			Grid.SetRow(FlipSeconds, 1);
			Grid.SetColumn(FlipMinutes, 1);
			Grid.SetRow(FlipMinutes, 1);

			LayoutRoot.Children.Add(FlipSeconds);
			LayoutRoot.Children.Add(FlipMinutes);

			_tellerS = 0;
			_tellerM = 0;

			UpdateClock();

			_timer.Interval = new TimeSpan(0, 0, 1);
			_timer.Tick += TimerTick;
		}
	}
}
