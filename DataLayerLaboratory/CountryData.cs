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

        public CountryModel GetCountryModel(int id)
        {
            using (var connection = new MySqlConnection(ConnString))
            {
                SqlQuery = $"SELECT Id, Name FROM Country WHERE Id = @id";
                ParamQuery = new { id = id };
                return connection.Query<CountryModel>(SqlQuery, ParamQuery).FirstOrDefault();
            }
        }
    }
}
