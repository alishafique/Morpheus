using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Controller
{
   public class frmActivateDeActivatePlugins_Controller
    {
        DataTable dt;
        Connection con;
        string strQuery;
        SqlCommand cmd;
        public string ErrorString;

        public frmActivateDeActivatePlugins_Controller() { }
        public DataTable populateCompanyGridview()
        {
            try
            {
                dt = new DataTable();
                con = new Connection();
                strQuery = "spManagePlugins";
                cmd = new SqlCommand(strQuery);
                cmd.Parameters.Add("@Mode", SqlDbType.VarChar).Value = "ShowCompanies";
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
        public DataTable LoadCompanyPlugins(int UserID)
        {
            try
            {
                dt = new DataTable();
                con = new Connection();
                strQuery = "spManagePlugins";
                cmd = new SqlCommand(strQuery);
                cmd.Parameters.Add("@Mode", SqlDbType.VarChar).Value = "LoadCompanyPlugins";
                cmd.Parameters.Add("@user_id", SqlDbType.BigInt).Value = UserID;
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
        public bool UpdatePlugins(int companyID, bool subCon, bool activity, bool roster, bool form, bool incidentRpt)
        {
            try
            {
                dt = new DataTable();
                con = new Connection();
                strQuery = "spManagePlugins";
                cmd = new SqlCommand(strQuery);
                cmd.Parameters.Add("@Mode", SqlDbType.VarChar).Value = "UpdatePlugIns";
                cmd.Parameters.Add("@CompanyId", SqlDbType.BigInt).Value = companyID;
                cmd.Parameters.Add("@subContractor", SqlDbType.Bit).Value = subCon;
                cmd.Parameters.Add("@activity", SqlDbType.Bit).Value = activity;
                cmd.Parameters.Add("@incident", SqlDbType.Bit).Value = incidentRpt;
                cmd.Parameters.Add("@forms", SqlDbType.Bit).Value = form;
                cmd.Parameters.Add("@roster", SqlDbType.Bit).Value = roster;
                if (con.InsertUpdateDataUsingSp(cmd))
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
