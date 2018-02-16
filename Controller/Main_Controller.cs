using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    public class Main_Controller
    {
        private DataTable dt;
        private Connection con;
        private string strQuery;
        private SqlCommand cmd;
        public string ErrorString;
        public Main_Controller() { }

        public DataTable CompanyLogo(int CompanyId)
        {
            try
            {

                dt = new DataTable();
                con = new Connection();
                strQuery = "spCompanyLogo";
                cmd = new SqlCommand(strQuery);
                cmd.Parameters.Add("@CompanyId", SqlDbType.BigInt).Value = CompanyId;
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
        public DataTable GetCompanyIdOfEmployee(int UserId)
        {
            try
            {
                dt = new DataTable();
                con = new Connection();
                strQuery = "spGetCompanyIdOfEmployee";
                cmd = new SqlCommand(strQuery);
                cmd.Parameters.Add("@user_id", SqlDbType.BigInt).Value = UserId;
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

        public DataTable GetCompanyIdOfSubContractor(int SubCOntractorID)
        {
            try
            {
                dt = new DataTable();
                con = new Connection();
                strQuery = "spGetCompanyIdOfSubContractor";
                cmd = new SqlCommand(strQuery);
                cmd.Parameters.Add("@userID", SqlDbType.BigInt).Value = SubCOntractorID;
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
        public bool UpdateCompanyLogo(string imageURL, int ComID)
        {
            try
            {
                con = new Connection();
                strQuery = "spUpdateCompanyLogo";
                cmd = new SqlCommand(strQuery);
                cmd.Parameters.Add("@CompanyLogo", SqlDbType.VarChar).Value = imageURL;
                cmd.Parameters.Add("@CompanyId", SqlDbType.BigInt).Value = ComID;
                if (con.InsertUpdateDataUsingSp(cmd) == true)
                {
                    return true;
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
        public DataTable GetCompanyIdOfUser(int userid)
        {
            try
            {
                con = new Connection();
                strQuery = "spGetCompanyIdOfUser";
                cmd = new SqlCommand(strQuery);
                cmd.Parameters.Add("@user_id", SqlDbType.BigInt).Value = userid;
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


    }
}
