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
    public partial class frmManageClient : System.Web.UI.Page
    {
        frmManageClient_Controller obj;
        DataTable dt;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["UserTypeID"].ToString() == "2") // if Company
                {
                    btnUpdate.Enabled = false;
                    LoadClientName(int.Parse(Session["userid"].ToString()));
                }
                else if (Session["UserTypeID"].ToString() == "4") // if Sub-contractor Acting as company
                {
                    btnUpdate.Enabled = false;
                    LoadClientName(int.Parse(Session["userid"].ToString()));
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("login.aspx");
            }
        }
        private void LoadClientName(int comID)
        {
            try
            {
                obj = new frmManageClient_Controller();
                dt = new DataTable();
                dt = obj.LoadClients(comID);
                if (dt != null)
                {
                    gvMaster.DataSource = dt;
                    gvMaster.DataBind();
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

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                resetMessage();
                obj = new frmManageClient_Controller();
                if (obj.InsertClient(int.Parse(Session["userid"].ToString()), txtName.Text.Trim()))
                {
                    ResetFeilds();
                    showErrorMessage("Client Name Added", true);
                    LoadClientName(int.Parse(Session["userid"].ToString()));
                }
                else
                    showErrorMessage(obj.ErrorString, false);
            }
            catch(Exception ex)
            {
                showErrorMessage(ex.Message, false);
            }
        }

        private void ResetFeilds()
        {
            txtName.Text = "";
            btnUpdate.Enabled = false;
            btnAdd.Enabled = true;
        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                resetMessage();
                obj = new frmManageClient_Controller();
                if (obj.UpdateClient(Convert.ToInt32(lblID.Text), txtName.Text))
                {
                    showErrorMessage("Updated Successfully.", true);
                    ResetFeilds();
                    LoadClientName(int.Parse(Session["userid"].ToString()));
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
        private void resetMessage()
        {
            lblErrorMsg.Text = "";
            lblsuccessmsg.Text = "";
            successMsg.Style.Add("display", "none");
            errorMsg.Style.Add("display", "none");
        }

        protected void gvMaster_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                resetMessage();
                if (e.CommandName.ToString().ToUpper() == "EDITROW")
                {
                    lblID.Text = e.CommandArgument.ToString();
                    dt = new DataTable();
                    dt = (DataTable)ViewState["dtClient"];
                    foreach(DataRow dr in dt.Rows)
                    {
                        if (dr["clientId"].ToString() == lblID.Text)
                            txtName.Text = dr["ClientName"].ToString();
                    }
                    btnUpdate.Enabled = true;
                    btnAdd.Enabled = false;
                    btnUpdate.Focus();
                }

                if (e.CommandName.ToString().ToUpper() == "DELETECLIENT")
                {
                    obj = new frmManageClient_Controller();
                    if (obj.DeleteClient(Convert.ToInt32(e.CommandArgument.ToString())))
                    {
                        LoadClientName(int.Parse(Session["userid"].ToString()));
                        showErrorMessage("Client Name successfully deleted!", true);
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
    }
}