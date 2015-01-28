using System.Windows.Browser;

namespace HelperFramework
{
	public static class Screen
	{
		private static bool _isNavigator = HtmlPage.BrowserInformation.Name.Contains("Netscape");

		public static double ScreenWidth
		{
			get
			{
				return _isNavigator ? (double)HtmlPage.Window.GetProperty("innerWidth") : (double)HtmlPage.Document.Body.GetProperty("clientWidth");
			}
		}

		public static double ScreenHeight
		{
			get
			{
				return _isNavigator ? (double)HtmlPage.Window.GetProperty("innerHeight")
					: (double)HtmlPage.Document.Body.GetProperty("clientHeight");
			}
		}

		public static double ScreenResolutionWidth
		{
			get
			{
				return (double)HtmlPage.Window.Eval("screen.width");
			}
		}

		public static double ScreenResolutionHeight
		{
			get
			{
				return (double)HtmlPage.Window.Eval("screen.height");
			}
		}



	}
}
