using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using ClassLibraryModel;

namespace ClassLibraryDAL
{
    public class CountryDAL
    {
        public static int SaveCountry(CountryModel cm)
        {
            SqlConnection con = DBHelper.GetConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("Sp_SaveCountry", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CountryName", cm.CountryName);
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;
        }

        public static List<CountryModel> GetCountry()
        {
            SqlConnection con = DBHelper.GetConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("Sp_GetCountry", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            SqlDataReader sdr = cmd.ExecuteReader();
            List<CountryModel> Countrylist = new List<CountryModel>();
            while (sdr.Read())
            {
                CountryModel country = new CountryModel();
                country.CountryID = int.Parse(sdr["CountryID"].ToString());
                country.CountryName = sdr["CountryName"].ToString();
                Countrylist.Add(country);
            }
            con.Close();
            return Countrylist;
        }

        public static List<CountryModel> GetCountryByID(int CountryID)
        {
            SqlConnection con = DBHelper.GetConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("Sp_GetCountryByID", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CountryID", CountryID);

            SqlDataReader sdr = cmd.ExecuteReader();
            List<CountryModel> Countrylist = new List<CountryModel>();
            while (sdr.Read())
            {
                CountryModel country = new CountryModel();
                country.CountryName = sdr["CountryName"].ToString();
                Countrylist.Add(country);
            }
            con.Close();
            return Countrylist;
        }

        public static int EditCountry(CountryModel cm)
        {
            SqlConnection con = DBHelper.GetConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("Sp_EditCountry", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CountryID", cm.CountryID);
            cmd.Parameters.AddWithValue("@CountryName", cm.CountryName);
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;
        }

        public static int DeleteCountry(int CountryID)
        {
            SqlConnection con = DBHelper.GetConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("Sp_DeleteCountry", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CountryID", CountryID);
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;
        }
    }
}
