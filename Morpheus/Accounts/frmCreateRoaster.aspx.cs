using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using Controller;

namespace Morpheus.Accounts
{
    public partial class frmCreateRoaster : System.Web.UI.Page
    {
        DataTable dt;
        frmCreateRoaster_Controller obj;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                try
                {
                    if(Session["UserTypeID"].ToString() == "2" || Session["UserTypeID"].ToString() == "4")
                    {
                        LoadHours();
                        LoadMinutes();
                        loadEmployees();
                        PopulateLocation();
                        loadDate();
                    }
                    else
                        Response.Redirect("login.aspx");
                }
                catch (Exception ex)
                {
                    Response.Redirect("login.aspx");
                }
            }
           
        }

        private void LoadHours()
        {
            try
            {
                for (int i = 0; i<24; i++)
                {
                    if (i < 10)
                    {
                        dpStartHours.Items.Add("0" + i.ToString());
                        dpEndHours.Items.Add("0" + i.ToString());
                    }
                    else
                    {
                        dpStartHours.Items.Add(i.ToString());
                        dpEndHours.Items.Add(i.ToString());
                    }

                }
            }
            catch(Exception ex)
            {
                showErrorMessage(ex.Message, false);
            }
        }

        private void LoadMinutes()
        {
            try
            {
                for (int i = 0; i < 60; i++)
                {
                    if (i < 10)
                    {
                        dpStartMinutes.Items.Add("0" + i.ToString());
                        dpEndMinutes.Items.Add("0" + i.ToString());
                    }
                    else
                    {
                        dpStartMinutes.Items.Add(i.ToString());
                        dpEndMinutes.Items.Add(i.ToString());
                    }

                }
            }
            catch (Exception ex)
            {
                showErrorMessage(ex.Message, false);
            }
        }

        private void showErrorMessage(string message, bool status)
        {
            if (status == true)
            {
                lblsuccessmsg.Text = message;
                successMsg.Style.Add("display", "block");
                errorMsg.Style.Add("display", "none");
                string script = @"setTimeout(function(){document.getElementById('" + errorMsg.ClientID + "').style.display='none';},8000);";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "somekey", script, true);
            }
            else
            {
                lblErrorMsg.Text = message;
                errorMsg.Style.Add("display", "block");
                successMsg.Style.Add("display", "none");
                string script = @"setTimeout(function(){document.getElementById('" + errorMsg.ClientID + "').style.display='none';},8000);";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "somekey", script, true);
            }

        }

        private void loadEmployees()
        {
            try
            {
                dt = new DataTable();
                obj = new frmCreateRoaster_Controller();
                dt = obj.listEmployeesByCompany(int.Parse(Session["userid"].ToString()));
                if (dt != null)
                {
                    string _text = "";
                    string _value = "";
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        _text = dt.Rows[i]["emp_name"].ToString() + " - " + dt.Rows[i]["email"].ToString();
                        _value = dt.Rows[i]["UserId"].ToString();//+" - "+ dt.Rows[i]["EmployeeId"].ToString();
                        listEmployees.Items.Add(new ListItem() { Text = _text, Value = _value });
                    }
                }
                else
                    showErrorMessage(obj.ErrorString, false);
            }
            catch (Exception ex)
            {
                showErrorMessage(ex.Message, false);
            }
        }

        private void PopulateLocation()
        {
            try
            {
                obj = new frmCreateRoaster_Controller();
                dt = new DataTable();
                dt = obj.LoadSites(int.Parse(Session["userid"].ToString()));
                if (dt != null)
                {
                    dt.Columns.Remove("LocationCompany");
                    dpAddSite.DataSource = dt;
                    dpAddSite.DataBind();
                }
                else
                    showErrorMessage(obj.ErrorString, false);
            }
            catch(Exception ex)
            {
                showErrorMessage(ex.Message, false);
            }
        }

        private void loadDate()
        {
            DateTime date = DateTime.Now; 

            DayOfWeek fdow = CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek;
         


            int offset = fdow - date.DayOfWeek;
            DateTime fdowDate = date.AddDays(offset);
            lblStartWeekDate.Text = fdow.ToString()+"-"+ fdowDate.Date.ToShortDateString();

            DateTime ldowDate = fdowDate.AddDays(6);
            lblEndWeekdate.Text = ldowDate.DayOfWeek.ToString()+"-"+ ldowDate.ToShortDateString();

        }

        [WebMethod]
        public static List<string> GetEmployeeName(string empName)
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