using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Domain;


namespace Controller
{
    public class ActivateDeactivateCompanyAccount_Controller
    {
        DataTable dt;
        Connection con;
        string strQuery;
        SqlCommand cmd;
        public string ErrorString;
        public ActivateDeactivateCompanyAccount_Controller() {
           
        }

        public bool notificationToCompany(string _to, string _name)
        {
            if (_to != "" || _name != "")
            {
                return Email.companyActivation(_to, _name);
            }
            else
            {
                return false;
            }
        }
        public bool notificationDeActiveToCompany(string _to, string _name)
        {
            if (_to != "" || _name != "")
            {
                return Email.companyDeActivation(_to, _name);
            }
            else
            {
                return false;
            }

        }
        public DataTable populateGridviewToActivateOrDeactivate()
        {
            try
            {
                dt = new DataTable();
                con = new Connection();
                strQuery = "activateDeactivateCompanyAccount";
                cmd = new SqlCommand(strQuery);
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
            catch(Exception ex)
            {
                ErrorString = ex.Message;
                return null;
            }
        }
        public bool updateCompanyStatus(int userID, int status)
        {
            try
            {
                con = new Connection();
                strQuery = "UpdateCompanyAccountStatus";
                cmd = new SqlCommand(strQuery);
                cmd.Parameters.Add("@active_status", SqlDbType.Int).Value = status;
                cmd.Parameters.Add("@user_id", SqlDbType.BigInt).Value = userID;
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

