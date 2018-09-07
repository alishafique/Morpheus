using Controller;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Seguro.Accounts
{
    public partial class viewCompanies : System.Web.UI.Page
    {
        DataTable dt;
        viewEditCompanies_Controller objviewEditCompanies;
        Dictionary<string, Int16> memberShip_type = new Dictionary<string, Int16>();
        Dictionary<string, Int16> company_type = new Dictionary<string, Int16>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                try
                {
                    if (Session["UserName"].ToString() != "")
                    {
                        if (Session["UserTypeID"].ToString() == "1")
                        {
                            populateCompany();
                            loadDropBoxOnPageLoad();
                            btnUpdateCompanyDetails.Enabled = false;
                        }
                    }
                    else
                    {
                        Response.Redirect("login.aspx");
                    }
                }
                catch (Exception)
                {
                    Response.Redirect("login.aspx");
                }
            }

        }

        private void populateCompany()
        {
            try
            {
                objviewEditCompanies = new viewEditCompanies_Controller();
                dt = new DataTable();
                dt = objviewEditCompanies.populateCompanyGridview();
                if (dt != null)
                {
                    dt.Columns.Add("Status1", typeof(string)); // added column of age.
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        //dt.Rows[i]["Age"] = getAge(dt.Rows[i]["DOB"].ToString());
                        if (dt.Rows[i]["Status"] + string.Empty == "1")
                            dt.Rows[i]["Status1"] = "Active";
                        else
                            dt.Rows[i]["Status1"] = "Disabled";
                    }
                    dtgridview_companies.DataSource = dt;
                    dtgridview_companies.DataBind();
                }
                else
                {
                    showErrorMessage(objviewEditCompanies.ErrorString, false);
                }

            }
            catch (Exception ex)
            {
                showErrorMessage("Unable to load companies: Error= "+ex.Message, false);
            }

        }

        protected void dtgridview_companies_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                dt = new DataTable();
                objviewEditCompanies = new viewEditCompanies_Controller();
                memberShip_type.Add("Silver", 0);
                memberShip_type.Add("Gold", 1);
                memberShip_type.Add("Platinium", 2);

                DataTable dtCT = new DataTable();
                dtCT = (DataTable)ViewState["CompanyType"];

                foreach (DataRow dr in dtCT.Rows)
                {
                    company_type.Add(dr["type_name"].ToString(), Int16.Parse(dr["company_Type_id"].ToString()));
                }
                // Get the currently selected row using the SelectedRow property.
                GridViewRow row = dtgridview_companies.SelectedRow;

                //MessageLabel.Text = "Editing CompanyID : " + row.Cells[1].Text + ".";
                txtbox_UserId.Text = row.Cells[2].Text;         // load User ID
                txtbox_UserId.Enabled = false;
                txtbox_CompanyID.Text = row.Cells[1].Text; // load Company Id
                txtbox_CompanyID.Enabled = false;
                loadAddressTxtboxes(Int32.Parse(row.Cells[1].Text));  // load address by company id
                txtbox_CompanyName.Text = row.Cells[3].Text.Replace("&amp;", "&").Replace("&nbsp;", "");    // Load COmpany Name
                txtbox_CompanyEmail.Text = row.Cells[4].Text;       // load Company EMail
                dp_CompanyAccountStatus.SelectedIndex = Int32.Parse(row.Cells[7].Text); // load Account Status
               
                if (memberShip_type.ContainsKey(row.Cells[5].Text))
                    Dp_MemberShipPlan.SelectedIndex = memberShip_type[row.Cells[5].Text];

                if (company_type.ContainsKey(row.Cells[6].Text))
                    dp_CompanyType.SelectedValue = company_type[row.Cells[6].Text].ToString();

                dt = objviewEditCompanies.phoneNumberOfCompany(int.Parse(row.Cells[1].Text));
                if (dt!=null)
                {
                    TextBox_Mobile.Text = dt.Rows[0]["MobileNumber"].ToString();
                    TextBox_landline.Text = dt.Rows[0]["LandlineNumber"].ToString();
                }
                else
                    showErrorMessage("Mobile Number error: " + objviewEditCompanies.ErrorString, false);

                btnUpdateCompanyDetails.Enabled = true;
                btnUpdateCompanyDetails.Focus();
            }
            catch (Exception ex)
            {
                showErrorMessage(" Please contact administrator.: "+ ex.Message, false);
            }

        }

        protected void dtgridview_companies_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            try
            {
                GridViewRow row = dtgridview_companies.Rows[e.NewSelectedIndex];
                if (row.Cells[1].Text == "ANATR")
                {
                    e.Cancel = true;
                    showErrorMessage("You cannot select " + row.Cells[2].Text + ".", false);
                }
            }
            catch (Exception ex)
            {
                showErrorMessage("ex.Message" + " Please contact administrator.", false);
            }
        }

        // load dropbox
        private void loadDropBoxOnPageLoad()
        {
            try
            {
                objviewEditCompanies = new viewEditCompanies_Controller();
                dt = new DataTable();
                // Membership DropBox
                dt = objviewEditCompanies.loadMemberShipPlanes();
                Dp_MemberShipPlan.DataSource = dt;

                dt.Columns.Add("FullDesc", typeof(string), "membership_level + ' - ' + description");
                Dp_MemberShipPlan.DataTextField = "FullDesc";
                Dp_MemberShipPlan.DataValueField = "membership_id";
                Dp_MemberShipPlan.DataBind();
                //CompanyType dropbox load from db
                dt = objviewEditCompanies.loadCompanyTypes();
                dp_CompanyType.DataSource = dt;
                ViewState["CompanyType"] = dt;
                dp_CompanyType.DataTextField = "type_name";
                dp_CompanyType.DataValueField = "company_Type_id";
                dp_CompanyType.DataBind();
            }
            catch(Exception ex)
            {
                showErrorMessage(ex.Message, false);
            }
        }
        private void loadAddressTxtboxes(int id)
        {
            try
            {
                objviewEditCompanies = new viewEditCompanies_Controller();
                dt = new DataTable();
                dt = objviewEditCompanies.loadAddress(id);
                if (dt != null)
                {
                    if (dt.Rows.Count != 0)
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
                        else
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
                        showErrorMessage("No address for this company!!!", true);
                }
                else
                    showErrorMessage(objviewEditCompanies.ErrorString, false);
            }
            catch (Exception ex)
            {
                showErrorMessage(ex.Message, false);
            }
        }

        protected void btnUpdateCompanyDetails_Click(object sender, EventArgs e)
        {
            try
            {
                Company objCom = new Company();
                Address objAdd1 = new Address();
                Address objAdd2 = new Address();
                objviewEditCompanies = new viewEditCompanies_Controller();
                objCom.companyName = txtbox_CompanyName.Text;
                objCom.company_email = txtbox_CompanyEmail.Text;
                objCom.membership_id = int.Parse(Dp_MemberShipPlan.SelectedValue);
                objCom.companyType_id = int.Parse(dp_CompanyType.SelectedValue);
                objCom.Mobile = TextBox_Mobile.Text;
                objCom.Landline = TextBox_landline.Text;

                objAdd1.StreetAddress = txtbox_Address1Street.Text;
                objAdd1.Postcode = txtbox_Address1Postcode.Text;
                objAdd1.State = txtbox_Address1State.Text;
                objAdd1.Suburb = txtbox_Address1Suburb.Text;

                objAdd2.StreetAddress = txtbox_Address2Street.Text;
                objAdd2.Postcode = txtbox_Address2Postcode.Text;
                objAdd2.State = txtbox_Address2State.Text;
                objAdd2.Suburb = txtbox_Address2Suburb.Text;

                if (objviewEditCompanies.UpdateCompanyProfile(objCom, int.Parse(txtbox_CompanyID.Text)) == true)
                {
                    if (TextBox_addressID1.Text != "")
                    {
                        if (objviewEditCompanies.UpdateCompanyAddress(objAdd1, int.Parse(TextBox_addressID1.Text)) == true)
                        {
                            if (TextBox_addressID2.Text != "")
                            {
                                if (objviewEditCompanies.UpdateCompanyAddress(objAdd2, int.Parse(TextBox_addressID2.Text)) == false)
                                    showErrorMessage("Address 2 failed to Update", true);
                            }
                            if (TextBox_addressID2.Text == "" && txtbox_Address2Street.Text != "")
                            {
                                if (objviewEditCompanies.insertCompanyAddress(int.Parse(txtbox_CompanyID.Text), objAdd2) == false)
                                    showErrorMessage("Unable to Add Address 2", true);
                            }                    
                        }
                        else
                            showErrorMessage("profile was not Updated: " + objviewEditCompanies.ErrorString, false);
                    }
                    else
                    {
                        if (objviewEditCompanies.insertCompanyAddress(int.Parse(txtbox_CompanyID.Text), objAdd1) == false)
                            showErrorMessage("Address 1 failed to Update", false);

                        if (TextBox_addressID2.Text != "")
                        {
                            if (objviewEditCompanies.UpdateCompanyAddress(objAdd2, int.Parse(TextBox_addressID2.Text)) == false)
                                showErrorMessage("Address 2 failed to Update", true);
                        }
                        if (TextBox_addressID2.Text == "" && txtbox_Address2Street.Text != "")
                        {
                            if (objviewEditCompanies.insertCompanyAddress(int.Parse(txtbox_CompanyID.Text), objAdd2) == false)
                                showErrorMessage("Unable to Add Address 2", true);
                        }
                    }
                    showErrorMessage("Updated Successfully", true);
                }
                else
                {
                    showErrorMessage("Unable to update Company's Details.: "+ objviewEditCompanies.ErrorString, false);
                }
                populateCompany();
            }
            catch (Exception ex)
            {
                showErrorMessage(ex.Message + " Please contact administrator.", false);
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

        

        //private void resetDisplayMsg()
        //{
        //    successMsg.Style.Add("display", "none");
        //    errorMsg.Style.Add("display", "none");
        //}


        protected void dtgridview_companies_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dtgridview_companies.PageIndex = e.NewPageIndex;
            populateCompany();
        }
    }
}