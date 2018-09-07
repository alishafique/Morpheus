﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Controller;
using System.Data;
using System.Windows.Forms;
using System.Drawing;

namespace Seguro.Accounts
{
    public partial class viewIncidentReports : System.Web.UI.Page
    {
        DataTable dt;
        ViewIncidentReprots_Controller objInc;
        Dictionary<string, string> severanityLevel = new Dictionary<string, string>();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (Session["UserTypeID"].ToString() == "3")
                    {
                        LoadCompanyType();
                        loadReports(int.Parse(Session["userid"].ToString()));
                        btnUpdateReport.Enabled = false;
                    }
                    else
                    {
                        Response.Redirect("login.aspx");
                    }
                }
            }
            catch(Exception)
            {
                Response.Redirect("login.aspx");
            }
        }

        private void loadReports(int EmployeeId)
        {
            try
            {
                dt = new DataTable();
                objInc = new ViewIncidentReprots_Controller();
                dt = objInc.loadIncidentReportsByEmployee(EmployeeId);
                if(dt != null)
                {
                    dtgridview_IncidentReports.DataSource = dt;
                    dtgridview_IncidentReports.DataBind();                   
                }
                else
                {
                    showErrorMessage(objInc.ErrorString, false);
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
            dtgridview_IncidentReports.PageIndex = e.NewPageIndex;
            loadReports(int.Parse(Session["userid"].ToString()));
        }

        protected void dtgridview_IncidentReports_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void dtgridview_IncidentReports_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                clearTxtBox();
                DataTable dtComType = new DataTable();
                dtComType = (DataTable)ViewState["CompanyType"];
                dt = new DataTable();
                objInc = new ViewIncidentReprots_Controller();

                foreach(DataRow dr in dtComType.Rows)
                {
                    severanityLevel.Add(dr["RptTpye"].ToString(), dr["id"].ToString());
                }
                GridViewRow row = dtgridview_IncidentReports.SelectedRow;
                TextBox_ReportId.Text = row.Cells[1].Text;
                TextBox_reportedBy.Text = row.Cells[2].Text;
                TextBox_reportedTo.Text = row.Cells[3].Text;

               // dp_severityLevel.SelectedItem.Text = row.Cells[4].Text;
                if (severanityLevel.ContainsKey(row.Cells[4].Text))
                {
                    dp_severityLevel.SelectedValue = severanityLevel[row.Cells[4].Text];
                }
                txtbox_Description.Text = row.Cells[5].Text;
                txtbox_siteName.Text = row.Cells[8].Text;
                txtbox_actionTaken.Text = row.Cells[9].Text;
                btnUpdateReport.Enabled = true;
                dp_severityLevel.Enabled = true;
                dt = objInc.loadImagesOfReport(int.Parse(row.Cells[1].Text)); //loading images 
                if (dt != null && dt.Rows.Count != 0)
                {
                    List<System.Web.UI.WebControls.Image> pictureBoxList = new List<System.Web.UI.WebControls.Image>();

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        System.Web.UI.WebControls.Image picture = new System.Web.UI.WebControls.Image();
                        picture.ImageUrl = "upload/"+dt.Rows[i]["imageName"].ToString();
                        picture.Width = 484;
                        pictureBoxList.Add(picture);
                    }

                    foreach (System.Web.UI.WebControls.Image p in pictureBoxList)
                    {
                        pnlDisplayImage.Controls.Add(p);
                    }
                }

                btnUpdateReport.Focus();
            }
            catch (Exception ex)
            {
                showErrorMessage(ex.Message, false);
            }
        }

        private void clearTxtBox()
        {
            dp_severityLevel.SelectedIndex = 0;
            dp_severityLevel.Enabled = false;
            txtbox_siteName.Text = "";
            txtbox_Description.Text = "";
            txtbox_actionTaken.Text = "";
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
            try
            {
                objInc = new ViewIncidentReprots_Controller();
                IncidentReport objIncdentReport = new IncidentReport()
                {
                    ReportedBy = int.Parse(Session["userid"].ToString()),
                    Severitylevel = dp_severityLevel.SelectedItem.ToString(),
                    Description = txtbox_Description.Text,
                    Status = "unseen",
                    Location = txtbox_siteName.Text,
                    ActionTaken = txtbox_actionTaken.Text
                };
                if (objInc.updateIncidentReportByEmployee(objIncdentReport, int.Parse(TextBox_ReportId.Text)))
                {
                    showErrorMessage("Report Updated Successfully", true);
                    loadReports(int.Parse(Session["userid"].ToString()));
                    clearTxtBox();
                    btnUpdateReport.Enabled = false;
                }
                else
                    showErrorMessage(objInc.ErrorString, false);

            }
            catch(Exception ex)
            {
                showErrorMessage(ex.Message + ". Contact Administrator", false);
            }

        }
        private void LoadCompanyType()
        {
            try
            {
                objInc = new ViewIncidentReprots_Controller();
                dt = new DataTable();
                dt = objInc.loadRptTypesByCompanyTypes(Convert.ToInt32(Session["userid"].ToString()));
                if (dt != null)
                {
                    dp_severityLevel.DataSource = dt;
                    dp_severityLevel.DataTextField = "RptTpye";
                    dp_severityLevel.DataValueField = "id";
                    dp_severityLevel.DataBind();
                    ViewState["CompanyType"] = dt;
                }
                else
                    showErrorMessage(objInc.ErrorString, false);
            }
            catch (Exception ex)
            {
                showErrorMessage(ex.Message, false);
            }
        }
    }
}