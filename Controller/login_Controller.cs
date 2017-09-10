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
        public login_Controller()
        {
        }

        public DataTable Validate_User()
        {
            
            dt = new DataTable();
            objCon = new Connection();
            strQuery = "select * from user_name where user_name = @usr and password = @psw";
            cmd = new SqlCommand(strQuery);
            cmd.Parameters.AddWithValue("@usr", _UserName.Trim());
            cmd.Parameters.AddWithValue("@psw", _Password.Trim());
            dt = objCon.GetData(cmd);
            return dt;
        }
    }
}
