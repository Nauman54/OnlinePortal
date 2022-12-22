using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using ClassLibraryModel;

namespace ClassLibraryDAL
{
	public class ExpDAL
	{
		public static int SaveExp(ExpModel em)
		{
			SqlConnection con = DBHelper.GetConnection();
			con.Open();
			SqlCommand cmd = new SqlCommand("Sp_SaveExp", con);
			cmd.CommandType = System.Data.CommandType.StoredProcedure;
			cmd.Parameters.AddWithValue("@ExpTitle", em.ExpTitle);
			cmd.Parameters.AddWithValue("@Abbreviation", em.Abbreviation);
			int i = cmd.ExecuteNonQuery();
			con.Close();
			return i;
		}

		public static List<ExpModel> GetExp()
		{
			SqlConnection con = DBHelper.GetConnection();
			con.Open();
			SqlCommand cmd = new SqlCommand("Sp_GetExp", con);
			cmd.CommandType = System.Data.CommandType.StoredProcedure;

			SqlDataReader sdr = cmd.ExecuteReader();
			List<ExpModel> Explist = new List<ExpModel>();
			while (sdr.Read())
			{
				ExpModel exp = new ExpModel();
				exp.ExpID = int.Parse(sdr["ExpID"].ToString());
				exp.ExpTitle = sdr["ExpTitle"].ToString();
				exp.Abbreviation = sdr["Abbreviation"].ToString();
				Explist.Add(exp);
			}
			con.Close();
			return Explist;
		}

		public static int DeleteExp(int ExpID)
		{
			SqlConnection con = DBHelper.GetConnection();
			con.Open();
			SqlCommand cmd = new SqlCommand("Sp_DeleteExp", con);
			cmd.CommandType = System.Data.CommandType.StoredProcedure;
			cmd.Parameters.AddWithValue("@ExpID", ExpID);
			int i = cmd.ExecuteNonQuery();
			con.Close();
			return i;
		}
	}
}
