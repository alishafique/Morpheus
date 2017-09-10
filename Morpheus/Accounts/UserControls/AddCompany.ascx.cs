using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Controller;
using System.Web.Services;

namespace Morpheus.Accounts.UserControls
{
    public partial class AddCompany : System.Web.UI.UserControl
    {
        DataTable dt;
        dashboard_Controller objDashController;
        protected void Page_Load(object sender, EventArgs e)
        {
            loadDropBoxOnPageLoad();
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
            int tempCompanyID;
            int tempUserID;
            Company objCompany = new Company();

            objCompany.companyName = txtbox_CompanyName.Text.Trim();
            objCompany.company_email = txtbox_CompanyEmail.Text.Trim();
            objCompany.membership_id = Dp_MemberShipPlan.SelectedIndex + 1;
            objCompany.created_date_time = DateTime.Now;
            objCompany.companyType_id = dp_CompanyType.SelectedIndex + 1;
            // create Company profile
            tempCompanyID = objDashController.createCompanyAccountByAdmin(objCompany);
            if (tempCompanyID > 0)
            {
                // create User_name for company
                tempUserID = objDashController.createUserAccountUserTable(2, txtbox_CompanyPassword.Text, objCompany);
                if (tempUserID > 0)
                {
                    objDashController.insertTbCompanyUser(tempUserID, tempCompanyID);

                    if (txtbox_Address1Suburb.Text.Trim() != "" && txtbox_Address1Suburb.Text.Trim() != "" && txtbox_Address1State.Text.Trim() != "" && txtbox_Address1Postcode.Text.Trim() != "")
                    {
                        objDashController.insertCompanyAddress(tempCompanyID, txtbox_Address1Suburb.Text.Trim(), txtbox_Address1Suburb.Text.Trim(), txtbox_Address1State.Text.Trim(), txtbox_Address1Postcode.Text.Trim());
                    }
                    if (txtbox_Address2Suburb.Text.Trim() != "" && txtbox_Address2Suburb.Text.Trim() != "" && txtbox_Address2State.Text.Trim() != "" && txtbox_Address2Postcode.Text.Trim() != "")
                    {
                        objDashController.insertCompanyAddress(tempCompanyID, txtbox_Address2Suburb.Text.Trim(), txtbox_Address2Suburb.Text.Trim(), txtbox_Address2State.Text.Trim(), txtbox_Address2Postcode.Text.Trim());
                    }
                }
            }


        }

        protected void txtbox_CompanyEmail_TextChanged(object sender, EventArgs e)
        {
            if (objDashController.checkUserName(txtbox_CompanyEmail.Text.Trim()) != true)
            {
                lbl_error_message.Text = "Please enter another email";

            }

        }
        public bool chechUserName(string username)
        {
            if (objDashController.checkUserName(username.Trim()) || objDashController.checkEmailFromCompanyProfile(username.Trim()) == true)
                return true;
            else
                return false;

        }

        [WebMethod]
        public static bool UserNameChecker(string newUserName)
        {
            AddCompany objDb = new AddCompany();
            if (newUserName == "")
                return true;
            if (objDb.chechUserName(newUserName) == true)
                return true;
            else
                return false;
        }
    }
}