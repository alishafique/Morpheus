using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;


namespace Controller
{
    public class companyProfile_Controller
    {
        private DataTable dt;
        private Connection con;
        private string strQuery;
        private SqlCommand cmd;
        public string ErrorString;
        public companyProfile_Controller() { }

        public DataTable loadCompanyProfile(int USerID)
        {
            try
            {
                dt = new DataTable();
                con = new Connection();
                strQuery = "loadCompanyProfile";
                cmd = new SqlCommand(strQuery);
                cmd.Parameters.Add("@UserId", SqlDbType.BigInt).Value = USerID;
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
            catch (Exception ex)
            {
                ErrorString = ex.Message;
                return null;
            }
        }

        public DataTable loadAddress(int id)
        {
            dt = new DataTable();
            con = new Connection();
            strQuery = "loadAddressByCompanyId";
            cmd = new SqlCommand(strQuery);
            cmd.Parameters.Add("@companyID", SqlDbType.BigInt).Value = id;
            dt = con.GetDataUsingSp(cmd);
            return dt;
        }
        public DataTable loadMemberShipPlanes()
        {
            dt = new DataTable();
            con = new Connection();
            strQuery = "loadMembership";
            cmd = new SqlCommand(strQuery);
            dt = con.GetDataUsingSp(cmd);
            return dt;
        }
        public bool UpdateCompanyProfile(Company com, int companyId)
        {
            try
            {
                con = new Connection();
                strQuery = "UpdateCompanyProfileByCompany";
                cmd = new SqlCommand(strQuery);
                cmd.Parameters.Add("@CompanyId", SqlDbType.BigInt).Value = companyId;
                cmd.Parameters.Add("@membership_id", SqlDbType.BigInt).Value = com.membership_id;
                cmd.Parameters.Add("@Company_name", SqlDbType.VarChar).Value = com.companyName;
                cmd.Parameters.Add("@company_email", SqlDbType.VarChar).Value = com.company_email;
                cmd.Parameters.Add("@created_date_time", SqlDbType.DateTime).Value = DateTime.Now;
                cmd.Parameters.Add("@mobile", SqlDbType.VarChar).Value = com.Mobile;
                cmd.Parameters.Add("@landline", SqlDbType.VarChar).Value = com.Landline;

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
        public bool UpdateCompanyAddress(Address objAdd, int AddressID)
        {
            con = new Connection();
            strQuery = "updateCompanyAddress";
            cmd = new SqlCommand(strQuery);
            cmd.Parameters.Add("@address_id", SqlDbType.BigInt).Value = AddressID;
            cmd.Parameters.Add("@address", SqlDbType.VarChar).Value = objAdd.StreetAddress;
            cmd.Parameters.Add("@suburb", SqlDbType.VarChar).Value = objAdd.Suburb;
            cmd.Parameters.Add("@state", SqlDbType.VarChar).Value = objAdd.State;
            cmd.Parameters.Add("@postcode", SqlDbType.VarChar).Value = objAdd.Postcode;
            return con.InsertUpdateDataUsingSp(cmd);
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

    }
}
