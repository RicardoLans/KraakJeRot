using System.Windows.Controls;

namespace GameFramework.HUD
{
	public class HudElement : UserControl
	{
		public HudElement(UserControl control)
		{
			this.Content = control;
		}

		public virtual void Update() { }
	}
}
