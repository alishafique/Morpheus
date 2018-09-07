using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Data;
using System.Data.SqlClient;

namespace Controller
{
   public class viewEmployeeActivity_Controller
    {
        DataTable dt;
        Connection con;
        SqlCommand cmd;
        String strQuery;
        public string ErrorString;
        public viewEmployeeActivity_Controller() { }

        public DataTable viewEmployeeActivities(int empID)
        {
            try
            {
                dt = new DataTable();
                con = new Connection();
                strQuery = "spManageActivity";
                cmd = new SqlCommand(strQuery);
                cmd.Parameters.Add("@Mode", SqlDbType.VarChar).Value = "viewEmployeeActivities";
                cmd.Parameters.Add("@AssigneduserID", SqlDbType.BigInt).Value = empID;
                dt = con.GetDataUsingSp(cmd);
                if (dt != null)
                {
                    return dt;
                }
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
