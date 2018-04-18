using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Controller;

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
                    //dtgridview_Employees.HeaderRow.TableSection = TableRowSection.TableHeader;
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

        protected void btnAll_Click(object sender, EventArgs e)
        {
            try
            {
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
                btnAll.Enabled = true;
                btnMon.Enabled = false;
                btnTue.Enabled = true;
                btnWed.Enabled = true;
                btnThur.Enabled = true;
                btnFri.Enabled = true;
                btnSat.Enabled = true;
                btnSun.Enabled = true;
                //lblTotal.Text = "";
                string[] stD = lblStartWeekDate.Text.Split('-');
                string[] endD = lblEndWeekdate.Text.Split('-');
            }
            catch (Exception ex)
            {
                showErrorMessage(ex.Message, false);
            }
        }

        protected void btnTue_Click(object sender, EventArgs e)
        {
            try
            {
                btnAll.Enabled = true;
                btnMon.Enabled = true;
                btnTue.Enabled = false;
                btnWed.Enabled = true;
                btnThur.Enabled = true;
                btnFri.Enabled = true;
                btnSat.Enabled = true;
                btnSun.Enabled = true;
                //lblTotal.Text = "";
                string[] stD = lblStartWeekDate.Text.Split('-');
                string[] endD = lblEndWeekdate.Text.Split('-');
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
                btnAll.Enabled = true;
                btnMon.Enabled = true;
                btnTue.Enabled = true;
                btnWed.Enabled = false;
                btnThur.Enabled = true;
                btnFri.Enabled = true;
                btnSat.Enabled = true;
                btnSun.Enabled = true;
                //lblTotal.Text = "";
                string[] stD = lblStartWeekDate.Text.Split('-');
                string[] endD = lblEndWeekdate.Text.Split('-');
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
                btnAll.Enabled = true;
                btnMon.Enabled = true;
                btnTue.Enabled = true;
                btnWed.Enabled = true;
                btnThur.Enabled = false;
                btnFri.Enabled = true;
                btnSat.Enabled = true;
                btnSun.Enabled = true;
                //lblTotal.Text = "";
                string[] stD = lblStartWeekDate.Text.Split('-');
                string[] endD = lblEndWeekdate.Text.Split('-');
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
                btnAll.Enabled = true;
                btnMon.Enabled = true;
                btnTue.Enabled = true;
                btnWed.Enabled = true;
                btnThur.Enabled = true;
                btnFri.Enabled = true;
                btnSat.Enabled = true;
                btnSun.Enabled = true;
                //lblTotal.Text = "";
                string[] stD = lblStartWeekDate.Text.Split('-');
                string[] endD = lblEndWeekdate.Text.Split('-');
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
                dt = obj.viewTimeSheetOfEmployee(UID, EmpID, stdt, endDt);
                ViewState["EmpTimeSheet"] = dt;
                float totalHours = 0;
                if (dt != null)
                {
                    dt.Columns.Add("TotalHours", typeof(string));

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

                        //lblTotal.Text = totalHours.ToString();
                        grdViewShifts.DataSource = dt;
                        grdViewShifts.DataBind();

                    //Calculate Sum and display in Footer Row
                    float total = totalHours;//dt.AsEnumerable().Sum(row => row.Field<decimal>("TotalHours"));
                    grdViewShifts.FooterRow.Cells[0].Visible = false;
                    grdViewShifts.FooterRow.Cells[3].Text = "Total hours";
                    grdViewShifts.FooterRow.Cells[3].HorizontalAlign = HorizontalAlign.Right;
                    grdViewShifts.FooterRow.Cells[3].Font.Bold = true;
                    grdViewShifts.FooterRow.Cells[4].Text = total.ToString("N2");
                    grdViewShifts.FooterRow.Cells[4].Font.Bold = true;

                }
                else
                {
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
                string[] stD = lblStartWeekDate.Text.Split('-');
                string[] endD = lblEndWeekdate.Text.Split('-');

                DateTime fdowDate = DateTime.Parse(endD[1]).AddDays(1);
                DateTime ldowDate = fdowDate.AddDays(6);
                lblStartWeekDate.Text = fdowDate.DayOfWeek.ToString() + "-" + fdowDate.Date.ToShortDateString();
                lblEndWeekdate.Text = ldowDate.DayOfWeek.ToString() + "-" + ldowDate.ToShortDateString();

                btnAll_Click(null, null);
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

                foreach(DataRow dr in dt.Rows)
                {
                    string dayS = DateTime.Parse(dr["RosterDate"].ToString()).DayOfWeek.ToString()+" "+ DateTime.Parse(dr["RosterDate"].ToString()).ToShortDateString();
                    string timeS = DateTime.Parse(dr["RosterStartTime"].ToString()).ToShortTimeString() +" to " + DateTime.Parse(dr["RosterEndTime"].ToString()).ToShortTimeString();
                    shifts.Add(dayS +": "+dr["RosterSite"].ToString()+": "+ dr["RosterTask"].ToString() +"; "+ timeS);
                }

                obj.SendRosterNotificationToEmployee("to", dt.Rows[0]["emp_name"].ToString(), stD[1], endD[1], shifts);
            }
            catch(Exception ex)
            {
                showErrorMessage(ex.Message, false);
            }
        }
    }
}