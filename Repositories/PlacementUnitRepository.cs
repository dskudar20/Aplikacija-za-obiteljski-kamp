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
    public class PlacementUnitRepository
    {
        public static PlacementUnit GetPlacementUnit(int id)
        {
            PlacementUnit placementUnit = null;
            string sql = $"SELECT * FROM Placements WHERE PlacementUnit = {id}";
            DB.OpenConnection();
            var reader = DB.GetDataReader(sql);
            if (reader.HasRows)
            {
                reader.Read();
                placementUnit = CreateObject(reader);
                reader.Close();
            }
            DB.CloseConnection();
            return placementUnit;
        }


        public static List<PlacementUnit> GetPlacementUnits()
        {
            List<PlacementUnit> placementUnits = new List<PlacementUnit>();
            string sql = "SELECT * FROM Placements";
            DB.OpenConnection();
            var reader = DB.GetDataReader(sql);
            while (reader.Read())
            {
                PlacementUnit placementUnit = CreateObject(reader);
                placementUnits.Add(placementUnit);
            }
            reader.Close();
            DB.CloseConnection();
            return placementUnits;
        }

        private static PlacementUnit CreateObject(SqlDataReader reader)
        {
            int id = int.Parse(reader["IdPlaceUnit"].ToString());
            string name = reader["Name"].ToString();
            var placementUnit = new PlacementUnit
            {
                Name = name
            };
            return placementUnit;
        }

}
}