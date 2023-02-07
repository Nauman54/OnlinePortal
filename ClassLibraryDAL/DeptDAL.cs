using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using ClassLibraryModel;

namespace ClassLibraryDAL
{
	public class DeptDAL
	{
		public static int SaveDept(DeptModel dm)
		{
			SqlConnection con = DBHelper.GetConnection();
			con.Open();
			SqlCommand cmd = new SqlCommand("Sp_SaveDept", con);
			cmd.CommandType = System.Data.CommandType.StoredProcedure;
			cmd.Parameters.AddWithValue("@DeptName", dm.DeptName);
			cmd.Parameters.AddWithValue("@OrgID", dm.OrgID);
			int i = cmd.ExecuteNonQuery();
			con.Close();
			return i;
		}

		public static List<DeptModel> GetDept()
		{
			SqlConnection con = DBHelper.GetConnection();
			con.Open();
			SqlCommand cmd = new SqlCommand("Sp_GetDept", con);
			cmd.CommandType = System.Data.CommandType.StoredProcedure;

			SqlDataReader sdr = cmd.ExecuteReader();
			List<DeptModel> Deptlist = new List<DeptModel>();
			while (sdr.Read())
			{
				DeptModel dept = new DeptModel();
				dept.DeptID = int.Parse(sdr["DeptID"].ToString());
				dept.DeptName = sdr["DeptName"].ToString();
				dept.OrgID = int.Parse(sdr["OrgID"].ToString());
				Deptlist.Add(dept);
			}

			con.Close();
			return Deptlist;
		}

		public static int EditDept(DeptModel dm)
		{
			SqlConnection con = DBHelper.GetConnection();
			con.Open();
			SqlCommand cmd = new SqlCommand("Sp_EditDept", con);
			cmd.CommandType = System.Data.CommandType.StoredProcedure;
			cmd.Parameters.AddWithValue("@DeptID", dm.DeptID);
			cmd.Parameters.AddWithValue("@DeptName", dm.DeptName);
			cmd.Parameters.AddWithValue("@OrgID", dm.OrgID);
			int i = cmd.ExecuteNonQuery();
			con.Close();
			return i;
		}

		public static int DeleteDept(int DeptID)
		{
			SqlConnection con = DBHelper.GetConnection();
			con.Open();
			SqlCommand cmd = new SqlCommand("Sp_DeleteDept", con);
			cmd.CommandType = System.Data.CommandType.StoredProcedure;
			cmd.Parameters.AddWithValue("@DeptID", DeptID);
			int i = cmd.ExecuteNonQuery();
			con.Close();
			return i;
		}
	}
}
