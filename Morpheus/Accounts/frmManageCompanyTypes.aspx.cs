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
    public partial class frmManageCompanyTypes : System.Web.UI.Page
    {
        DataTable dt;
        frmManageCompanyTypes_Controller obj;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                try
                {
                    if (Session["UserTypeID"].ToString() == "1")
                    {
                        btnUpdate.Enabled = false;
                        LoadCompanyTypes();
                    }
                    else
                        Response.Redirect("login.aspx");
                }
                catch (Exception ex)
                {
                    Response.Redirect("login.aspx");
                }
            }
        }

        private void LoadCompanyTypes()
        {
            try
            {
                obj = new frmManageCompanyTypes_Controller();
                dt = new DataTable();
                dt = obj.LoadCompanyTypes();
                if(dt != null)
                {
                    gvMaster.DataSource = dt;
                    gvMaster.DataBind();
                    ViewState["dtC"] = dt;
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
                    dt = (DataTable)ViewState["dtC"];
                    foreach(DataRow dr in dt.Rows)
                    {
                        if (dr["company_Type_id"].ToString() == lblID.Text)
                        {
                            txtName.Text = dr["type_name"].ToString();
                            txtDesc.Text = dr["description"].ToString();
                        }
                    }
                    btnUpdate.Enabled = true;
                    btnAddLocation.Enabled = false;
                    btnUpdate.Focus();
                }
                if (e.CommandName.ToString().ToUpper() == "DELETE")
                {
                    obj = new frmManageCompanyTypes_Controller();
                    if (obj.DeleteCompanyType(Convert.ToInt32(e.CommandArgument.ToString())))
                    {
                        showErrorMessage("Company Type deleted successfully deleted!", true);
                        LoadCompanyTypes();
                    }
                    else
                    {
                        showErrorMessage(obj.ErrorString, false);
                    }
                }
            }
            catch(Exception ex)
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

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                obj = new frmManageCompanyTypes_Controller();
                if (obj.AddcompanyType(txtName.Text, txtDesc.Text))
                {
                    showErrorMessage("Added Successfully", true);
                    LoadCompanyTypes();
                }
                else
                    showErrorMessage(obj.ErrorString, false);
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
                obj = new frmManageCompanyTypes_Controller();
                if (obj.UpdateCompanyType(Convert.ToInt32(lblID.Text), txtName.Text, txtDesc.Text))
                {
                    showErrorMessage("Updated Successfully", true);
                    txtName.Text = "";
                    txtDesc.Text = "";
                    btnAddLocation.Enabled = true;
                    btnUpdate.Enabled = false;
                    LoadCompanyTypes();
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
                Response.Redirect("frmManageCompanyTypes.aspx");
            }
            catch (Exception ex)
            {
                showErrorMessage(ex.Message, false);
            }
        }
    }
}