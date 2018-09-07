using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Controller;

namespace Seguro.Accounts
{
    public partial class frmViewRoster : System.Web.UI.Page
    {
        DataTable dt;
        frmViewRoster_Controller obj;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                try
                {
                    if (Session["UserTypeID"].ToString() == "3")
                    {
                        loadDate();
                        LoadEmployeesShift(lblStartWeekDate.Text, lblEndWeekdate.Text);
                    }
                    else
                        Response.Redirect("login.aspx");
                }
                catch(Exception ex)
                {
                    Response.Redirect("login.aspx");
                }
            }
        }

        private void LoadEmployeesShift(string startDate, string EndDate)
        {
            try
            {
                resetLabel();
                string[] stD = startDate.Split('-');
                string[] endD = EndDate.Split('-');
                dt = new DataTable();
                obj = new frmViewRoster_Controller();
                dt = obj.LoadEmployeeRoster(int.Parse(Session["userid"].ToString()), DateTime.Parse(stD[1]), DateTime.Parse(endD[1]));
                dt.Columns.Add("TotalHours", typeof(string));
                float totalHours = 0;          

                if (dt != null)
                {
                    if (dt.Rows.Count != 0)
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



                        float total = totalHours;
                        grdViewShifts.FooterRow.Cells[0].Visible = false;
                        grdViewShifts.FooterRow.Cells[3].Text = "Total hours";
                        grdViewShifts.FooterRow.Cells[3].HorizontalAlign = HorizontalAlign.Right;
                        grdViewShifts.FooterRow.Cells[3].Font.Bold = true;
                        grdViewShifts.FooterRow.Cells[4].Text = total.ToString("N2");
                        grdViewShifts.FooterRow.Cells[4].Font.Bold = true;
                    }
                    else
                    {
                        grdViewShifts.DataSource = null;
                        grdViewShifts.DataBind();
                        showErrorMessage("No Roster for selected Date", false);
                    }
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
            lblStartWeekDate.Text = fdow.ToString() + "-" + fdowDate.Date.ToShortDateString();

            DateTime ldowDate = fdowDate.AddDays(6);
            lblEndWeekdate.Text = ldowDate.DayOfWeek.ToString() + "-" + ldowDate.ToShortDateString();

        }


        protected void btnPrevious_Click(object sender, EventArgs e)
        {
            try
            {
                string[] stD = lblStartWeekDate.Text.Split('-');
                string[] endD = lblEndWeekdate.Text.Split('-');

                DateTime ldowDate = DateTime.Parse(stD[1]).AddDays(-1);
                DateTime fdowDate = ldowDate.AddDays(-6);
                lblStartWeekDate.Text = fdowDate.DayOfWeek.ToString() + "-" + fdowDate.Date.ToShortDateString();
                lblEndWeekdate.Text = ldowDate.DayOfWeek.ToString() + "-" + ldowDate.ToShortDateString();

                LoadEmployeesShift(lblStartWeekDate.Text, lblEndWeekdate.Text);
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

                DateTime fdowDate = DateTime.Parse(endD[1]).AddDays(1);
                DateTime ldowDate = fdowDate.AddDays(6);
                lblStartWeekDate.Text = fdowDate.DayOfWeek.ToString() + "-" + fdowDate.Date.ToShortDateString();
                lblEndWeekdate.Text = ldowDate.DayOfWeek.ToString() + "-" + ldowDate.ToShortDateString();

                LoadEmployeesShift(lblStartWeekDate.Text, lblEndWeekdate.Text);

            }
            catch (Exception ex)
            {
                showErrorMessage(ex.Message, false);
            }
        }

        protected void grdViewShifts_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                obj = new frmViewRoster_Controller();
                if (e.CommandName.ToString().ToUpper() == "ACCEPTSHIFT")
                {
                    if (obj.UpdateEmployeeRoster(Guid.Parse(e.CommandArgument.ToString().Trim()), "Accepted"))
                    {
                        LoadEmployeesShift(lblStartWeekDate.Text, lblEndWeekdate.Text);
                        showErrorMessage("Shift Accepted", true);
                    }
                    else
                        showErrorMessage(obj.ErrorString, false);
                }
                if(e.CommandName.ToString().ToUpper() == "REJECTSHIFT")
                {
                    if (obj.UpdateEmployeeRoster(Guid.Parse(e.CommandArgument.ToString().Trim()), "Rejected"))
                    {
                        LoadEmployeesShift(lblStartWeekDate.Text, lblEndWeekdate.Text);
                        showErrorMessage("Shift Rejected", true);
                    }
                    else
                        showErrorMessage(obj.ErrorString, false);
                }
            }

            catch (Exception ex)
            {
                showErrorMessage(ex.Message, false);
            }
        }

        protected void grdViewShifts_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.Cells[6].Text.ToLower() == "pending")
                    e.Row.BackColor = System.Drawing.Color.Yellow;

                if (e.Row.Cells[6].Text.ToLower() == "rejected")
                    e.Row.CssClass = "danger";

                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    LinkButton lbDelete = (LinkButton)e.Row.FindControl("lbReject");
                    lbDelete.Attributes.Add("onclick", "return confirm('Are you sure to Reject the Roster/shift ?');");
                }
            }
            catch(Exception ex)
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

        private void resetLabel()
        {
            lblErrorMsg.Text = "";
            lblsuccessmsg.Text = "";
            successMsg.Style.Add("display", "none");
            errorMsg.Style.Add("display", "none");

        }
    }
}