using API.Models.Interfaces;
using MySql.Data.MySqlClient;

namespace API.Models
{
    public class DeleteBook : IDelete
    {
        public void GetDeleted(int id)
        {
            DBConnect db = new DBConnect();
            bool isOpen = db.OpenConnection();

            if(isOpen)
            {
                MySqlConnection conn = db.GetConnection();
                MySqlCommand cmd = new MySqlCommand();

                cmd.Connection = conn;

                cmd.CommandText = @"DELETE FROM books WHERE id=@id";
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Prepare();
                cmd.ExecuteNonQuery();

                
            }
        }
    }
}