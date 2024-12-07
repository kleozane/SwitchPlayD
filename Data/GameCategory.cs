namespace SwitchPlayD.Data
{
	public class GameCategory
	{
		public int GameId { get; set; }
		public int CategoryId { get; set; }

		public virtual Game Game { get; set; }
		public virtual Category Category { get; set; }
	}
}
