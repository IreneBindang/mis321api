using API.Models.Interfaces;
using System.Data.SQLite;
namespace API.Models
{
    public class SaveBook : IInsertBook
    {
        public void InsertBook(Book value)
        {
            string cs = @"URI=file:C:\Users\irenebindangabesoangue\Documents\MIS321\REPOS\DatabaseCode\book.db";
            using var con = new SQLiteConnection(cs);
            con.Open();

            using var cmd = new SQLiteCommand(con);

            cmd.CommandText = @"INSERT INTO books(title, author) VALUES(@title, @author)";
            cmd.Parameters.AddWithValue("@title", value.Title);
            cmd.Parameters.AddWithValue("@author", value.Author);
            cmd.Prepare();
            cmd.ExecuteNonQuery();
        }
    }
}