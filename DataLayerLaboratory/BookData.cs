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
				SqlQuery = $"SELECT book.Id, book.CountryId, book.Title, book.Editorial, book.Author, book.Year,  country.Id, country.Name FROM book AS book INNER JOIN country AS country ON book.CountryId = country.Id";
				return connection.Query<BookModel>("");
			}
		}

		public IEnumerable<BookModel> GetBookModels(string name)
		{
			using (var connection = new MySqlConnection(ConnString))
			{
				SqlQuery = $"SELECT book.Id, book.CountryId, book.Title, book.Editorial, book.Author, book.Year,  country.Id, country.Name FROM book AS book INNER JOIN country AS country ON book.CountryId = country.Id WHERE book.Title = @title";
				ParamQuery = new { title = name};
				var queryResult = connection.Query<BookModel>(SqlQuery, SqlQuery);
				return queryResult;
			}
		}

		public void DelBookModel(int id)
		{
			using (var connection = new MySqlConnection(ConnString))
			{
				SqlQuery = $"DELETE FROM computaciónservidorwebunir.book WHERE Id @id;";
				ObjMySqlCommand.Parameters.Add("@id", MySqlDbType.Int16).Value = id;
				ObjMySqlCommand.Connection = connection;
				ObjMySqlCommand.CommandText = SqlQuery;
				ObjMySqlCommand.ExecuteNonQuery();
			}
		}

		public void PutBookModels(BookModel objBookModel)
		{
			using (var connection = new MySqlConnection(ConnString))
			{
				SqlQuery = $"UPDATE computaciónservidorwebunir.book SET CountryId = @CountryId, Title = @Title, Editorial = @Editorial, Author = @Author, Year = @Year WHERE Id = @Id;";
				ObjMySqlCommand.Parameters.Add("@Id", MySqlDbType.Int16).Value = objBookModel.Country.Id;
				ObjMySqlCommand.Parameters.Add("@CountryId", MySqlDbType.Int16).Value = objBookModel.Country.Id;
				ObjMySqlCommand.Parameters.Add("@Title", MySqlDbType.VarChar).Value = objBookModel.Title;
				ObjMySqlCommand.Parameters.Add("@Editorial", MySqlDbType.VarChar).Value = objBookModel.Editorial;
				ObjMySqlCommand.Parameters.Add("@Author", MySqlDbType.VarChar).Value = objBookModel.Author;
				ObjMySqlCommand.Parameters.Add("@Year", MySqlDbType.Int16).Value = objBookModel.Year;
				ObjMySqlCommand.Connection = connection;
				ObjMySqlCommand.CommandText = SqlQuery;
				ObjMySqlCommand.ExecuteNonQuery();
			}
		}

		public void PostBookModels(BookModel objBookModel)
		{
			using (var connection = new MySqlConnection(ConnString))
			{
				SqlQuery = $"INSERT INTO computaciónservidorwebunir.book (CountryId, Title, Editorial, Author, Year ) VALUES ( @CountryId, @Title, @Editorial, @Author, @Year);";
				ObjMySqlCommand.Parameters.Add("@CountryId", MySqlDbType.Int16).Value = objBookModel.Country.Id;
				ObjMySqlCommand.Parameters.Add("@Title", MySqlDbType.VarChar).Value = objBookModel.Title;
				ObjMySqlCommand.Parameters.Add("@Editorial", MySqlDbType.VarChar).Value = objBookModel.Editorial;
				ObjMySqlCommand.Parameters.Add("@Author", MySqlDbType.VarChar).Value = objBookModel.Author;
				ObjMySqlCommand.Parameters.Add("@Year", MySqlDbType.Int16).Value = objBookModel.Year;
				ObjMySqlCommand.Connection = connection;
				ObjMySqlCommand.CommandText = SqlQuery;
				ObjMySqlCommand.ExecuteNonQuery();
			}
		}
	}
}
