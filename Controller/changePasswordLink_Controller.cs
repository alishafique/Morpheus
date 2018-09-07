using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    public class changePasswordLink_Controller
    {
        Connection con;
        public string _UserName;
        public string _Password;
        DataTable dt;
        String strQuery;
        SqlCommand cmd;
        public string ErrorString;
        public changePasswordLink_Controller() { }

        public bool spIsPasswordResetLinkValid(string guid)
        {
            try
            {
                dt = new DataTable();
                con = new Connection();
                strQuery = "spIsPasswordResetLinkValid";
                cmd = new SqlCommand(strQuery);
                cmd.Parameters.Add("@GUID", SqlDbType.UniqueIdentifier).Value = Guid.Parse(guid);
                dt = con.GetDataUsingSp(cmd);
                if (dt != null)
                {
                    if (dt.Rows[0]["IsValidPasswordResetLink"].ToString() == "1")
                        return true;
                    else
                        return false;

                }
                else
                {
                    ErrorString = con.strError;
                    return false;
                }

            }
            catch(Exception ex)
            {
                ErrorString = ex.Message;
                return false;
            }
        }

        public DataTable spChangePassword(string uniqID, string password)
        {
            try
            {
                dt = new DataTable();
                con = new Connection();
                strQuery = "spChangePassword";
                cmd = new SqlCommand(strQuery);
                cmd.Parameters.Add("@GUID", SqlDbType.UniqueIdentifier).Value = Guid.Parse(uniqID);
                cmd.Parameters.Add("@Password", SqlDbType.VarChar).Value = password;
                dt = con.GetDataUsingSp(cmd);
                if (dt != null)
                    return dt;
                else
                {
                    ErrorString = con.strError;
                    return null;
                }
            }
            catch (Exception ex)
            {
                ErrorString = ex.Message;
                return null;
            }
        }

    }
}
