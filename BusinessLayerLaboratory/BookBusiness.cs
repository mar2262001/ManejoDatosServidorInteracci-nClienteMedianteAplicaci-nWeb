using DataLayerLaboratory;
using ModelLayerLaboratory;

namespace BusinessLayerLaboratory
{
	public class BookBusiness
	{
		public BookData objBookData { get; set; }

		public BookBusiness()
		{
			objBookData = new BookData();
		}

		public IEnumerable<BookModel> GetBookModels()
		{
			return objBookData.GetBookModels();
		}

		public IEnumerable<BookModel> GetBookModels(string name)
		{
			return objBookData.GetBookModels(name);
		}

		public void DelBookModel(int id)
		{
			objBookData.DelBookModel(id);
		}

		public void PutBookModels(BookModel objBookModel)
		{
			objBookData.PutBookModels(objBookModel);
		}

		public void PostBookModels(BookModel objBookModel)
		{
			objBookData.PostBookModels(objBookModel);
		}
	}
}
