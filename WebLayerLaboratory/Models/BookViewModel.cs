using ModelLayerLaboratory;

namespace WebLayerLaboratory.Models
{
	public class BookViewModel
	{
		public int Id { get; set; }

		public string? Title { get; set; }

		public string? Editorial { get; set; }

		public CountryViewModel? Country { get; set; }

		public string? Author { get; set; }

		public int Year { get; set; }
	}
}
