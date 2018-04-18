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
   public class frmViewTimeSheet_Controller
    {
        DataTable dt;
        Connection con;
        SqlCommand cmd;
        String strQuery;
        public string ErrorString;
        public frmViewTimeSheet_Controller() { }

        public DataTable LoadAllEmployeesRoster(int companyID, DateTime startDate, DateTime EndDate)
        {
            try
            {
                dt = new DataTable();
                con = new Connection();
                strQuery = "spManageRosterOfEmployee";
                cmd = new SqlCommand(strQuery);
                cmd.Parameters.Add("@Mode", SqlDbType.VarChar).Value = "ViewAll";
                cmd.Parameters.Add("@userid", SqlDbType.BigInt).Value = companyID;
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

        public DataTable viewEmployeeByCompany(int comapnyId)
        {
            try
            {
                dt = new DataTable();
                con = new Connection();
                strQuery = "spManageTimeSheet";
                cmd = new SqlCommand(strQuery);
                cmd.Parameters.Add("@Mode", SqlDbType.VarChar).Value = "ViewEmployees";
                cmd.Parameters.Add("@createdByCompanyId", SqlDbType.BigInt).Value = comapnyId;
                
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

        public DataTable viewTimeSheetOfEmployee(int userID, int empID, DateTime startDt, DateTime endDt)
        {
            try
            {
                dt = new DataTable();
                con = new Connection();
                strQuery = "spManageTimeSheet";
                cmd = new SqlCommand(strQuery);
                cmd.Parameters.Add("@Mode", SqlDbType.VarChar).Value = "viewTimeSheet";
                cmd.Parameters.Add("@userid", SqlDbType.BigInt).Value = userID;
                cmd.Parameters.Add("@AssignedEmployeeID", SqlDbType.BigInt).Value = empID;
                cmd.Parameters.Add("@DateRangeStart", SqlDbType.Date).Value = startDt;
                cmd.Parameters.Add("@DateRangeEnd", SqlDbType.Date).Value = endDt;
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

        public bool SendRosterNotificationToEmployee(string _to, string _name, string StartDate, string endDate, List<string> shifts)
        {
            try
            {
                if (Email.RosterNotificationToEmployee(_to, _name, StartDate, endDate, shifts))
                    return true;
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
    }
}
