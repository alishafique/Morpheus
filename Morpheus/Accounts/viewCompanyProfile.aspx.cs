using Controller;
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
    public partial class viewCompanyProfile : System.Web.UI.Page
    {
        companyProfile_Controller objProfile;
        Dictionary<string, Int16> company_type = new Dictionary<string, Int16>();
        Dictionary<string, Int16> memberShip_type = new Dictionary<string, Int16>();
        DataTable dt;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                loadDropBoxOnPageLoad();
                loadProfile();
            }
        }

        protected void btnUpdateCompanyDetails_Click(object sender, EventArgs e)
        {
            try
            {
                Company objCom = new Company();
                Address objAdd1 = new Address();
                Address objAdd2 = new Address();
                objProfile = new companyProfile_Controller();
                objCom.companyName = txtbox_CompanyName.Text;
                objCom.company_email = txtbox_CompanyEmail.Text;
                objCom.membership_id = int.Parse(Dp_MemberShipPlan.SelectedValue);
                objCom.Mobile = TextBox_Mobile.Text;
                objCom.Landline = TextBox_landline.Text;

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
                if (objProfile.UpdateCompanyProfile(objCom, tempId) == true)
                {
                    if (TextBox_addressID1.Text != "")
                    {
                        if (objProfile.UpdateCompanyAddress(objAdd1, int.Parse(TextBox_addressID1.Text)) == true)
                        {
                            if (TextBox_addressID2.Text != "")
                            {
                                if (objProfile.UpdateCompanyAddress(objAdd2, int.Parse(TextBox_addressID2.Text)) == false)
                                    showErrorMessage("Address 2 failed to Update", true);
                            }
                            if (TextBox_addressID2.Text == "" && txtbox_Address2Street.Text != "")
                            {
                                if (objProfile.insertCompanyAddress(int.Parse(txtbox_CompanyID.Text), objAdd2) == false)
                                    showErrorMessage("Unable to Add Address 2", true);
                            }

                            showErrorMessage("Updated Successfully", true);
                        }
                        else
                            showErrorMessage("profile was not Updated: " + objProfile.ErrorString, false);
                    }
                    else
                    {
                        if (objProfile.insertCompanyAddress(int.Parse(txtbox_CompanyID.Text), objAdd1) == false)
                            showErrorMessage("Address 1 failed to Update", false);

                        if (TextBox_addressID2.Text != "")
                        {
                            if (objProfile.UpdateCompanyAddress(objAdd2, int.Parse(TextBox_addressID2.Text)) == false)
                                showErrorMessage("Address 2 failed to Update", true);
                        }
                        if (TextBox_addressID2.Text == "" && txtbox_Address2Street.Text != "")
                        {
                            if (objProfile.insertCompanyAddress(int.Parse(txtbox_CompanyID.Text), objAdd2) == false)
                                showErrorMessage("Unable to Add Address 2", true);
                        }

                        showErrorMessage("Updated Successfully", true);
                    }
                }
                else
                {
                    showErrorMessage("Unable to update Company's Details.", false);
                }
            }
            catch (Exception ex)
            {
                showErrorMessage(ex.Message + " Please contact administrator.", false);
            }

        }

        private void loadProfile()
        {
            try
            {
                memberShip_type.Add("Silver", 0);
                memberShip_type.Add("Gold", 1);
                memberShip_type.Add("Platinium", 2);
                objProfile = new companyProfile_Controller();
                dt = new DataTable();
                dt = objProfile.loadCompanyProfile(int.Parse(Session["userid"].ToString()));
                if (dt != null)
                {
                    txtbox_CompanyID.Text = dt.Rows[0]["CompanyID"].ToString();
                    txtbox_UserId.Text = dt.Rows[0]["UserID"].ToString();
                    txtbox_CompanyName.Text = dt.Rows[0]["CompanyName"].ToString();
                    txtbox_CompanyEmail.Text = dt.Rows[0]["Email"].ToString();
                    TextBox_CompanyType.Text = dt.Rows[0]["Type"].ToString();
                    TextBox_Mobile.Text = dt.Rows[0]["MobileNumber"].ToString();
                    TextBox_landline.Text = dt.Rows[0]["LandlineNumber"].ToString();
                    if (memberShip_type.ContainsKey(dt.Rows[0]["MemberShip"].ToString()))
                        Dp_MemberShipPlan.SelectedIndex = memberShip_type[dt.Rows[0]["MemberShip"].ToString()];

                    loadAddressTxtboxes(int.Parse(dt.Rows[0]["CompanyID"].ToString()));

                }
                else
                {
                    showErrorMessage(objProfile.ErrorString, false);
                }
            }
            catch (Exception ex)
            {
                showErrorMessage(ex.Message, false);
            }

        }

        private void loadAddressTxtboxes(int id)
        {
            try
            {
                objProfile = new companyProfile_Controller();
                dt = new DataTable();
                dt = objProfile.loadAddress(id);
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
                {
                    showErrorMessage(objProfile.ErrorString, false);
                }
            }
            catch (Exception ex)
            {
                showErrorMessage(ex.Message, false);
            }
        }

        private void loadDropBoxOnPageLoad()
        {
            try
            {
                objProfile = new companyProfile_Controller();
                dt = new DataTable();
                // Membership DropBox
                dt = objProfile.loadMemberShipPlanes();
                Dp_MemberShipPlan.DataSource = dt;

                dt.Columns.Add("FullDesc", typeof(string), "membership_level + ' - ' + description");
                Dp_MemberShipPlan.DataTextField = "FullDesc";
                Dp_MemberShipPlan.DataValueField = "membership_id";
                Dp_MemberShipPlan.DataBind();
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