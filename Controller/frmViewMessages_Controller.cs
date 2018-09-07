using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    public class frmViewMessages_Controller
    {

        Connection con;
        DataTable dt;
        String strQuery;
        SqlCommand cmd;
        public string ErrorString;
        public frmViewMessages_Controller() { }

        public DataTable ViewContactUsMessages()
        {
            try
            {
                dt = new DataTable();
                con = new Connection();
                strQuery = "spViewContactUsMessages";
                cmd = new SqlCommand(strQuery);
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

    }
}
