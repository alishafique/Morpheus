using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
   public class StartActivity_Controller
    {
        Connection con;
        DataTable dt;
        String strQuery;
        SqlCommand cmd;
        public string ErrorString;
        public StartActivity_Controller() { }


        public DataTable LoadActivityOfToday(int empUId)
        {
            try
            {
                dt = new DataTable();
                con = new Connection();
                strQuery = "spManageActivity";
                cmd = new SqlCommand(strQuery);
                cmd.Parameters.Add("@Mode", SqlDbType.VarChar).Value = "LoadTodaysActivity";
                cmd.Parameters.Add("@AssigneduserID", SqlDbType.BigInt).Value = empUId;
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
        public bool StartActivity(int ActivityId, string ActivityResult, string FormLocation, string Activity_Status, string CLoc)
        {
            try
            {
                con = new Connection();
                strQuery = "spManageActivity";
                cmd = new SqlCommand(strQuery);
                cmd.Parameters.Add("@Mode", SqlDbType.VarChar).Value = "StartActivity";
                cmd.Parameters.Add("@ActivityId", SqlDbType.BigInt).Value = ActivityId;
                cmd.Parameters.Add("@ActivityResult", SqlDbType.VarChar).Value = ActivityResult;
                cmd.Parameters.Add("@FormLocation", SqlDbType.VarChar).Value = FormLocation;
                cmd.Parameters.Add("@Activity_Status", SqlDbType.VarChar).Value = Activity_Status;
                cmd.Parameters.Add("@CurrentLocation", SqlDbType.VarChar).Value = CLoc;
                if (con.InsertUpdateDataUsingSp(cmd))
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

        public bool EndActivity(int ActivityId, string Activity_Status)
        {
            try
            {
                con = new Connection();
                strQuery = "spManageActivity";
                cmd = new SqlCommand(strQuery);
                cmd.Parameters.Add("@Mode", SqlDbType.VarChar).Value = "ENDACTIVITY";
                cmd.Parameters.Add("@ActivityId", SqlDbType.BigInt).Value = ActivityId;
                cmd.Parameters.Add("@Activity_Status", SqlDbType.VarChar).Value = Activity_Status;
                if (con.InsertUpdateDataUsingSp(cmd))
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
