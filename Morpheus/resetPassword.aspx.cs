using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Controller;

namespace Seguro
{
    public partial class resetPassword : System.Web.UI.Page
    {
        DataTable dt;
        resetPassword_Controller objReset;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnResetPassword_Click(object sender, EventArgs e)
        {
            try
            {
                objReset = new resetPassword_Controller();
                dt = new DataTable();
                dt = objReset.spResetPasswordFunc(txtbox_email.Text);
                if (dt != null)
                {
                    if (dt.Rows[0]["ReturnCode"].ToString() == "0")
                        showErrorMessage("Email does not exsist!!!", false);
                    else
                    if (dt.Rows[0]["ReturnCode"].ToString() == "1")
                    {
                        if (objReset._SendPasswordResetEmail(txtbox_email.Text, txtbox_email.Text, dt.Rows[0]["UniqueId"].ToString()) == true)
                        {
                            showErrorMessage("Password reset link has been sent to your Email", true);
                            txtbox_email.Text = "";
                            myDiv.Style.Add("display", "none");                           
                        }
                        else
                            showErrorMessage(objReset.ErrorString,false);
                    }
                }
                else
                    showErrorMessage(objReset.ErrorString, false);
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
    }
}