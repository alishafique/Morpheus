using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    public class viewEditCompanyIncidentReports_Controller
    {
        DataTable dt;
        Connection con;
        SqlCommand cmd;
        String strQuery;
        public string ErrorString;

        public viewEditCompanyIncidentReports_Controller() { }

        public DataTable loadIncidentReportsByCompany(int userID)
        {
            try
            {
                dt = new DataTable();
                con = new Connection();
                strQuery = "spLoadIncidentReportsByCompany";
                cmd = new SqlCommand(strQuery);
                cmd.Parameters.Add("@reportedTo", SqlDbType.BigInt).Value = userID;
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

        public DataTable LoadSubContractors(int CompanyId)
        {
            try
            {
                dt = new DataTable();
                con = new Connection();
                strQuery = "spViewContractorList";
                cmd = new SqlCommand(strQuery);
                cmd.Parameters.Add("@CreatedByCompany", SqlDbType.BigInt).Value = CompanyId;
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

        public bool UpdateIncidentReportStatus(int ReportID,int UpdatedbyId)
        {
            try
            {
                con = new Connection();
                strQuery = "spUpdateIncidentReportStatus";
                cmd = new SqlCommand(strQuery);
                cmd.Parameters.Add("@id", SqlDbType.BigInt).Value = ReportID;
                cmd.Parameters.Add("@status", SqlDbType.VarChar).Value = "Seen";
                cmd.Parameters.Add("@UpdatedbyId", SqlDbType.BigInt).Value = UpdatedbyId;
                if (con.InsertUpdateDataUsingSp(cmd) == true)
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

        public DataTable LoadReport(int reportID, int ReportedTo)
        {
            try
            {
                dt = new DataTable();
                con = new Connection();
                strQuery = "spLoadReport";
                cmd = new SqlCommand(strQuery);
                cmd.Parameters.Add("@ReportedTo", SqlDbType.BigInt).Value = ReportedTo;
                cmd.Parameters.Add("@ReportID", SqlDbType.BigInt).Value = reportID;

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
