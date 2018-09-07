using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    public class AddSubcontractor_Controller
    {
        DataTable dt;
        Connection con;
        SqlCommand cmd;
        String strQuery;
        public string ErrorString;
        public AddSubcontractor_Controller() { }
        public DataTable loadMemberShipPlanes()
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
            catch(Exception ex)
            {
                ErrorString = ex.Message;
                return null;
            }
        }

        public DataTable LoadCompanyTypes()
        {
            try
            {
                dt = new DataTable();
                con = new Connection();
                strQuery = "spLoadCompanyTypes";
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

        public int createCompanyAccountByAdmin(Company objComp, int createdByID)
        {
            try
            {
                int val = 0;
                con = new Connection();
                strQuery = "spAddSubContractorByCompany";
                cmd = new SqlCommand(strQuery);
                cmd.Parameters.Add("@Company_name", SqlDbType.VarChar).Value = objComp.companyName;
                cmd.Parameters.Add("@company_email", SqlDbType.VarChar).Value = objComp.company_email;
                cmd.Parameters.Add("@created_date_time", SqlDbType.DateTime).Value = objComp.created_date_time;
                cmd.Parameters.Add("@companyType_id", SqlDbType.BigInt).Value = objComp.companyType_id;
                cmd.Parameters.Add("@mobile", SqlDbType.VarChar).Value = objComp.Mobile;
                cmd.Parameters.Add("@landline", SqlDbType.VarChar).Value = objComp.Landline;
                cmd.Parameters.Add("@CreatedByCompany", SqlDbType.BigInt).Value = createdByID;
                cmd.Parameters.Add("@ABN", SqlDbType.VarChar).Value = objComp.ABN;
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

        public bool insertCompanyAddress(int companyId, string address, string suburb, string state, string postcode)
        {
            try
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

    }
}
