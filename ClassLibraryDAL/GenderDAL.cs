using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using ClassLibraryModel;

namespace ClassLibraryDAL
{
    public class GenderDAL
    {
        public static int SaveGender(GenderModel gm)
        {
            SqlConnection con = DBHelper.GetConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("Sp_SaveGender", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@GenderName", gm.GenderName);
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;
        }

        public static List<GenderModel> GetGender()
        {
            SqlConnection con = DBHelper.GetConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("Sp_GetGender", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            SqlDataReader sdr = cmd.ExecuteReader();
            List<GenderModel> Genderlist = new List<GenderModel>();
            while (sdr.Read())
            {
                GenderModel gender = new GenderModel();
                gender.GenderID = int.Parse(sdr["GenderID"].ToString());
                gender.GenderName = sdr["GenderName"].ToString();
                Genderlist.Add(gender);
            }
            con.Close();
            return Genderlist;
        }

        public static List<GenderModel> GetGenderByID(int GenderID)
        {
            SqlConnection con = DBHelper.GetConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("Sp_GetGenderByID", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@GenderID", GenderID);

            SqlDataReader sdr = cmd.ExecuteReader();
            List<GenderModel> Genderlist = new List<GenderModel>();
            while (sdr.Read())
            {
                GenderModel gender = new GenderModel();
                gender.GenderName = sdr["GenderName"].ToString();
                Genderlist.Add(gender);
            }
            con.Close();
            return Genderlist;
        }

        public static int EditGender(GenderModel gm)
        {
            SqlConnection con = DBHelper.GetConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("Sp_EditGender", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@GenderID", gm.GenderID);
            cmd.Parameters.AddWithValue("@GenderName", gm.GenderName);
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;
        }

        public static int DeleteGender(int GenderID)
        {
            SqlConnection con = DBHelper.GetConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("Sp_DeleteGender", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@GenderID", GenderID);
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;
        }
    }
}
