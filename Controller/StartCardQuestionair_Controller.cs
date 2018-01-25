using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
   public class StartCardQuestionair_Controller
    {
        Connection con;
        DataTable dt;
        String strQuery;
        SqlCommand cmd;
        public string _errorMsg = string.Empty;
        public StartCardQuestionair_Controller()
        {

        }

        public bool StartActivity(int ActivityId, int CreatedByCompanyID, string ActivityResult, string FormLocation, string Activity_Status, DateTime ActivityStartedDate)
        {
            try
            {
                con = new Connection();
                strQuery = "spStartActivity";
                cmd = new SqlCommand(strQuery);
                cmd.Parameters.Add("@ActivityId", SqlDbType.BigInt).Value = ActivityId;
                //cmd.Parameters.Add("@CreatedByCompanyID", SqlDbType.BigInt).Value = CreatedByCompanyID;
                cmd.Parameters.Add("@ActivityResult", SqlDbType.VarChar).Value = ActivityResult;
                cmd.Parameters.Add("@FormLocation", SqlDbType.VarChar).Value = FormLocation;
                cmd.Parameters.Add("@Activity_Status", SqlDbType.VarChar).Value = Activity_Status;
                cmd.Parameters.Add("@ActivityStartedDate", SqlDbType.DateTime).Value = ActivityStartedDate;
                           
                if (con.InsertUpdateDataUsingSp(cmd))
                {
                    return true;
                }
                else
                {
                    _errorMsg = con.strError;
                    return false;
                }
              
            }
            catch(Exception ex)
            {
                _errorMsg = ex.Message;
                return false;
            }
        }
    }
}
