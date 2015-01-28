using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace GameFramework.HUD
{
	public class Flipper : UserControl
	{
		public Storyboard Storyboard1 { get; set; }
		public Border LayoutRoot { get; set; }

		public TextBlock textBlockBottom { get; set; }
		public TextBlock textBlockFlipBottom { get; set; }
		public TextBlock textBlockTop { get; set; }
		public TextBlock textBlockFlipTop { get; set; }

		public TextBlock text1 { get; set; }
		public TextBlock text2 { get; set; }

		public Flipper(UserControl cntrl)
		{
			Content = cntrl;

			Storyboard1 = (Storyboard)cntrl.FindName("Storyboard1");
			textBlockBottom = (TextBlock)cntrl.FindName("textBlockBottom");
			textBlockFlipTop = (TextBlock)cntrl.FindName("textBlockFlipTop");
			textBlockFlipBottom = (TextBlock)cntrl.FindName("textBlockFlipBottom");
			textBlockTop = (TextBlock)cntrl.FindName("textBlockTop");
			LayoutRoot = (Border)cntrl.FindName("LayoutRoot");
		}
		#region Text1 Dependency Property

		/// <summary> 
		/// Get or Sets the Text1 dependency property.  
		/// </summary> 
		public string Text1
		{
			get { return (string)GetValue(Text1Property); }
			set { SetValue(Text1Property, value); }
		}

		/// <summary> 
		/// Identifies the Text1 dependency property. This enables animation, styling, binding, etc...
		/// </summary> 
		public static readonly DependencyProperty Text1Property =
			DependencyProperty.Register("Text1",
										typeof(string),
										typeof(Flipper),
										new PropertyMetadata("00", OnText1PropertyChanged));

		/// <summary>
		/// Text1 changed handler. 
		/// </summary>
		/// <param name="d">MainPage that changed its Text1.</param>
		/// <param name="e">DependencyPropertyChangedEventArgs.</param> 
		private static void OnText1PropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			var mainPage = d as Flipper;
			if (mainPage != null)
				mainPage.textBlockBottom.Text = mainPage.textBlockFlipTop.Text = (string)e.NewValue;
		}

		#endregion Text1 Dependency Property


		#region Text2 Dependency Property

		/// <summary> 
		/// Get or Sets the Text2 dependency property.  
		/// </summary> 
		public string Text2
		{
			get { return (string)GetValue(Text2Property); }
			set { SetValue(Text2Property, value); }
		}

		/// <summary> 
		/// Identifies the Text2 dependency property. This enables animation, styling, binding, etc...
		/// </summary> 
		public static readonly DependencyProperty Text2Property =
			DependencyProperty.Register("Text2",
										typeof(string),
										typeof(Flipper),
										new PropertyMetadata("01", OnText2PropertyChanged));

		/// <summary>
		/// Text2 changed handler. 
		/// </summary>
		/// <param name="d">MainPage that changed its Text2.</param>
		/// <param name="e">DependencyPropertyChangedEventArgs.</param> 
		private static void OnText2PropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			var mainPage = d as Flipper;
			if (mainPage != null)
				mainPage.textBlockTop.Text = mainPage.textBlockFlipBottom.Text = (string)e.NewValue;
		}

		#endregion Text2 Dependency Property


		public void Flip(string text1, string text2)
		{
			Text1 = text1;
			Text2 = text2;
			Storyboard1.Begin();
		}
	}
}
