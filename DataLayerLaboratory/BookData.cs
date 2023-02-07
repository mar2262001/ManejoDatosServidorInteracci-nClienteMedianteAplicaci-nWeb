using Dapper;
using ModelLayerLaboratory;
using MySql.Data.MySqlClient;

namespace DataLayerLaboratory
{
	public class BookData : Conecction
	{
		public BookData() 
		{
			SqlQuery = string.Empty;
			ParamQuery = new Object();
			ObjMySqlCommand = new MySqlCommand();
		}

		public IEnumerable<BookModel> GetBookModels()
		{
			using (var connection = new MySqlConnection(ConnString))
			{
				SqlQuery = $"SELECT Id, CountryId, Title, Editorial, Author, Year FROM book;";
				return connection.Query<BookModel>(SqlQuery);
			}
		}

        public BookModel GetBookModel(int id)
        {
            using (var connection = new MySqlConnection(ConnString))
            {
                SqlQuery = $"SELECT Id, CountryId, Title, Editorial, Author, Year FROM book WHERE Id = @id;";
                ParamQuery = new { id = id };
				return connection.Query<BookModel>(SqlQuery, ParamQuery).FirstOrDefault();
            }
        }

        public IEnumerable<BookModel> GetBookModels(string name)
		{
			using (var connection = new MySqlConnection(ConnString))
			{
				SqlQuery = $"SELECT Id, CountryId, Title, Editorial, Author, Year FROM book WHERE book.Title = @title";
				ParamQuery = new { title = name};
				return connection.Query<BookModel>(SqlQuery, SqlQuery);
			}
		}

		public void DelBookModel(int id)
		{
			using (var connection = new MySqlConnection(ConnString))
			{
                connection.Open();
                SqlQuery = $"DELETE FROM book WHERE Id = @id;";
				ObjMySqlCommand.Parameters.Add("@id", MySqlDbType.Int16).Value = id;
				ObjMySqlCommand.Connection = connection;
				ObjMySqlCommand.CommandText = SqlQuery;
				ObjMySqlCommand.ExecuteNonQuery();
                connection.Close();
            }
		}

		public void PutBookModel(BookModel objBookModel)
		{
			using (var connection = new MySqlConnection(ConnString))
			{
                connection.Open();
                SqlQuery = $"UPDATE book SET CountryId = @CountryId, Title = @Title, Editorial = @Editorial, Author = @Author, Year = @Year WHERE Id = @Id;";
				ObjMySqlCommand.Parameters.Add("@Id", MySqlDbType.Int16).Value = objBookModel.Id;
				ObjMySqlCommand.Parameters.Add("@CountryId", MySqlDbType.Int16).Value = objBookModel.CountryId;
				ObjMySqlCommand.Parameters.Add("@Title", MySqlDbType.VarChar).Value = objBookModel.Title;
				ObjMySqlCommand.Parameters.Add("@Editorial", MySqlDbType.VarChar).Value = objBookModel.Editorial;
				ObjMySqlCommand.Parameters.Add("@Author", MySqlDbType.VarChar).Value = objBookModel.Author;
				ObjMySqlCommand.Parameters.Add("@Year", MySqlDbType.Int16).Value = objBookModel.Year;
				ObjMySqlCommand.Connection = connection;
				ObjMySqlCommand.CommandText = SqlQuery;
				ObjMySqlCommand.ExecuteNonQuery();
                connection.Close();
            }
		}

		public void PostBookModel(BookModel objBookModel)
		{
			using (var connection = new MySqlConnection(ConnString))
			{
				connection.Open();
                SqlQuery = $"INSERT INTO book (CountryId, Title, Editorial, Author, Year ) VALUES ( @CountryId, @Title, @Editorial, @Author, @Year);";
				ObjMySqlCommand.Parameters.Add("@CountryId", MySqlDbType.Int16).Value = objBookModel.CountryId;
				ObjMySqlCommand.Parameters.Add("@Title", MySqlDbType.VarChar).Value = objBookModel.Title;
				ObjMySqlCommand.Parameters.Add("@Editorial", MySqlDbType.VarChar).Value = objBookModel.Editorial;
				ObjMySqlCommand.Parameters.Add("@Author", MySqlDbType.VarChar).Value = objBookModel.Author;
				ObjMySqlCommand.Parameters.Add("@Year", MySqlDbType.Int16).Value = objBookModel.Year;
				ObjMySqlCommand.Connection = connection;
				ObjMySqlCommand.CommandText = SqlQuery;
				ObjMySqlCommand.ExecuteNonQuery();
                connection.Close();
            }
		}
	}
}
