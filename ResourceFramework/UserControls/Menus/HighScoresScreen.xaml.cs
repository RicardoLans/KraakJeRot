using System;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Media;
using GameFramework.PointSystem;

namespace ResourceFramework.UserControls.Menus
{
	public partial class HighScoresScreen : UserControl
	{
		public ObservableCollection<Score> ScoresTop = new ObservableCollection<Score> {	
			new Score { Background = Colors.Green,	Country	= "The Netherlands", Name = "Henk",	Ranking = 1, TotalPoints = 945418, Date = new DateTime(2010,12,20)}, 
			new Score { Background = Colors.Green, 	Country	= "The Netherlands", Name = "Onno", Ranking = 2, TotalPoints = 942351, Date = new DateTime(2010,12,04)},
			new Score { Background = Colors.Green,  Country	= "Deutschland",	 Name = "Sjaak",Ranking = 3, TotalPoints = 910354, Date = new DateTime(2010,12,03)},
			new Score { Background = Colors.Orange,	Country	= "Japan",			 Name = "Jan", 	Ranking = 4, TotalPoints = 754520, Date = new DateTime(2010,01,02)},
		};

		public ObservableCollection<Score> ScoresRest = new ObservableCollection<Score> {	
			new Score { Background = Colors.Orange,	Country = "The Netherlands", Name = "Pietje", 	Ranking = 5, TotalPoints = 653842, Date = new DateTime(2010,12,27)},
			new Score { Background = Colors.Orange, Country = "USA",			  Name = "Ricardo", Ranking = 6, TotalPoints = 545265, Date = new DateTime(2010,12,18)},
			new Score { Background = Colors.Orange, Country = "The Netherlands",  Name = "Klaas", 	Ranking = 7, TotalPoints = 525241, Date = new DateTime(2010,12,28)},
			new Score { Background = Colors.Orange, Country = "Italy",			  Name = "Koen", 	Ranking = 8, TotalPoints = 252545, Date = new DateTime(2010,12,12)},
		};

		public HighScoresScreen()
		{
			InitializeComponent();

			lstTo5.ItemsSource = ScoresTop;
			lstTo10.ItemsSource = ScoresRest;
		}
	}
}