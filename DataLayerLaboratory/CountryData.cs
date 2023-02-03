using Dapper;
using ModelLayerLaboratory;
using MySql.Data.MySqlClient;

namespace DataLayerLaboratory
{
	public class CountryData : Conecction
	{
		public CountryData()
		{
			SqlQuery = string.Empty;
			ParamQuery = new Object();
		}

		public IEnumerable<CountryModel> GetCountryModels() 
		{
			using (var connection = new MySqlConnection(ConnString))
			{
				SqlQuery = $"SELECT Id, Name FROM Country";
				var queryResult = connection.Query<CountryModel>(SqlQuery);

				return queryResult;
			}
		}
	}
}
