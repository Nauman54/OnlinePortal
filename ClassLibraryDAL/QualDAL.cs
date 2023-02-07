using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using ClassLibraryModel;

namespace ClassLibraryDAL
{
	public class QualDAL
	{
		public static int SaveQual(QualModel qm)
		{
			SqlConnection con = DBHelper.GetConnection();
			con.Open();
			SqlCommand cmd = new SqlCommand("Sp_SaveQual", con);
			cmd.CommandType = System.Data.CommandType.StoredProcedure;
			cmd.Parameters.AddWithValue("@QualTitle", qm.QualTitle);
			int i = cmd.ExecuteNonQuery();
			con.Close();
			return i;
		}

		public static List<QualModel> GetQual()
		{
			SqlConnection con = DBHelper.GetConnection();
			con.Open();
			SqlCommand cmd = new SqlCommand("Sp_GetQual", con);
			cmd.CommandType = System.Data.CommandType.StoredProcedure;

			SqlDataReader sdr = cmd.ExecuteReader();
			List<QualModel> Quallist = new List<QualModel>();
			while (sdr.Read())
			{
				QualModel qual = new QualModel();
				qual.QualID = int.Parse(sdr["QualID"].ToString());
				qual.QualTitle = sdr["QualTitle"].ToString();
				Quallist.Add(qual);
			}
			con.Close();
			return Quallist;
		}

        public static List<QualModel> GetQualByID(int QualID)
        {
            SqlConnection con = DBHelper.GetConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("Sp_GetQualByID", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@QualID", QualID);

            SqlDataReader sdr = cmd.ExecuteReader();
            List<QualModel> Quallist = new List<QualModel>();
            while (sdr.Read())
            {
                QualModel qual = new QualModel();
                qual.QualTitle = sdr["QualTitle"].ToString();
                Quallist.Add(qual);
            }
            con.Close();
            return Quallist;
        }

        public static int EditQual(QualModel qm)
		{
			SqlConnection con = DBHelper.GetConnection();
			con.Open();
			SqlCommand cmd = new SqlCommand("Sp_EditQual", con);
			cmd.CommandType = System.Data.CommandType.StoredProcedure;
			cmd.Parameters.AddWithValue("@QualID", qm.QualID);
			cmd.Parameters.AddWithValue("@QualTitle", qm.QualTitle);
			int i = cmd.ExecuteNonQuery();
			con.Close();
			return i;
		}

		public static int DeleteQual(int QualID)
		{
			SqlConnection con = DBHelper.GetConnection();
			con.Open();
			SqlCommand cmd = new SqlCommand("Sp_DeleteQual", con);
			cmd.CommandType = System.Data.CommandType.StoredProcedure;
			cmd.Parameters.AddWithValue("@QualID", QualID);
			int i = cmd.ExecuteNonQuery();
			con.Close();
			return i;
		}
	}
}
