using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace GameFramework.Additional
{
	public class HelpControlHolder : Button
	{

		private string _imgBigString;

		public Key Key { get; set; }
		public String KeyName { get; set; }
		public ImageBrush ImgBrushBig { get; set; }
		public int GridRow { get; set; }
		public int GridCol { get; set; }
		public int GridColWidth { get; set; }

		public String ImgString
		{
			get
			{
				return _imgBigString;
			}
			set
			{
				_imgBigString = value;
				var sourceBig = new ImageSourceConverter().ConvertFromString(ImgString) as ImageSource;
				ImgBrushBig = new ImageBrush { ImageSource = sourceBig };
			}
		}
		
		public HelpControlHolder()
		{
			Width = base.Width;
			Height = base.Height;
			GridColWidth = 1;
		}

	}
}
