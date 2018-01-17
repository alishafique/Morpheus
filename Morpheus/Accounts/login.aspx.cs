using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Controller;
using System.Drawing;
using System.Data;

namespace Morpheus.Accounts
{
    public partial class login : System.Web.UI.Page
    {
        login_Controller log_in = new Controller.login_Controller();
        DataTable dtUser;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //lblerrorMessage.Visible = false;
            }
        }

        protected void btn_logIn_Click(object sender, EventArgs e)
        {
            try
            {
                dtUser = new DataTable();
                log_in._UserName = txtbox_userName.Text;
                log_in._Password = txtbox_Password.Text;
                dtUser = log_in.Validate_User();
                if (dtUser != null)
                {
                    if (dtUser.Rows.Count > 0)
                    {
                        if (dtUser.Rows[0]["active_status"].ToString() == "1")
                        {
                            Session["userid"] = dtUser.Rows[0]["user_id"].ToString();
                            Session["UserName"] = dtUser.Rows[0]["user_name"].ToString();
                            Session["UserTypeID"] = dtUser.Rows[0]["role_id"].ToString();
                            Response.Redirect("Dashboard.aspx");
                        }
                        else
                            showErrorMessage("Your UserName is In Active. Please contact administrator..", false);
                        
                    }
                    else
                    {
                        showErrorMessage("Please enter valid User Name and Password.", false);
                    }
                }
                else
                    showErrorMessage(log_in._errorMsg, false);
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
                string script = @"setTimeout(function(){document.getElementById('" + successMsg.ClientID + "').style.display='none';},4000);";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "somekey", script, true);
            }
            else
            {
                lblErrorMsg.Text = message;
                errorMsg.Style.Add("display", "block");
                successMsg.Style.Add("display", "none");
               
            }

        }
    }
}