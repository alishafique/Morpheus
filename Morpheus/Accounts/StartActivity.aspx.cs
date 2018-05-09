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
    public partial class StartActivity : System.Web.UI.Page
    {
        StartActivity_Controller obj;
        DataTable dt;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (Session["UserTypeID"].ToString() == "3")
                    {
                        LoadActivity();
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

        protected void btnStart_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch(Exception ex)
            {
                showErrorMessage(ex.Message, false);
            }
        }

        private void LoadActivity()
        {
            try
            {
                obj = new StartActivity_Controller();
                dt = obj.LoadActivityOfToday(int.Parse(Session["userid"].ToString()));
                if(dt!=null)
                {
                    dgvLoadTodaysActivity.DataSource = dt;
                    dgvLoadTodaysActivity.DataBind();
                }
                else
                {
                    showErrorMessage(obj.ErrorString, false);
                }
            }
            catch(Exception ex)
            {
                showErrorMessage(ex.Message,false);
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

        protected void dgvLoadTodaysActivity_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void dgvLoadTodaysActivity_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void dgvLoadTodaysActivity_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }
    }
}