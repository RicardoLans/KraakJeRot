using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace ResourceFramework.UserControls.Additional
{
	public partial class SignPost : UserControl
	{
		public SignPost()
		{
			InitializeComponent();
		}

		private string _signText = "temp";
		public string SignText { get { return _signText; } set { txtSign.Text = _signText = value; } }



	}
}