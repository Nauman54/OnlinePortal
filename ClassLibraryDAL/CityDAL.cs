using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using ClassLibraryModel;

namespace ClassLibraryDAL
{
    public class CityDAL
    {
        public static int SaveCity(CityModel cm)
        {
            SqlConnection con = DBHelper.GetConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("Sp_SaveCity", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CityName", cm.CityName);
            cmd.Parameters.AddWithValue("@CountryID", cm.CountryID);
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;
        }

        public static List<CityModel> GetCity()
        {
            SqlConnection con = DBHelper.GetConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("Sp_GetCity", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            SqlDataReader sdr = cmd.ExecuteReader();
            List<CityModel> Citylist = new List<CityModel>();
            while (sdr.Read())
            {
                CityModel city = new CityModel();
                city.CityID = int.Parse(sdr["CityID"].ToString());
                city.CityName = sdr["CityName"].ToString();
                city.CountryName = sdr["CountryName"].ToString();
                Citylist.Add(city);
            }

            con.Close();
            return Citylist;
        }

        public static List<CityModel> GetCityByID(int CityID)
        {
            SqlConnection con = DBHelper.GetConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("Sp_GetCityByID", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CityID", CityID);

            SqlDataReader sdr = cmd.ExecuteReader();
            List<CityModel> Citylist = new List<CityModel>();
            while (sdr.Read())
            {
                CityModel city = new CityModel();
                city.CityName = sdr["CityName"].ToString();
                city.CountryID = int.Parse(sdr["CountryID"].ToString());
                Citylist.Add(city);
            }

            con.Close();
            return Citylist;
        }

        public static int EditCity(CityModel cm)
        {
            SqlConnection con = DBHelper.GetConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("Sp_EditCity", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CityID", cm.CityID);
            cmd.Parameters.AddWithValue("@CityName", cm.CityName);
            cmd.Parameters.AddWithValue("@CountryID", cm.CountryID);
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;
        }
		public static List<CityModel> GetCityByCountry(int CountryID)
		{
			SqlConnection con = DBHelper.GetConnection();
			con.Open();
			SqlCommand cmd = new SqlCommand("Sp_GetCityByCountry", con);
			cmd.CommandType = System.Data.CommandType.StoredProcedure;
			cmd.Parameters.AddWithValue("@CountryID", CountryID);

			SqlDataReader sdr = cmd.ExecuteReader();
			List<CityModel> Citylist = new List<CityModel>();
			while (sdr.Read())
			{
				CityModel city = new CityModel();
				city.CityID = int.Parse(sdr["CityID"].ToString());
				city.CityName = sdr["CityName"].ToString();
				Citylist.Add(city);
			}

			con.Close();
			return Citylist;
		}

		public static int DeleteCity(int CityID)
        {
            SqlConnection con = DBHelper.GetConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("Sp_DeleteCity", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CityID", CityID);
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;
        }
    }
}
