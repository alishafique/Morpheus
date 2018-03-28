using Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Morpheus.Accounts
{
    public partial class changePassword : System.Web.UI.Page
    {
        ChangePassword_Controller objchangepass;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["UserTypeID"].ToString() == "")
                {
                    Response.Redirect("login.aspx");
                }
                if (!Page.IsPostBack)
                {
                    if (Session["UserTypeID"].ToString() == "")
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

        protected void TextValidate(object source, ServerValidateEventArgs e)
        {
            e.IsValid = (e.Value.Length >= 6 && e.Value.Length <= 15);
        }

        protected void btnUpdatePassword_Click(object sender, EventArgs e)
        {
            try
            {
                if (oldPassword.Text.Trim().Equals(newPassword.Text.Trim()) == false)
                {
                    objchangepass = new ChangePassword_Controller();
                    if (objchangepass.updateCompanyPassword(int.Parse(Session["userid"].ToString()), Session["UserName"].ToString(), newPassword.Text, oldPassword.Text) == true)
                    {
                        showErrorMessage("Password Successfully changed", true);
                        clear();
                    }
                    else
                    {
                        showErrorMessage("Old password does not match!!!!", false);
                        oldPassword.Focus();
                    }
                }
                else

                {
                    showErrorMessage("Your new and old password con not be same!!", false);
                    oldPassword.Focus();
                }

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
        private void clear()
        {
            oldPassword.Text = "";
            newPassword.Text = "";
            confirmNewPassword.Text = "";
        }
    }
}