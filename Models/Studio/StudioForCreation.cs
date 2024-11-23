using System.ComponentModel.DataAnnotations;

namespace SwitchPlayD.Models.Studio
{
	public class StudioForCreation
	{
		[Required(ErrorMessage = "Name cannot be empty!")]
		public string Name { get; set; }

		[Required(ErrorMessage = "Description cannot be empty!")]
		public string Description { get; set; }

		public string? Logo { get; set; }

		public virtual IEnumerable<Data.Category> Categories { get; set; }
	}
}
