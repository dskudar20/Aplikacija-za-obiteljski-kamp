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

    public class GuestRepository
    {

        public static Guest GetGuest(int id)
        {
            Guest guest = null;
            string sql = $"SELECT * FROM Guests WHERE Id = {id}";
            DB.OpenConnection();
            var reader = DB.GetDataReader(sql);
            if (reader.HasRows)
            {
                reader.Read();
                guest = CreateObject(reader);
                reader.Close();
            }
            DB.CloseConnection();
            return guest;
        }

      
        public static List<Guest> GetGuests()
        {
            List<Guest> guests = new List<Guest>();
            string sql = "SELECT * FROM Guests";
            DB.OpenConnection();
            var reader = DB.GetDataReader(sql);
            while (reader.Read())
            {
                Guest guest = CreateObject(reader);
                guests.Add(guest);
            }
            reader.Close();
            DB.CloseConnection();
            return guests;
        }
        //ovo je za search bar
        public static List<Guest> GetGosti(string text)
        {
            List<Guest> gosti = new List<Guest>();
            string sql = $"SELECT * FROM Guests WHERE FirstName LIKE '{text + "%"}'";
            DB.OpenConnection();
            var reader = DB.GetDataReader(sql);
            while (reader.Read())
            {
                Guest guest = CreateObject(reader);
                gosti.Add(guest);
            }
            reader.Close();
            DB.CloseConnection();
            return gosti;
        }


        private static Guest CreateObject(SqlDataReader reader)
        {
            int id = int.Parse(reader["Id"].ToString());
            string firstName = reader["FirstName"].ToString();
            string lastName = reader["LastName"].ToString();
            DateTime birthDate = DateTime.Parse(reader["BirthDate"].ToString());
            int idPlaceUnit = int.Parse(reader["IdPlaceUnit"].ToString());
            DateTime periodFrom = DateTime.Parse(reader["PeriodFrom"].ToString());
            DateTime periodTo = DateTime.Parse(reader["PeriodTo"].ToString());
            int guestsNum = int.Parse(reader["GuestsNum"].ToString());
            string phoneNumber = reader["PhoneNumber"].ToString();
            string ownerName = reader["OwnerName"].ToString();
            

            var guest = new Guest
            {
                Id = id,
                FirstName = firstName,
                LastName = lastName,
                BirthDate = birthDate,
                IdPlaceUnit = idPlaceUnit,
                PeriodFrom = periodFrom,
                PeriodTo = periodTo,
                GuestsNum = guestsNum,
                PhoneNumber = phoneNumber,
                OwnerName = ownerName
            };
            return guest;
        }
       
    }
}
