namespace KraakjeRot
{
	public class Player : ME
	{
		public int DeathPoints { get; set; }
		public int LifesLeft { get; set; }

		public Player(int lifes = 4)
		{
			LifesLeft = lifes;
			HealthPoints = 100;
		}
	}
}
