using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    public class createActivity_Controller
    {
        DataTable dt;
        Connection con;
        SqlCommand cmd;
        String strQuery;
        public string ErrorString;
        
        public createActivity_Controller()
        {

        }

        public bool createActivityByCompany(Activity obj)
        {
            try
            {
                con = new Connection();
                strQuery = "createActivityByCompany";
                cmd = new SqlCommand(strQuery);
                cmd.Parameters.Add("@CompanyCreatedID", SqlDbType.BigInt).Value = obj.companyCreatedID;
                cmd.Parameters.Add("@AssigneduserID", SqlDbType.BigInt).Value = obj.assigneduserID;
                cmd.Parameters.Add("@Activity_Name", SqlDbType.VarChar).Value = obj.activity_Name;
                cmd.Parameters.Add("@Activity_Location", SqlDbType.VarChar).Value = obj.activity_Location;
                cmd.Parameters.Add("@Activity_Type", SqlDbType.VarChar).Value = obj.activity_Type;
                cmd.Parameters.Add("@Activity_Description", SqlDbType.VarChar).Value = obj.activity_Description;
                cmd.Parameters.Add("@Activity_Status", SqlDbType.VarChar).Value = obj.activity_Status;
                cmd.Parameters.Add("@startDate", SqlDbType.VarChar).Value = obj.StartDate;
                cmd.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = obj.EndDate;
                cmd.Parameters.Add("@startTime", SqlDbType.VarChar).Value = obj.StartTime;
                cmd.Parameters.Add("@EndTime", SqlDbType.VarChar).Value = obj.EndTime;

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
    }
}
