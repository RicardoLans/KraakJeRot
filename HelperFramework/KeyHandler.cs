using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;

namespace HelperFramework
{
	public class KeyHandler
	{
		private Dictionary<Key, Boolean> isPressed = new Dictionary<Key, Boolean>();

		public KeyHandler(FrameworkElement target)
		{
			ClearKeyPresses();
			target.KeyDown += target_KeyDown;
			target.KeyUp += target_KeyUp;
			target.LostFocus += target_LostFocus;
		}

		public void ClearKeyPresses()
		{
			isPressed.Clear();
		}
		public void ClearKeyPresses(Key key)
		{
			isPressed.Remove(key);
		}

		public Boolean IsKeyPressed(Key k)
		{
			return isPressed.ContainsKey(k);
		}

		private void target_KeyDown(Object sender, KeyEventArgs e)
		{
			if (!isPressed.ContainsKey(e.Key))
			{
				isPressed.Add(e.Key, true);
			}
		}

		private void target_KeyUp(Object sender, KeyEventArgs e)
		{
			if (isPressed.ContainsKey(e.Key))
			{
				isPressed.Remove(e.Key);
			}
		}

		private void target_LostFocus(Object sender, RoutedEventArgs e)
		{
			ClearKeyPresses();
		}
	}
}
