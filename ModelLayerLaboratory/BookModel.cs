namespace ModelLayerLaboratory
{
	public class BookModel
	{
		public int Id { get; set; }

		public int CountryId { get; set; }

		public string? Title { get; set; }

		public string? Editorial { get; set; }

		public string? Author { get; set; }

		public int Year { get; set; }

		public CountryModel? ObjCountryModel { get; set; }
	}
}
