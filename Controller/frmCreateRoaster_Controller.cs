using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    public class frmCreateRoaster_Controller
    {
        DataTable dt;
        Connection con;
        SqlCommand cmd;
        String strQuery;
        public string ErrorString;
        public frmCreateRoaster_Controller(){}


        public DataTable listEmployeesByCompany(int userID)
        {
            try
            {
                dt = new DataTable();
                con = new Connection();
                strQuery = "listEmployeesByCompany";
                cmd = new SqlCommand(strQuery);
                cmd.Parameters.Add("@userid", SqlDbType.BigInt).Value = userID;
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

        public DataTable LoadSites(int companyID)
        {
            try
            {
                dt = new DataTable();
                con = new Connection();
                strQuery = "spManagelocations";
                cmd = new SqlCommand(strQuery);
                cmd.Parameters.Add("@Mode", SqlDbType.VarChar).Value = "View";
                cmd.Parameters.Add("@LocationCompanyID", SqlDbType.BigInt).Value = companyID;
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
