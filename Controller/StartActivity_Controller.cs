using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
   public class StartActivity_Controller
    {
        Connection con;
        DataTable dt;
        String strQuery;
        SqlCommand cmd;
        public string ErrorString;
        public StartActivity_Controller() { }


        public DataTable LoadActivityOfToday(int empUId)
        {
            try
            {
                dt = new DataTable();
                con = new Connection();
                strQuery = "spManageActivity";
                cmd = new SqlCommand(strQuery);
                cmd.Parameters.Add("@Mode", SqlDbType.VarChar).Value = "LoadTodaysActivity";
                cmd.Parameters.Add("@AssigneduserID", SqlDbType.BigInt).Value = empUId;
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
