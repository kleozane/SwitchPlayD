namespace SwitchPlayD.Data
{
	public class StudioCategory
	{
		public int StudioId { get; set; }
		public int CategoryId { get; set; }

		public virtual Studio Studio { get; set; }
		public virtual Category Category { get; set; }
	}
}
