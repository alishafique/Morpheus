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
                cmd.Parameters.Add("@userID", SqlDbType.BigInt).Value = companyID;
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

        public bool AddEmployeeRoster(Roster empRoster)
        {
            try
            {
                con = new Connection();
                strQuery = "spManageRosterOfEmployee";
                cmd = new SqlCommand(strQuery);
                cmd.Parameters.Add("@Mode", SqlDbType.VarChar).Value = "Insert";
                cmd.Parameters.Add("@userid", SqlDbType.BigInt).Value = empRoster.CreatedByID;
                cmd.Parameters.Add("@AssignedEmployeeEmail", SqlDbType.VarChar).Value = empRoster.AssignedEmployeeEmail;
                cmd.Parameters.Add("@RosterDate", SqlDbType.DateTime).Value = empRoster.RosterDate;
                cmd.Parameters.Add("@RosterStartTime", SqlDbType.DateTime).Value = empRoster.RosterStartTime;
                cmd.Parameters.Add("@RosterEndTime", SqlDbType.DateTime).Value = empRoster.RosterEndTime;
                cmd.Parameters.Add("@RosterSite", SqlDbType.VarChar).Value = empRoster.RosterSite;
                cmd.Parameters.Add("@RosterTask", SqlDbType.VarChar).Value = empRoster.RosterTask;
                cmd.Parameters.Add("@ClientName", SqlDbType.VarChar).Value = empRoster.ClientName;
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

        public DataTable CheckEmployeeAvailbility(Roster obj)
        {
            try
            {
                dt = new DataTable();
                con = new Connection();
                strQuery = "spManageRosterOfEmployee";
                cmd = new SqlCommand(strQuery);
                cmd.Parameters.Add("@Mode", SqlDbType.VarChar).Value = "checkEmployeeAvailbility";
                cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = obj.AssignedEmployeeEmail;
                cmd.Parameters.Add("@RosterDate", SqlDbType.DateTime).Value = obj.RosterDate;
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

        public bool UpdateEmployeeRoster(Roster empRoster)
        {
            try
            {
                con = new Connection();
                strQuery = "spManageRosterOfEmployee";
                cmd = new SqlCommand(strQuery);
                cmd.Parameters.Add("@Mode", SqlDbType.VarChar).Value = "UpdateRosterShift";
                cmd.Parameters.Add("@AssignedEmployeeEmail", SqlDbType.VarChar).Value = empRoster.AssignedEmployeeEmail;
                cmd.Parameters.Add("@RosterDate", SqlDbType.DateTime).Value = empRoster.RosterDate;
                cmd.Parameters.Add("@RosterStartTime", SqlDbType.DateTime).Value = empRoster.RosterStartTime;
                cmd.Parameters.Add("@RosterEndTime", SqlDbType.DateTime).Value = empRoster.RosterEndTime;
                cmd.Parameters.Add("@RosterSite", SqlDbType.VarChar).Value = empRoster.RosterSite;
                cmd.Parameters.Add("@RosterTask", SqlDbType.VarChar).Value = empRoster.RosterTask;
                cmd.Parameters.Add("@RosterID", SqlDbType.UniqueIdentifier).Value = empRoster.RosterID;
                cmd.Parameters.Add("@ClientName", SqlDbType.VarChar).Value = empRoster.ClientName;
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

        public bool DeleteShift(Guid rosterID)
        {
            try
            {
                con = new Connection();
                strQuery = "spManageRosterOfEmployee";
                cmd = new SqlCommand(strQuery);
                cmd.Parameters.Add("@Mode", SqlDbType.VarChar).Value = "DELETESHIFT";
                cmd.Parameters.Add("@RosterID", SqlDbType.UniqueIdentifier).Value = rosterID;
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

        public DataTable GetEmpNameEmail(Guid RosterID)
        {
            try
            {
                dt = new DataTable();
                con = new Connection();
                strQuery = "spManageRosterOfEmployee";
                cmd = new SqlCommand(strQuery);
                cmd.Parameters.Add("@Mode", SqlDbType.VarChar).Value = "GetUserName";
                cmd.Parameters.Add("@RosterID", SqlDbType.UniqueIdentifier).Value = RosterID;
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

        public DataTable LoadClients(int userID)
        {
            try
            {
                dt = new DataTable();
                con = new Connection();
                strQuery = "spManageCompanyClient";
                cmd = new SqlCommand(strQuery);
                cmd.Parameters.Add("@Mode", SqlDbType.VarChar).Value = "View";
                cmd.Parameters.Add("@userID", SqlDbType.BigInt).Value = userID;
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
