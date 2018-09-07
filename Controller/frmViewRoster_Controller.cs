using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    public class frmViewRoster_Controller
    {
        DataTable dt;
        Connection con;
        SqlCommand cmd;
        String strQuery;
        public string ErrorString;
        public frmViewRoster_Controller()
        {

        }

        public DataTable LoadEmployeeRoster(int userID, DateTime startDate, DateTime EndDate)
        {
            try
            {
                dt = new DataTable();
                con = new Connection();
                strQuery = "spManageRosterOfEmployee";
                cmd = new SqlCommand(strQuery);
                cmd.Parameters.Add("@Mode", SqlDbType.VarChar).Value = "ViewEmployeeShifts";
                cmd.Parameters.Add("@userid", SqlDbType.BigInt).Value = userID;
                cmd.Parameters.Add("@DateRangeStart", SqlDbType.Date).Value = startDate;
                cmd.Parameters.Add("@DateRangeEnd", SqlDbType.Date).Value = EndDate;
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

        public bool UpdateEmployeeRoster(Guid rosterID, string rosterStatus)
        {
            try
            {
                con = new Connection();
                strQuery = "spManageRosterOfEmployee";
                cmd = new SqlCommand(strQuery);
                cmd.Parameters.Add("@Mode", SqlDbType.VarChar).Value = "UpdateRosterStatusByEmployee";
                cmd.Parameters.Add("@RosterID", SqlDbType.UniqueIdentifier).Value = rosterID;
                cmd.Parameters.Add("@RStatus", SqlDbType.VarChar).Value = rosterStatus;
                if (con.InsertUpdateDataUsingSp(cmd) == true)
                    return true;
                else
                {
                    ErrorString = con.strError;
                    return false;
                }
            }
            catch (Exception ex)
            {
                ErrorString = ex.Message;
                return false;
            }
        }
    }
}
