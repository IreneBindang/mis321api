using System.Collections.Generic;
using API.Models.Interfaces;
using System.Data.SQLite;
namespace API.Models
{
    public class ReadBookData : IGetAllBooks, IGetBook
    {
        public List<Book> GetAllBooks()
        {
            string cs = @"URI=file:C:\Users\irenebindangabesoangue\Documents\MIS321\REPOS\DatabaseCode\book.db";
            using var con = new SQLiteConnection(cs); 
            con.Open();

            string stm = "SELECT * FROM books";
            //execute the above statement
            using var cmd = new SQLiteCommand(stm, con); 

            using SQLiteDataReader rdr = cmd.ExecuteReader(); 

            List<Book> allBooks = new List<Book>();
            while(rdr.Read())
            {
                // option1: Book temp = new Book(){id = rdr.GetInt32(0), Title = rdr.GetString(1), Author = rdr.GetString(2)};
                allBooks.Add(new Book(){Id = rdr.GetInt32(0), Title = rdr.GetString(1), Author = rdr.GetString(2)});
            }
            return allBooks; 

        }

        public Book GetBook(int id)
        {
            string cs = @"URI=file:C:\Users\irenebindangabesoangue\Documents\MIS321\REPOS\DatabaseCode\book.db";
            using var con = new SQLiteConnection(cs); 
            con.Open();

            string stm = "SELECT * FROM books WHERE id = @id";
            using var cmd = new SQLiteCommand(stm, con); 
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Prepare();
            using SQLiteDataReader rdr = cmd.ExecuteReader();

            rdr.Read();
            return new Book(){Id = rdr.GetInt32(0), Title = rdr.GetString(1), Author = rdr.GetString(2)};
        }
        
    }
}