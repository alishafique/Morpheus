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
    public partial class AddLocationForm : System.Web.UI.Page
    {
        AddLocationForm_Controller obj;
        DataTable dt;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                try
                {
                    if (Session["UserTypeID"].ToString() == "2") // if Company
                    {
                        btnUpdate.Enabled = false;
                        LoadLocationNames(int.Parse(Session["userid"].ToString()));
                    }
                    else if (Session["UserTypeID"].ToString() == "4") // if Sub-contractor Acting as company
                    {
                        btnUpdate.Enabled = false;
                        LoadLocationNames(int.Parse(Session["userid"].ToString()));
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

        protected void btnAddLocation_Click(object sender, EventArgs e)
        {
            try
            {
                resetMessage();
                obj = new AddLocationForm_Controller();
                if (obj.InsertLocation(int.Parse(Session["userid"].ToString()), txtName.Text.Trim()))
                {
                    txtName.Text = "";
                    btnUpdate.Enabled = false;
                    showErrorMessage("Location Added", true);
                    LoadLocationNames(int.Parse(Session["userid"].ToString()));
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
        private void LoadLocationNames(int comID)
        {
            try
            {
                obj = new AddLocationForm_Controller();
                dt = new DataTable();
                dt = obj.LoadLocations(comID);
                if (dt != null)
                {
                    gvMaster.DataSource = dt;
                    gvMaster.DataBind();
                    ViewState["dtL"] = dt;
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
                resetMessage();
                obj = new AddLocationForm_Controller();
                if (obj.UpdateLocation(Convert.ToInt32(lblID.Text), int.Parse(Session["userid"].ToString()), txtName.Text))
                {
                    showErrorMessage("Updated Successfully.", true);
                    txtName.Text = "";
                    btnAddLocation.Enabled = true;
                    btnUpdate.Enabled = false;
                    LoadLocationNames(int.Parse(Session["userid"].ToString()));
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
            resetMessage();
            Response.Redirect("AddLocationForm.aspx");
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
                    dt = (DataTable)ViewState["dtL"];
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (dt.Rows[i]["LocationtoId"].ToString() == lblID.Text)
                            txtName.Text = dt.Rows[i]["LocationtoName"].ToString();
                    }
                    btnUpdate.Enabled = true;
                    btnAddLocation.Enabled = false;
                    btnUpdate.Focus();
                }
                if (e.CommandName.ToString().ToUpper() == "DELETE")
                {
                    obj = new AddLocationForm_Controller();
                    if (obj.DeleteLocation(Convert.ToInt32(e.CommandArgument.ToString())))
                    {
                        LoadLocationNames(int.Parse(Session["userid"].ToString()));
                        showErrorMessage("Location successfully deleted!", true);
                    }
                    else
                        showErrorMessage(obj.ErrorString, false);
                }
            }
            catch(Exception ex)
            {
                showErrorMessage(ex.Message, false);
            }
        }

        protected void gvMaster_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton lbDelete = (LinkButton)e.Row.FindControl("lbDelete");
                lbDelete.Attributes.Add("onclick", "return confirm('Are you sure to delete?');");
            }
        }

        protected void gvMaster_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Response.Redirect("AddLocationForm.aspx");
        }

        //protected void gvMaster_RowEditing(object sender, GridViewEditEventArgs e)
        //{
        //    gvMaster.EditIndex = e.NewEditIndex;
        //    dt = new DataTable();
        //    dt = (DataTable)ViewState["dtL"];
        //    for(int i=0;i<dt.Rows.Count;i++)
        //    {
        //        if (dt.Rows[i]["LocationtoId"].ToString() == lblID.Text)
        //            txtName.Text = dt.Rows[i]["LocationtoName"].ToString();
        //    }
        //    btnUpdate.Enabled = true;
        //    btnAddLocation.Enabled = false;
        //    btnUpdate.Focus();
        //    //gvMaster.Enabled = false;
        //}

        
    }
}