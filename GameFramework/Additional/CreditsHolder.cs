using System;
using System.Windows.Controls;
using System.Windows.Media;

namespace GameFramework.Additional
{
	public class CreditsHolder
	{
		public String Name { get; set; }
		public String Age { get; set; }
		public String City { get; set; }
		public String ShortStory { get; set; }
		public String ProjectInput { get; set; }

		public String WebsiteName { get; set; }
		public String WebsiteUrl { get; set; }

		public ImageBrush ImgBrush { get; set; }
		public ImageBrush ImgBrushBig { get; set; }
		public String ImgSmallString { get; set; }
		public String ImgBigString { get; set; }
		public Button CreditButton { get; set; }
	}
}
