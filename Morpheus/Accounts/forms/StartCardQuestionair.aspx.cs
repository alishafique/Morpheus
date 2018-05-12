using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Controller;

namespace Morpheus.Accounts
{
    public partial class survey : System.Web.UI.Page
    {
        StartCardQuestionair_Controller objController;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["UserName"].ToString() != "")
                {
                    txtTask.Text = Session["ActivityId"].ToString();
                    txtemployee.Text = Session["UserName"].ToString();
                    txtstartdate.Text = DateTime.Now.ToString();
                }
                else
                {
                    Response.Redirect("login.aspx");
                }
            }
            catch(Exception ex)
            {
                showErrorMessage(ex.Message, false);
            }
        }

        
        protected void btnSubmitSurvey_Click(object sender, EventArgs e)
        {
            try
            {
                objController = new StartCardQuestionair_Controller();
                if(CheckNo() ==  false)
                {
                    showErrorMessage("Please inform your supervisor, as you have selected one of the answer as No.", false);
                    return;
                }
                if(CheckDesireAnswer())
                {
                    //bool result = objController.StartActivity(int.Parse(txtTask.Text), int.Parse(Session["userid"].ToString()), "Completed", "form/StartCardQuestionair.aspx", "Started", DateTime.Now);
                    //if (result)
                    //{
                        Session["SuccessMsg"] = "Congratulations your job has been started";
                        Response.Redirect("../StartActivity.aspx");
                    //}
                    //else
                    //    showErrorMessage(objController._errorMsg, false);
                }
            }
            catch(Exception ex)
            {
                showErrorMessage(ex.Message, false);
            }
        }

        private bool CheckDesireAnswer()
        {
            if (rdYesQ1.Checked && rdYesQ2.Checked && rdYesQ3.Checked && rdYesQ4.Checked && rdYesQ5.Checked && rdYesQ6.Checked && rdYesQ7.Checked && rdYesQ8.Checked)
                return true;
            else
                return false;
        }

        private bool CheckNo()
        {
            if (rdNoQ1.Checked)
                return false;
            if (rdNoQ2.Checked)
                return false;
            if (rdNoQ3.Checked)
                return false;
            if (rdNoQ4.Checked)
                return false;
            if (rdNoQ5.Checked)
                return false;
            if (rdNoQ6.Checked)
                return false;
            if (rdNoQ7.Checked)
                return false;
            if (rdNoQ8.Checked)
                return false;
            if (rdNoQ9.Checked)
                return false;
            if (rdNoQ10.Checked)
                return false;
            if (rdNoQ11.Checked)
                return false;
            if (rdNoQ12.Checked)
                return false;

            return true;


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

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("../StartActivity.aspx");
        }
    }
}