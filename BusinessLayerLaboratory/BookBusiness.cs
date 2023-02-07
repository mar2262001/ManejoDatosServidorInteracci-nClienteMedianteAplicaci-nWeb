using DataLayerLaboratory;
using ModelLayerLaboratory;

namespace BusinessLayerLaboratory
{
	public class BookBusiness
	{
		public BookData objBookData { get; set; }
		public CountryData objCountryData { get; set; }

		public BookBusiness()
		{
			objBookData = new BookData();
			objCountryData = new CountryData();

        }

		public IEnumerable<BookModel> GetBookModels()
		{
			var lstBookModel = objBookData.GetBookModels();
			foreach (BookModel itm in lstBookModel) {
				itm.ObjCountryModel = objCountryData.GetCountryModel(itm.CountryId);

            }
			return lstBookModel;
		}

        public BookModel GetBookModel(int id)
        {
            BookModel objBookModel = objBookData.GetBookModel(id);
            objBookModel.ObjCountryModel = objCountryData.GetCountryModel(id);
			return objBookModel;
        }

        public IEnumerable<BookModel> GetBookModels(int contryId)
		{
            var lstBookModel = objBookData.GetBookModels(contryId);
            foreach (BookModel itm in lstBookModel)
            {
                itm.ObjCountryModel = objCountryData.GetCountryModel(itm.CountryId);

            }
            return lstBookModel;
        }

		public void DelBookModel(int id)
		{
			objBookData.DelBookModel(id);
		}

		public void PutBookModel(BookModel objBookModel)
		{
			objBookData.PutBookModel(objBookModel);
		}

		public void PostBookModel(BookModel objBookModel)
		{
			objBookData.PostBookModel(objBookModel);
		}
	}
}
