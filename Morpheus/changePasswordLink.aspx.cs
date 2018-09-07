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
    public partial class changePasswordLink : System.Web.UI.Page
    {
        DataTable dt;
        changePasswordLink_Controller obj;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                obj = new changePasswordLink_Controller();
                if (obj.spIsPasswordResetLinkValid(Request.QueryString["uid"]) == false)
                {
                    showErrorMessage("Password Reset link has expired or is invalid", false);
                    divID.Style.Add("display", "none");
                }
            }

        }

        protected void btnChangePassword_Click(object sender, EventArgs e)
        {
            try
            {
                obj = new changePasswordLink_Controller();
                dt = new DataTable();
                dt = obj.spChangePassword(Request.QueryString["uid"], txtNewPassword.Text);
                if(dt != null)
                {
                    if(dt.Rows[0]["IsPasswordChanged"].ToString() == "1")
                    {
                        showErrorMessage("Password Changed Successfully", true);
                        divID.Style.Add("display", "none");
                    }
                    else
                    {
                        showErrorMessage("UserId does not exist", false);
                    }
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
        protected void TextValidate(object source, ServerValidateEventArgs e)
        {
            e.IsValid = (e.Value.Length >= 6 && e.Value.Length <= 15);
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