using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using Controller;
using System.Drawing;

namespace Morpheus.Accounts
{
    public partial class frmViewTimeSheet : System.Web.UI.Page
    {
        DataTable dt;
        frmViewTimeSheet_Controller obj;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if(!IsPostBack)
                {
                    loadDate();
                    loadEmployee(int.Parse(Session["userid"].ToString()));
                    btnSendRosterEmail.Enabled = false;
                }
            }
            catch(Exception ex)
            {
                Response.Redirect("login.aspx");
            }
        }

        private void loadEmployee(int companyId)
        {
            try
            {
                dt = new DataTable();
                obj = new frmViewTimeSheet_Controller();
                dt = obj.viewEmployeeByCompany(companyId);
                if (dt != null)
                {
                    dtgridview_Employees.DataSource = dt;
                    dtgridview_Employees.DataBind();
                    ViewState["dtEmployees"] = dt;
                }
                else
                    showErrorMessage(obj.ErrorString, false);
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
               
            }
            catch (Exception ex)
            {
                showErrorMessage(ex.Message, false);
            }
        }


        private void LoadTimeSheet(int UID, int EmpID, DateTime stdt, DateTime endDt)
        {
            try
            {
                obj = new frmViewTimeSheet_Controller();
                dt = new DataTable();
                grdViewShifts.DataSource = null;
                grdViewShifts.DataBind();
                dt = obj.viewTimeSheetOfEmployee(UID, EmpID, stdt, endDt);
                ViewState["EmpTimeSheet"] = dt;
                float totalHours = 0;
                if (dt != null)
                {
                    dt.Columns.Add("TotalHours", typeof(string));

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

                        //Calculate Sum and display in Footer Row
                        float total = totalHours;
                        grdViewShifts.FooterRow.Cells[0].Visible = false;
                        grdViewShifts.FooterRow.Cells[4].Text = "Total hours";
                        grdViewShifts.FooterRow.Cells[4].HorizontalAlign = HorizontalAlign.Right;
                        grdViewShifts.FooterRow.Cells[5].Font.Bold = true;
                        grdViewShifts.FooterRow.Cells[5].Text = total.ToString("N2");
                        grdViewShifts.FooterRow.Cells[5].Font.Bold = true;
                        grdViewShifts.FooterRow.Cells[9].Visible = false;
                    }
                    else
                        showErrorMessage("No TimeSheet Found", false);
                }
                else
                    showErrorMessage(obj.ErrorString, false);
            }
            catch(Exception ex)
            {
                showErrorMessage(ex.Message, false);
            }
        }
        protected void grdViewShifts_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                showErrorMessage(ex.Message, false);
            }
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
                if (ViewState["EmpID"] != null)
                    LoadTimeSheet(int.Parse(Session["userid"].ToString()), int.Parse(ViewState["EmpID"].ToString()), DateTime.Parse(fdowDate.Date.ToShortDateString()), DateTime.Parse(ldowDate.ToShortDateString()));
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
                if (ViewState["EmpID"] != null)
                    LoadTimeSheet(int.Parse(Session["userid"].ToString()), int.Parse(ViewState["EmpID"].ToString()), DateTime.Parse(fdowDate.Date.ToShortDateString()), DateTime.Parse(ldowDate.ToShortDateString()));
            }
            catch (Exception ex)
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

        protected void dtgridview_Employees_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void dtgridview_Employees_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                
                obj = new frmViewTimeSheet_Controller();
                DataTable dtRoster = new DataTable();
                string[] stD = lblStartWeekDate.Text.Split('-');
                string[] endD = lblEndWeekdate.Text.Split('-');
                if (e.CommandName.ToString().ToUpper() == "TIMESHEET")
                {
                    btnSendRosterEmail.Enabled = true;
                    string rId = e.CommandArgument.ToString();
                    ViewState["EmpID"] = rId;
                    dt = new DataTable();
                    dt = (DataTable)ViewState["dtEmployees"];
                    LoadTimeSheet(int.Parse(Session["userid"].ToString()), int.Parse(rId), DateTime.Parse(stD[1]), DateTime.Parse(endD[1]));
                }
            }
            catch(Exception ex)
            {
                showErrorMessage(ex.Message, false);
            }
        }

        protected void dtgridview_Employees_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void btnSendRosterEmail_Click(object sender, EventArgs e)
        {
            try
            {
                obj = new frmViewTimeSheet_Controller();
                dt = new DataTable();
                dt = (DataTable)ViewState["EmpTimeSheet"];
                string[] stD = lblStartWeekDate.Text.Split('-');
                string[] endD = lblEndWeekdate.Text.Split('-');
                List<string> shifts = new List<string>();
                string RID = (string)ViewState["EmpID"];
                DataTable dtEmp = new DataTable();
                dtEmp = (DataTable)ViewState["dtEmployees"];
                string _toEmail = string.Empty;

                foreach(DataRow dr in dtEmp.Rows)
                {
                    if (RID == dr["EmployeeId"].ToString())
                    {
                        _toEmail = dr["email"].ToString();
                        break;
                    }
                }

                foreach (DataRow dr in dt.Rows)
                {
                    string dayS = DateTime.Parse(dr["RosterDate"].ToString()).DayOfWeek.ToString()+" "+ DateTime.Parse(dr["RosterDate"].ToString()).ToShortDateString();
                    string timeS = DateTime.Parse(dr["RosterStartTime"].ToString()).ToShortTimeString() +" to " + DateTime.Parse(dr["RosterEndTime"].ToString()).ToShortTimeString();
                    shifts.Add(dayS +": "+dr["RosterSite"].ToString()+": "+ dr["RosterTask"].ToString() +"; "+ timeS);
                }

                if (obj.SendRosterNotificationToEmployee(_toEmail, dt.Rows[0]["emp_name"].ToString(), stD[1], endD[1], shifts))
                    showErrorMessage("Roster has been sent on email.", true);
                else
                    showErrorMessage(obj.ErrorString, false);
            }
            catch(Exception ex)
            {
                showErrorMessage(ex.Message, false);
            }
        }

        protected void btnExportToExcel_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = (DataTable)ViewState["EmpTimeSheet"];

                Response.Clear();
                Response.AddHeader("content-disposition", "attachment;filename=" + dt.Rows[0]["emp_name"].ToString() + ".xls");
                Response.Charset = "";
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.ContentType = "application/vnd.ms-excel";

                System.IO.StringWriter stringWrite = new System.IO.StringWriter();
                System.Web.UI.HtmlTextWriter htmlWrite = new System.Web.UI.HtmlTextWriter(stringWrite);
                ClearControls(grdViewShifts);
                grdViewShifts.RenderControl(htmlWrite);
                HttpContext.Current.Response.Write(stringWrite.ToString());
                HttpContext.Current.Response.End();
            }
            catch(Exception ex)
            {
                showErrorMessage(ex.Message, false);
            }
        }

        private static void ClearControls(System.Web.UI.Control control)
        {
            //Recursively loop through the controls, calling this method
            for (int i = control.Controls.Count - 1; i >= 0; i--)
            {
                ClearControls(control.Controls[i]);
            }

            //If we have a control that is anything other than a table cell
            if (!(control is TableCell))
            {
                if (control.GetType().GetProperty("SelectedItem") != null)
                {
                    LiteralControl literal = new LiteralControl();
                    control.Parent.Controls.Add(literal);
                    try
                    {
                        literal.Text = (string)control.GetType().GetProperty("SelectedItem").GetValue(control, null);
                    }
                    catch
                    {
                    }
                    control.Parent.Controls.Remove(control);
                }
                else
                    if (control.GetType().GetProperty("Text") != null)
                {
                    LiteralControl literal = new LiteralControl();
                    control.Parent.Controls.Add(literal);
                    literal.Text = (string)control.GetType().GetProperty("Text").GetValue(control, null);
                    control.Parent.Controls.Remove(control);
                }
            }
            return;
        }
    }

    
}