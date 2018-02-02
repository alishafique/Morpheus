using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Controller;
using System.Data;
using System.Windows.Forms;
using System.Text;

namespace Morpheus.Accounts
{
    public partial class viewEditCompanyIncidentReports : System.Web.UI.Page
    {
        DataTable dt;
        viewEditCompanyIncidentReports_Controller obj;
        Dictionary<string, Int16> severanityLevel = new Dictionary<string, Int16>();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (Session["UserTypeID"].ToString() == "2")
                    {
                        loadReports(int.Parse(Session["userid"].ToString()));
                        LoadSubContractorReports();
                        btnUpdateReport.Enabled = false;
                        btnUpdateReport.Visible = false;
                    }
                    else if (Session["UserTypeID"].ToString() == "4")
                    {
                        loadReports(int.Parse(Session["userid"].ToString()));                       
                        btnUpdateReport.Enabled = false;
                        btnUpdateReport.Visible = false;
                    }
                    else
                    {
                        Response.Redirect("login.aspx");
                    }
                }
            }
            catch (Exception)
            {
                Response.Redirect("login.aspx");
            }
        }

        private void loadReports(int userID)
        {
            try
            {
                obj = new viewEditCompanyIncidentReports_Controller();
                dt = obj.loadIncidentReportsByCompany(userID);
                if(dt != null && dt.Rows.Count != 0)
                {
                    dtgridview_IncidentReports.DataSource = dt;
                    dtgridview_IncidentReports.DataBind();         
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

        private void LoadSubContractorReports()
        {
            try
            {
                obj = new viewEditCompanyIncidentReports_Controller();
                DataTable dtSubConList = new DataTable();
                dt = new DataTable();
                dtSubConList = obj.LoadSubContractors(int.Parse(Session["userid"].ToString()));

                for (int i = 0; i < dtSubConList.Rows.Count; i++)
                {
                    DataTable dtTemp = new DataTable();
                    dtTemp = obj.loadIncidentReportsByCompany(int.Parse(dtSubConList.Rows[i]["UserId"].ToString()));
                    dt.Merge(dtTemp);
                    dt.AcceptChanges();
                }

                if (dt != null && dt.Rows.Count != 0)
                {
                    gdIncidentSubcontractor.DataSource = dt;
                    gdIncidentSubcontractor.DataBind();
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

        protected void dtgridview_IncidentReports_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                dtgridview_IncidentReports.PageIndex = e.NewPageIndex;
                loadReports(int.Parse(Session["userid"].ToString()));
            }
            catch (Exception ex)
            {
                showErrorMessage(ex.Message, false);
            }
        }

        protected void dtgridview_IncidentReports_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void dtgridview_IncidentReports_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                dt = new DataTable();
                ViewIncidentReprots_Controller objInc = new ViewIncidentReprots_Controller();
                obj = new viewEditCompanyIncidentReports_Controller();
                severanityLevel.Add("Level 1 - Immediate response, threat of injury or death", 0);
                severanityLevel.Add("Level 2 – Within 1 hour, no physical danger, work has ceased", 1);
                severanityLevel.Add("Level 3 – Within 3 hours, no physical danger, work has been", 2);

                GridViewRow row = dtgridview_IncidentReports.SelectedRow;
                TextBox_ReportId.Text = row.Cells[1].Text;
                TextBox_user_id.Text = row.Cells[2].Text;
                TextBox_Reportedby.Text = row.Cells[3].Text;

                if (severanityLevel.ContainsKey(row.Cells[4].Text))
                {
                    dp_severityLevel.SelectedIndex = severanityLevel[row.Cells[4].Text];
                }
                txtbox_Description.Text = row.Cells[5].Text;
                txtbox_siteName.Text = row.Cells[7].Text;
                txtbox_actionTaken.Text = row.Cells[8].Text;
               // btnUpdateReport.Enabled = true;
                dp_severityLevel.Enabled = true;
                dt = objInc.loadImagesOfReport(int.Parse(row.Cells[1].Text)); //loading images 
                if (dt != null && dt.Rows.Count != 0)
                {
                    List<Image> pictureBoxList = new List<Image>();

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        Image picture = new Image();
                        picture.ImageUrl = "upload/" + dt.Rows[i]["imageName"].ToString();
                        picture.Width = 484;
                        pictureBoxList.Add(picture);
                    }

                    foreach (Image p in pictureBoxList)
                    {
                        pnlDisplayImage.Controls.Add(p);
                    }
                }

                btnUpdateReport.Focus();
                if (!obj.UpdateIncidentReportStatus(int.Parse(TextBox_ReportId.Text), int.Parse(Session["userid"].ToString())))// Update Status
                {
                    showErrorMessage(obj.ErrorString, false);
                }
                Popup(true);
            }
            catch (Exception ex)
            {
                showErrorMessage(ex.Message, false);
            }
        }

        protected void dtgridview_IncidentReports_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            try
            {

                GridViewRow row = dtgridview_IncidentReports.Rows[e.NewSelectedIndex];
                if (row.Cells[1].Text == "ANATR")
                {
                    e.Cancel = true;
                    showErrorMessage("You cannot select " + row.Cells[2].Text + ".", false);
                }
            }
            catch (Exception ex)
            {
                showErrorMessage(ex.Message + " Please contact administrator.", false);
            }
        }

        protected void btnUpdateReport_Click(object sender, EventArgs e)
        {

        }

        //To show message after performing operations
        void Popup(bool isDisplay)
        {
            StringBuilder builder = new StringBuilder();
            if (isDisplay)
            {
                builder.Append("<script language=JavaScript> ShowPopup(); </script>\n");
                Page.ClientScript.RegisterStartupScript(this.GetType(), "ShowPopup", builder.ToString());
            }
            else
            {
                builder.Append("<script language=JavaScript> HidePopup(); </script>\n");
                Page.ClientScript.RegisterStartupScript(this.GetType(), "HidePopup", builder.ToString());
            }
        }

        protected void btnClose_Click(object sender, EventArgs e)
        {
            loadReports(int.Parse(Session["userid"].ToString()));
        }

        protected void gdIncidentSubcontractor_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                dt = new DataTable();
                ViewIncidentReprots_Controller objInc = new ViewIncidentReprots_Controller();
                obj = new viewEditCompanyIncidentReports_Controller();
                severanityLevel.Add("Level 1 - Immediate response, threat of injury or death", 0);
                severanityLevel.Add("Level 2 – Within 1 hour, no physical danger, work has ceased", 1);
                severanityLevel.Add("Level 3 – Within 3 hours, no physical danger, work has been", 2);

                GridViewRow row = gdIncidentSubcontractor.SelectedRow;
                TextBox_ReportId.Text = row.Cells[1].Text;
                TextBox_user_id.Text = row.Cells[2].Text;
                TextBox_Reportedby.Text = row.Cells[3].Text;

                if (severanityLevel.ContainsKey(row.Cells[4].Text))
                {
                    dp_severityLevel.SelectedIndex = severanityLevel[row.Cells[4].Text];
                }
                txtbox_Description.Text = row.Cells[5].Text;
                txtbox_siteName.Text = row.Cells[7].Text;
                txtbox_actionTaken.Text = row.Cells[8].Text;
                // btnUpdateReport.Enabled = true;
                dp_severityLevel.Enabled = true;
                dt = objInc.loadImagesOfReport(int.Parse(row.Cells[1].Text)); //loading images 
                if (dt != null && dt.Rows.Count != 0)
                {
                    List<Image> pictureBoxList = new List<Image>();

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        Image picture = new Image();
                        picture.ImageUrl = "upload/" + dt.Rows[i]["imageName"].ToString();
                        picture.Width = 484;
                        pictureBoxList.Add(picture);
                    }

                    foreach (Image p in pictureBoxList)
                    {
                        pnlDisplayImage.Controls.Add(p);
                    }
                }

                btnUpdateReport.Focus();
                if (!obj.UpdateIncidentReportStatus(int.Parse(TextBox_ReportId.Text), int.Parse(Session["userid"].ToString())))// Update Status
                {
                    showErrorMessage(obj.ErrorString, false);
                }
                Popup(true);
            }
            catch (Exception ex)
            {
                showErrorMessage(ex.Message, false);
            }
        }

        protected void gdIncidentSubcontractor_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            try
            {
                GridViewRow row = gdIncidentSubcontractor.Rows[e.NewSelectedIndex];
                if (row.Cells[1].Text == "ANATR")
                {
                    e.Cancel = true;
                    showErrorMessage("You cannot select " + row.Cells[2].Text + ".", false);
                }
            }
            catch (Exception ex)
            {
                showErrorMessage(ex.Message + " Please contact administrator.", false);
            }
        }

        protected void dtgridview_IncidentReports_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.Cells[10].Text == "unseen")
            {
                e.Row.CssClass = "danger";
            }
        }

        protected void gdIncidentSubcontractor_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.Cells[10].Text == "unseen")
            {
                e.Row.CssClass = "danger";
            }
        }
    }
}