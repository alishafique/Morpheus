using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Controller;
using System.Windows.Forms;

namespace Morpheus.Accounts
{
    public partial class ActivateDeactivateCompanyAccount : System.Web.UI.Page
    {
        DataTable dt;
        ActivateDeactivateCompanyAccount_Controller objADC;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                try
                {
                    if (Session["UserName"].ToString() != "")
                    {
                        lblUserName.Text = Session["UserName"].ToString();
                        if (Session["UserTypeID"].ToString() == "1")
                        {
                            populateToActivateOrDeactivateCompany();
                           
                            dashboardmenu1.Visible = true;
                            companySideMenu1.Visible = false;
                            employeeDashMenu1.Visible = false;
                            btnUpdateCompanyDetails.Enabled = false;
                        }
                    }
                    else
                    {
                        Response.Redirect("login.aspx");
                    }
                }
                catch (Exception)
                {
                    Response.Redirect("login.aspx");
                }
            }
        }

        private void populateToActivateOrDeactivateCompany()
        {
            try
            {
                dt = new DataTable();
                objADC = new ActivateDeactivateCompanyAccount_Controller();
                dt = objADC.populateGridviewToActivateOrDeactivate();
                dt.Columns.Add("active_status1", typeof(string));
                if (dt != null)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        if (row["Status"] + string.Empty == "1")
                            row["active_status1"] = "Active";
                        else
                            row["active_status1"] = "Disabled";
                    }

                    dtgridview_companies.DataSource = dt;
                    dtgridview_companies.DataBind();
                }
                else
                    showErrorMessage(objADC.ErrorString, false);    
            }
            catch(Exception ex)
            {
                showErrorMessage(ex.Message, false);
            }
        }

        protected void dtgridview_companies_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GridViewRow row = dtgridview_companies.SelectedRow;
                txtbox_UserId.Text = row.Cells[2].Text;         // load User ID
                txtbox_UserId.Enabled = false;
                txtbox_CompanyID.Text = row.Cells[1].Text; // load Company Id
                txtbox_CompanyID.Enabled = false;
                txtbox_CompanyName.Text = row.Cells[3].Text.Replace("&amp;", "&");    // Load COmpany Name
                txtbox_CompanyEmail.Text = row.Cells[4].Text;       // load Company EMail
                dp_CompanyAccountStatus.SelectedIndex = Int32.Parse(row.Cells[7].Text); // load Account Status                
                btnUpdateCompanyDetails.Enabled = true;
                dp_CompanyAccountStatus.Focus();   
            }
            catch (Exception ex)
            {
                showErrorMessage(ex.Message + " Please contact administrator.", false);
            }

        }
        protected void dtgridview_companies_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            try
            {
                GridViewRow row = dtgridview_companies.Rows[e.NewSelectedIndex];
                if (row.Cells[1].Text == "ANATR")
                {
                    e.Cancel = true;
                    showErrorMessage("You cannot select " + row.Cells[2].Text + ".", false);
                }
            }
            catch (Exception ex)
            {
                showErrorMessage("ex.Message" + " Please contact administrator.", false);
            }
        }

        protected void dtgridview_companies_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dtgridview_companies.PageIndex = e.NewPageIndex;
            populateToActivateOrDeactivateCompany();
        }

        private void showErrorMessage(string message, bool status)
        {
            if (status == true)
            {
                lblsuccessmsg.Text = message;
                successMsg.Style.Add("display", "block");
                errorMsg.Style.Add("display", "none");
                string script = @"setTimeout(function(){document.getElementById('" + successMsg.ClientID + "').style.display='none';},8000);";
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

        protected void btnUpdateCompanyDetails_Click(object sender, EventArgs e)
        {
            try
            {
                    objADC = new ActivateDeactivateCompanyAccount_Controller();
                    if (objADC.updateCompanyStatus(int.Parse(txtbox_UserId.Text), dp_CompanyAccountStatus.SelectedIndex) == true)
                    {
                        if (dp_CompanyAccountStatus.SelectedIndex == 1)
                        {
                            if (objADC.notificationToCompany(txtbox_CompanyEmail.Text, txtbox_CompanyName.Text) == true)
                                showErrorMessage("Company's Account has been Activated. And Notification has been sent to company.", true);
                        }
                        else
                        {
                            if (objADC.notificationDeActiveToCompany(txtbox_CompanyEmail.Text, txtbox_CompanyName.Text) == true)
                                showErrorMessage("Company's Account has been successfully de-activated", true);
                        }
                        populateToActivateOrDeactivateCompany();
                    }
                    else
                        showErrorMessage(objADC.ErrorString, false);
            }
            catch (Exception ex)
            {
                showErrorMessage(ex.Message + " Please contact administrator.", false);
            }
        }
    }
}