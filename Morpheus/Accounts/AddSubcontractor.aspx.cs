using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using Controller;

namespace Morpheus.Accounts
{
    public partial class AddSubcontractor : System.Web.UI.Page
    {
        DataTable dt;
        AddSubcontractor_Controller obj;
       // dashboard_Controller objDashController;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!this.IsPostBack)
                {                  
                    if (Session["UserTypeID"].ToString() != "2")
                        Response.Redirect("login.aspx");
                    else
                        loadDropBoxOnPageLoad();
                }
            }
            catch (Exception)
            {
                Response.Redirect("login.aspx");
            }
        }

        private void loadDropBoxOnPageLoad()
        {
            obj = new AddSubcontractor_Controller();
            dt = new DataTable();
            //CompanyType dropbox load from db
            dt = obj.LoadCompanyTypes();
            if (dt != null)
            {
                dp_CompanyType.DataSource = dt;
                dp_CompanyType.DataTextField = "type_name";
                dp_CompanyType.DataValueField = "company_Type_id";
                dp_CompanyType.DataBind();
            }
            else
                showErrorMessage(obj.ErrorString, false);
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
        protected void TextValidate(object source, ServerValidateEventArgs e)
        {
            e.IsValid = (e.Value.Length >= 6 && e.Value.Length <= 15);
        }

        protected void btnAddSubContractor_Click(object sender, EventArgs e)
        {
            try
            {
                obj = new AddSubcontractor_Controller();
                if (chechUserName(txtbox_CompanyEmail.Text) == true || obj.checkEmailFromCompanyProfile(txtbox_CompanyEmail.Text.Trim()) == true)
                {
                    showErrorMessage("Please use another Username!", false);
                    txtbox_CompanyEmail.Focus();
                }
                else
                {
                    int tempCompanyID;
                    int tempUserID;
                    Company objCompany = new Company();
                    objCompany.companyName = txtbox_CompanyName.Text.Trim();
                    objCompany.company_email = txtbox_CompanyEmail.Text.Trim();
                    objCompany.created_date_time = DateTime.Now;
                    objCompany.companyType_id = dp_CompanyType.SelectedIndex + 1;
                    objCompany.Mobile = TextBox_Mobile.Text;
                    objCompany.Landline = TextBox_landline.Text;
                    objCompany.ABN = txtbox_ABN.Text;
                    // create Sub-Contractor as "Company profile"
                    tempCompanyID = obj.createCompanyAccountByAdmin(objCompany, int.Parse(Session["userid"].ToString()));

                    if (tempCompanyID > 0)
                    {
                        // create User_name for company
                        tempUserID = obj.createUserAccountUserTable(4, txtbox_CompanyPassword.Text, objCompany); // "4" represent the Role id i.e. Sub-contractor type
                        if (tempUserID > 0)
                        {
                            if (obj.insertTbCompanyUser(tempUserID, tempCompanyID))
                            {
                                if (txtbox_Address1Suburb.Text.Trim() != "")
                                {
                                    obj.insertCompanyAddress(tempCompanyID, txtbox_Address1Street.Text.Trim(), txtbox_Address1Suburb.Text.Trim(), txtbox_Address1State.Text.Trim(), txtbox_Address1Postcode.Text.Trim());
                                }
                                if (txtbox_Address2Suburb.Text.Trim() != "")
                                {
                                    obj.insertCompanyAddress(tempCompanyID, txtbox_Address2Street.Text.Trim(), txtbox_Address2Suburb.Text.Trim(), txtbox_Address2State.Text.Trim(), txtbox_Address2Postcode.Text.Trim());
                                }
                                resetFeilds();
                                showErrorMessage("Successfully Added Sub-contract's Account", true);
                            }
                            else
                                showErrorMessage(obj.ErrorString, false); // error Message if unable to Update table companyUser
                        }
                        else
                            showErrorMessage(obj.ErrorString, false); // error message if unable to create user account
                    }
                    else
                        showErrorMessage(obj.ErrorString, false); // Error message If unable to create Contract's profile
                }
            }
            catch (Exception ex)
            {
                showErrorMessage(ex.Message, false);
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

        public bool chechUserName(string username)
        {
            obj = new AddSubcontractor_Controller();
            if (obj.checkUserName(username.Trim()) || obj.checkEmailFromCompanyProfile(username.Trim()) == true)
                return true;
            else
                return false;
        }

        [WebMethod]
        public static bool UserNameChecker(string newUserName)
        {
            AddSubcontractor objDb = new AddSubcontractor();
            if (newUserName == "")
                return true;
            if (objDb.chechUserName(newUserName) == true)
                return true;
            else
                return false;
        }
    }
}