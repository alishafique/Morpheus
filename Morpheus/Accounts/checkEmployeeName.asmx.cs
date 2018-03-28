using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace Morpheus.Accounts
{
    /// <summary>
    /// Summary description for checkEmployeeName
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class checkEmployeeName : System.Web.Services.WebService
    {

        [WebMethod]
        public List<string> GetEmployeeName(string empName)
        {
            List<string> empResult = new List<string>();
            using (SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["morpheus_db"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "SELECT TOP (10) [emp_name] ,[mobile] FROM [dbo].[Employee_profile] where [emp_name] LIKE '%'+@SearchEmpName+'%'";
                    cmd.Connection = con;
                    con.Open();
                    cmd.Parameters.AddWithValue("@SearchEmpName", empName);
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        empResult.Add(dr["emp_name"].ToString());
                    }
                    con.Close();
                    return empResult;
                }
            }
        }
    }
}
