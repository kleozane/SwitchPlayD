using System.ComponentModel.DataAnnotations.Schema;

namespace SwitchPlayD.Data
{
	public class Game
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public string MagnetLink { get; set; }
		public double Size { get; set; }
		public DateTime PublishDate { get; set; }
		public double Price { get; set; }
		public string? Poster { get; set; }
		public double? Discount { get; set; }

		[ForeignKey("StudioId")]
		public int StudioId { get; set; }
		public virtual Studio Studio { get; set; }

		public ICollection<GameCategory> GameCategories { get; set; }
		public ICollection<GamePlatform> GamePlatforms { get; set; }
	}
}
