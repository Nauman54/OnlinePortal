using ClassLibraryModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryDAL
{
    public class StdDAL
    {
        public static int SaveStd(StdModel sm)
        {
            SqlConnection con = DBHelper.GetConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("Sp_SaveStd", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@StdFirstName", sm.StdFirstName);
            cmd.Parameters.AddWithValue("@StdLastName", sm.StdLastName);
            cmd.Parameters.AddWithValue("@GenderID", sm.GenderID);
            cmd.Parameters.AddWithValue("@StdCNIC", sm.StdCNIC);
            cmd.Parameters.AddWithValue("@StdPhoneNo", sm.StdPhoneNo);
            cmd.Parameters.AddWithValue("@StdEmail", sm.StdEmail);
            cmd.Parameters.AddWithValue("@CountryID", sm.CountryID);
            cmd.Parameters.AddWithValue("@CityID", sm.CityID);
            cmd.Parameters.AddWithValue("@StdAddress", sm.StdAddress);
            cmd.Parameters.AddWithValue("@StdLastEducation", sm.StdLastEducation);
            cmd.Parameters.AddWithValue("@OrgID", sm.OrgID);
            cmd.Parameters.AddWithValue("@DeptID", sm.DeptID);
            cmd.Parameters.AddWithValue("@StdImage", sm.StdImage);
            cmd.Parameters.AddWithValue("@StdIsActive", sm.StdIsActive);
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;
        }

        public static List<StdModel> GetStd()
        {
            SqlConnection con = DBHelper.GetConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("Sp_GetStd", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            SqlDataReader sdr = cmd.ExecuteReader();
            List<StdModel> Stdlist = new List<StdModel>();
            while (sdr.Read())
            {
                StdModel std = new StdModel();
				std.StdID = int.Parse(sdr["StdID"].ToString());
				std.StdFirstName = sdr["StdFirstName"].ToString();
                std.StdLastName = sdr["StdLastName"].ToString();
                std.GenderName = sdr["GenderName"].ToString();
                std.StdCNIC = sdr["StdCNIC"].ToString();
                std.StdPhoneNo = sdr["StdPhoneNo"].ToString();
                std.StdEmail = sdr["StdEmail"].ToString();
                std.CountryName = sdr["CountryName"].ToString();
                std.CityName = sdr["CityName"].ToString();
                std.StdAddress = sdr["StdAddress"].ToString();
                std.StdLastEducation = sdr["StdLastEducation"].ToString();
                std.OrgName = sdr["OrgName"].ToString();
                std.DeptName = sdr["DeptName"].ToString();
                std.StdImage = sdr["StdImage"].ToString();
                std.StdIsActive = bool.Parse(sdr["StdIsActive"].ToString());
                Stdlist.Add(std);
            }

            con.Close();
            return Stdlist;
        }

        public static List<StdModel> GetStdByID(int StdID)
        {
            SqlConnection con = DBHelper.GetConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("Sp_GetStdByID", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@StdID", StdID);

            SqlDataReader sdr = cmd.ExecuteReader();
            List<StdModel> Stdlist = new List<StdModel>();
            while (sdr.Read())
            {
                StdModel std = new StdModel();
                std.StdFirstName = sdr["StdFirstName"].ToString();
                std.StdLastName = sdr["StdLastName"].ToString();
                std.GenderID = int.Parse(sdr["GenderID"].ToString());
				std.StdCNIC = sdr["StdCNIC"].ToString();
                std.StdPhoneNo = sdr["StdPhoneNo"].ToString();
                std.StdEmail = sdr["StdEmail"].ToString();
                std.CountryID = int.Parse(sdr["CountryID"].ToString());
				std.CityID = int.Parse(sdr["CityID"].ToString());
				std.StdAddress = sdr["StdAddress"].ToString();
                std.StdLastEducation = sdr["StdLastEducation"].ToString();
                std.OrgID = int.Parse(sdr["OrgID"].ToString());
				std.DeptID = int.Parse(sdr["DeptID"].ToString());
				std.StdImage = sdr["StdImage"].ToString();
                std.StdIsActive = bool.Parse(sdr["StdIsActive"].ToString());
                Stdlist.Add(std);
            }

            con.Close();
            return Stdlist;
        }

        public static int EditStd(StdModel sm)
        {
            SqlConnection con = DBHelper.GetConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("Sp_EditStd", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
			cmd.Parameters.AddWithValue("@StdID", sm.StdID);
			cmd.Parameters.AddWithValue("@StdFirstName", sm.StdFirstName);
            cmd.Parameters.AddWithValue("@StdLastName", sm.StdLastName);
            cmd.Parameters.AddWithValue("@GenderID", sm.GenderID);
            cmd.Parameters.AddWithValue("@StdCNIC", sm.StdCNIC);
            cmd.Parameters.AddWithValue("@StdPhoneNo", sm.StdPhoneNo);
            cmd.Parameters.AddWithValue("@StdEmail", sm.StdEmail);
            cmd.Parameters.AddWithValue("@CountryID", sm.CountryID);
            cmd.Parameters.AddWithValue("@CityID", sm.CityID);
            cmd.Parameters.AddWithValue("@StdAddress", sm.StdAddress);
            cmd.Parameters.AddWithValue("@StdLastEducation", sm.StdLastEducation);
            cmd.Parameters.AddWithValue("@OrgID", sm.OrgID);
            cmd.Parameters.AddWithValue("@DeptID", sm.DeptID);
            cmd.Parameters.AddWithValue("@StdImage", sm.StdImage);
            cmd.Parameters.AddWithValue("@StdIsActive", sm.StdIsActive);
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;
        }


		public static List<StdModel> GetStdByEmail(string StdEmail)
		{
			SqlConnection con = DBHelper.GetConnection();
			con.Open();
			SqlCommand cmd = new SqlCommand("Sp_GetStdByEmail", con);
			cmd.CommandType = System.Data.CommandType.StoredProcedure;
			cmd.Parameters.AddWithValue("@StdEmail", StdEmail);

			SqlDataReader sdr = cmd.ExecuteReader();
			List<StdModel> Stdlist = new List<StdModel>();
			while (sdr.Read())
			{
				StdModel std = new StdModel();
				std.StdID = int.Parse(sdr["StdID"].ToString());
				std.StdFirstName = sdr["StdFirstName"].ToString();
				std.StdLastName = sdr["StdLastName"].ToString();
				std.GenderID = int.Parse(sdr["GenderID"].ToString());
				std.StdCNIC = sdr["StdCNIC"].ToString();
				std.StdPhoneNo = sdr["StdPhoneNo"].ToString();
				std.StdEmail = sdr["StdEmail"].ToString();
				std.CountryID = int.Parse(sdr["CountryID"].ToString());
				std.CityID = int.Parse(sdr["CityID"].ToString());
				std.StdAddress = sdr["StdAddress"].ToString();
				std.StdLastEducation = sdr["StdLastEducation"].ToString();
				std.OrgID = int.Parse(sdr["OrgID"].ToString());
				std.DeptID = int.Parse(sdr["DeptID"].ToString());
				std.StdImage = sdr["StdImage"].ToString();
				std.StdIsActive = bool.Parse(sdr["StdIsActive"].ToString());
				Stdlist.Add(std);
			}

			con.Close();
			return Stdlist;
		}

		public static int DeleteStd(int StdID)
        {
            SqlConnection con = DBHelper.GetConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("Sp_DeleteStd", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@StdID", StdID);
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;
        }

    }
}
