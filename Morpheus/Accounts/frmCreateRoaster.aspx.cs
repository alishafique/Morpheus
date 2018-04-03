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
                        PopulateLocation();
                        loadDate();
                        LoadWeekRang();                     
                        btnAll_Click(null, null);
                        btnUpdate.Visible = false;
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
                        dpStartHoursMonday.Items.Add("0" + i.ToString());
                        dpEndHoursMonday.Items.Add("0" + i.ToString());
                    }
                    else
                    {
                        dpStartHoursMonday.Items.Add(i.ToString());
                        dpEndHoursMonday.Items.Add(i.ToString());
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
                        dpStartMinutesMonday.Items.Add("0" + i.ToString());
                        dpEndMinutesMonday.Items.Add("0" + i.ToString());
                    }
                    else
                    {
                        dpStartMinutesMonday.Items.Add(i.ToString());
                        dpEndMinutesMonday.Items.Add(i.ToString());
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
                    dpSiteMonday.DataSource = dt;
                    dpSiteMonday.DataBind();

                }
                else
                    showErrorMessage(obj.ErrorString, false);
            }
            catch(Exception ex)
            {
                showErrorMessage(ex.Message, false);
            }
        }

        private void LoadWeekRang()
        {
            try
            {
                int currentYear = DateTime.Today.Year;
                DateTime firstDayOfYear = new DateTime(currentYear, 1, 1);
                DateTime lastDayOfYear = new DateTime(currentYear, 12, 31);
                int weekNumber = 0;
                List<string> weekList = new List<string>();

                DateTime tempDate = firstDayOfYear;
                string tempString = string.Empty;

                while (tempDate <= lastDayOfYear)
                {
                    weekNumber++;
                    tempString ="Week "+ weekNumber.ToString() + " | ";
                    tempString += tempDate.ToShortDateString() + " - ";
                    tempDate = GetLastDayOfWeek(tempDate, lastDayOfYear);
                    tempString += tempDate.ToShortDateString();
                    weekList.Add(tempString);
                    tempDate = tempDate.AddDays(1);
                }

                DateDropDown.DataSource = weekList;
                DateDropDown.DataBind();

                DateDropDown.SelectedValue = weekList.FirstOrDefault(s => s.Contains(CurrentWeek()));
                DateDropDown_SelectedIndexChanged(null, null);

            }
            catch(Exception ex)
            {
                showErrorMessage(ex.Message, false);
            }
        }

        private string CurrentWeek()
        {
            string dateToSelect = string.Empty;
            DateTime date = DateTime.Now;
            DayOfWeek fdow = CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek;
            int offset = fdow - date.DayOfWeek;
            DateTime fdowDate = date.AddDays(offset);
            DateTime ldowDate = fdowDate.AddDays(6);
            return fdowDate.Date.ToShortDateString() + " - " + ldowDate.ToShortDateString();
        }
        private DateTime GetLastDayOfWeek(DateTime firstDayOfWeek, DateTime lastDayOfYear)
        {
            DateTime lastDayOfWeek = firstDayOfWeek;
            
            if (firstDayOfWeek.DayOfWeek == DayOfWeek.Monday) { lastDayOfWeek = firstDayOfWeek.AddDays(6); }
            if (firstDayOfWeek.DayOfWeek == DayOfWeek.Tuesday) { lastDayOfWeek = firstDayOfWeek.AddDays(5); }
            if (firstDayOfWeek.DayOfWeek == DayOfWeek.Wednesday) { lastDayOfWeek = firstDayOfWeek.AddDays(4); }
            if (firstDayOfWeek.DayOfWeek == DayOfWeek.Thursday) { lastDayOfWeek = firstDayOfWeek.AddDays(3); }
            if (firstDayOfWeek.DayOfWeek == DayOfWeek.Friday) { lastDayOfWeek = firstDayOfWeek.AddDays(2); }
            if (firstDayOfWeek.DayOfWeek == DayOfWeek.Saturday) { lastDayOfWeek = firstDayOfWeek.AddDays(1); }
            if (firstDayOfWeek.DayOfWeek == DayOfWeek.Sunday) { lastDayOfWeek = firstDayOfWeek; }

            if (lastDayOfWeek > lastDayOfYear) { lastDayOfWeek = lastDayOfYear; }

            return lastDayOfWeek;
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
        protected void btnCreateRoster_Click(object sender, EventArgs e)
        {
            try
            {     
                obj = new frmCreateRoaster_Controller();
                string[] empEmail = txtSearchEmployeeName.Text.Split('-');
                string[] rosterDayAndDate = dpSelectDay.SelectedValue.Split(',');
                Roster objRoster = new Roster()
                {
                    CreatedByID =  int.Parse(Session["userid"].ToString())
                    ,AssignedEmployeeEmail = empEmail[1].Trim()
                    ,RosterDate = DateTime.Parse(rosterDayAndDate[1].Trim())
                    ,RosterStartTime = DateTime.Parse(dpStartHoursMonday.SelectedItem.Text+":"+dpStartMinutesMonday.SelectedItem.Text)
                    ,RosterEndTime = DateTime.Parse(dpEndHoursMonday.SelectedItem.Text+":"+dpEndMinutesMonday.SelectedItem.Text)
                    ,RosterSite = dpSiteMonday.SelectedItem.Text
                    ,RosterTask = txtTaskMonday.Text
                };

                if (obj.AddEmployeeRoster(objRoster))
                    showErrorMessage("Roster Added", true);
                else
                    showErrorMessage(obj.ErrorString, false);

                clearForm();
                btnAll_Click(null, null);
            }
            catch(Exception ex)
            {
                showErrorMessage(ex.Message, false);
            }
        }

        protected void DateDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string LoadShiftsWeekRange = DateDropDown.SelectedItem.Text.Trim();
                dpSelectDay.DataSource = LoadWeekDays(LoadShiftsWeekRange);
                dpSelectDay.DataBind();
                dpSelectDay.Focus();
                dpSelectDay.Enabled = true;
                string[] weekSeparator = LoadShiftsWeekRange.Split('|');
                string[] dateRangeSeparator = weekSeparator[1].Split('-');

                lblStartWeekDate.Text = DateTime.Parse(dateRangeSeparator[0]).DayOfWeek +"-"+ dateRangeSeparator[0];
                lblEndWeekdate.Text = DateTime.Parse(dateRangeSeparator[1]).DayOfWeek + "-" + dateRangeSeparator[1];
                btnAll_Click(null, null);
                clearForm();
            }
            catch(Exception ex)
            {
                showErrorMessage(ex.Message, false);
            }
        }

        private List<string> LoadWeekDays(string dpValue)
        {
            string[] dateRangWeek = dpValue.Split('|');
            string[] startDateOfWeek = dateRangWeek[1].Trim().Split('-');

            TimeSpan TimeWeek = new TimeSpan(7, 0, 0, 0, 0);
            DateTime StartDate = DateTime.Parse(startDateOfWeek[0].Trim());
            DateTime EndDate = StartDate;
            //add 7 days to get ending date
            EndDate += TimeWeek;
            int Month = StartDate.Month;
            List<string> dateList = new List<string>();
            while (StartDate != EndDate)
            {
                dateList.Add(StartDate.DayOfWeek.ToString() + ", " + StartDate.ToString("dd/MMM/yyyy"));
                StartDate += new TimeSpan(1, 0, 0, 0, 0);
            }

            return dateList;
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

        protected void btnAll_Click(object sender, EventArgs e)
        {
            try
            {
                btnAll.Enabled = false;
                string[] stD = lblStartWeekDate.Text.Split('-');
                string[] endD = lblEndWeekdate.Text.Split('-');
                obj = new frmCreateRoaster_Controller();
                dt = new DataTable();
                dt = obj.LoadAllEmployeesRoster(int.Parse(Session["userid"].ToString()), DateTime.Parse(stD[1]), DateTime.Parse(endD[1]));
                if(dt!=null)
                {
                    grdViewShifts.DataSource = dt;
                    grdViewShifts.DataBind();
                }
                else
                    showErrorMessage(obj.ErrorString, false);

                ViewState["dtShifts"] = dt; 
            }
            catch(Exception ex)
            {
                showErrorMessage(ex.Message, false);
            }
        }

        protected void grdViewShifts_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                obj = new frmCreateRoaster_Controller();
                if(e.CommandName.ToString().ToUpper() == "EDITROW")
                {
                    dt = new DataTable();
                    dt = (DataTable)ViewState["dtShifts"];

                    for(int i=0;i<dt.Rows.Count;i++)
                    {
                        if(dt.Rows[i]["RosterID"].ToString().Trim() == e.CommandArgument.ToString().Trim())
                        {
                            // roster Start time
                            var RosterTime = DateTime.Parse(dt.Rows[i]["RosterStartTime"].ToString().Trim());
                            dpStartHoursMonday.ClearSelection();
                            if(RosterTime.Hour.ToString().Length == 1)
                            {
                                var hourTime = "0" + RosterTime.Hour.ToString();
                                dpStartHoursMonday.Items.FindByText(hourTime).Selected = true;
                            }
                            else
                                dpStartHoursMonday.Items.FindByText(RosterTime.Hour.ToString()).Selected = true;
                            dpStartMinutesMonday.ClearSelection();
                            if(RosterTime.Minute.ToString().Length == 1)
                            {
                                var minutetime = "0" + RosterTime.Minute.ToString();
                                dpStartMinutesMonday.Items.FindByText(minutetime).Selected = true;
                            }
                            else
                                dpStartMinutesMonday.Items.FindByText(RosterTime.Minute.ToString()).Selected = true;
                            // roster ENd Time
                            var RosterEndTime = DateTime.Parse(dt.Rows[i]["RosterEndTime"].ToString().Trim());
                            dpEndHoursMonday.ClearSelection();
                            if (RosterEndTime.Hour.ToString().Length == 1)
                            {
                                var hourTime = "0" + RosterEndTime.Hour.ToString();
                                dpEndHoursMonday.Items.FindByText(hourTime).Selected = true;
                            }
                            else
                                dpEndHoursMonday.Items.FindByText(RosterEndTime.Hour.ToString()).Selected = true;
                            dpEndMinutesMonday.ClearSelection();
                            if (RosterEndTime.Minute.ToString().Length == 1)
                            {
                                var minutetime = "0" + RosterEndTime.Minute.ToString();
                                dpEndMinutesMonday.Items.FindByText(minutetime).Selected = true;
                            }
                            else
                                dpEndMinutesMonday.Items.FindByText(RosterEndTime.Minute.ToString()).Selected = true;

                            lblROster.Text = e.CommandArgument.ToString().Trim(); // roster ID
                            dpSiteMonday.ClearSelection();
                            dpSiteMonday.Items.FindByText(dt.Rows[i]["RosterSite"].ToString().Trim()).Selected = true; // roster site
                            txtTaskMonday.Text = dt.Rows[i]["RosterTask"].ToString().Trim(); // roster Task

                            // roster Day
                            var rosterDayDate = DateTime.Parse(dt.Rows[i]["RosterDate"].ToString().Trim());
                            dpSelectDay.ClearSelection();
                            dpSelectDay.Items.FindByText(rosterDayDate.DayOfWeek +", "+rosterDayDate.ToString("dd/MMM/yyyy")).Selected = true;
                            break;
                        }
                       
                    }

                    btnCreateRoster.Visible = false;
                    btnUpdate.Visible = true;
                    
                }
                if(e.CommandName.ToString().ToUpper() == "DELETEROW")
                {
                    if (obj.DeleteShift(Guid.Parse(e.CommandArgument.ToString().Trim())))
                        showErrorMessage("Delete Successfully", true);
                    else
                        showErrorMessage(obj.ErrorString, false);
                }

                btnAll_Click(null, null);
            }
            catch(Exception ex)
            {
                showErrorMessage(ex.Message, false);
            }
        }

        protected void grdViewShifts_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton lbDelete = (LinkButton)e.Row.FindControl("lbDelete");
                lbDelete.Attributes.Add("onclick", "return confirm('Are you sure to delete?');");
            }
        }

        private void clearForm()
        {
            txtSearchEmployeeName.Text = "";
            dpSelectDay.SelectedIndex = 0;
            dpSiteMonday.SelectedIndex = 0;
            txtTaskMonday.Text = "";
            dpStartHoursMonday.SelectedIndex = 0;
            dpStartMinutesMonday.SelectedIndex = 0;
            dpEndHoursMonday.SelectedIndex = 0;
            dpEndMinutesMonday.SelectedIndex = 0;
            btnCreateRoster.Visible = true;
            btnUpdate.Visible = false;
        }
        protected void btnPrevious_Click(object sender, EventArgs e)
        {
            try
            {
               
            }
            catch (Exception ex)
            {
                showErrorMessage(ex.Message, false);
            }
        }

        protected void bntNext_Click(object sender, EventArgs e)
        {
            try
            {
                string[] stD = lblStartWeekDate.Text.Split('-');
                string[] endD = lblEndWeekdate.Text.Split('-');
            }
            catch(Exception ex)
            {
                showErrorMessage(ex.Message, false);
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch(Exception ex)
            {
                showErrorMessage(ex.Message, false);
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            clearForm();
        }
    }
}