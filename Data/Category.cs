namespace SwitchPlayD.Data
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

		public ICollection<StudioCategory> StudioCategories { get; set; }
		public ICollection<GameCategory> GameCategories { get; set; }
	}
}
