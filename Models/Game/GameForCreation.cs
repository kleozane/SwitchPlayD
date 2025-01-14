using System.ComponentModel.DataAnnotations;

namespace SwitchPlayD.Models.Game
{
	public class GameForCreation
	{
		[Required(ErrorMessage = "Title cannot be empty!")]
		public string Title { get; set; }

		[Required(ErrorMessage = "Description cannot be empty!")]
		public string Description { get; set; }

        [Required(ErrorMessage = "Magnet link cannot be empty!")]
        public string MagnetLink { get; set; }

        [Required(ErrorMessage = "Size cannot be empty!")]
		public double Size { get; set; }

		[Required(ErrorMessage = "Date cannot be empty!")]
		public string PublishDate { get; set; }

		[Required(ErrorMessage = "Price cannot be empty!")]
		public double Price { get; set; }

		[Required(ErrorMessage = "Poster cannot be empty!")]
		public string? Poster { get; set; }

        public double? Discount { get; set; }

        public virtual IEnumerable<Data.Category> Categories { get; set; }
		public List<int> CategoryIds { get; set; }

		public virtual IEnumerable<Data.Platform> Platforms { get; set; }
		public List<int> PlatformIds { get; set; }

		public virtual IEnumerable<Data.Studio> Studios { get; set; }
		public int StudioId { get; set; }
	}
}
