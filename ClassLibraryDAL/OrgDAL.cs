using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using ClassLibraryModel;
using System.Security.Cryptography;

namespace ClassLibraryDAL
{
	public class OrgDAL
	{
		public static int SaveOrg(OrgModel om)
		{
			SqlConnection con = DBHelper.GetConnection();
			con.Open();
			SqlCommand cmd = new SqlCommand("Sp_SaveOrg", con);
			cmd.CommandType = System.Data.CommandType.StoredProcedure;
			cmd.Parameters.AddWithValue("@OrgName", om.OrgName);
			cmd.Parameters.AddWithValue("@OrgAddress", om.OrgAddress);
			cmd.Parameters.AddWithValue("@OrgPhoneNo", om.OrgPhoneNo);
			cmd.Parameters.AddWithValue("@OrgEmail", om.OrgEmail);
			int i = cmd.ExecuteNonQuery();
			con.Close();
			return i;
		}

		public static List<OrgModel> GetOrg()
		{
			SqlConnection con = DBHelper.GetConnection();
			con.Open();
			SqlCommand cmd = new SqlCommand("Sp_GetOrg", con);
			cmd.CommandType = System.Data.CommandType.StoredProcedure;

			SqlDataReader sdr = cmd.ExecuteReader();
			List<OrgModel> Orglist = new List<OrgModel>();
			while (sdr.Read())
			{
				OrgModel org = new OrgModel();
				org.OrgID = int.Parse(sdr["OrgID"].ToString());
				org.OrgName = sdr["OrgName"].ToString();
				org.OrgAddress = sdr["OrgAddress"].ToString();
				org.OrgPhoneNo = sdr["OrgPhoneNo"].ToString();
				org.OrgEmail = sdr["OrgEmail"].ToString();
				Orglist.Add(org);
			}

			con.Close();
			return Orglist;
		}

		public static List<OrgModel> GetOrgByID(int OrgID)
		{
			SqlConnection con = DBHelper.GetConnection();
			con.Open();
			SqlCommand cmd = new SqlCommand("Sp_GetOrgByID", con);
			cmd.CommandType = System.Data.CommandType.StoredProcedure;
			cmd.Parameters.AddWithValue("@OrgID", OrgID);

			SqlDataReader sdr = cmd.ExecuteReader();
			List<OrgModel> Orglist = new List<OrgModel>();
			while (sdr.Read())
			{
				OrgModel org = new OrgModel();
				org.OrgName = sdr["OrgName"].ToString();
				org.OrgAddress = sdr["OrgAddress"].ToString();
				org.OrgPhoneNo = sdr["OrgPhoneNo"].ToString();
				org.OrgEmail = sdr["OrgEmail"].ToString();
				Orglist.Add(org);
			}
			con.Close();
			return Orglist;
		}

		public static int EditOrg(OrgModel om)
		{
			SqlConnection con = DBHelper.GetConnection();
			con.Open();
			SqlCommand cmd = new SqlCommand("Sp_EditOrg", con);
			cmd.CommandType = System.Data.CommandType.StoredProcedure;
			cmd.Parameters.AddWithValue("@OrgID", om.OrgID);
			cmd.Parameters.AddWithValue("@OrgName", om.OrgName);
			cmd.Parameters.AddWithValue("@OrgAddress", om.OrgAddress);
			cmd.Parameters.AddWithValue("@OrgPhoneNo", om.OrgPhoneNo);
			cmd.Parameters.AddWithValue("@OrgEmail", om.OrgEmail);
			int i = cmd.ExecuteNonQuery();
			con.Close();
			return i;
		}

		public static int DeleteOrg(int OrgID)
		{
			SqlConnection con = DBHelper.GetConnection();
			con.Open();
			SqlCommand cmd = new SqlCommand("Sp_DeleteOrg", con);
			cmd.CommandType = System.Data.CommandType.StoredProcedure;
			cmd.Parameters.AddWithValue("@OrgID", OrgID);
			int i = cmd.ExecuteNonQuery();
			con.Close();
			return i;
		}
	}
}


