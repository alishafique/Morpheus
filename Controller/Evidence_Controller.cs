using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Controller;
using System.Data;
using System.Data.SqlClient;

namespace Controller
{
    public class Evidence_Controller
    {
        DataTable dt;
        Connection con;
        SqlCommand cmd;
        String strQuery;
        public string ErrorString;
        public Evidence_Controller()
        {
        }
        public int insertIncidentReport(Evidence objEvidence)
        {
            try
            {
                con = new Connection();
                strQuery = "insertEvidenceOfReport";
                cmd = new SqlCommand(strQuery);
                int val = 0;
                cmd.Parameters.Add("@incidentReportID", SqlDbType.BigInt).Value = objEvidence.IncidentID;
                cmd.Parameters.Add("@imageName", SqlDbType.VarChar).Value = objEvidence.FileName;
                val = con.InsertUpdateDataUsingSpWithReturn(cmd);
                return val;
            }
            catch (Exception ex)
            {
                ErrorString = ex.Message;
                return 0;
            }
        }
    }
}
