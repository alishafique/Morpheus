using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    public class SubContractorProfile_Controller
    {
        private DataTable dt;
        private Connection con;
        private string strQuery;
        private SqlCommand cmd;
        public string ErrorString;
        public SubContractorProfile_Controller() { }

        public DataTable loadCompanyProfile(int USerID)
        {
            try
            {
                dt = new DataTable();
                con = new Connection();
                strQuery = "spLoadSubContractorProfile";
                cmd = new SqlCommand(strQuery);
                cmd.Parameters.Add("@UserId", SqlDbType.BigInt).Value = USerID;
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

        public bool UpdateCompanyAddress(Address objAdd, int AddressID)
        {
            try
            {
                con = new Connection();
                bool result = false;
                strQuery = "spUpdateCompanyAddress";
                cmd = new SqlCommand(strQuery);
                cmd.Parameters.Add("@address_id", SqlDbType.BigInt).Value = AddressID;
                cmd.Parameters.Add("@address", SqlDbType.VarChar).Value = objAdd.StreetAddress;
                cmd.Parameters.Add("@suburb", SqlDbType.VarChar).Value = objAdd.Suburb;
                cmd.Parameters.Add("@state", SqlDbType.VarChar).Value = objAdd.State;
                cmd.Parameters.Add("@postcode", SqlDbType.VarChar).Value = objAdd.Postcode;
                result = con.InsertUpdateDataUsingSp(cmd);
                if (result)
                    return result;
                else
                {
                    ErrorString = con.strError;
                    return result;
                }
            }
            catch (Exception ex)
            {
                ErrorString = ex.Message;
                return false;
            }
        }

        public bool insertCompanyAddress(int companyId, Address objAdd)
        {
            try
            {
                con = new Connection();
                strQuery = "insertCompanyAddress";
                cmd = new SqlCommand(strQuery);
                cmd.Parameters.Add("@CompanyID", SqlDbType.BigInt).Value = companyId;
                cmd.Parameters.Add("@address", SqlDbType.VarChar).Value = objAdd.StreetAddress;
                cmd.Parameters.Add("@suburb", SqlDbType.VarChar).Value = objAdd.Suburb;
                cmd.Parameters.Add("@state", SqlDbType.VarChar).Value = objAdd.State;
                cmd.Parameters.Add("@postcode", SqlDbType.VarChar).Value = objAdd.Postcode;
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

        public DataTable loadAddress(int id)
        {
            try
            {
                dt = new DataTable();
                con = new Connection();
                strQuery = "spLoadAddressByCompanyId";
                cmd = new SqlCommand(strQuery);
                cmd.Parameters.Add("@companyID", SqlDbType.BigInt).Value = id;
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

        public bool UpdateCompanyProfile(Company com, int companyId)
        {
            try
            {
                con = new Connection();
                strQuery = "spUpdateCompanyProfile";
                cmd = new SqlCommand(strQuery);
                cmd.Parameters.Add("@CompanyId", SqlDbType.BigInt).Value = companyId;
                cmd.Parameters.Add("@Company_name", SqlDbType.VarChar).Value = com.companyName;
                cmd.Parameters.Add("@company_email", SqlDbType.VarChar).Value = com.company_email;
                cmd.Parameters.Add("@created_date_time", SqlDbType.DateTime).Value = DateTime.Now;
                cmd.Parameters.Add("@companyType_id", SqlDbType.BigInt).Value = com.companyType_id;
                cmd.Parameters.Add("@mobile", SqlDbType.VarChar).Value = com.Mobile;
                cmd.Parameters.Add("@landline", SqlDbType.VarChar).Value = com.Landline;
                cmd.Parameters.Add("@ABN", SqlDbType.VarChar).Value = com.ABN;
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
    }
}
