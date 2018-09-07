using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    public class frmManageCompanyTypes_Controller
    {
        DataTable dt;
        Connection con;
        SqlCommand cmd;
        String strQuery;
        public string ErrorString;
        public frmManageCompanyTypes_Controller() { }

        public DataTable LoadCompanyTypes()
        {
            try
            {
                dt = new DataTable();
                con = new Connection();
                strQuery = "spManageCompanyTypes";
                cmd = new SqlCommand(strQuery);
                cmd.Parameters.Add("@Mode", SqlDbType.VarChar).Value = "View";
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

        public bool AddcompanyType(string type, string desc)
        {
            try
            {
                con = new Connection();
                strQuery = "spManageCompanyTypes";
                cmd = new SqlCommand(strQuery);
                cmd.Parameters.Add("@Mode", SqlDbType.VarChar).Value = "Add";
                cmd.Parameters.Add("@type_name", SqlDbType.VarChar).Value = type;
                cmd.Parameters.Add("@description", SqlDbType.VarChar).Value = desc;
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

        public bool UpdateCompanyType(int comID, string type, string desc)
        {
            try
            {
                con = new Connection();
                strQuery = "spManageCompanyTypes";
                cmd = new SqlCommand(strQuery);
                cmd.Parameters.Add("@Mode", SqlDbType.VarChar).Value = "Update";
                cmd.Parameters.Add("@company_Type_id", SqlDbType.BigInt).Value = comID;
                cmd.Parameters.Add("@type_name", SqlDbType.VarChar).Value = type;
                cmd.Parameters.Add("@description", SqlDbType.VarChar).Value = desc;
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

        public bool DeleteCompanyType(int comID)
        {
            try
            {
                con = new Connection();
                strQuery = "spManageCompanyTypes";
                cmd = new SqlCommand(strQuery);
                cmd.Parameters.Add("@Mode", SqlDbType.VarChar).Value = "Delete";
                cmd.Parameters.Add("@company_Type_id", SqlDbType.BigInt).Value = comID;
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
