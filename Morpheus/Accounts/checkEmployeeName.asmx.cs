using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;
using Controller;
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

        [WebMethod(EnableSession = true)]
        public void AddEmployeeRoster(Roster empRoster)
        {
            frmCreateRoaster_Controller obj = new frmCreateRoaster_Controller();
            obj.AddEmployeeRoster(empRoster); 

        }


        [WebMethod(EnableSession = true)]
        public List<string> GetEmployeeName(string empName)
        {
            List<string> empResult = new List<string>();
            string emplist = string.Empty;
            if(empName.Contains(";"))
            {
                string[] tempstr = empName.Split(';');
                emplist = tempstr[tempstr.Length - 1];
            }
            else
            {
                emplist = empName;
            }
            using (SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["morpheus_db"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "SELECT TOP (10) [emp_name] ,[mobile], [email] FROM [dbo].[Employee_profile] where ([emp_name] LIKE '%'+@SearchEmpName+'%'  AND [createdByCompanyId] =@CompanyID) OR ([mobile] LIKE '%'+@SearchEmpName+'%'  AND [createdByCompanyId] =@CompanyID)";
                    cmd.Connection = con;
                    con.Open();
                    cmd.Parameters.AddWithValue("@SearchEmpName", emplist);
                    cmd.Parameters.AddWithValue("@CompanyID", Session["userid"].ToString());
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        empResult.Add(dr["emp_name"].ToString()+" - "+ dr["email"].ToString());
                    }
                    con.Close();
                    return empResult;
                }
            }
        }
    }
}
