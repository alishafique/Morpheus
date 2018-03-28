using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Controller;
using Domain;

namespace Morpheus
{
    public partial class ContactUs : System.Web.UI.Page
    {
        ContactUs_Controller obj;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnContactUs_Click(object sender, EventArgs e)
        {
            try
            {
                obj = new ContactUs_Controller();
                if (Page.IsValid)
                {
                    bool isHuman = ExampleCaptcha.Validate();
                    if (isHuman)
                    {
                        if (Email.ContactUsEmail(txtName.Text, txtEmail.Text, txtPhone.Text, txtMessage.Text) && obj.InsertContactUsForm(txtName.Text, txtEmail.Text, txtPhone.Text, txtMessage.Text))
                        {                          
                            showErrorMessage("Thank you for contacting us", true);
                            txtName.Text = "";
                            txtEmail.Text = "";
                            txtMessage.Text = "";
                            txtPhone.Text = "";
                        }
                        else
                            showErrorMessage(Email.Error + ". " + obj.ErrorString , false);
                    }
                    else
                    {
                        CaptchaCorrectLabel.Visible = false;
                        CaptchaIncorrectLabel.Visible = true;
                        CaptchaCodeTextBox.Focus();
                    }


                }
            }
            catch (Exception ex)
            {
                showErrorMessage("There is an unkwon problem. Please try later", false);
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