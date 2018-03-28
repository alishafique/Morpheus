using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Controller;

namespace Morpheus.Accounts
{
    public partial class SubContractorProfile : System.Web.UI.Page
    {
        DataTable dt;
        SubContractorProfile_Controller obj;
        Dictionary<string, Int16> company_type = new Dictionary<string, Int16>();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!this.IsPostBack)
                {
                    if (Session["UserTypeID"].ToString() == "4")
                    {
                        loadDropBoxOnPageLoad();
                        loadProfile();
                    }
                    else
                    {
                        Response.Redirect("~/Accounts/login.aspx", false);
                    }
                }
            }
            catch(Exception ex)
            {
                Response.Redirect("~/Accounts/login.aspx", false);
            }
        }

        protected void btnUpdateSubContractorProfile_Click(object sender, EventArgs e)
        {
            try
            {
                Company objCom = new Company();
                Address objAdd1 = new Address();
                Address objAdd2 = new Address();
                obj = new SubContractorProfile_Controller();
                objCom.companyName = txtbox_CompanyName.Text;
                objCom.company_email = txtbox_CompanyEmail.Text;

                objCom.companyType_id = int.Parse(dp_CompanyType.SelectedValue);
                objCom.Mobile = TextBox_Mobile.Text;
                objCom.Landline = TextBox_landline.Text;
                objCom.ABN = txtbox_ABN.Text;
                // Address 1
                objAdd1.StreetAddress = txtbox_Address1Street.Text;
                objAdd1.Postcode = txtbox_Address1Postcode.Text;
                objAdd1.State = txtbox_Address1State.Text;
                objAdd1.Suburb = txtbox_Address1Suburb.Text;
                // Address 2
                objAdd2.StreetAddress = txtbox_Address2Street.Text;
                objAdd2.Postcode = txtbox_Address2Postcode.Text;
                objAdd2.State = txtbox_Address2State.Text;
                objAdd2.Suburb = txtbox_Address2Suburb.Text;


                int tempId = int.Parse(txtbox_CompanyID.Text);
                if (obj.UpdateCompanyProfile(objCom, tempId) == true)
                {
                    if (TextBox_addressID1.Text != "")
                    {
                        if (obj.UpdateCompanyAddress(objAdd1, int.Parse(TextBox_addressID1.Text)) == true)
                        {
                            if (TextBox_addressID2.Text != "")
                            {
                                if (obj.UpdateCompanyAddress(objAdd2, int.Parse(TextBox_addressID2.Text)) == false)
                                    showErrorMessage("Address 2 failed to Update", true);
                            }
                            if (TextBox_addressID2.Text == "" && txtbox_Address2Street.Text != "")
                            {
                                if (obj.insertCompanyAddress(int.Parse(txtbox_CompanyID.Text), objAdd2) == false)
                                    showErrorMessage("Unable to Add Address 2", true);
                            }

                            showErrorMessage("Updated Successfully", true);
                        }
                        else
                            showErrorMessage("profile was not Updated: " + obj.ErrorString, false);
                    }
                    else
                    {
                        if (obj.insertCompanyAddress(int.Parse(txtbox_CompanyID.Text), objAdd1) == false)
                            showErrorMessage("Address 1 failed to Update", false);

                        if (TextBox_addressID2.Text != "")
                        {
                            if (obj.UpdateCompanyAddress(objAdd2, int.Parse(TextBox_addressID2.Text)) == false)
                                showErrorMessage("Address 2 failed to Update", true);
                        }
                        if (TextBox_addressID2.Text == "" && txtbox_Address2Street.Text != "")
                        {
                            if (obj.insertCompanyAddress(int.Parse(txtbox_CompanyID.Text), objAdd2) == false)
                                showErrorMessage("Unable to Add Address 2", true);
                        }

                        showErrorMessage("Updated Successfully", true);
                    }
                }
                else
                    showErrorMessage("Unable to update Company's Details.: "+obj.ErrorString, false);
            }
            catch(Exception ex)
            {
                showErrorMessage(ex.Message, false);
            }
        }

        private void loadProfile()
        {
            try
            {
                obj = new SubContractorProfile_Controller();
                dt = new DataTable();
                company_type.Add("Construction", 0);
                company_type.Add("Hospitality", 1);

                dt = obj.loadCompanyProfile(int.Parse(Session["userid"].ToString()));
                if (dt != null)
                {
                    txtbox_CompanyID.Text = dt.Rows[0]["CompanyID"].ToString();
                    txtbox_UserId.Text = dt.Rows[0]["UserID"].ToString();
                    txtbox_CompanyName.Text = dt.Rows[0]["CompanyName"].ToString();
                    txtbox_CompanyEmail.Text = dt.Rows[0]["Email"].ToString();
                    txtbox_ABN.Text = dt.Rows[0]["ABN"].ToString();

                    if (company_type.ContainsKey(dt.Rows[0]["Type"].ToString())) // select the type of Sub-Contractor
                        dp_CompanyType.SelectedIndex = company_type[dt.Rows[0]["Type"].ToString()];
                    //TextBox_CompanyType.Text = dt.Rows[0]["Type"].ToString();
                    TextBox_Mobile.Text = dt.Rows[0]["MobileNumber"].ToString();
                    TextBox_landline.Text = dt.Rows[0]["LandlineNumber"].ToString();

                    loadAddressTxtboxes(int.Parse(dt.Rows[0]["CompanyID"].ToString()));

                }
                else
                    showErrorMessage(obj.ErrorString, false);
            }
            catch (Exception ex)
            {
                showErrorMessage(ex.Message, false);
            }

        }

        private void loadDropBoxOnPageLoad()
        {
            obj = new SubContractorProfile_Controller();
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

        private void loadAddressTxtboxes(int id)
        {
            try
            {
                obj = new SubContractorProfile_Controller();
                dt = new DataTable();
                dt = obj.loadAddress(id);
                if (dt != null)
                {
                    if (dt.Rows.Count > 1)
                    {
                        TextBox_addressID1.Text = dt.Rows[0]["address_id"].ToString();
                        txtbox_Address1Street.Text = dt.Rows[0]["address"].ToString();
                        txtbox_Address1Suburb.Text = dt.Rows[0]["suburb"].ToString();
                        txtbox_Address1State.Text = dt.Rows[0]["state"].ToString();
                        txtbox_Address1Postcode.Text = dt.Rows[0]["postcode"].ToString();

                        TextBox_addressID2.Text = dt.Rows[1]["address_id"].ToString();
                        txtbox_Address2Street.Text = dt.Rows[1]["address"].ToString();
                        txtbox_Address2Suburb.Text = dt.Rows[1]["suburb"].ToString();
                        txtbox_Address2State.Text = dt.Rows[1]["state"].ToString();
                        txtbox_Address2Postcode.Text = dt.Rows[1]["postcode"].ToString();

                    }
                    else if (dt.Rows.Count == 1)
                    {

                        TextBox_addressID1.Text = dt.Rows[0]["address_id"].ToString();
                        txtbox_Address1Street.Text = dt.Rows[0]["address"].ToString();
                        txtbox_Address1Suburb.Text = dt.Rows[0]["suburb"].ToString();
                        txtbox_Address1State.Text = dt.Rows[0]["state"].ToString();
                        txtbox_Address1Postcode.Text = dt.Rows[0]["postcode"].ToString();

                        txtbox_Address2Street.Text = "";
                        txtbox_Address2Suburb.Text = "";
                        txtbox_Address2State.Text = "";
                        txtbox_Address2Postcode.Text = "";
                    }
                }
                else
                    showErrorMessage(obj.ErrorString, false);
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
    }
}