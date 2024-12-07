namespace SwitchPlayD.Data
{
	public class GamePlatform
	{
		public int GameId { get; set; }
		public int PlatformId { get; set; }

		public virtual Game Game { get; set; }
		public virtual Platform Platform { get; set; }
	}
}
