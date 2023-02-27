using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using ClassLibraryModel;

namespace ClassLibraryDAL
{
    public class FaclDAL
    {
		public static int SaveFacl(FaclModel fm)
		{
			SqlConnection con = DBHelper.GetConnection();
			con.Open();
			SqlCommand cmd = new SqlCommand("Sp_SaveFacl", con);
			cmd.CommandType = System.Data.CommandType.StoredProcedure;
			cmd.Parameters.AddWithValue("@FaclFirstName", fm.FaclFirstName);
			cmd.Parameters.AddWithValue("@FaclLastName", fm.FaclLastName);
			cmd.Parameters.AddWithValue("@GenderID", fm.GenderID);
			cmd.Parameters.AddWithValue("@FaclCNIC", fm.FaclCNIC);
			cmd.Parameters.AddWithValue("@FaclPhoneNo", fm.FaclPhoneNo);
			cmd.Parameters.AddWithValue("@FaclEmail", fm.FaclEmail);
			cmd.Parameters.AddWithValue("@CountryID", fm.CountryID);
			cmd.Parameters.AddWithValue("@CityID", fm.CityID);
			cmd.Parameters.AddWithValue("@FaclAddress", fm.FaclAddress);
			cmd.Parameters.AddWithValue("@FaclLastJob", fm.FaclLastJob);
			cmd.Parameters.AddWithValue("@FaclExperience", fm.FaclExperience);
			cmd.Parameters.AddWithValue("@PosID", fm.PosID);
			cmd.Parameters.AddWithValue("@QualID", fm.QualID);
			cmd.Parameters.AddWithValue("@OrgID", fm.OrgID);
			cmd.Parameters.AddWithValue("@DeptID", fm.DeptID);
			cmd.Parameters.AddWithValue("@FaclImage", fm.FaclImage);
			cmd.Parameters.AddWithValue("@FaclIsActive", fm.FaclIsActive);
			int i = cmd.ExecuteNonQuery();
			con.Close();
			return i;
		}

		public static List<FaclModel> GetFacl()
		{
			SqlConnection con = DBHelper.GetConnection();
			con.Open();
			SqlCommand cmd = new SqlCommand("Sp_GetFacl", con);
			cmd.CommandType = System.Data.CommandType.StoredProcedure;

			SqlDataReader sdr = cmd.ExecuteReader();
			List<FaclModel> Facllist = new List<FaclModel>();
			while (sdr.Read())
			{
				FaclModel facl = new FaclModel();
				facl.FaclID = int.Parse(sdr["FaclID"].ToString());
				facl.FaclFirstName = sdr["FaclFirstName"].ToString();
				facl.FaclLastName = sdr["FaclLastName"].ToString();
				facl.GenderName = sdr["GenderName"].ToString();
				facl.FaclCNIC = sdr["FaclCNIC"].ToString();
				facl.FaclPhoneNo = sdr["FaclPhoneNo"].ToString();
				facl.FaclEmail = sdr["FaclEmail"].ToString();
				facl.CountryName = sdr["CountryName"].ToString();
				facl.CityName = sdr["CityName"].ToString();
				facl.FaclAddress = sdr["FaclAddress"].ToString();
				facl.FaclLastJob = sdr["FaclLastJob"].ToString();
				facl.FaclExperience = sdr["FaclExperience"].ToString();
				facl.PosTitle = sdr["PosTitle"].ToString();
				facl.QualTitle = sdr["QualTitle"].ToString();
				facl.OrgName = sdr["OrgName"].ToString();
				facl.DeptName = sdr["DeptName"].ToString();
				facl.FaclImage = sdr["FaclImage"].ToString();
				facl.FaclIsActive = bool.Parse(sdr["FaclIsActive"].ToString());
				Facllist.Add(facl);
			}

			con.Close();
			return Facllist;
		}

        public static List<FaclModel> GetFaclByID(int FaclID)
        {
            SqlConnection con = DBHelper.GetConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("Sp_GetFaclByID", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FaclID", FaclID);

            SqlDataReader sdr = cmd.ExecuteReader();
            List<FaclModel> Facllist = new List<FaclModel>();
            while (sdr.Read())
            {
                FaclModel facl = new FaclModel();
				facl.FaclFirstName = sdr["FaclFirstName"].ToString();
				facl.FaclLastName = sdr["FaclLastName"].ToString();
				facl.GenderID = int.Parse(sdr["GenderID"].ToString());
				facl.FaclCNIC = sdr["FaclCNIC"].ToString();
				facl.FaclPhoneNo = sdr["FaclPhoneNo"].ToString();
				facl.FaclEmail = sdr["FaclEmail"].ToString();
				facl.CountryID = int.Parse(sdr["CountryID"].ToString());
				facl.CityID = int.Parse(sdr["CityID"].ToString());
				facl.FaclAddress = sdr["FaclAddress"].ToString();
				facl.FaclLastJob = sdr["FaclLastJob"].ToString();
				facl.FaclExperience = sdr["FaclExperience"].ToString();
				facl.PosID = int.Parse(sdr["PosID"].ToString());
				facl.QualID = int.Parse(sdr["QualID"].ToString());
				facl.OrgID = int.Parse(sdr["OrgID"].ToString());
				facl.DeptID = int.Parse(sdr["DeptID"].ToString());
				facl.FaclImage = sdr["FaclImage"].ToString();
				facl.FaclIsActive = bool.Parse(sdr["FaclIsActive"].ToString());
				Facllist.Add(facl);
            }

            con.Close();
            return Facllist;
        }

        public static int EditFacl(FaclModel fm)
		{
			SqlConnection con = DBHelper.GetConnection();
			con.Open();
			SqlCommand cmd = new SqlCommand("Sp_EditFacl", con);
			cmd.CommandType = System.Data.CommandType.StoredProcedure;
			cmd.Parameters.AddWithValue("@FaclID", fm.FaclID);
			cmd.Parameters.AddWithValue("@FaclFirstName", fm.FaclFirstName);
			cmd.Parameters.AddWithValue("@FaclLastName", fm.FaclLastName);
			cmd.Parameters.AddWithValue("@GenderID", fm.GenderID);
			cmd.Parameters.AddWithValue("@FaclCNIC", fm.FaclCNIC);
			cmd.Parameters.AddWithValue("@FaclPhoneNo", fm.FaclPhoneNo);
			cmd.Parameters.AddWithValue("@FaclEmail", fm.FaclEmail);
			cmd.Parameters.AddWithValue("@CountryID", fm.CountryID);
			cmd.Parameters.AddWithValue("@CityID", fm.CityID);
			cmd.Parameters.AddWithValue("@FaclAddress", fm.FaclAddress);
			cmd.Parameters.AddWithValue("@FaclLastJob", fm.FaclLastJob);
			cmd.Parameters.AddWithValue("@FaclExperience", fm.FaclExperience);
			cmd.Parameters.AddWithValue("@PosID", fm.PosID);
			cmd.Parameters.AddWithValue("@QualID", fm.QualID);
			cmd.Parameters.AddWithValue("@OrgID", fm.OrgID);
			cmd.Parameters.AddWithValue("@DeptID", fm.DeptID);
			cmd.Parameters.AddWithValue("@FaclImage", fm.FaclImage);
			cmd.Parameters.AddWithValue("@FaclIsActive", fm.FaclIsActive);
			int i = cmd.ExecuteNonQuery();
			con.Close();
			return i;
		}

		public static int DeleteFacl(int FaclID)
		{
			SqlConnection con = DBHelper.GetConnection();
			con.Open();
			SqlCommand cmd = new SqlCommand("Sp_DeleteFacl", con);
			cmd.CommandType = System.Data.CommandType.StoredProcedure;
			cmd.Parameters.AddWithValue("@FaclID", FaclID);
			int i = cmd.ExecuteNonQuery();
			con.Close();
			return i;
		}

	}
}
