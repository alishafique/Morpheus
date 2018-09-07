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
    public partial class frmViewTimeSheetFull : System.Web.UI.Page
    {
        frmViewTimeSheetFull_Controller obj;
        DataTable dt;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (Session["UserTypeID"].ToString() == "2" || Session["UserTypeID"].ToString() == "4")
                    {
                        loadDate();
                        string[] stD = lblStartWeekDate.Text.Split('-');
                        string[] endD = lblEndWeekdate.Text.Split('-');
                        LoadClientName(int.Parse(Session["userid"].ToString()));
                        LoadCompanyTimeSheet(int.Parse(Session["userid"].ToString()), dpClients.SelectedItem.Text, DateTime.Parse(stD[1]), DateTime.Parse(endD[1]));
                    }
                    else
                        Response.Redirect("login.aspx");
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("login.aspx");
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

                stD = lblStartWeekDate.Text.Split('-');
                endD = lblEndWeekdate.Text.Split('-');
                LoadCompanyTimeSheet(int.Parse(Session["userid"].ToString()), dpClients.SelectedItem.Text, DateTime.Parse(stD[1]), DateTime.Parse(endD[1]));

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
                obj = new frmViewTimeSheetFull_Controller();
                dt = new DataTable();
                dt = obj.LoadClients(comID);
                if (dt != null)
                {
                    dt.Columns.Remove("CompanyId");
                    dpClients.DataSource = dt;
                    dpClients.DataBind();
                    dpClients.Items.Insert(0, new ListItem("All", "0"));
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
        private void LoadCompanyTimeSheet(int userId, string CompanyName, DateTime stdt, DateTime endDt)
        {
            try
            {
                ReSetMsg();
                obj = new frmViewTimeSheetFull_Controller();
                dt = new DataTable();
                grdViewShifts.DataSource = null;
                grdViewShifts.DataBind();
                if (CompanyName == "All")
                    dt = obj.viewTimeSheetOfCompany(userId, CompanyName, stdt, endDt);
                else
                    dt = obj.ViewCompanyTimeSheetByCompany(userId, CompanyName, stdt, endDt);
                ViewState["ComTimeSheet"] = dt;
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
                stD = lblStartWeekDate.Text.Split('-');
                endD = lblEndWeekdate.Text.Split('-');
                LoadCompanyTimeSheet(int.Parse(Session["userid"].ToString()), dpClients.SelectedItem.Text, DateTime.Parse(stD[1]), DateTime.Parse(endD[1]));
            }
            catch (Exception ex)
            {
                showErrorMessage(ex.Message, false);
            }
        }

        protected void dpClients_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string[] stD = lblStartWeekDate.Text.Split('-');
                string[] endD = lblEndWeekdate.Text.Split('-');
                LoadCompanyTimeSheet(int.Parse(Session["userid"].ToString()), dpClients.SelectedItem.Text, DateTime.Parse(stD[1]), DateTime.Parse(endD[1]));
            }
            catch(Exception ex)
            {
                showErrorMessage(ex.Message, false);
            }
        }
        public override void VerifyRenderingInServerForm(Control control)
        {
        }
        protected void btnExportToExcel_Click(object sender, EventArgs e)
        {
            try
            {
              
                Response.ClearContent();
                Response.AppendHeader("content-disposition", "attachment; filename="+Guid.NewGuid()+".xls");
                Response.ContentType = "application/excel";
                System.IO.StringWriter stringWriter = new System.IO.StringWriter();
                HtmlTextWriter htw = new HtmlTextWriter(stringWriter);
                grdViewShifts.RenderControl(htw);
                Response.Write(stringWriter.ToString());
                Response.End();
            }
            catch(Exception ex)
            {
                showErrorMessage(ex.Message, false);
            }
        }

        protected void grdViewShifts_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        private void ReSetMsg()
        {
            lblErrorMsg.Text = "";
            lblsuccessmsg.Text = "";
           
            errorMsg.Style.Add("display", "none");
            successMsg.Style.Add("display", "none");
           
        }
        protected void grdViewShifts_RowDataBound(object sender, GridViewRowEventArgs e)
        {

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
    }
}