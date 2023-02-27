using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using ClassLibraryModel;

namespace ClassLibraryDAL
{
    public class FYPDAL
    {
        public static int SaveFYP(FYPModel fypm)
        {
            SqlConnection con = DBHelper.GetConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("Sp_SaveFYP", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FYPTitle", fypm.FYPTitle);
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;
        }

        public static List<FYPModel> GetFYP()
        {
            SqlConnection con = DBHelper.GetConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("Sp_GetFYP", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            SqlDataReader sdr = cmd.ExecuteReader();
            List<FYPModel> FYPlist = new List<FYPModel>();
            while (sdr.Read())
            {
                FYPModel fyp = new FYPModel();
                fyp.FYPID = int.Parse(sdr["FYPID"].ToString());
                fyp.FYPTitle = sdr["FYPTitle"].ToString();
                FYPlist.Add(fyp);
            }
            con.Close();
            return FYPlist;
        }

        public static List<FYPModel> GetFYPByID(int FYPID)
        {
            SqlConnection con = DBHelper.GetConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("Sp_GetFYPByID", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FYPID", FYPID);

            SqlDataReader sdr = cmd.ExecuteReader();
            List<FYPModel> FYPlist = new List<FYPModel>();
            while (sdr.Read())
            {
                FYPModel fyp = new FYPModel();
                fyp.FYPTitle = sdr["FYPTitle"].ToString();
                FYPlist.Add(fyp);
            }
            con.Close();
            return FYPlist;
        }

        public static int EditFYP(FYPModel fypm)
        {
            SqlConnection con = DBHelper.GetConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("Sp_EditFYP", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FYPID", fypm.FYPID);
            cmd.Parameters.AddWithValue("@FYPTitle", fypm.FYPTitle);
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;
        }

        public static int DeleteFYP(int FYPID)
        {
            SqlConnection con = DBHelper.GetConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("Sp_DeleteFYP", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FYPID", FYPID);
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;
        }
    }
}
