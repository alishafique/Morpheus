using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using Controller;

namespace Morpheus.Accounts
{
    public partial class AdminDashboard : System.Web.UI.Page
    {
        public static Int64 UserID;
        dashboard_Controller objController = new dashboard_Controller();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["UserTypeID"].ToString() == "1")
                {
                    incidentReportPanel.Style.Add("display", "none");
                    EmployeeCount.Style.Add("display", "none");
                    lblDashmsg.Text = "Site-Admin";
                } else
                if (Session["UserTypeID"].ToString() == "2")
                {
                    IncidentReportCounter();
                    EmployeeCounter();
                    incidentReportPanel.Style.Add("display", "block");
                    EmployeeCount.Style.Add("display", "block");
                    lblDashmsg.Text = "Company's";
                }
                else if (Session["UserTypeID"].ToString() == "3")
                {
                    incidentReportPanel.Style.Add("display", "none");
                    EmployeeCount.Style.Add("display", "none");
                    lblDashmsg.Text = "Employee's";
                }
                else if (Session["UserTypeID"].ToString() == "4")
                {
                    IncidentReportCounter();
                    EmployeeCounter();
                    incidentReportPanel.Style.Add("display", "block");
                    EmployeeCount.Style.Add("display", "block");
                    lblDashmsg.Text = "Sub-Contractor's";
                }
                else
                {
                    Response.Redirect("login.aspx");
                }

                UserID = Int64.Parse(Session["userid"].ToString());
            }
            catch(Exception ex)
            {
                Response.Redirect("login.aspx");
            }
        }

        private void IncidentReportCounter()
        {
            try
            {
                lblIncidentReportCount.Text = objController.CountIncidentReports(int.Parse(Session["userid"].ToString())).ToString();
            }
            catch(Exception ex)
            {
                showErrorMessage(ex.Message, false);
            }
        }

        private void EmployeeCounter()
        {
            try
            {
                string _empCt = string.Empty;
                _empCt = objController.EmployeeCount(int.Parse(Session["userid"].ToString())).ToString();
                if (_empCt != "0" && _empCt != "-1")
                {
                    lblEmployeeCount.Text = _empCt;
                }
                else
                {
                    if(_empCt == "-1")
                        lblEmployeeCount.Text = "0";
                    else
                        showErrorMessage(objController.ErrorString, false);
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
            }
            else
            {
                lblErrorMsg.Text = message;
                errorMsg.Style.Add("display", "block");
                successMsg.Style.Add("display", "none");
            }

        }

        [WebMethod]
        public static IEnumerable<IncidentReport> GetData()
        {
            try
            {
                using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["morpheus_db"].ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(@"SELECT count( distinct [id])
                FROM [dbo].[incidentReport] where [reportedTo] ="+ UserID, connection))
                    {
                        // Make sure the command object does not already have
                        // a notification object associated with it.
                        command.Notification = null;
                        SqlDependency.Start(ConfigurationManager.ConnectionStrings["morpheus_db"].ConnectionString);
                        SqlDependency dependency = new SqlDependency(command);
                        dependency.OnChange += new OnChangeEventHandler(dependency_OnChange);

                        if (connection.State == ConnectionState.Closed)
                            connection.Open();


                        using (var reader = command.ExecuteReader())
                            return reader.Cast<IDataRecord>()
                                .Select(x => new IncidentReport()
                                {
                                    id = x.GetInt32(0),
                                    //ReportedBy = x.GetInt64(1),
                                    //ReportedTo = x.GetInt64(2),
                                    //Severitylevel = x.GetString(3)
                                }).ToList();



                    }
                }
            }
            catch(Exception ex)
            {
                return null;
            }
        }
        private static void dependency_OnChange(object sender, SqlNotificationEventArgs e)
        {
            MyHub.Show();
        }

        protected void btnUploadLogo_Click(object sender, EventArgs e)
        {
            
        }
    }
}