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
        string error = string.Empty;
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
                        btnUpdate.Visible = false;
                        LoadClientName(int.Parse(Session["userid"].ToString()));
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
            ReSetMsg();
            if (status == true)
            {
                lblsuccessmsg.Text = message;
                successMsg.Style.Add("display", "block");
                //string script = @"setTimeout(function(){document.getElementById('" + errorMsg.ClientID + "').style.display='none';},8000);";
                //Page.ClientScript.RegisterStartupScript(this.GetType(), "somekey", script, true);
            }
            else
            {
                lblErrorMsg.Text = message;
                errorMsg.Style.Add("display", "block");
                //string script = @"setTimeout(function(){document.getElementById('" + errorMsg.ClientID + "').style.display='none';},8000);";
                //Page.ClientScript.RegisterStartupScript(this.GetType(), "somekey", script, true);
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
                ViewState["WeekRange"] = weekList;
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
        private bool checkAvailbility(Roster objR)
        {
            dt = new DataTable();
            obj = new frmCreateRoaster_Controller();
            dt = obj.CheckEmployeeAvailbility(objR);

            if (dt == null)
            {
                error = obj.ErrorString;
                return false;
            }
            else
            {
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        DateTime startT = Convert.ToDateTime(dr["RosterStartTime"].ToString());
                        DateTime endT = Convert.ToDateTime(dr["RosterEndTime"].ToString());
                        if (startT >= objR.RosterStartTime && endT <= objR.RosterEndTime)
                        {
                            error = "Roster for employee: " + objR.AssignedEmployeeEmail + " already exist in that specific time slot.";
                            break;
                        }

                        if(objR.RosterStartTime >= startT && objR.RosterStartTime <= endT)
                        {
                            error = "Start time overlapping. Roster for employee: " + objR.AssignedEmployeeEmail + " already exist in that specific time slot.";
                            break;
                        }
                        if (objR.RosterEndTime >= startT && objR.RosterEndTime <= endT)
                        {
                            error = "End time overlapping. Roster for employee: " + objR.AssignedEmployeeEmail + " already exist in that specific time slot.";
                            break;
                        }
                    }

                    if (error == "")
                        return true;
                    else
                        return false;
                }
                else
                    return true;
            }
        }
        protected void btnCreateRoster_Click(object sender, EventArgs e)
        {
            try
            {
                ReSetMsg();
                obj = new frmCreateRoaster_Controller();
                string[] empList = txtSearchEmployeeName.Text.Split(';');
                List<string> listEmpEmail = new List<string>(); 
                foreach(string val in empList)
                {
                    if (val != "")
                    {
                        string[] tempStr = val.Split('-');
                        listEmpEmail.Add(tempStr[1].Trim());
                    }
                }
                string[] rosterDayAndDate = new string[2];
                Roster objRoster = new Roster()
                {
                    CreatedByID = int.Parse(Session["userid"].ToString())
                   ,RosterStartTime = DateTime.Parse(dpStartHoursMonday.SelectedItem.Text + ":" + dpStartMinutesMonday.SelectedItem.Text)
                   ,RosterEndTime = DateTime.Parse(dpEndHoursMonday.SelectedItem.Text + ":" + dpEndMinutesMonday.SelectedItem.Text)
                   ,RosterSite = dpSiteMonday.SelectedItem.Text
                   ,RosterTask = txtTaskMonday.Text
                   ,ClientName = dpClients.SelectedItem.Text
                };

                foreach (string val in listEmpEmail)
                {
                    objRoster.AssignedEmployeeEmail = val.Trim();
                    if (chkMon.Checked)
                    {
                        rosterDayAndDate = chkMon.Text.Split(',');
                        objRoster.RosterDate = DateTime.Parse(rosterDayAndDate[1].Trim());

                        if (checkAvailbility(objRoster))
                        {
                            if (obj.AddEmployeeRoster(objRoster))
                            {
                                showErrorMessage("Roster Added", true);
                                btnAll_Click(null, null);
                            }
                            else
                                showErrorMessage(obj.ErrorString, false);
                        }
                        else
                            showErrorMessage(error, false);
                    }
                    if (chkTue.Checked)
                    {
                        rosterDayAndDate = chkTue.Text.Split(',');
                        objRoster.RosterDate = DateTime.Parse(rosterDayAndDate[1].Trim());

                        if (checkAvailbility(objRoster))
                        {
                            if (obj.AddEmployeeRoster(objRoster))
                            {
                                showErrorMessage("Roster Added", true);
                                btnAll_Click(null, null);
                            }
                            else
                                showErrorMessage(obj.ErrorString, false);
                        }
                        else
                            showErrorMessage(error, false);
                    }
                    if (chkWed.Checked)
                    {
                        rosterDayAndDate = chkWed.Text.Split(',');
                        objRoster.RosterDate = DateTime.Parse(rosterDayAndDate[1].Trim());

                        if (checkAvailbility(objRoster))
                        {
                            if (obj.AddEmployeeRoster(objRoster))
                            {
                                showErrorMessage("Roster Added", true);
                                btnAll_Click(null, null);
                            }
                            else
                                showErrorMessage(obj.ErrorString, false);
                        }
                        else
                            showErrorMessage(error, false);
                    }
                    if (chkThu.Checked)
                    {
                        rosterDayAndDate = chkThu.Text.Split(',');
                        objRoster.RosterDate = DateTime.Parse(rosterDayAndDate[1].Trim());

                        if (checkAvailbility(objRoster))
                        {
                            if (obj.AddEmployeeRoster(objRoster))
                            {
                                showErrorMessage("Roster Added", true);
                                btnAll_Click(null, null);
                            }
                            else
                                showErrorMessage(obj.ErrorString, false);
                        }
                        else
                            showErrorMessage(error, false);
                    }
                    if (chkFri.Checked)
                    {
                        rosterDayAndDate = chkFri.Text.Split(',');
                        objRoster.RosterDate = DateTime.Parse(rosterDayAndDate[1].Trim());

                        if (checkAvailbility(objRoster))
                        {
                            if (obj.AddEmployeeRoster(objRoster))
                            {
                                showErrorMessage("Roster Added", true);
                                btnAll_Click(null, null);
                            }
                            else
                                showErrorMessage(obj.ErrorString, false);
                        }
                        else
                            showErrorMessage(error, false);
                    }
                    if (chkSat.Checked)
                    {
                        rosterDayAndDate = chkSat.Text.Split(',');
                        objRoster.RosterDate = DateTime.Parse(rosterDayAndDate[1].Trim());

                        if (checkAvailbility(objRoster))
                        {
                            if (obj.AddEmployeeRoster(objRoster))
                            {
                                showErrorMessage("Roster Added", true);
                                btnAll_Click(null, null);
                            }
                            else
                                showErrorMessage(obj.ErrorString, false);
                        }
                        else
                            showErrorMessage(error, false);
                    }
                    if (chkSun.Checked)
                    {
                        rosterDayAndDate = chkSun.Text.Split(',');
                        objRoster.RosterDate = DateTime.Parse(rosterDayAndDate[1].Trim());

                        if (checkAvailbility(objRoster))
                        {
                            if (obj.AddEmployeeRoster(objRoster))
                            {
                                showErrorMessage("Roster Added", true);
                                btnAll_Click(null, null);
                            }
                            else
                                showErrorMessage(obj.ErrorString, false);
                        }
                        else
                            showErrorMessage(error, false);
                    }

                    clearForm();
                }
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
                ReSetMsg();
                string LoadShiftsWeekRange = DateDropDown.SelectedItem.Text.Trim();
                List<string> dates = new List<string>(LoadWeekDays(LoadShiftsWeekRange));

                if (dates.Count != 0)
                {
                    chkMon.Text = dates[0];
                    chkTue.Text = dates[1];
                    chkWed.Text = dates[2];
                    chkThu.Text = dates[3];
                    chkFri.Text = dates[4];
                    chkSat.Text = dates[5];
                    chkSun.Text = dates[6];
                }
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
        protected void grdViewShifts_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                ReSetMsg();
                obj = new frmCreateRoaster_Controller();
                if(e.CommandName.ToString().ToUpper() == "EDITROW")
                {
                    clearForm();
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

                            // roster ID
                            lblROster.Text = e.CommandArgument.ToString().Trim();

                            // roster site
                            dpSiteMonday.ClearSelection();
                            dpSiteMonday.SelectedIndex = dpSiteMonday.Items.IndexOf(dpSiteMonday.Items.FindByText(dt.Rows[i]["RosterSite"].ToString().Trim()));
                            //dpSiteMonday.Items.FindByText(dt.Rows[i]["RosterSite"].ToString().Trim()).Selected = true;

                            // roster Task
                            txtTaskMonday.Text = dt.Rows[i]["RosterTask"].ToString().Trim(); 

                            // roster Day
                            var rosterDayDate = DateTime.Parse(dt.Rows[i]["RosterDate"].ToString().Trim());
                            //dpSelectDay.ClearSelection();
                            //dpSelectDay.Items.FindByText(rosterDayDate.DayOfWeek +", "+rosterDayDate.ToString("dd/MMM/yyyy")).Selected = true;
                            switch (rosterDayDate.DayOfWeek.ToString().ToLower())
                            {
                                case "monday":
                                    chkMon.Checked = true;
                                    break;
                                case "tuesday":
                                    chkTue.Checked = true;
                                    break;
                                case "wednesday":
                                    chkWed.Checked = true;
                                    break;
                                case "thursday":
                                    chkThu.Checked = true;
                                    break;
                                case "friday":
                                    chkFri.Checked = true;
                                    break;
                                case "saturday":
                                    chkSat.Checked = true;
                                    break;
                                case "sunday":
                                    chkSun.Checked = true;
                                    break;     
                            }

                            //Employee Name
                            DataTable dtEmpNameEmail = new DataTable();
                            dtEmpNameEmail = obj.GetEmpNameEmail(Guid.Parse(lblROster.Text));
                            if (dtEmpNameEmail == null)
                                showErrorMessage(obj.ErrorString, false);
                            else
                                txtSearchEmployeeName.Text = dtEmpNameEmail.Rows[0]["emp_name"].ToString() + " - " + dtEmpNameEmail.Rows[0]["email"].ToString();
                            break;
                        }
                       
                    }

                    btnCreateRoster.Visible = false;
                    btnUpdate.Visible = true;
                    
                }
                if(e.CommandName.ToString().ToUpper() == "DELETEROW")
                {
                    if (obj.DeleteShift(Guid.Parse(e.CommandArgument.ToString().Trim())))
                    {
                        lblTotal.Text = "";
                        btnAll_Click(null, null);
                        showErrorMessage("Delete Successfully", true);
                    }
                    else
                        showErrorMessage(obj.ErrorString, false);

                    
                }

                
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
            PopulateLocation();
            LoadHours();
            LoadMinutes();
            txtTaskMonday.Text = "";
            btnCreateRoster.Visible = true;
            btnUpdate.Visible = false;
            chkMon.Checked = false;
            chkTue.Checked = false;
            chkWed.Checked = false;
            chkThu.Checked = false;
            chkFri.Checked = false;
            chkSat.Checked = false;
            chkSun.Checked = false;
            dpStartHoursMonday.SelectedIndex = 0;
            dpEndHoursMonday.SelectedIndex = 0;
            dpStartMinutesMonday.SelectedIndex = 0;
            dpEndMinutesMonday.SelectedIndex = 0;
        }
        protected void btnPrevious_Click(object sender, EventArgs e)
        {
            try
            {
                ReSetMsg();
                string[] stD = lblStartWeekDate.Text.Split('-');
                string[] endD = lblEndWeekdate.Text.Split('-');

                DateTime ldowDate = DateTime.Parse(stD[1]).AddDays(-1);
                DateTime fdowDate = ldowDate.AddDays(-6);
                lblStartWeekDate.Text = fdowDate.DayOfWeek.ToString() + "-" + fdowDate.Date.ToShortDateString();
                lblEndWeekdate.Text = ldowDate.DayOfWeek.ToString() + "-" + ldowDate.ToShortDateString();
                string dtTimerange = fdowDate.Date.ToShortDateString() + " - " + ldowDate.ToShortDateString();
                List<string> weekList = (List<string>)ViewState["WeekRange"];
                string finalWeek = weekList.FirstOrDefault(s => s.Contains(dtTimerange));
                DateDropDown.ClearSelection();
                DateDropDown.Items.FindByText(finalWeek).Selected = true;
                btnAll_Click(null, null);
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
                ReSetMsg();
                string[] stD = lblStartWeekDate.Text.Split('-');
                string[] endD = lblEndWeekdate.Text.Split('-');

                DateTime fdowDate = DateTime.Parse(endD[1]).AddDays(1);
                DateTime ldowDate = fdowDate.AddDays(6);
                lblStartWeekDate.Text = fdowDate.DayOfWeek.ToString()+"-"+ fdowDate.Date.ToShortDateString();
                lblEndWeekdate.Text = ldowDate.DayOfWeek.ToString()+"-"+ ldowDate.ToShortDateString();
                string dtTimerange = fdowDate.Date.ToShortDateString() + " - "+ ldowDate.ToShortDateString();
                List<string> weekList = (List<string>)ViewState["WeekRange"];
                string finalWeek = weekList.FirstOrDefault(s => s.Contains(dtTimerange));
                DateDropDown.ClearSelection();
                DateDropDown.Items.FindByText(finalWeek).Selected = true;

                btnAll_Click(null, null);

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
                ReSetMsg();
                obj = new frmCreateRoaster_Controller();
                string[] empEmail = txtSearchEmployeeName.Text.Split('-');
                string[] rosterDayAndDate = new string[2]; /*= dpSelectDay.SelectedValue.Split(',');*/

                if (chkMon.Checked)
                    rosterDayAndDate = chkMon.Text.Split(',');
                else if (chkTue.Checked)
                    rosterDayAndDate = chkTue.Text.Split(',');
                else if (chkWed.Checked)
                    rosterDayAndDate = chkWed.Text.Split(',');
                else if (chkThu.Checked)
                    rosterDayAndDate = chkThu.Text.Split(',');
                else if (chkFri.Checked)
                    rosterDayAndDate = chkFri.Text.Split(',');
                else if (chkSat.Checked)
                    rosterDayAndDate = chkSat.Text.Split(',');
                else if (chkSun.Checked)
                    rosterDayAndDate = chkSun.Text.Split(',');

                Roster objRoster = new Roster()
                {
                    AssignedEmployeeEmail = empEmail[1].Trim()
                    ,RosterDate = DateTime.Parse(rosterDayAndDate[1].Trim())
                    ,RosterStartTime = DateTime.Parse(dpStartHoursMonday.SelectedItem.Text + ":" + dpStartMinutesMonday.SelectedItem.Text)
                    ,RosterEndTime = DateTime.Parse(dpEndHoursMonday.SelectedItem.Text + ":" + dpEndMinutesMonday.SelectedItem.Text)
                    ,RosterSite = dpSiteMonday.SelectedItem.Text
                    ,RosterTask = txtTaskMonday.Text
                    ,RosterID = Guid.Parse(lblROster.Text)
                };

                if (obj.UpdateEmployeeRoster(objRoster))
                {
                    showErrorMessage("Update Successfully", true);
                    btnAll_Click(null, null);
                    clearForm();
                }
                else
                    showErrorMessage(obj.ErrorString, false);


            }
            catch (Exception ex)
            {
                showErrorMessage(ex.Message, false);
            }
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            clearForm();
        }
        protected void btnAll_Click(object sender, EventArgs e)
        {
            try
            {
                //ReSetMsg();
                btnAll.Enabled = false;
                btnMon.Enabled = true;
                btnTue.Enabled = true;
                btnWed.Enabled = true;
                btnThur.Enabled = true;
                btnFri.Enabled = true;
                btnSat.Enabled = true;
                btnSun.Enabled = true;
                string[] stD = lblStartWeekDate.Text.Split('-');
                string[] endD = lblEndWeekdate.Text.Split('-');
                obj = new frmCreateRoaster_Controller();
                dt = new DataTable();
                dt = obj.LoadAllEmployeesRoster(int.Parse(Session["userid"].ToString()), DateTime.Parse(stD[1]), DateTime.Parse(endD[1]));
                dt.Columns.Add("TotalHours", typeof(string));
                grdViewShifts.DataSource = null;
                grdViewShifts.DataBind();
                float totalHours = 0;

                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dt.Rows)
                        {
                            int startTime = Convert.ToInt32(DateTime.Parse(dr["RosterStartTime"].ToString()).Hour.ToString());
                            int EndTime = Convert.ToInt32(DateTime.Parse(dr["RosterEndTime"].ToString()).Hour.ToString());
                            if (startTime < EndTime)
                            {
                                TimeSpan duration = DateTime.Parse(dr["RosterEndTime"].ToString()).Subtract(DateTime.Parse(dr["RosterStartTime"].ToString()));
                                dr["TotalHours"] = duration.ToString();
                                totalHours += (float)duration.TotalHours;
                            }
                            else
                            {
                                DateTime Rosterdate = DateTime.Parse(dr["RosterEndTime"].ToString());
                                DateTime startTimeA = DateTime.Parse(dr["RosterStartTime"].ToString());

                                DateTime RosterEndDate = Rosterdate.AddDays(1);
                                DateTime startTimeB = DateTime.Parse(dr["RosterEndTime"].ToString());

                                DateTime a = new DateTime(Rosterdate.Year, Rosterdate.Month, Rosterdate.Day, startTimeA.Hour, startTimeA.Minute, startTimeA.Second);
                                DateTime b = new DateTime(RosterEndDate.Year, RosterEndDate.Month, RosterEndDate.Day, startTimeB.Hour, startTimeB.Minute, startTimeB.Second);

                                TimeSpan duration = b - a;
                                dr["TotalHours"] = duration.ToString();
                                totalHours += (float)duration.TotalHours;
                            }

                        }

                        grdViewShifts.DataSource = dt;
                        grdViewShifts.DataBind();
                        lblTotal.Text = totalHours.ToString();
                    }
                    else
                    {
                        showAlertMessage("No Roster Found in current Selected Week.");
                        btnAll.Enabled = false;
                        btnMon.Enabled = false;
                        btnTue.Enabled = false;
                        btnWed.Enabled = false;
                        btnThur.Enabled = false;
                        btnFri.Enabled = false;
                        btnSat.Enabled = false;
                        btnSun.Enabled = false;
                    }
                }
                else
                    showErrorMessage(obj.ErrorString, false);

                ViewState["dtShifts"] = dt;
            }
            catch (Exception ex)
            {
                showErrorMessage(ex.Message, false);
            }
        }
        protected void btnMon_Click(object sender, EventArgs e)
        {
            try
            {
                ReSetMsg();
                btnAll.Enabled = true;
                btnMon.Enabled = false;
                btnTue.Enabled = true;
                btnWed.Enabled = true;
                btnThur.Enabled = true;
                btnFri.Enabled = true;
                btnSat.Enabled = true;
                btnSun.Enabled = true;
                lblTotal.Text = "";
                string[] stD = lblStartWeekDate.Text.Split('-');
                string[] endD = lblEndWeekdate.Text.Split('-');
                grdViewShifts.DataSource = null;
                grdViewShifts.DataBind();
                obj = new frmCreateRoaster_Controller();
                dt = new DataTable();
                dt = obj.LoadAllEmployeesRoster(int.Parse(Session["userid"].ToString()), DateTime.Parse(stD[1]), DateTime.Parse(endD[1]));

                if (dt != null)
                {
                    if (dt.Rows.Count != 0)
                    {

                        DataTable dtMonday = new DataTable();
                        dtMonday = dt.Clone();
                        float totalHours = 0;
                        foreach (DataRow dr in dt.Rows)
                        {
                            var dayt = DateTime.Parse(dr["RosterDate"].ToString());
                            if (dayt.DayOfWeek.ToString().ToLower() == "monday")
                                dtMonday.ImportRow(dr);
                        }
                        dtMonday.Columns.Add("TotalHours", typeof(string));

                        if (dtMonday.Rows.Count != 0)
                        {

                            foreach (DataRow dr in dtMonday.Rows)
                            {
                                int startTime = Convert.ToInt32(DateTime.Parse(dr["RosterStartTime"].ToString()).Hour.ToString());
                                int EndTime = Convert.ToInt32(DateTime.Parse(dr["RosterEndTime"].ToString()).Hour.ToString());
                                if (startTime < EndTime)
                                {
                                    TimeSpan duration = DateTime.Parse(dr["RosterEndTime"].ToString()).Subtract(DateTime.Parse(dr["RosterStartTime"].ToString()));
                                    dr["TotalHours"] = duration.ToString();
                                    totalHours += (float)duration.TotalHours;
                                }
                                else
                                {
                                    DateTime Rosterdate = DateTime.Parse(dr["RosterEndTime"].ToString());
                                    DateTime startTimeA = DateTime.Parse(dr["RosterStartTime"].ToString());
                                    DateTime RosterEndDate = Rosterdate.AddDays(1);
                                    DateTime startTimeB = DateTime.Parse(dr["RosterEndTime"].ToString());
                                    DateTime a = new DateTime(Rosterdate.Year, Rosterdate.Month, Rosterdate.Day, startTimeA.Hour, startTimeA.Minute, startTimeA.Second);
                                    DateTime b = new DateTime(RosterEndDate.Year, RosterEndDate.Month, RosterEndDate.Day, startTimeB.Hour, startTimeB.Minute, startTimeB.Second);
                                    TimeSpan duration = b - a;
                                    dr["TotalHours"] = duration.ToString();
                                    totalHours += (float)duration.TotalHours;
                                }
                            }

                            lblTotal.Text = totalHours.ToString();
                            grdViewShifts.DataSource = dtMonday;
                            grdViewShifts.DataBind();

                            float total = totalHours;
                            grdViewShifts.FooterRow.Cells[0].Visible = false;
                            grdViewShifts.FooterRow.Cells[4].Text = "Total hours";
                            grdViewShifts.FooterRow.Cells[4].HorizontalAlign = HorizontalAlign.Right;
                            grdViewShifts.FooterRow.Cells[4].Font.Bold = true;
                            grdViewShifts.FooterRow.Cells[5].Text = total.ToString("N2");
                            grdViewShifts.FooterRow.Cells[5].Font.Bold = true;
                        }
                        else
                        {
                            showAlertMessage("no Roster Shifts on Tuesday");
                        }
                    }
                    else
                        showAlertMessage("No Roster Found in current Selected Week.");
                }
                else
                    showErrorMessage(obj.ErrorString, false);

               
            }
            catch(Exception ex)
            {
                showErrorMessage(ex.Message, false);
            }
        }
        protected void btnTue_Click(object sender, EventArgs e)
        {
            try
            {
                ReSetMsg();
                btnAll.Enabled = true;
                btnMon.Enabled = true;
                btnTue.Enabled = false;
                btnWed.Enabled = true;
                btnThur.Enabled = true;
                btnFri.Enabled = true;
                btnSat.Enabled = true;
                btnSun.Enabled = true;
                string[] stD = lblStartWeekDate.Text.Split('-');
                string[] endD = lblEndWeekdate.Text.Split('-');
                grdViewShifts.DataSource = null;
                grdViewShifts.DataBind();
                obj = new frmCreateRoaster_Controller();
                dt = new DataTable();
                dt = obj.LoadAllEmployeesRoster(int.Parse(Session["userid"].ToString()), DateTime.Parse(stD[1]), DateTime.Parse(endD[1]));
                if(dt != null)
                {
                    if(dt.Rows.Count != 0)
                    {
                        DataTable dtTuesday = new DataTable();
                        dtTuesday = dt.Clone();
                        float totalHours = 0;
                        foreach (DataRow dr in dt.Rows)
                        {
                            var dayt = DateTime.Parse(dr["RosterDate"].ToString());
                            if (dayt.DayOfWeek.ToString().ToLower() == "tuesday")
                                dtTuesday.ImportRow(dr);
                        }

                        dtTuesday.Columns.Add("TotalHours", typeof(string));

                        if (dtTuesday.Rows.Count != 0)
                        {
                            foreach (DataRow dr in dtTuesday.Rows)
                            {
                                int startTime = Convert.ToInt32(DateTime.Parse(dr["RosterStartTime"].ToString()).Hour.ToString());
                                int EndTime = Convert.ToInt32(DateTime.Parse(dr["RosterEndTime"].ToString()).Hour.ToString());
                                if (startTime < EndTime)
                                {
                                    TimeSpan duration = DateTime.Parse(dr["RosterEndTime"].ToString()).Subtract(DateTime.Parse(dr["RosterStartTime"].ToString()));
                                    dr["TotalHours"] = duration.ToString();
                                    totalHours += (float)duration.TotalHours;
                                }
                                else
                                {
                                    DateTime Rosterdate = DateTime.Parse(dr["RosterEndTime"].ToString());
                                    DateTime startTimeA = DateTime.Parse(dr["RosterStartTime"].ToString());
                                    DateTime RosterEndDate = Rosterdate.AddDays(1);
                                    DateTime startTimeB = DateTime.Parse(dr["RosterEndTime"].ToString());
                                    DateTime a = new DateTime(Rosterdate.Year, Rosterdate.Month, Rosterdate.Day, startTimeA.Hour, startTimeA.Minute, startTimeA.Second);
                                    DateTime b = new DateTime(RosterEndDate.Year, RosterEndDate.Month, RosterEndDate.Day, startTimeB.Hour, startTimeB.Minute, startTimeB.Second);
                                    TimeSpan duration = b - a;
                                    dr["TotalHours"] = duration.ToString();
                                    totalHours += (float)duration.TotalHours;
                                }
                            }


                            lblTotal.Text = totalHours.ToString();
                            grdViewShifts.DataSource = dtTuesday;
                            grdViewShifts.DataBind();

                            float total = totalHours;
                            grdViewShifts.FooterRow.Cells[0].Visible = false;
                            grdViewShifts.FooterRow.Cells[4].Text = "Total hours";
                            grdViewShifts.FooterRow.Cells[4].HorizontalAlign = HorizontalAlign.Right;
                            grdViewShifts.FooterRow.Cells[4].Font.Bold = true;
                            grdViewShifts.FooterRow.Cells[5].Text = total.ToString("N2");
                            grdViewShifts.FooterRow.Cells[5].Font.Bold = true;
                        }
                        else
                            showAlertMessage("no Roster found for Tuesday");            
                    }
                    else
                        showAlertMessage("No Roster Found in current Selected Week.");
                }
                else
                    showErrorMessage(obj.ErrorString, false);

               
            }
            catch (Exception ex)
            {
                showErrorMessage(ex.Message, false);
            }
        }
        protected void btnWed_Click(object sender, EventArgs e)
        {
            try
            {
                ReSetMsg();
                btnAll.Enabled = true;
                btnMon.Enabled = true;
                btnTue.Enabled = true;
                btnWed.Enabled = false;
                btnThur.Enabled = true;
                btnFri.Enabled = true;
                btnSat.Enabled = true;
                btnSun.Enabled = true;
                string[] stD = lblStartWeekDate.Text.Split('-');
                string[] endD = lblEndWeekdate.Text.Split('-');
                obj = new frmCreateRoaster_Controller();
                grdViewShifts.DataSource = null;
                grdViewShifts.DataBind();
                float totalHours = 0;
                dt = new DataTable();
                dt = obj.LoadAllEmployeesRoster(int.Parse(Session["userid"].ToString()), DateTime.Parse(stD[1]), DateTime.Parse(endD[1]));

                if (dt != null)
                {
                    if (dt.Rows.Count != 0)
                    {
                        DataTable dtWednesday = new DataTable();
                        dtWednesday = dt.Clone();

                        foreach (DataRow dr in dt.Rows)
                        {
                            var dayt = DateTime.Parse(dr["RosterDate"].ToString());
                            if (dayt.DayOfWeek.ToString().ToLower() == "wednesday")
                                dtWednesday.ImportRow(dr);
                        }

                        if (dtWednesday.Rows.Count != 0)
                        {
                            dtWednesday.Columns.Add("TotalHours", typeof(string));
                            foreach (DataRow dr in dtWednesday.Rows)
                            {
                                int startTime = Convert.ToInt32(DateTime.Parse(dr["RosterStartTime"].ToString()).Hour.ToString());
                                int EndTime = Convert.ToInt32(DateTime.Parse(dr["RosterEndTime"].ToString()).Hour.ToString());
                                if (startTime < EndTime)
                                {
                                    TimeSpan duration = DateTime.Parse(dr["RosterEndTime"].ToString()).Subtract(DateTime.Parse(dr["RosterStartTime"].ToString()));
                                    dr["TotalHours"] = duration.ToString();
                                    totalHours += (float)duration.TotalHours;
                                }
                                else
                                {
                                    DateTime Rosterdate = DateTime.Parse(dr["RosterEndTime"].ToString());
                                    DateTime startTimeA = DateTime.Parse(dr["RosterStartTime"].ToString());
                                    DateTime RosterEndDate = Rosterdate.AddDays(1);
                                    DateTime startTimeB = DateTime.Parse(dr["RosterEndTime"].ToString());
                                    DateTime a = new DateTime(Rosterdate.Year, Rosterdate.Month, Rosterdate.Day, startTimeA.Hour, startTimeA.Minute, startTimeA.Second);
                                    DateTime b = new DateTime(RosterEndDate.Year, RosterEndDate.Month, RosterEndDate.Day, startTimeB.Hour, startTimeB.Minute, startTimeB.Second);
                                    TimeSpan duration = b - a;
                                    dr["TotalHours"] = duration.ToString();
                                    totalHours += (float)duration.TotalHours;
                                }
                            }

                            lblTotal.Text = totalHours.ToString();
                            grdViewShifts.DataSource = dtWednesday;
                            grdViewShifts.DataBind();

                            float total = totalHours;
                            grdViewShifts.FooterRow.Cells[0].Visible = false;
                            grdViewShifts.FooterRow.Cells[4].Text = "Total hours";
                            grdViewShifts.FooterRow.Cells[4].HorizontalAlign = HorizontalAlign.Right;
                            grdViewShifts.FooterRow.Cells[4].Font.Bold = true;
                            grdViewShifts.FooterRow.Cells[5].Text = total.ToString("N2");
                            grdViewShifts.FooterRow.Cells[5].Font.Bold = true;

                        }
                        else
                            showAlertMessage("No shifts for Wednesday");
                    }
                    else
                        showAlertMessage("No Roster Found in current Selected Week.");
                }
                else
                    showErrorMessage(obj.ErrorString, false);

               
            }
            catch (Exception ex)
            {
                showErrorMessage(ex.Message, false);
            }
        }
        protected void btnThur_Click(object sender, EventArgs e)
        {
            try
            {
                ReSetMsg();
                btnAll.Enabled = true;
                btnMon.Enabled = true;
                btnTue.Enabled = true;
                btnWed.Enabled = true;
                btnThur.Enabled = false;
                btnFri.Enabled = true;
                btnSat.Enabled = true;
                btnSun.Enabled = true;
                grdViewShifts.DataSource = null;
                grdViewShifts.DataBind();
                string[] stD = lblStartWeekDate.Text.Split('-');
                string[] endD = lblEndWeekdate.Text.Split('-');
                obj = new frmCreateRoaster_Controller();
                dt = new DataTable();
                dt = obj.LoadAllEmployeesRoster(int.Parse(Session["userid"].ToString()), DateTime.Parse(stD[1]), DateTime.Parse(endD[1]));

                if (dt != null)
                {
                    if (dt.Rows.Count != 0)
                    {
                        DataTable dtthursday = new DataTable();
                        dtthursday = dt.Clone();
                        float totalHours = 0;
                        foreach (DataRow dr in dt.Rows)
                        {
                            var dayt = DateTime.Parse(dr["RosterDate"].ToString());
                            if (dayt.DayOfWeek.ToString().ToLower() == "thursday")
                                dtthursday.ImportRow(dr);
                        }

                        dtthursday.Columns.Add("TotalHours", typeof(string));

                        if (dtthursday.Rows.Count != 0)
                        {
                            foreach (DataRow dr in dtthursday.Rows)
                            {
                                int startTime = Convert.ToInt32(DateTime.Parse(dr["RosterStartTime"].ToString()).Hour.ToString());
                                int EndTime = Convert.ToInt32(DateTime.Parse(dr["RosterEndTime"].ToString()).Hour.ToString());
                                if (startTime < EndTime)
                                {
                                    TimeSpan duration = DateTime.Parse(dr["RosterEndTime"].ToString()).Subtract(DateTime.Parse(dr["RosterStartTime"].ToString()));
                                    dr["TotalHours"] = duration.ToString();
                                    totalHours += (float)duration.TotalHours;
                                }
                                else
                                {
                                    DateTime Rosterdate = DateTime.Parse(dr["RosterEndTime"].ToString());
                                    DateTime startTimeA = DateTime.Parse(dr["RosterStartTime"].ToString());
                                    DateTime RosterEndDate = Rosterdate.AddDays(1);
                                    DateTime startTimeB = DateTime.Parse(dr["RosterEndTime"].ToString());
                                    DateTime a = new DateTime(Rosterdate.Year, Rosterdate.Month, Rosterdate.Day, startTimeA.Hour, startTimeA.Minute, startTimeA.Second);
                                    DateTime b = new DateTime(RosterEndDate.Year, RosterEndDate.Month, RosterEndDate.Day, startTimeB.Hour, startTimeB.Minute, startTimeB.Second);
                                    TimeSpan duration = b - a;
                                    dr["TotalHours"] = duration.ToString();
                                    totalHours += (float)duration.TotalHours;
                                }
                            }
                            lblTotal.Text = totalHours.ToString();
                            grdViewShifts.DataSource = dtthursday;
                            grdViewShifts.DataBind();

                            float total = totalHours;
                            grdViewShifts.FooterRow.Cells[0].Visible = false;
                            grdViewShifts.FooterRow.Cells[4].Text = "Total hours";
                            grdViewShifts.FooterRow.Cells[4].HorizontalAlign = HorizontalAlign.Right;
                            grdViewShifts.FooterRow.Cells[4].Font.Bold = true;
                            grdViewShifts.FooterRow.Cells[5].Text = total.ToString("N2");
                            grdViewShifts.FooterRow.Cells[5].Font.Bold = true;
                        }
                        else
                            showAlertMessage("No roster for thursday");

                       
                    }
                    else
                        showAlertMessage("No Roster Found in current Selected Week.");
                }
                else
                    showErrorMessage(obj.ErrorString, false);

                
            }
            catch (Exception ex)
            {
                showErrorMessage(ex.Message, false);
            }
        }
        protected void btnFri_Click(object sender, EventArgs e)
        {
            try
            {
                ReSetMsg();
                btnAll.Enabled = true;
                btnMon.Enabled = true;
                btnTue.Enabled = true;
                btnWed.Enabled = true;
                btnThur.Enabled = true;
                btnFri.Enabled = false;
                btnSat.Enabled = true;
                btnSun.Enabled = true;
                grdViewShifts.DataSource = null;
                grdViewShifts.DataBind();
                string[] stD = lblStartWeekDate.Text.Split('-');
                string[] endD = lblEndWeekdate.Text.Split('-');
                obj = new frmCreateRoaster_Controller();
                dt = new DataTable();
                dt = obj.LoadAllEmployeesRoster(int.Parse(Session["userid"].ToString()), DateTime.Parse(stD[1]), DateTime.Parse(endD[1]));

                if (dt != null)
                {
                    if (dt.Rows.Count != 0)
                    {
                        DataTable dtFriday = new DataTable();
                        dtFriday = dt.Clone();
                        float totalHours = 0;
                        foreach (DataRow dr in dt.Rows)
                        {
                            var dayt = DateTime.Parse(dr["RosterDate"].ToString());
                            if (dayt.DayOfWeek.ToString().ToLower() == "friday")
                                dtFriday.ImportRow(dr);
                        }

                        dtFriday.Columns.Add("TotalHours", typeof(string));

                        if(dtFriday.Rows.Count !=0)
                        {
                            foreach (DataRow dr in dtFriday.Rows)
                            {
                                int startTime = Convert.ToInt32(DateTime.Parse(dr["RosterStartTime"].ToString()).Hour.ToString());
                                int EndTime = Convert.ToInt32(DateTime.Parse(dr["RosterEndTime"].ToString()).Hour.ToString());
                                if (startTime < EndTime)
                                {
                                    TimeSpan duration = DateTime.Parse(dr["RosterEndTime"].ToString()).Subtract(DateTime.Parse(dr["RosterStartTime"].ToString()));
                                    dr["TotalHours"] = duration.ToString();
                                    totalHours += (float)duration.TotalHours;
                                }
                                else
                                {
                                    DateTime Rosterdate = DateTime.Parse(dr["RosterEndTime"].ToString());
                                    DateTime startTimeA = DateTime.Parse(dr["RosterStartTime"].ToString());
                                    DateTime RosterEndDate = Rosterdate.AddDays(1);
                                    DateTime startTimeB = DateTime.Parse(dr["RosterEndTime"].ToString());
                                    DateTime a = new DateTime(Rosterdate.Year, Rosterdate.Month, Rosterdate.Day, startTimeA.Hour, startTimeA.Minute, startTimeA.Second);
                                    DateTime b = new DateTime(RosterEndDate.Year, RosterEndDate.Month, RosterEndDate.Day, startTimeB.Hour, startTimeB.Minute, startTimeB.Second);
                                    TimeSpan duration = b - a;
                                    dr["TotalHours"] = duration.ToString();
                                    totalHours += (float)duration.TotalHours;
                                }
                            }
                            lblTotal.Text = totalHours.ToString();
                            grdViewShifts.DataSource = dtFriday;
                            grdViewShifts.DataBind();

                            float total = totalHours;
                            grdViewShifts.FooterRow.Cells[0].Visible = false;
                            grdViewShifts.FooterRow.Cells[4].Text = "Total hours";
                            grdViewShifts.FooterRow.Cells[4].HorizontalAlign = HorizontalAlign.Right;
                            grdViewShifts.FooterRow.Cells[4].Font.Bold = true;
                            grdViewShifts.FooterRow.Cells[5].Text = total.ToString("N2");
                            grdViewShifts.FooterRow.Cells[5].Font.Bold = true;
                        }
                        else
                        {
                            showAlertMessage("No Roster Shifts for Friday");
                        }

                        
                    }
                    else
                        showAlertMessage("No Roster Found in current Selected Week.");
                }
                else
                    showErrorMessage(obj.ErrorString, false);

               
            }
            catch (Exception ex)
            {
                showErrorMessage(ex.Message, false);
            }
        }
        protected void btnSat_Click(object sender, EventArgs e)
        {
            try
            {
                ReSetMsg();
                btnAll.Enabled = true;
                btnMon.Enabled = true;
                btnTue.Enabled = true;
                btnWed.Enabled = true;
                btnThur.Enabled = true;
                btnFri.Enabled = true;
                btnSat.Enabled = false;
                btnSun.Enabled = true;
                grdViewShifts.DataSource = null;
                grdViewShifts.DataBind();

                string[] stD = lblStartWeekDate.Text.Split('-');
                string[] endD = lblEndWeekdate.Text.Split('-');
                obj = new frmCreateRoaster_Controller();
                dt = new DataTable();
                dt = obj.LoadAllEmployeesRoster(int.Parse(Session["userid"].ToString()), DateTime.Parse(stD[1]), DateTime.Parse(endD[1]));

                if (dt != null)
                {
                    if (dt.Rows.Count != 0)
                    {
                        DataTable dtSaturday = new DataTable();
                        dtSaturday = dt.Clone();
                        float totalHours = 0;
                        foreach (DataRow dr in dt.Rows)
                        {
                            var dayt = DateTime.Parse(dr["RosterDate"].ToString());
                            if (dayt.DayOfWeek.ToString().ToLower() == "saturday")
                                dtSaturday.ImportRow(dr);
                        }

                        dtSaturday.Columns.Add("TotalHours", typeof(string));

                        if (dtSaturday.Rows.Count != 0)
                        {
                            foreach (DataRow dr in dtSaturday.Rows)
                            {
                                int startTime = Convert.ToInt32(DateTime.Parse(dr["RosterStartTime"].ToString()).Hour.ToString());
                                int EndTime = Convert.ToInt32(DateTime.Parse(dr["RosterEndTime"].ToString()).Hour.ToString());
                                if (startTime < EndTime)
                                {
                                    TimeSpan duration = DateTime.Parse(dr["RosterEndTime"].ToString()).Subtract(DateTime.Parse(dr["RosterStartTime"].ToString()));
                                    dr["TotalHours"] = duration.ToString();
                                    totalHours += (float)duration.TotalHours;
                                }
                                else
                                {
                                    DateTime Rosterdate = DateTime.Parse(dr["RosterEndTime"].ToString());
                                    DateTime startTimeA = DateTime.Parse(dr["RosterStartTime"].ToString());
                                    DateTime RosterEndDate = Rosterdate.AddDays(1);
                                    DateTime startTimeB = DateTime.Parse(dr["RosterEndTime"].ToString());
                                    DateTime a = new DateTime(Rosterdate.Year, Rosterdate.Month, Rosterdate.Day, startTimeA.Hour, startTimeA.Minute, startTimeA.Second);
                                    DateTime b = new DateTime(RosterEndDate.Year, RosterEndDate.Month, RosterEndDate.Day, startTimeB.Hour, startTimeB.Minute, startTimeB.Second);
                                    TimeSpan duration = b - a;
                                    dr["TotalHours"] = duration.ToString();
                                    totalHours += (float)duration.TotalHours;
                                }
                            }
                            lblTotal.Text = totalHours.ToString();
                            grdViewShifts.DataSource = dtSaturday;
                            grdViewShifts.DataBind();

                            float total = totalHours;
                            grdViewShifts.FooterRow.Cells[0].Visible = false;
                            grdViewShifts.FooterRow.Cells[4].Text = "Total hours";
                            grdViewShifts.FooterRow.Cells[4].HorizontalAlign = HorizontalAlign.Right;
                            grdViewShifts.FooterRow.Cells[4].Font.Bold = true;
                            grdViewShifts.FooterRow.Cells[5].Text = total.ToString("N2");
                            grdViewShifts.FooterRow.Cells[5].Font.Bold = true;
                        }
                        else
                            showAlertMessage("No Roster Shifts for Saturday");
                       
                    }
                    else
                        showAlertMessage("No Roster Found in current Selected Week.");
                }
                else
                    showErrorMessage(obj.ErrorString, false);

              
            }
            catch (Exception ex)
            {
                showErrorMessage(ex.Message, false);
            }
        }
        protected void btnSun_Click(object sender, EventArgs e)
        {
            try
            {
                ReSetMsg();
                grdViewShifts.DataSource = null;
                grdViewShifts.DataBind();
                btnAll.Enabled = true;
                btnMon.Enabled = true;
                btnTue.Enabled = true;
                btnWed.Enabled = true;
                btnThur.Enabled = true;
                btnFri.Enabled = true;
                btnSat.Enabled = true;
                btnSun.Enabled = false;
                string[] stD = lblStartWeekDate.Text.Split('-');
                string[] endD = lblEndWeekdate.Text.Split('-');
                obj = new frmCreateRoaster_Controller();
                dt = new DataTable();
                dt = obj.LoadAllEmployeesRoster(int.Parse(Session["userid"].ToString()), DateTime.Parse(stD[1]), DateTime.Parse(endD[1]));

                if (dt != null)
                {
                    if (dt.Rows.Count != 0)
                    {
                        DataTable dtSunday = new DataTable();
                        dtSunday = dt.Clone();
                        float totalHours = 0;
                        foreach (DataRow dr in dt.Rows)
                        {
                            var dayt = DateTime.Parse(dr["RosterDate"].ToString());
                            if (dayt.DayOfWeek.ToString().ToLower() == "sunday")
                                dtSunday.ImportRow(dr);
                        }

                        dtSunday.Columns.Add("TotalHours", typeof(string));

                        if (dtSunday.Rows.Count != 0)
                        {
                            foreach (DataRow dr in dtSunday.Rows)
                            {
                                int startTime = Convert.ToInt32(DateTime.Parse(dr["RosterStartTime"].ToString()).Hour.ToString());
                                int EndTime = Convert.ToInt32(DateTime.Parse(dr["RosterEndTime"].ToString()).Hour.ToString());
                                if (startTime < EndTime)
                                {
                                    TimeSpan duration = DateTime.Parse(dr["RosterEndTime"].ToString()).Subtract(DateTime.Parse(dr["RosterStartTime"].ToString()));
                                    dr["TotalHours"] = duration.ToString();
                                    totalHours += (float)duration.TotalHours;
                                }
                                else
                                {
                                    DateTime Rosterdate = DateTime.Parse(dr["RosterEndTime"].ToString());
                                    DateTime startTimeA = DateTime.Parse(dr["RosterStartTime"].ToString());
                                    DateTime RosterEndDate = Rosterdate.AddDays(1);
                                    DateTime startTimeB = DateTime.Parse(dr["RosterEndTime"].ToString());
                                    DateTime a = new DateTime(Rosterdate.Year, Rosterdate.Month, Rosterdate.Day, startTimeA.Hour, startTimeA.Minute, startTimeA.Second);
                                    DateTime b = new DateTime(RosterEndDate.Year, RosterEndDate.Month, RosterEndDate.Day, startTimeB.Hour, startTimeB.Minute, startTimeB.Second);
                                    TimeSpan duration = b - a;
                                    dr["TotalHours"] = duration.ToString();
                                    totalHours += (float)duration.TotalHours;
                                }
                            }
                            lblTotal.Text = totalHours.ToString();
                            grdViewShifts.DataSource = dtSunday;
                            grdViewShifts.DataBind();

                            float total = totalHours;
                            grdViewShifts.FooterRow.Cells[0].Visible = false;
                            grdViewShifts.FooterRow.Cells[4].Text = "Total hours";
                            grdViewShifts.FooterRow.Cells[4].HorizontalAlign = HorizontalAlign.Right;
                            grdViewShifts.FooterRow.Cells[4].Font.Bold = true;
                            grdViewShifts.FooterRow.Cells[5].Text = total.ToString("N2");
                            grdViewShifts.FooterRow.Cells[5].Font.Bold = true;
                        }
                        else
                            showAlertMessage("No roster shifts for Sunday.");
                       
                    }
                    else
                        showAlertMessage("No Roster Found in current Selected Week.");
                }
                else
                    showErrorMessage(obj.ErrorString, false);

              
            }
            catch (Exception ex)
            {
                showErrorMessage(ex.Message, false);
            }
        }
        private void LoadClientName(int comID)
        {
            try
            {
                obj = new frmCreateRoaster_Controller();
                dt = new DataTable();
                dt = obj.LoadClients(comID);
                if (dt != null)
                {
                    dt.Columns.Remove("CompanyId");
                    dpClients.DataSource = dt;
                    dpClients.DataBind();
                    ViewState["dtClient"] = dt;
                }
                else
                    showErrorMessage(obj.ErrorString, false);
            }
            catch (Exception ex)
            {
                showErrorMessage(ex.Message, false);
            }
        }
        private void ReSetMsg()
        {
            lblErrorMsg.Text = "";
            lblsuccessmsg.Text = "";
            lblAlert.Text = "";
            lblTotal.Text = "";
            errorMsg.Style.Add("display", "none");
            successMsg.Style.Add("display", "none");
            AlertDiv.Style.Add("display", "none");
        }
        private void showAlertMessage(string msg)
        {
            ReSetMsg();
            lblAlert.Text = msg;
            AlertDiv.Style.Add("display", "block");
            string script = @"setTimeout(function(){document.getElementById('" + AlertDiv.ClientID + "').style.display='none';},8000);";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "somekey", script, true);
        }
    }
}