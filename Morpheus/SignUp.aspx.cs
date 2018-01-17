using Controller;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Morpheus
{
    public partial class SignUp : System.Web.UI.Page
    {
        DataTable dt;
        SignUp_Controller objSignUp;
        int i= 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!this.IsPostBack)
                {
                    loadDropBoxOnPageLoad();
                    ViewState["userName"] = "";
                    // set control text
                   
                    CaptchaCorrectLabel.Text = "Correct!";
                    CaptchaIncorrectLabel.Text = "Incorrect!";

                    // these messages are shown only after validation
                    CaptchaCorrectLabel.Visible = false;
                    CaptchaIncorrectLabel.Visible = false;
                }
            }
            catch (Exception)
            {
                Response.Redirect("login.aspx");
            }

        }
        private void loadDropBoxOnPageLoad()
        {
            try
            {
                objSignUp = new SignUp_Controller();
                dt = new DataTable();
                // Membership DropBox
                dt = objSignUp.loadMemberShipPlanes();
                if (dt != null)
                {
                    Dp_MemberShipPlan.DataSource = dt;
                    dt.Columns.Add("FullDesc", typeof(string), "membership_level + ' - ' + description");
                    Dp_MemberShipPlan.DataTextField = "FullDesc";
                    Dp_MemberShipPlan.DataValueField = "membership_id";
                    Dp_MemberShipPlan.DataBind();
                }
                else
                {
                    showErrorMessage("Unable to load Membership plan: " +objSignUp.ErrorString, false);
                }
               
                //CompanyType dropbox load from db
                dt = objSignUp.loadCompanyTypes();
                if (dt != null)
                {
                    dp_CompanyType.DataSource = dt;
                    dp_CompanyType.DataTextField = "type_name";
                    dp_CompanyType.DataValueField = "company_Type_id";
                    dp_CompanyType.DataBind();
                }
                else
                {
                    showErrorMessage("Unable to load Company Type:  " + objSignUp.ErrorString, false);
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
            }
            else
            {
                lblErrorMsg.Text = message;
                errorMsg.Style.Add("display", "block");
                successMsg.Style.Add("display", "none");
            }

        }
        protected void btnAddCompany_Click(object sender, EventArgs e)
        {
            try
            {
                bool isHuman = ExampleCaptcha.Validate();
                if (isHuman)
                {
                    CaptchaCorrectLabel.Visible = true;
                    CaptchaIncorrectLabel.Visible = false;
                    if (chechUserName(txtbox_CompanyEmail.Text) == true)
                    {
                        showErrorMessage("Please use another Username!", false);
                        txtbox_CompanyEmail.Focus();
                    }
                    else
                    {
                        if (IsValidEmail(txtbox_CompanyEmail.Text) == true)
                        {
                            int tempCompanyID;
                            int tempUserID;
                            Company objCompany = new Company();
                            objSignUp = new SignUp_Controller();

                            objCompany.companyName = txtbox_CompanyName.Text.Trim();
                            objCompany.company_email = txtbox_CompanyEmail.Text.Trim();
                            objCompany.membership_id = Dp_MemberShipPlan.SelectedIndex + 1;
                            objCompany.created_date_time = DateTime.Now;
                            objCompany.companyType_id = dp_CompanyType.SelectedIndex + 1;
                            objCompany.Mobile = TextBox_Mobile.Text;
                            objCompany.Landline = TextBox_landline.Text;
                            // create Company profile
                            tempCompanyID = objSignUp.createCompanyAccount(objCompany);
                            if (tempCompanyID > 0)
                            {
                                // create User_name for company
                                tempUserID = objSignUp.createUserAccountUserTable(2, txtbox_CompanyPassword.Text, objCompany);
                                if (tempUserID > 0)
                                {
                                    if (objSignUp.insertTbCompanyUser(tempUserID, tempCompanyID) == true)
                                    {

                                        if (txtbox_Address1Street.Text.Trim() != "")
                                        {
                                            if (objSignUp.insertCompanyAddress(tempCompanyID, txtbox_Address1Street.Text.Trim(), locality.Text.Trim(), txtbox_Address1State.Text.Trim(), txtbox_Address1Postcode.Text.Trim()) == false)
                                                showErrorMessage(objSignUp.ErrorString, false);
                                        }
                                        if (txtbox_Address1Street.Text.Trim() != "")
                                        {
                                            if (objSignUp.insertCompanyAddress(tempCompanyID, txtbox_Address2Street.Text.Trim(), txtbox_Address2Suburb.Text.Trim(), txtbox_Address2State.Text.Trim(), txtbox_Address2Postcode.Text.Trim()) == false)
                                                showErrorMessage(objSignUp.ErrorString, false);
                                        }


                                      
                                        if (objSignUp.signUpNotificationToCompany(objCompany.company_email, txtbox_CompanyName.Text, txtbox_CompanyPassword.Text, objCompany.created_date_time) == true)
                                        {
                                            showErrorMessage("Successfully Created Account. And Notification is sent on your Email.", true);
                                        }
                                        else
                                        {
                                            showErrorMessage("Successfully created Account", true);
                                        }
                                        resetFeilds();
                                    }
                                    else
                                    {
                                        showErrorMessage(objSignUp.ErrorString, false);
                                    }
                                }
                                else
                                {
                                    showErrorMessage(objSignUp.ErrorString, false);
                                }
                            }
                            else
                            {
                                showErrorMessage(objSignUp.ErrorString, false);
                            }
                        }
                    }
                }
                else
                {
                    CaptchaCorrectLabel.Visible = false;
                    CaptchaIncorrectLabel.Visible = true;
                    CaptchaCodeTextBox.Focus();

                }

            }
            catch (Exception ex)
            {
                showErrorMessage(ex.Message, false);
            }
        }
        private void splitAdd(string add)
        {
            string[] temp = add.Split(',');
        }
        protected void TextValidate(object source, ServerValidateEventArgs e)
        {
            e.IsValid = (e.Value.Length >= 6 && e.Value.Length <= 15);
        }

        private void resetFeilds()
        {
            txtbox_CompanyName.Text = "";
            txtbox_CompanyEmail.Text = "";
            txtbox_CompanyPassword.Text = "";
            txtbox_CompanyRePassword.Text = "";
            txtbox_Address1Street.Text = "";
            locality.Text = "";
            txtbox_Address1Postcode.Text = "";
            txtbox_Address1State.Text = "";
            txtbox_Address2Street.Text = "";
            txtbox_Address2Suburb.Text = "";
            txtbox_Address2Postcode.Text = "";
            txtbox_Address2State.Text = "";
            TextBox_Mobile.Text = "";
            TextBox_landline.Text = "";
            CaptchaCorrectLabel.Visible = false;
            CaptchaIncorrectLabel.Visible = false;

        }

        public bool chechUserName(string username)
        {
            objSignUp = new SignUp_Controller();
            if (objSignUp.checkUserName(username.Trim()) || objSignUp.checkEmailFromCompanyProfile(username.Trim()) == true)
             return true;
              else
             return false;
         }
        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return true;
            }
            catch (Exception ex)
            {
                showErrorMessage("Please enter Valid Email address", false);
                txtbox_CompanyEmail.Focus();
                return false;
            }
        }
       
        [WebMethod]
        public static bool UserNameChecker(string newUserName)
        {
            SignUp objDb = new SignUp();
            if (newUserName == "")
                return true;
            if (objDb.chechUserName(newUserName) == true)
                return true;
            else
                return false;
        }
        


    }
}