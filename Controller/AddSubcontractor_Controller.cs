using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    public class AddSubcontractor_Controller
    {
        DataTable dt;
        Connection con;
        SqlCommand cmd;
        String strQuery;
        public string ErrorString;
        public AddSubcontractor_Controller() { }
        public DataTable loadMemberShipPlanes()
        {
            try
            {
                dt = new DataTable();
                con = new Connection();
                strQuery = "sploadMemberShipPlanes";
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

        public DataTable LoadCompanyTypes()
        {
            try
            {
                dt = new DataTable();
                con = new Connection();
                strQuery = "spLoadCompanyTypes";
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
            catch (Exception ex)
            {
                ErrorString = ex.Message;
                return null;
            }
        }

    }
}
