using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    public class addUpdateNews_Controller
    {
        Connection con;
        DataTable dt;
        String strQuery;
        SqlCommand cmd;
        public string ErrorString;
        public addUpdateNews_Controller() { }

        public DataTable LoadNews()
        {
            try
            {
                dt = new DataTable();
                con = new Connection();
                strQuery = "spLoadNews";
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

        public bool UpdateNews(int NewsId, string postTitle, string postDesc, string postImg)
        {
            try
            {
                con = new Connection();
                strQuery = "spUpdateNews";
                cmd = new SqlCommand(strQuery);
                cmd.Parameters.Add("@id", SqlDbType.BigInt).Value = NewsId;
                cmd.Parameters.Add("@postTitle", SqlDbType.VarChar).Value = postTitle;
                cmd.Parameters.Add("@newsDescription", SqlDbType.VarChar).Value = postDesc;
                cmd.Parameters.Add("@postImage", SqlDbType.VarChar).Value = postImg;
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
