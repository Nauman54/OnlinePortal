using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using ClassLibraryModel;

namespace ClassLibraryDAL
{
    public class RoleDAL
    {
        public static int SaveRoles(RoleModel rm)
        {
            SqlConnection con = DBHelper.GetConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("Sp_SaveRoles", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@RoleName", rm.RoleName);
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;
        }

        public static List<RoleModel> GetRoles()
        {
            SqlConnection con = DBHelper.GetConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("Sp_GetRoles", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            SqlDataReader sdr = cmd.ExecuteReader();
            List<RoleModel> Rolelist = new List<RoleModel>();
            while (sdr.Read())
            {
                RoleModel role = new RoleModel();
                role.RoleID = int.Parse(sdr["RoleID"].ToString());
                role.RoleName = sdr["RoleName"].ToString();
                Rolelist.Add(role);
            }
            con.Close();
            return Rolelist;
        }

        public static List<RoleModel> GetRolesByID(int RoleID)
        {
            SqlConnection con = DBHelper.GetConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("Sp_GetRolesByID", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@RoleID", RoleID);

            SqlDataReader sdr = cmd.ExecuteReader();
            List<RoleModel> Rolelist = new List<RoleModel>();
            while (sdr.Read())
            {
                RoleModel role = new RoleModel();
                role.RoleName = sdr["RoleName"].ToString();
                Rolelist.Add(role);
            }
            con.Close();
            return Rolelist;
        }

        public static int EditRoles(RoleModel rm)
        {
            SqlConnection con = DBHelper.GetConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("Sp_EditRoles", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@RoleID", rm.RoleID);
            cmd.Parameters.AddWithValue("@RoleName", rm.RoleName);
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;
        }

        public static int DeleteRoles(int RoleID)
        {
            SqlConnection con = DBHelper.GetConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("Sp_DeleteRoles", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@RoleID", RoleID);
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;
        }
    }
}
