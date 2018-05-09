using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Controller;

namespace Morpheus.Accounts
{
    public partial class frmManageincidentReportTypes : System.Web.UI.Page
    {
        DataTable dt;
        frmManageincidentReportTypes_Controller obj;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!this.IsPostBack)
                {
                    if (Session["UserTypeID"].ToString() == "1")
                    {
                        btnUpdate.Enabled = false;
                        LoadCompanyType();
                        LoadIncidentReportType();
                    }
                    else
                        Response.Redirect("login.aspx");
                }
            }
            catch(Exception ex)
            {
                Response.Redirect("login.aspx");
            }
        }

        protected void btnAddLocation_Click(object sender, EventArgs e)
        {
            try
            {
                obj = new frmManageincidentReportTypes_Controller();
                if (obj.AddIncidentRptType(txtName.Text, txtDesc.Text, dp_CompanyType.SelectedValue))
                {
                    showErrorMessage("Added Successfully", true);
                    LoadIncidentReportType();
                    Reset();
                }
                else
                    showErrorMessage(obj.ErrorString, false);
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
                obj = new frmManageincidentReportTypes_Controller();
                if (obj.UpdateRptType(Convert.ToInt32(lblID.Text), txtName.Text, txtDesc.Text, Convert.ToInt32(dp_CompanyType.SelectedValue)))
                {
                    showErrorMessage("Updated Successfully", true);
                    LoadIncidentReportType();
                    Reset();                   
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
            try
            {
                Response.Redirect("frmManageincidentReportTypes.aspx");
            }
            catch (Exception ex)
            {
                showErrorMessage(ex.Message, false);
            }
        }


        private void LoadCompanyType()
        {
            try
            {
                obj = new frmManageincidentReportTypes_Controller();
                dt = new DataTable();
                dt = obj.loadCompanyTypes();
                if (dt != null)
                {
                    if (dt.Rows.Count != 0)
                    {
                        dp_CompanyType.DataSource = dt;
                        dp_CompanyType.DataTextField = "type_name";
                        dp_CompanyType.DataValueField = "company_Type_id";
                        dp_CompanyType.DataBind();
                    }
                    else
                    {
                        showErrorMessage("Company types not loaded", false);
                        dp_CompanyType.Focus();
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

        protected void gvMaster_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.ToString().ToUpper() == "EDITROW")
                {
                    lblID.Text = e.CommandArgument.ToString();
                    dt = new DataTable();
                    dt = (DataTable)ViewState["dtRptType"];
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (dr["id"].ToString() == lblID.Text)
                        {
                            txtName.Text = dr["RptTpye"].ToString();
                            txtDesc.Text = dr["RptDescription"].ToString();
                            dp_CompanyType.SelectedItem.Text = dr["type_name"].ToString();
                        }
                    }
                    btnUpdate.Enabled = true;
                    btnAddLocation.Enabled = false;
                    btnUpdate.Focus();
                }
                if (e.CommandName.ToString().ToUpper() == "DELETE")
                {
                    obj = new frmManageincidentReportTypes_Controller();
                    if (obj.DeleteRptType(Convert.ToInt32(e.CommandArgument.ToString())))
                    {
                        showErrorMessage("Company Type deleted successfully deleted!", true);
                        LoadIncidentReportType();
                        Reset();
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

        protected void gvMaster_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    LinkButton lbDelete = (LinkButton)e.Row.FindControl("lbDelete");
                    lbDelete.Attributes.Add("onclick", "return confirm('Are you sure to delete?');");
                }
            }
            catch (Exception ex)
            {
                showErrorMessage(ex.Message, false);
            }
        }

        protected void gvMaster_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                showErrorMessage(ex.Message, false);
            }
        }

        private void LoadIncidentReportType()
        {
            try
            {
                dt = new DataTable();
                obj = new frmManageincidentReportTypes_Controller();
                dt = obj.LoadIncidentRptTypes();
                if(dt!=null)
                {
                    gvMaster.DataSource = dt;
                    gvMaster.DataBind();
                    ViewState["dtRptType"] = dt;
                }
                else
                {
                    showErrorMessage(obj.ErrorString, false);
                }
            }
            catch (Exception ex)
            {
                showErrorMessage(ex.Message, false);
            }
        }

        private void Reset()
        {
            txtDesc.Text = "";
            txtName.Text = "";
            LoadCompanyType();
            btnAddLocation.Enabled = true;
            btnUpdate.Enabled = false;
        }
    }
}