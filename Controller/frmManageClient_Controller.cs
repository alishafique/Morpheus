using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    public class frmManageClient_Controller
    {
        DataTable dt;
        Connection con;
        SqlCommand cmd;
        String strQuery;
        public string ErrorString;
        public frmManageClient_Controller() { }

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
        public bool InsertClient(int userId, string ClientName)
        {
            try
            {
                con = new Connection();
                strQuery = "spManageCompanyClient";
                cmd = new SqlCommand(strQuery);
                cmd.Parameters.Add("@Mode", SqlDbType.VarChar).Value = "Insert";
                cmd.Parameters.Add("@userID", SqlDbType.BigInt).Value = userId;
                cmd.Parameters.Add("@ClientName", SqlDbType.VarChar).Value = ClientName;
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

        public bool DeleteClient(int ClientId)
        {
            try
            {
                con = new Connection();
                strQuery = "spManageCompanyClient";
                cmd = new SqlCommand(strQuery);
                cmd.Parameters.Add("@Mode", SqlDbType.VarChar).Value = "Delete";
                cmd.Parameters.Add("@clientId", SqlDbType.BigInt).Value = ClientId;
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
        public bool UpdateClient(int clientId, string CName)
        {
            try
            {
                con = new Connection();
                strQuery = "spManageCompanyClient";
                cmd = new SqlCommand(strQuery);
                cmd.Parameters.Add("@Mode", SqlDbType.VarChar).Value = "Update";
                cmd.Parameters.Add("@ClientName", SqlDbType.VarChar).Value = CName;
                cmd.Parameters.Add("@clientId", SqlDbType.BigInt).Value = clientId;
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
