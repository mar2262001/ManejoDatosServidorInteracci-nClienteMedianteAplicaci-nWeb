using ModelLayerLaboratory;
using DataLayerLaboratory;

namespace BusinessLayerLaboratory
{
	public class CountryBusiness
	{
		public CountryData ObjCountryData { get; set; }

		public CountryBusiness()
		{
			ObjCountryData = new CountryData();
		}

		public IEnumerable<CountryModel> GetCountryModels()
		{
			return ObjCountryData.GetCountryModels();
		}
	}
}
