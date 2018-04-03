using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{

    public class AddLocationForm_Controller
    {
        DataTable dt;
        Connection con;
        SqlCommand cmd;
        String strQuery;
        public string ErrorString;

        public AddLocationForm_Controller() { }

        public bool InsertLocation(int companyID, string locationName)
        {
            try
            {
                con = new Connection();
                strQuery = "spManagelocations";
                cmd = new SqlCommand(strQuery);
                cmd.Parameters.Add("@Mode", SqlDbType.VarChar).Value = "Insert";
                cmd.Parameters.Add("@userID", SqlDbType.BigInt).Value = companyID;
                cmd.Parameters.Add("@LocationtoName", SqlDbType.VarChar).Value = locationName;
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

        public bool DeleteLocation(int LocationID)
        {
            try
            {
                con = new Connection();
                strQuery = "spManagelocations";
                cmd = new SqlCommand(strQuery);
                cmd.Parameters.Add("@Mode", SqlDbType.VarChar).Value = "Delete";
                cmd.Parameters.Add("@userID", SqlDbType.BigInt).Value = LocationID;
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

        public bool UpdateLocation(int LocationID, int compID, string locationName)
        {
            try
            {
                con = new Connection();
                strQuery = "spManagelocations";
                cmd = new SqlCommand(strQuery);
                cmd.Parameters.Add("@Mode", SqlDbType.VarChar).Value = "Update";
                cmd.Parameters.Add("@userID", SqlDbType.BigInt).Value = compID;
                cmd.Parameters.Add("@LocationtoName", SqlDbType.VarChar).Value = locationName;
                cmd.Parameters.Add("@LocationtoId", SqlDbType.BigInt).Value = LocationID;
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
        public DataTable LoadLocations(int companyID)
        {
            try
            {
                dt = new DataTable();
                con = new Connection();
                strQuery = "spManagelocations";
                cmd = new SqlCommand(strQuery);
                cmd.Parameters.Add("@Mode", SqlDbType.VarChar).Value = "View";
                cmd.Parameters.Add("@userID", SqlDbType.BigInt).Value = companyID;
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

    }
}
