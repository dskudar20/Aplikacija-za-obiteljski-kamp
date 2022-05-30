using Aplikacija_za_obiteljski_kamp.Models;
using DBLayer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplikacija_za_obiteljski_kamp.Repositories
{
    public class OwnerRepository
    {
        public static Owner GetOwner(string username)
        {
            string sql = $"SELECT * FROM Owners WHERE Username = '{username}'";
            return FetchOwner(sql);
        }
        public static Owner GetOwner(int id)
        {
            string sql = $"SELECT * FROM Owners WHERE Id = {id}";
            return FetchOwner(sql);
        }
        private static Owner FetchOwner(string sql)
        {
            DB.SetConfiguration("dskudar20_DB", "dskudar20", "%9@^xU6l");

            DB.OpenConnection();
            var reader = DB.GetDataReader(sql);
            Owner owner = null;
            if (reader.HasRows == true)
            {
                reader.Read();
                owner = CreateObject(reader);
                reader.Close();
            }
            DB.CloseConnection();
            return owner;
        }
        private static Owner CreateObject(SqlDataReader reader)
        {
            int id = int.Parse(reader["Id"].ToString());
            string firstName = reader["FirstName"].ToString();
            string lastName = reader["LastName"].ToString();
            string username = reader["Username"].ToString();
            string password = reader["Password"].ToString();
            var owner = new Owner
            {
                Id = id,
                FirstName = firstName,
                LastName = lastName,
                Username = username,
                Password = password
            };
            return owner;
        }

    }
}
