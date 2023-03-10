namespace WebLayerLaboratory.Models
{
    public class DataIndexViewModel
    {
        public IEnumerable<CountryViewModel> LstCountry { get; set; }
        public IEnumerable<BookViewModel> LstBook { get; set; }
        public BookViewModel? ObjBook { get; set; }
        public int CountryId { get; set; }
    }
}
