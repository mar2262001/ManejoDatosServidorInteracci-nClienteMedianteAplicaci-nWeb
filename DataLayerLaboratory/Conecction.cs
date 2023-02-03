using MySql.Data.MySqlClient;
using System.Collections;

namespace DataLayerLaboratory
{
	public class Conecction
	{
		public string ConnString { get; set; }

		public string SqlQuery { get; set; }

		public Object ParamQuery { get; set; }

		public MySqlCommand ObjMySqlCommand {get;set;}

		public Conecction() {

			MySqlConnectionStringBuilder conn_string = new MySqlConnectionStringBuilder();
			conn_string.Server = "127.0.0.1";
			conn_string.Port = 3306;
			conn_string.UserID = "root";
			conn_string.Password = "";
			conn_string.Database = "computaciónservidorwebunir";

			ConnString = conn_string.ToString();
		}
	}
}
