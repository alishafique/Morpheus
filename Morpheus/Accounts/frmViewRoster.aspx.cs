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
                        LoadEmployeesShift();
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

        private void LoadEmployeesShift()
        {
            try
            {
                string[] stD = lblStartWeekDate.Text.Split('-');
                string[] endD = lblEndWeekdate.Text.Split('-');
                dt = new DataTable();
                obj = new frmViewRoster_Controller();
                dt = obj.LoadEmployeeRoster(int.Parse(Session["userid"].ToString()), DateTime.Parse(stD[1]), DateTime.Parse(endD[1]));
                if (dt != null)
                {
                    grdViewShifts.DataSource = dt;
                    grdViewShifts.DataBind();
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

                LoadEmployeesShift();
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

                LoadEmployeesShift();

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
                        LoadEmployeesShift();
                        showErrorMessage("Shift Accepted", true);
                    }
                    else
                        showErrorMessage(obj.ErrorString, false);
                }
                if(e.CommandName.ToString().ToUpper() == "REJECTSHIFT")
                {
                    if (obj.UpdateEmployeeRoster(Guid.Parse(e.CommandArgument.ToString().Trim()), "Rejected"))
                    {
                        LoadEmployeesShift();
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
                {
                    e.Row.BackColor = System.Drawing.Color.Yellow;
                }
                if (e.Row.Cells[6].Text.ToLower() == "rejected")
                {
                    e.Row.CssClass = "danger";
                }

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
    }
}