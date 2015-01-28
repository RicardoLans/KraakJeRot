using System;
using System.Windows.Media;

namespace GameFramework.PointSystem
{
	public class Score
	{
		public String Name { get; set; }
		public String Country { get; set; }
		public Int32 TotalPoints { get; set; }
		
		public DateTime Date { get; set; }
		public Boolean IsHighScore { get; set; }
		public Int32 Ranking { get; set; }
		public Color Background { get; set; }
	}
}
