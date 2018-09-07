using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    public class ViewIncidentReprots_Controller
    {
        DataTable dt;
        Connection con;
        SqlCommand cmd;
        String strQuery;
        public string ErrorString;
        public ViewIncidentReprots_Controller() { }

        public DataTable loadIncidentReportsByEmployee(int employeeId)
        {
            try
            {
                dt = new DataTable();
                con = new Connection();
                strQuery = "spLoadIncidentReportsByEmployee";
                cmd = new SqlCommand(strQuery);
                cmd.Parameters.Add("@reportedBy", SqlDbType.BigInt).Value = employeeId;
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


        public bool updateIncidentReportByEmployee(IncidentReport obj, int reportID)
        {
            try
            {
                con = new Connection();
                strQuery = "updateIncidentReportByEmployee";
                cmd = new SqlCommand(strQuery);
                cmd.Parameters.Add("@reportID", SqlDbType.BigInt).Value = reportID;
                cmd.Parameters.Add("@severitylevel", SqlDbType.VarChar).Value = obj.Severitylevel;
                cmd.Parameters.Add("@description", SqlDbType.VarChar).Value = obj.Description;
                cmd.Parameters.Add("@status", SqlDbType.VarChar).Value = obj.Status;
                cmd.Parameters.Add("@location", SqlDbType.VarChar).Value = obj.Location;
                cmd.Parameters.Add("@actionTaken", SqlDbType.VarChar).Value = obj.ActionTaken;
                cmd.Parameters.Add("@UpdatedbyId", SqlDbType.BigInt).Value = obj.ReportedBy;
                if (con.InsertUpdateDataUsingSp(cmd))
                    return true;
                else
                {
                    ErrorString = con.strError;
                    return false;
                }
            }
            catch(Exception ex)
            {
                ErrorString = ex.Message;
                return false;
            }

        }

        public DataTable loadImagesOfReport(int reportID)
        {

            try
            {
                dt = new DataTable();
                con = new Connection();
                strQuery = "loadImagesOfReport";
                cmd = new SqlCommand(strQuery);
                cmd.Parameters.Add("@incidentReportID", SqlDbType.BigInt).Value = reportID;
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
        public DataTable loadRptTypesByCompanyTypes(int userID)
        {
            try
            {
                dt = new DataTable();
                con = new Connection();
                strQuery = "spManageIncidentReportTypes";
                cmd = new SqlCommand(strQuery);
                cmd.Parameters.Add("@Mode", SqlDbType.VarChar).Value = "ViewIncidentReportTypesByCompanyType";
                cmd.Parameters.Add("@user_id", SqlDbType.BigInt).Value = userID;
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
