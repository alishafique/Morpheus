using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Controller;
using System.Data;
using System.Data.SqlClient;

namespace Controller
{
    public class reportIncident_Controller
    {
        DataTable dt;
        Connection con;
        SqlCommand cmd;
        String strQuery;
        public string ErrorString;
        public reportIncident_Controller()
        {
        }
        public int insertIncidentReport(IncidentReport objIncidentReport)
        {
            try
            {
                con = new Connection();
                strQuery = "insertIncidentReport";
                cmd = new SqlCommand(strQuery);
                int val = 0;
                cmd.Parameters.Add("@reportedBy", SqlDbType.BigInt).Value = objIncidentReport.ReportedBy;
                cmd.Parameters.Add("@reportedTo", SqlDbType.BigInt).Value = objIncidentReport.ReportedTo;
                cmd.Parameters.Add("@severitylevel", SqlDbType.VarChar).Value = objIncidentReport.Severitylevel;
                cmd.Parameters.Add("@description", SqlDbType.VarChar).Value = objIncidentReport.Description;
                cmd.Parameters.Add("@status", SqlDbType.VarChar).Value = objIncidentReport.Status;
                cmd.Parameters.Add("@dateTime", SqlDbType.DateTime).Value = objIncidentReport.reportDateTime;
                cmd.Parameters.Add("@location", SqlDbType.VarChar).Value = objIncidentReport.Location;
                cmd.Parameters.Add("@actionTaken", SqlDbType.VarChar).Value = objIncidentReport.ActionTaken;
                cmd.Parameters.Add("@incidenteportedLocation", SqlDbType.VarChar).Value = objIncidentReport.ReportedLocation;
                val = con.InsertUpdateDataUsingSpWithReturn(cmd);
                if (val != 0)
                    return val;
                else
                {
                    ErrorString = con.strError;
                    return val;
                }

            }
            catch (Exception ex)
            {
                ErrorString = ex.Message;
                return 0;
            }
        }

        public DataTable selectReportedToIncidentId(int userdid)
        {
            try
            {
                dt = new DataTable();
                con = new Connection();
                strQuery = "selectReportedToIncidentId";
                cmd = new SqlCommand(strQuery);
                cmd.Parameters.Add("@userid", SqlDbType.BigInt).Value = userdid;
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
            catch(Exception ex)
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
