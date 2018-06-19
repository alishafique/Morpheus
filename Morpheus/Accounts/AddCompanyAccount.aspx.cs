using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Controller;
using System.Web.Services;

namespace Morpheus.Accounts
{
    public partial class AddCompanyAccount : System.Web.UI.Page
    {
        DataTable dt;
        dashboard_Controller objDashController;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!this.IsPostBack)
                {

                    loadDropBoxOnPageLoad();
                    if (Session["UserTypeID"].ToString() != "1")
                    {
                        Response.Redirect("login.aspx");
                    }
                    else
                        if (Session["UserTypeID"].ToString() == "1")
                    {
                        lblUserName.Text = Session["UserName"].ToString();
                        dashboardmenu1.Visible = true;
                        companySideMenu1.Visible = false;
                        employeeDashMenu1.Visible = false;
                        //AddCompany1.Visible = true;
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
        private void loadDropBoxOnPageLoad()
        {
            objDashController = new dashboard_Controller();
            dt = new DataTable();
            // Membership DropBox
            dt = objDashController.loadMemberShipPlanes();
            Dp_MemberShipPlan.DataSource = dt;
            dt.Columns.Add("FullDesc", typeof(string), "membership_level + ' - ' + description");
            Dp_MemberShipPlan.DataTextField = "FullDesc";
            Dp_MemberShipPlan.DataValueField = "membership_id";
            Dp_MemberShipPlan.DataBind();
            //CompanyType dropbox load from db
            dt = objDashController.loadCompanyTypes();
            dp_CompanyType.DataSource = dt;
            dp_CompanyType.DataTextField = "type_name";
            dp_CompanyType.DataValueField = "company_Type_id";
            dp_CompanyType.DataBind();

        }
        protected void btnAddCompany_Click(object sender, EventArgs e)
        {
            try
            {
                if (chechUserName(txtbox_CompanyEmail.Text) == true || objDashController.checkEmailFromCompanyProfile(txtbox_CompanyEmail.Text.Trim()) == true)
                {
                    showErrorMessage("Please use another Username!", false);
                    txtbox_CompanyEmail.Focus();
                }
                else
                {
                    int tempCompanyID;
                    int tempUserID;
                    Company objCompany = new Company();
                    objDashController = new dashboard_Controller();

                    objCompany.companyName = txtbox_CompanyName.Text.Trim();
                    objCompany.company_email = txtbox_CompanyEmail.Text.Trim();
                    objCompany.membership_id = Dp_MemberShipPlan.SelectedIndex + 1;
                    objCompany.created_date_time = DateTime.Now;
                    objCompany.companyType_id = int.Parse(dp_CompanyType.SelectedValue);
                    objCompany.Mobile = TextBox_Mobile.Text;
                    objCompany.Landline = TextBox_landline.Text;
                    // create Company profile
                    tempCompanyID = objDashController.createCompanyAccountByAdmin(objCompany);

                    if (tempCompanyID > 0)
                    {
                        // create User_name for company
                        tempUserID = objDashController.createUserAccountUserTable(2, txtbox_CompanyPassword.Text, objCompany); // 2 represent the Role id i.e. Company type
                        if (tempUserID > 0)
                        {
                            objDashController.insertTbCompanyUser(tempUserID, tempCompanyID);
                            if (txtbox_Address1Suburb.Text.Trim() != "")
                                objDashController.insertCompanyAddress(tempCompanyID, txtbox_Address1Street.Text.Trim(), txtbox_Address1Suburb.Text.Trim(), txtbox_Address1State.Text.Trim(), txtbox_Address1Postcode.Text.Trim());
                            if (txtbox_Address2Suburb.Text.Trim() != "")
                                objDashController.insertCompanyAddress(tempCompanyID, txtbox_Address2Street.Text.Trim(), txtbox_Address2Suburb.Text.Trim(), txtbox_Address2State.Text.Trim(), txtbox_Address2Postcode.Text.Trim());
                            resetFeilds();
                            showErrorMessage("Successfully Added Company", true);
                        }
                        else
                            showErrorMessage(objDashController.ErrorString, false);
                    }
                    else
                        showErrorMessage(objDashController.ErrorString, false);
                }
            }
            catch (Exception ex)
            {
                showErrorMessage(ex.Message, false);
            }

        }

        protected void txtbox_CompanyEmail_TextChanged(object sender, EventArgs e)
        {
            try
            {
                objDashController = new dashboard_Controller();
                if (objDashController.checkUserName(txtbox_CompanyEmail.Text.Trim()) != true)
                {
                    lbl_error_message.Text = "Please enter another email";

                }
            }
            catch (Exception ex)
            {
                showErrorMessage(ex.Message + " Please contact administrator.", false);
            }

        }


        private void resetFeilds()
        {
            txtbox_CompanyName.Text = "";
            txtbox_CompanyEmail.Text = "";
            txtbox_CompanyPassword.Text = "";
            txtbox_CompanyRePassword.Text = "";
            txtbox_Address1Street.Text = "";
            txtbox_Address1Suburb.Text = "";
            txtbox_Address1Postcode.Text = "";
            txtbox_Address1State.Text = "";
            txtbox_Address2Street.Text = "";
            txtbox_Address2Suburb.Text = "";
            txtbox_Address2Postcode.Text = "";
            txtbox_Address2State.Text = "";
            TextBox_landline.Text = "";
            TextBox_Mobile.Text = "";
            
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
        public bool chechUserName(string username)
        {
            objDashController = new dashboard_Controller();
            if (objDashController.checkUserName(username.Trim()) || objDashController.checkEmailFromCompanyProfile(username.Trim()) == true)
                return true;
            else
                return false;

        }

        [WebMethod]
        public static bool UserNameChecker(string newUserName)
        {
            AddCompanyAccount objDb = new AddCompanyAccount();
            if (newUserName == "")
                return true;
            if (objDb.chechUserName(newUserName) == true)
                return true;
            else
                return false;
        }
    }
}