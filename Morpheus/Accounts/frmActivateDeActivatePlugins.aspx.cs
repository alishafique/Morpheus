using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Controller;
namespace Seguro.Accounts
{
    public partial class frmActivateDeActivatePlugins : System.Web.UI.Page
    {
        frmActivateDeActivatePlugins_Controller obj;
        DataTable dt;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                try
                {
                    if (Session["UserName"].ToString() != "")
                    {
                        if (Session["UserTypeID"].ToString() == "1")
                        {
                            populateCompany();
                        }
                    }
                    else
                    {
                        Response.Redirect("login.aspx");
                    }
                }
                catch(Exception ex)
                {
                    Response.Redirect("login.aspx");
                }
            }
        }


        private void populateCompany()
        {
            try
            {
                obj = new frmActivateDeActivatePlugins_Controller();
                dt = new DataTable();
                dt = obj.populateCompanyGridview();
                if (dt != null)
                {
                    dtgridview_companies.DataSource = dt;
                    dtgridview_companies.DataBind();
                    ViewState["dtComPany"] = dt;
                    Reset();
                }
                else
                    showErrorMessage(obj.ErrorString, false);

            }
            catch (Exception ex)
            {
                showErrorMessage("Unable to load companies: Error= "+ex.Message, false);
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

        protected void dtgridview_companies_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.ToString().ToUpper() == "EDITPLUGIN")
                {
                    dt = new DataTable();
                    lblCompanyId.Text = e.CommandArgument.ToString();
                    dt = (DataTable)ViewState["dtComPany"];
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (dr["CompanyID"].ToString() == lblCompanyId.Text)
                        {
                            txtCompanyName.Text = dr["CompanyName"].ToString();
                            txtCompanyEmail.Text = dr["Email"].ToString();
                            if (dr["subContractor"].ToString() == "True")
                                chksubContractor.Checked =  true;
                            if (dr["activity"].ToString() == "True")
                                chkactivity.Checked = true;
                            if (dr["incident"].ToString() == "True")
                                chkincident.Checked = true;
                            if (dr["forms"].ToString() == "True")
                                chkforms.Checked = true;
                            if (dr["roster"].ToString() == "True")
                                chkroster.Checked = true;

                            btnUpdate.Enabled = true;
                            btnCancel.Enabled = true;
                            btnUpdate.Focus();
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                showErrorMessage(ex.Message, false);
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                obj = new frmActivateDeActivatePlugins_Controller();
                if (obj.UpdatePlugins(int.Parse(lblCompanyId.Text), ((chksubContractor.Checked) ? true : false), ((chkactivity.Checked) ? true : false), (chkroster.Checked) ? true : false, (chkforms.Checked) ? true : false, (chkincident.Checked) ? true : false))
                {
                    populateCompany();
                    showErrorMessage("Plugin Status changes successfully.", true);
                }
                else
                    showErrorMessage(obj.ErrorString, false);
            }
            catch(Exception ex)
            {
                showErrorMessage(ex.Message, false);
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {

        }

        private void Reset()
        {
            lblCompanyId.Text = "";
            txtCompanyEmail.Text = "";
            txtCompanyName.Text = "";
            chksubContractor.Checked = false;
            chkroster.Checked = false;
            chkactivity.Checked = false;
            chkforms.Checked = false;
            chkincident.Checked = false;
            btnUpdate.Enabled = false;
            btnCancel.Enabled = false;

        }
    }
}