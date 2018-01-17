using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Controller;
using System.Data;
using System.Data.SqlClient;


namespace Controller
{
    public class login_Controller
    {
        Connection objCon;
        public string _UserName;
        public string _Password;
        DataTable dt;
        String strQuery;
        SqlCommand cmd;
        public string _errorMsg = string.Empty;
        public login_Controller()
        {
        }

        public DataTable Validate_User()
        {
            try
            {
                dt = new DataTable();
                objCon = new Connection();
                strQuery = "select * from user_name where user_name = @usr and password = @psw";
                cmd = new SqlCommand(strQuery);
                cmd.Parameters.AddWithValue("@usr", _UserName.Trim());
                cmd.Parameters.AddWithValue("@psw", _Password.Trim());
                dt = objCon.GetData(cmd);
                if (dt != null)
                    return dt;
                else
                {
                    _errorMsg = objCon.strError;
                    return null;
                }
            }
            catch(Exception ex)
            {
                _errorMsg = ex.Message;
                return null;
            }
        }
    }
}
