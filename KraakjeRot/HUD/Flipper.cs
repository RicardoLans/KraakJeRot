using System.Windows;

namespace KraakjeRot.HUD
{
	public class Flipper : GameFramework.HUD.Flipper
	{
		public Flipper()
			: base(new ResourceFramework.UserControls.HUD.Flipper())
		{
			this.SizeChanged += Flipper_SizeChanged;
		}

		private void Flipper_SizeChanged(object sender, SizeChangedEventArgs e)
		{
			LayoutRoot.Height = this.ActualHeight;
		}
	}
}
