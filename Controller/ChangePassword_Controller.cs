using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
  public class ChangePassword_Controller
    {
        Connection con;
        DataTable dt;
        String strQuery;
        SqlCommand cmd;
        string ErrorString;
        public ChangePassword_Controller() { }


        public bool updateCompanyPassword(int userID, string username, string newpass, string oldpass)
        {
            try
            {
                int val = 0;
                con = new Connection();
                strQuery = "updateCompanyPassword";
                cmd = new SqlCommand(strQuery);
                cmd.Parameters.Add("@userId", SqlDbType.BigInt).Value = userID;
                cmd.Parameters.Add("@username", SqlDbType.VarChar).Value = username;
                cmd.Parameters.Add("@currentPassword", SqlDbType.VarChar).Value = oldpass;
                cmd.Parameters.Add("@Newpassword", SqlDbType.VarChar).Value = newpass;
                val = con.InsertUpdateDataUsingSpWithReturn(cmd);
                if (val == 1)
                {
                    return true;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                ErrorString = ex.Message;
                return false;
            }
        }
    }
}
