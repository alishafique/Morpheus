using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace Controller
{
    public class ContactUs_Controller
    {
        Connection con;
        DataTable dt;
        String strQuery;
        SqlCommand cmd;
        public string ErrorString;
        public ContactUs_Controller() { }

        public bool InsertContactUsForm(string name, string email, string phone, string message)
        {
            try
            {
                con = new Connection();
                strQuery = "spInsertContactUsForm";
                cmd = new SqlCommand(strQuery);
                cmd.Parameters.Add("@name", SqlDbType.VarChar).Value = name;
                cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = email;
                cmd.Parameters.Add("@phone", SqlDbType.VarChar).Value = phone;
                cmd.Parameters.Add("@message", SqlDbType.VarChar).Value = message;
                if (con.InsertUpdateDataUsingSp(cmd))
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
