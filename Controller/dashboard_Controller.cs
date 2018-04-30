using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Controller;
using System.Data;
using System.Data.SqlClient;



namespace Controller
{
    public class dashboard_Controller
    {
        DataTable dt;
        Connection con;
        SqlCommand cmd;
        String strQuery;
        public string ErrorString;

        public dashboard_Controller()
        {
        }

        // load membership planes into dropdown menu
        public DataTable loadMemberShipPlanes ()
        {
            try
            {
                dt = new DataTable();
                con = new Connection();
                strQuery = "sploadMemberShipPlanes";
                cmd = new SqlCommand(strQuery);
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

        public DataTable loadCompanyTypes()
        {
            try
            {
                dt = new DataTable();
                con = new Connection();
                strQuery = "select * from company_type";
                cmd = new SqlCommand(strQuery);
                dt = con.GetData(cmd);
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


        public int createCompanyAccountByAdmin(Company objComp)
        {
            try
            {
                int val = 0;
                con = new Connection();
                strQuery = "CreateCompanyAccountByAdmin";
                cmd = new SqlCommand(strQuery);
                // cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = TextBox1.Text; 
                cmd.Parameters.Add("@membership_id", SqlDbType.BigInt).Value = objComp.membership_id;
                cmd.Parameters.Add("@Company_name", SqlDbType.VarChar).Value = objComp.companyName;
                cmd.Parameters.Add("@company_email", SqlDbType.VarChar).Value = objComp.company_email;
                cmd.Parameters.Add("@created_date_time", SqlDbType.DateTime).Value = objComp.created_date_time;
                cmd.Parameters.Add("@companyType_id", SqlDbType.BigInt).Value = objComp.companyType_id;
                cmd.Parameters.Add("@mobile", SqlDbType.VarChar).Value = objComp.Mobile;
                cmd.Parameters.Add("@landline", SqlDbType.VarChar).Value = objComp.Landline;
                val = con.InsertUpdateDataUsingSpWithReturn(cmd);
                if (val != 0)
                {
                    return val;
                }
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

        // create User_name for company
        public int createUserAccountUserTable(int roleId, string pass, Company objComp)
        {
            try
            {
                int val = 0;
                con = new Connection();
                strQuery = "createUserName";
                cmd = new SqlCommand(strQuery);
                cmd.Parameters.Add("@role_id", SqlDbType.BigInt).Value = roleId;
                cmd.Parameters.Add("@user_name", SqlDbType.VarChar).Value = objComp.company_email;
                cmd.Parameters.Add("@password", SqlDbType.VarChar).Value = pass.Trim();
                cmd.Parameters.Add("@dateTime", SqlDbType.DateTime).Value = objComp.created_date_time;
                cmd.Parameters.Add("@active_status", SqlDbType.Int).Value = 1;
                val = con.InsertUpdateDataUsingSpWithReturn(cmd);
                if (val != 0)
                {
                    return val;
                }
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
        public bool insertCompanyAddress(int companyId, string address, string suburb,string state, string postcode)
        {
            con = new Connection();
            strQuery = "insertCompanyAddress";
            cmd = new SqlCommand(strQuery);
            cmd.Parameters.Add("@CompanyID", SqlDbType.BigInt).Value = companyId;
            cmd.Parameters.Add("@address", SqlDbType.VarChar).Value = address;
            cmd.Parameters.Add("@suburb", SqlDbType.VarChar).Value = suburb;
            cmd.Parameters.Add("@state", SqlDbType.VarChar).Value = state;
            cmd.Parameters.Add("@postcode", SqlDbType.VarChar).Value = postcode;
            if (con.InsertUpdateDataUsingSp(cmd) == true)
                return true;
            else
                return false;
        }

        public bool insertTbCompanyUser(int UserID, int CompanyID)
        {
            try
            {
                con = new Connection();
                strQuery = "insertTbCompanyUser";
                cmd = new SqlCommand(strQuery);
                cmd.Parameters.Add("@UserID", SqlDbType.BigInt).Value = UserID;
                cmd.Parameters.Add("@CompanyID", SqlDbType.VarChar).Value = CompanyID;
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

        public bool checkUserName(string email)
        {
            dt = new DataTable();
            con = new Connection();
            strQuery = "checkUserName";
            cmd = new SqlCommand(strQuery);
            cmd.Parameters.Add("@userNameEmail", SqlDbType.VarChar).Value = email;
            dt = con.GetDataUsingSp(cmd);
            if (dt.Rows.Count != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool checkEmailFromCompanyProfile(string email)
        {
            try
            {
                dt = new DataTable();
                con = new Connection();
                strQuery = "checkEmailFromCompanyProfile";
                cmd = new SqlCommand(strQuery);
                cmd.Parameters.Add("@userNameEmail", SqlDbType.VarChar).Value = email;
                dt = con.GetDataUsingSp(cmd);
                if (dt != null)
                {
                    if (dt.Rows.Count != 0)
                        return true;
                    else
                        return false;
                }
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

        public DataTable populateCompanyGridview()
        {
            dt = new DataTable();
            con = new Connection();
            strQuery = "ShowCompanies";
            cmd = new SqlCommand(strQuery);
            dt = con.GetDataUsingSp(cmd);
            return dt;
        }

        public Int64 CountIncidentReports(int rptToID)
        {
            try
            {
                dt = new DataTable();
                con = new Connection();
                strQuery = "spCountIncidentReports";
                cmd = new SqlCommand(strQuery);
                cmd.Parameters.Add("@reportedTo", SqlDbType.BigInt).Value = rptToID;
                dt = con.GetDataUsingSp(cmd);
                if (dt != null)
                {
                    return Int64.Parse(dt.Rows[0]["count"].ToString());
                }
                else
                {
                    ErrorString = con.strError;
                    return 0;
                }
               
      
            }
            catch(Exception ex)
            {
                ErrorString = ex.Message;
                return 0;
            }
        }
        public Int64 EmployeeCount(int _Id)
        {
            try
            {
                dt = new DataTable();
                con = new Connection();
                strQuery = "spEmployeeCount";
                cmd = new SqlCommand(strQuery);
                cmd.Parameters.Add("@createdByCompanyId", SqlDbType.BigInt).Value = _Id;
                dt = con.GetDataUsingSp(cmd);
                if (dt != null)
                {
                    Int64 temp = Int64.Parse(dt.Rows[0]["count"].ToString());
                    if (temp == 0)
                        return -1;
                    else
                        return temp;
                }
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
    }
}
