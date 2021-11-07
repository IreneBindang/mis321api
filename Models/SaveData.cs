using System.Data.SQLite;
using API.Models.Interfaces;
namespace API.Models
{
    public class SaveData: ISeedData, ISaveData, IDelete
    {
        public void SaveBook(Book value)
        {
            string cs = @"URI=file:C:\Users\irenebindangabesoangue\Documents\MIS321\REPOS\DatabaseCode\book.db";
            using var con = new SQLiteConnection(cs); 
            con.Open();

            using var cmd = new SQLiteCommand(con);

            cmd.CommandText = @"UPDATE books set title = @title, author = @author WHERE id = @id ";
            cmd.Parameters.AddWithValue("@id", value.Id);
            cmd.Parameters.AddWithValue("@title", value.Title);
            cmd.Parameters.AddWithValue("@author", value.Author);
            cmd.Prepare();
            cmd.ExecuteNonQuery();


        }
        public void GetDeleted()
        {
            string cs = @"URI=file:C:\Users\irenebindangabesoangue\Documents\MIS321\REPOS\DatabaseCode\book.db";
            using var con = new SQLiteConnection(cs); 
            con.Open();

            using var cmd = new SQLiteCommand(con);
            cmd.CommandText = @"DELETE FROM books WHERE id = 1"; 
            cmd.Prepare(); 
            cmd.ExecuteNonQuery();
        }
        
        public void SeedData()
        {
            string cs = @"URI=file:C:\Users\irenebindangabesoangue\Documents\MIS321\REPOS\DatabaseCode\book.db";
            using var con = new SQLiteConnection(cs); 
            con.Open();

            using var cmd = new SQLiteCommand(con);

            cmd.CommandText = "DROP TABLE IF EXISTS books";
            cmd.ExecuteNonQuery();

            cmd.CommandText = @"CREATE TABLE books(id INTEGER PRIMARY KEY, title TEXT, author TEXT)";
            cmd.ExecuteNonQuery();

            cmd.CommandText = @"INSERT INTO books(title, author) VALUES(@title, @author)";
            cmd.Parameters.AddWithValue("@title", "Mistborn"); 
            cmd.Parameters.AddWithValue("@author", "Brandon Sanderson"); 
            cmd.Prepare();
            cmd.ExecuteNonQuery();

            cmd.CommandText = @"INSERT INTO books(title, author) VALUES(@title, @author)";
            cmd.Parameters.AddWithValue("@title", "Oathbringer"); 
            cmd.Parameters.AddWithValue("@author", "Brandon Sanderson"); 
            cmd.Prepare();
            cmd.ExecuteNonQuery();

            cmd.CommandText = @"INSERT INTO books(title, author) VALUES(@title, @author)";
            cmd.Parameters.AddWithValue("@title", "The Dragon Reborn"); 
            cmd.Parameters.AddWithValue("@author", "Robert Jordan"); 
            cmd.Prepare();
            cmd.ExecuteNonQuery();
        }
    }
}