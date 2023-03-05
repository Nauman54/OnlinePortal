using ClassLibraryModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryDAL
{
    public class StdGroupDAL
    {
		public static int SaveSGroup(StdGroupModel sg)
		{
			SqlConnection con = DBHelper.GetConnection();
			con.Open();
			SqlCommand cmd = new SqlCommand("Sp_SaveSGroup", con);
			cmd.CommandType = System.Data.CommandType.StoredProcedure;
			cmd.Parameters.AddWithValue("@SgName", sg.SgName);
			cmd.Parameters.AddWithValue("@StdID", sg.StdID);
			cmd.Parameters.AddWithValue("@SgIsActive", sg.SgIsActive);
			int i = cmd.ExecuteNonQuery();
			con.Close();
			return i;
		}

		public static List<StdGroupModel> GetSGroupByStd(int StdID)
		{
			SqlConnection con = DBHelper.GetConnection();
			con.Open();
			SqlCommand cmd = new SqlCommand("Sp_GetSGroupByStd", con);
			cmd.CommandType = System.Data.CommandType.StoredProcedure;
			cmd.Parameters.AddWithValue("@StdID", StdID);

			SqlDataReader sdr = cmd.ExecuteReader();
			List<StdGroupModel> stdGroupList = new List<StdGroupModel>();
			while (sdr.Read())
			{
				StdGroupModel stdGroup = new StdGroupModel();
				stdGroup.SgID = int.Parse(sdr["SgID"].ToString());
				stdGroup.SgName = sdr["SgName"].ToString();
				stdGroup.StdFirstName = sdr["StdFirstName"].ToString();
				stdGroup.StdLastName = sdr["StdLastName"].ToString();
				stdGroup.SgIsActive = bool.Parse(sdr["SgIsActive"].ToString());
				stdGroupList.Add(stdGroup);
			}

			con.Close();
			return stdGroupList;
		}

		public static List<StdGroupModel> GetSGroupByID(int SgID)
		{
			SqlConnection con = DBHelper.GetConnection();
			con.Open();
			SqlCommand cmd = new SqlCommand("Sp_GetSGroupByID", con);
			cmd.CommandType = System.Data.CommandType.StoredProcedure;
			cmd.Parameters.AddWithValue("@SgID", SgID);

			SqlDataReader sdr = cmd.ExecuteReader();
			List<StdGroupModel> stdGroupList = new List<StdGroupModel>();
			while (sdr.Read())
			{
				StdGroupModel stdGroup = new StdGroupModel();
				stdGroup.SgName = sdr["SgName"].ToString();
                stdGroup.StdID = int.Parse(sdr["StdID"].ToString());
                stdGroup.SgIsActive = bool.Parse(sdr["SgIsActive"].ToString());
				stdGroupList.Add(stdGroup);
			}

			con.Close();
			return stdGroupList;
		}

		public static int EditSGroup(StdGroupModel sg)
		{
			SqlConnection con = DBHelper.GetConnection();
			con.Open();
			SqlCommand cmd = new SqlCommand("Sp_EditSGroup", con);
			cmd.CommandType = System.Data.CommandType.StoredProcedure;
			cmd.Parameters.AddWithValue("@SgID", sg.SgID);
			cmd.Parameters.AddWithValue("@SgName", sg.SgName);
			cmd.Parameters.AddWithValue("@StdID", sg.StdID);
			cmd.Parameters.AddWithValue("@SgIsActive", sg.SgIsActive);
			int i = cmd.ExecuteNonQuery();
			con.Close();
			return i;
		}

		public static int DeleteSGroup(int SgID)
		{
			SqlConnection con = DBHelper.GetConnection();
			con.Open();
			SqlCommand cmd = new SqlCommand("Sp_DeleteSGroup", con);
			cmd.CommandType = System.Data.CommandType.StoredProcedure;
			cmd.Parameters.AddWithValue("@SgID", SgID);
			int i = cmd.ExecuteNonQuery();
			con.Close();
			return i;
		}
	}
}
