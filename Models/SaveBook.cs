using API.Models.Interfaces;
using MySql.Data.MySqlClient;
using System.Data.SQLite;
namespace API.Models
{
    public class SaveBook : IInsertBook
    {
        public void InsertBook(Book value)
        {
            DBConnect db = new DBConnect();
            bool isOpen = db.OpenConnection();

            if(isOpen)
            {
                MySqlConnection conn = db.GetConnection();
                MySqlCommand cmd = new MySqlCommand();

                cmd.Connection = conn;

                cmd.CommandText = @"INSERT INTO books(title, author) VALUES(@title, @author)";
                cmd.Parameters.AddWithValue("@title",value.Title);
                cmd.Parameters.AddWithValue("@title",value.Author);
                cmd.Prepare();
                cmd.ExecuteNonQuery();

                db.CloseConnection();
            }
            
            
            // string cs = @"URI=file:C:\Users\irenebindangabesoangue\Documents\MIS321\REPOS\DatabaseCode\book.db";
            // using var con = new SQLiteConnection(cs);
            // con.Open();

            // using var cmd = new SQLiteCommand(con);

            // cmd.CommandText = @"INSERT INTO books(title, author) VALUES(@title, @author)";
            // cmd.Parameters.AddWithValue("@title", value.Title);
            // cmd.Parameters.AddWithValue("@author", value.Author);
            // cmd.Prepare();
            // cmd.ExecuteNonQuery();
        }
        public void UpdateBook(Book value)
        {
            DBConnect db = new DBConnect();
            bool isOpen = db.OpenConnection();

            if(isOpen)
            {
                MySqlConnection conn = db.GetConnection();
                MySqlCommand cmd = new MySqlCommand();

                cmd.Connection = conn;

                cmd.CommandText = @"UPDATE books SET title = @title, author = @author WHERE id = @id";
                cmd.Parameters.AddWithValue("@id",value.Id);
                cmd.Parameters.AddWithValue("@title",value.Title);
                cmd.Parameters.AddWithValue("@title",value.Author);
                cmd.Prepare();
                cmd.ExecuteNonQuery();

                db.CloseConnection();
            }
        }
    }
}