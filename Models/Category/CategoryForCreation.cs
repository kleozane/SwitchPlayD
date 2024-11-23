using System.ComponentModel.DataAnnotations;

namespace SwitchPlayD.Models.Category
{
    public class CategoryForCreation
    {
        [Required(ErrorMessage = "Name cannot be empty!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Description cannot be empty!")]
        public string Description { get; set; }
    }
}
