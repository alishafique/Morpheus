using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
   public class frmViewTimeSheetFull_Controller
    {
        DataTable dt;
        Connection con;
        SqlCommand cmd;
        String strQuery;
        public string ErrorString;
        public frmViewTimeSheetFull_Controller() { }
        public DataTable LoadClients(int userID)
        {
            try
            {
                dt = new DataTable();
                con = new Connection();
                strQuery = "spManageCompanyClient";
                cmd = new SqlCommand(strQuery);
                cmd.Parameters.Add("@Mode", SqlDbType.VarChar).Value = "View";
                cmd.Parameters.Add("@userID", SqlDbType.BigInt).Value = userID;
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
        public DataTable viewTimeSheetOfCompany(int userID, string CompanyName, DateTime startDt, DateTime endDt)
        {
            try
            {
                dt = new DataTable();
                con = new Connection();
                strQuery = "spManageRosterOfEmployee";
                cmd = new SqlCommand(strQuery);
                cmd.Parameters.Add("@Mode", SqlDbType.VarChar).Value = "ViewCompanyTimeSheets";
                cmd.Parameters.Add("@userid", SqlDbType.BigInt).Value = userID;
                cmd.Parameters.Add("@DateRangeStart", SqlDbType.Date).Value = startDt;
                cmd.Parameters.Add("@DateRangeEnd", SqlDbType.Date).Value = endDt;
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

        public DataTable ViewCompanyTimeSheetByCompany(int userID, string CompanyName, DateTime startDt, DateTime endDt)
        {
            try
            {
                dt = new DataTable();
                con = new Connection();
                strQuery = "spManageRosterOfEmployee";
                cmd = new SqlCommand(strQuery);
                cmd.Parameters.Add("@Mode", SqlDbType.VarChar).Value = "ViewCompanyTimeSheetByCompany";
                cmd.Parameters.Add("@userid", SqlDbType.BigInt).Value = userID;
                cmd.Parameters.Add("@ClientName", SqlDbType.VarChar).Value = CompanyName;
                cmd.Parameters.Add("@DateRangeStart", SqlDbType.Date).Value = startDt;
                cmd.Parameters.Add("@DateRangeEnd", SqlDbType.Date).Value = endDt;
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
