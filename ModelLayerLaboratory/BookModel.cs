namespace ModelLayerLaboratory
{
	public class BookModel
	{
		public int Id { get; set; }

		public string Title { get; set; }

		public string Editorial { get; set; }

		public CountryModel Country { get; set; }

		public string Author { get; set; }

		public int Year { get; set; }
	}
}
