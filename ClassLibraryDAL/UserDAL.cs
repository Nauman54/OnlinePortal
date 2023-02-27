using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using ClassLibraryModel;

namespace ClassLibraryDAL
{
	public class UserDAL
	{
		public static int SaveUser(UserModel um)
		{
			SqlConnection con = DBHelper.GetConnection();
			con.Open();
			SqlCommand cmd = new SqlCommand("Sp_SaveUser", con);
			cmd.CommandType = System.Data.CommandType.StoredProcedure;
			cmd.Parameters.AddWithValue("@UserEmail", um.UserEmail);
			cmd.Parameters.AddWithValue("@UserPassword", um.UserPassword);
			cmd.Parameters.AddWithValue("@RoleID", um.RoleID);
			cmd.Parameters.AddWithValue("@UserIsActive", um.UserIsActive);
			int i = cmd.ExecuteNonQuery();
			con.Close();
			return i;
		}

        public static List<UserModel> GetUser()
        {
            SqlConnection con = DBHelper.GetConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("Sp_GetUser", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            SqlDataReader sdr = cmd.ExecuteReader();
            List<UserModel> Usrlist = new List<UserModel>();
            while (sdr.Read())
            {
                UserModel usr = new UserModel();
                usr.UserID = int.Parse(sdr["UserID"].ToString());
                usr.UserEmail = sdr["UserEmail"].ToString();
                usr.UserPassword = sdr["UserPassword"].ToString();
                usr.RoleName = sdr["RoleName"].ToString();
                usr.UserIsActive = bool.Parse(sdr["UserIsActive"].ToString());
                Usrlist.Add(usr);
            }
            con.Close();
            return Usrlist;
        }

        public static List<UserModel> GetUserByID(int UserID)
		{
			SqlConnection con = DBHelper.GetConnection();
			con.Open();
			SqlCommand cmd = new SqlCommand("Sp_GetUserByID", con);
			cmd.CommandType = System.Data.CommandType.StoredProcedure;
			cmd.Parameters.AddWithValue("@UserID", UserID);

			SqlDataReader sdr = cmd.ExecuteReader();
			List<UserModel> Usrlist = new List<UserModel>();
			while (sdr.Read())
			{
				UserModel usr = new UserModel();
				usr.UserEmail = sdr["UserEmail"].ToString();
				usr.UserPassword = sdr["UserPassword"].ToString();
				usr.RoleID = int.Parse(sdr["RoleID"].ToString());
				usr.UserIsActive = bool.Parse(sdr["UserIsActive"].ToString());
				Usrlist.Add(usr);
			}
			con.Close();
			return Usrlist;
		}

		public static int EditUser(UserModel um)
		{
			SqlConnection con = DBHelper.GetConnection();
			con.Open();
			SqlCommand cmd = new SqlCommand("Sp_EditUser", con);
			cmd.CommandType = System.Data.CommandType.StoredProcedure;
			cmd.Parameters.AddWithValue("@UserID",	um.UserID);
			cmd.Parameters.AddWithValue("@UserEmail", um.UserEmail);
			cmd.Parameters.AddWithValue("@UserPassword", um.UserPassword);
			cmd.Parameters.AddWithValue("@RoleID", um.RoleID);
			cmd.Parameters.AddWithValue("@UserIsActive", um.UserIsActive);
			int i = cmd.ExecuteNonQuery();
			con.Close();
			return i;
		}

		public static int DeleteUser(int UserID)
		{
			SqlConnection con = DBHelper.GetConnection();
			con.Open();
			SqlCommand cmd = new SqlCommand("Sp_DeleteUser", con);
			cmd.CommandType = System.Data.CommandType.StoredProcedure;
			cmd.Parameters.AddWithValue("@UserID", UserID);
			int i = cmd.ExecuteNonQuery();
			con.Close();
			return i;
		}
	}
}
