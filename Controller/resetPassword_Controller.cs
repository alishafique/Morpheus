using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace Controller
{
    public class resetPassword_Controller
    {
        Connection con;
        public string _UserName;
        public string _Password;
        DataTable dt;
        String strQuery;
        SqlCommand cmd;
        public string ErrorString;
        public resetPassword_Controller()
        { }

        public DataTable spResetPasswordFunc(string username)
        {
            try
            {
                dt = new DataTable();
                con = new Connection();
                strQuery = "spResetPassword";
                cmd = new SqlCommand(strQuery);
                cmd.Parameters.Add("@UserName", SqlDbType.VarChar).Value = username;
                dt = con.GetDataUsingSp(cmd);
                if(dt != null)
                    return dt;
                else
                {
                    ErrorString = con.strError;
                    return null;
                }
            }
            catch(Exception ex)
            {
                ErrorString = ex.Message;
                return null;
            }
        }

        public bool _SendPasswordResetEmail(string _to, string UserName, string UniqueId)
        {
            try
            {
                if (Email.SendPasswordResetEmail(_to, UserName, UniqueId) == true)
                {
                    return true;
                }
                else
                {
                    ErrorString = Email.Error;
                    return false;
                }
            }
            catch(Exception ex)
            {
                ErrorString = ex.Message;
                return false;
            }
        }

        public DataTable checkResetPasswordLinkSent(int userid)
        {
            try
            {
                dt = new DataTable();
                con = new Connection();
                strQuery = "checkResetPasswordLinkSent";
                cmd = new SqlCommand(strQuery);
                cmd.Parameters.Add("@UserId", SqlDbType.BigInt).Value = userid;
                dt = con.GetDataUsingSp(cmd);
                if (dt != null)
                    return dt;
                else
                {
                    ErrorString = con.strError;
                    return null;
                }

            }
            catch(Exception ex)
            {
                ErrorString = ex.Message;
                return null;
            }
        }
        public DataTable getUserIDByUserName(string username)
        {
            try
            {
                dt = new DataTable();
                con = new Connection();
                strQuery = "getUserIDByUserName";
                cmd = new SqlCommand(strQuery);
                cmd.Parameters.Add("@username", SqlDbType.VarChar).Value = username;
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
