using System;
using System.Windows;
using System.Windows.Controls;

namespace GameFramework.Menus
{
	public class Menu : UserControl
	{
		public Menu(UserControl level)
		{
			Content = level;
		}

		public MenuEngine MenuEngineReference { set; get; }

		public void Show()
		{
			this.Visibility = Visibility.Visible;
			this.Focus();
			if (Shown != null)
			{
				Shown(this);
			}
		}

		public void Hide()
		{
			this.Visibility = Visibility.Collapsed;
			if (Hidden != null)
			{
				Hidden(this);
			}
		}

		public void Update(TimeSpan elapsed)
		{
			if (Updated != null)
			{
				Updated(this, elapsed);
			}
		}

		#region Events;
		public delegate void OnShown(object sender);
		public event OnShown Shown;

		public delegate void OnHidden(object sender);
		public event OnHidden Hidden;

		public delegate void OnUpdate(object sender, TimeSpan elapsed);
		public event OnUpdate Updated;
		#endregion Events;

	}
}
