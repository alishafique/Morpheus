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
    public class createEmployeeAccount_Controller
    {
        DataTable dt;
        Connection con;
        SqlCommand cmd;
        String strQuery;
        public string ErrorString;
        public createEmployeeAccount_Controller() { }

        public bool checkUserName(string email)
        {
            try
            {
                dt = new DataTable();
                con = new Connection();
                strQuery = "checkUserName";
                cmd = new SqlCommand(strQuery);
                cmd.Parameters.Add("@userNameEmail", SqlDbType.VarChar).Value = email;
                dt = con.GetDataUsingSp(cmd);
                if (dt.Rows.Count != 0)
                    return true;
                else
                    return false;
            }
            catch(Exception ex)
            {
                ErrorString = ex.Message;
                return false;
            }
         }

        public int createUserAccountUserTable(int roleId, string pass, Employee objEmp)
        {
            try
            {
                int val = 0;
                con = new Connection();
                strQuery = "createUserName";
                cmd = new SqlCommand(strQuery);
                cmd.Parameters.Add("@role_id", SqlDbType.BigInt).Value = roleId;
                cmd.Parameters.Add("@user_name", SqlDbType.VarChar).Value = objEmp.Username.Trim();
                cmd.Parameters.Add("@password", SqlDbType.VarChar).Value = pass.Trim();
                cmd.Parameters.Add("@dateTime", SqlDbType.DateTime).Value = objEmp.Created_dateTime;
                cmd.Parameters.Add("@active_status", SqlDbType.Int).Value = 1;
                val = con.InsertUpdateDataUsingSpWithReturn(cmd);
                if(val > 0)
                  return val;
                else
                {
                    ErrorString = con.strError;
                    return 0;
                }
            }
            catch (Exception ex)
            {
                ErrorString = ex.Message;
                return 0;
            }

        }

        public bool createEmployeeProfile(Employee objEmp, int createdByID)
        {
            try
            {
                con = new Connection();
                strQuery = "createEmployeeProfile";
                cmd = new SqlCommand(strQuery);
                cmd.Parameters.Add("@UserId", SqlDbType.BigInt).Value = objEmp.UserID;
                cmd.Parameters.Add("@emp_name", SqlDbType.VarChar).Value = objEmp.Emp_name;
                cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = objEmp.Username;
                cmd.Parameters.Add("@created_dateTime", SqlDbType.DateTime).Value = objEmp.Created_dateTime;
                cmd.Parameters.Add("@date_of_birth", SqlDbType.Date).Value = objEmp.Date_of_birth;
                cmd.Parameters.Add("@Address", SqlDbType.VarChar).Value = objEmp.address;
                cmd.Parameters.Add("@suburb", SqlDbType.VarChar).Value = objEmp.Suburb;
                cmd.Parameters.Add("@postcode", SqlDbType.VarChar).Value = objEmp.Postcode;
                cmd.Parameters.Add("@createdByCompanyId", SqlDbType.BigInt).Value = createdByID;
                cmd.Parameters.Add("@state", SqlDbType.VarChar).Value = objEmp.State;
                cmd.Parameters.Add("@TFN", SqlDbType.VarChar).Value = objEmp.T_FN;
                cmd.Parameters.Add("@ABN", SqlDbType.VarChar).Value = objEmp.A_BN;
                cmd.Parameters.Add("@mobile", SqlDbType.VarChar).Value = objEmp.Mobile;
                cmd.Parameters.Add("@license", SqlDbType.VarChar).Value = objEmp.License;
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

        public bool deleteUserName(int userId)
        {
            con = new Connection();
            strQuery = "deleteUserName";
            cmd = new SqlCommand(strQuery);
            cmd.Parameters.Add("", SqlDbType.BigInt).Value = userId;
            return con.InsertUpdateDataUsingSp(cmd);
        }

        public bool sendNotification(string _to,string _name,string _password, DateTime _dateTime)
        {
            return Email.sendEmail(_to,_name,_password,_dateTime);
        }
    }
}
