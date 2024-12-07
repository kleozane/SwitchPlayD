namespace SwitchPlayD.Data
{
	public class Studio
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public string? Logo { get; set; }

		public ICollection<StudioCategory> StudioCategories { get; set; }
		public ICollection<Game> Games { get; set; }
	}
}
