using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Controller;

namespace Seguro.Accounts
{
    public partial class ViewSub_Contractor : System.Web.UI.Page
    {
        ViewSub_Contractor_Controller obj;
        DataTable dt;
        Dictionary<string, Int16> company_type = new Dictionary<string, Int16>();
        private string errorStr ="";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                try
                {
                    if (Session["UserName"].ToString() != "")
                    {
                        if (Session["UserTypeID"].ToString() == "2")
                        {
                            PopulateSubContractor();
                            loadDropBoxOnPageLoad();
                            btnUpdateSubContractorDetails.Enabled = false;
                        }
                    }
                    else
                        Response.Redirect("login.aspx");
                }

                catch (Exception)
                {
                    Response.Redirect("login.aspx");
                }
            }
            else
            {
                resetDisplayMsg();
            }
        }

        private void loadDropBoxOnPageLoad()
        {
            obj = new ViewSub_Contractor_Controller();
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

        private void PopulateSubContractor()
        {
            try
            {
               // resetDisplayMsg();
                obj = new ViewSub_Contractor_Controller();
                dt = new DataTable();
                dt = obj.populateSubContractorGridview(int.Parse(Session["userid"].ToString()));
                if (dt != null)
                {
                    dt.Columns.Add("Status1", typeof(string)); // added column of age.
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (dt.Rows[i]["Status"] + string.Empty == "1")
                            dt.Rows[i]["Status1"] = "Active";
                        else
                            dt.Rows[i]["Status1"] = "Disabled";
                    }
                    dtgridview_SubContractor.DataSource = dt;
                    dtgridview_SubContractor.DataBind();
                }
                else
                    showErrorMessage(obj.ErrorString, false);
            }
            catch (Exception ex)
            {
                showErrorMessage("Unable to load companies: Error= ", false);
            }
        }

        private void resetDisplayMsg()
        {
            successMsg.Style.Add("display", "none");
            errorMsg.Style.Add("display", "none");
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

        protected void btnUpdateSubContractorDetails_Click(object sender, EventArgs e)
        {
            try
            {
                Company objCom = new Company();
                Address objAdd1 = new Address();
                Address objAdd2 = new Address();
                obj = new ViewSub_Contractor_Controller();
                objCom.companyName = txtbox_CompanyName.Text;
                objCom.company_email = txtbox_CompanyEmail.Text;
   
                objCom.companyType_id = int.Parse(dp_CompanyType.SelectedValue);
                objCom.Mobile = TextBox_Mobile.Text;
                objCom.Landline = TextBox_landline.Text;
                objCom.ABN = txtbox_ABN.Text;
                //Address 1
                objAdd1.StreetAddress = txtbox_Address1Street.Text;
                objAdd1.Postcode = txtbox_Address1Postcode.Text;
                objAdd1.State = txtbox_Address1State.Text;
                objAdd1.Suburb = txtbox_Address1Suburb.Text;
                //Address 2
                objAdd2.StreetAddress = txtbox_Address2Street.Text;
                objAdd2.Postcode = txtbox_Address2Postcode.Text;
                objAdd2.State = txtbox_Address2State.Text;
                objAdd2.Suburb = txtbox_Address2Suburb.Text;

                if (obj.UpdateCompanyProfile(objCom, int.Parse(txtbox_CompanyID.Text)) == true)
                {
                    if (TextBox_addressID1.Text != "") 
                    {
                        if (obj.UpdateCompanyAddress(objAdd1, int.Parse(TextBox_addressID1.Text)) == true) // Update Address 1
                        {
                            if (TextBox_addressID2.Text != "")
                            {
                                if (obj.UpdateCompanyAddress(objAdd2, int.Parse(TextBox_addressID2.Text)) == true) // Address 2
                                {
                                    showErrorMessage("Updated Successfully", true);
                                }
                            }
                            if (TextBox_addressID2.Text == "" && txtbox_Address2Street.Text != "")
                            {
                                if (obj.insertCompanyAddress(int.Parse(txtbox_CompanyID.Text), objAdd2) == true)
                                    showErrorMessage("Updated Successfully", true);
                                else
                                    showErrorMessage(obj.ErrorString, false);
                            }
                            showErrorMessage("Updated Successfully", true);
                        }
                        else
                            showErrorMessage("Address was not Updated: " + obj.ErrorString, false);
                    }
                    else
                    {
                        // if No address exist
                        if (obj.insertCompanyAddress(int.Parse(txtbox_CompanyID.Text), objAdd1) == true)
                        {
                            if (TextBox_addressID2.Text != "")
                            {
                                if (obj.UpdateCompanyAddress(objAdd2, int.Parse(TextBox_addressID2.Text)) == true)
                                {
                                    showErrorMessage("Updated Successfully", true);
                                }
                            }
                            if (TextBox_addressID2.Text == "" && txtbox_Address2Street.Text != "")
                            {
                                if (obj.insertCompanyAddress(int.Parse(txtbox_CompanyID.Text), objAdd2) == true)
                                    showErrorMessage("Updated Successfully", true);
                                else
                                    showErrorMessage(obj.ErrorString, false);
                            }
                        }
                        else
                            showErrorMessage(obj.ErrorString, false);
                    }
                }
                else
                    showErrorMessage("Unable to update Sub-Contractor Details", false);

                showErrorMessage("Updated Successfully", true);
                PopulateSubContractor();
            }
            catch (Exception ex)
            {
                showErrorMessage(ex.Message + " Please contact administrator.", false);
            }
        }

        protected void dtgridview_SubContractor_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                dt = new DataTable();
                obj = new ViewSub_Contractor_Controller();
              
                company_type.Add("Construction", 0);
                company_type.Add("Hospitality", 1);
                // Get the currently selected row using the SelectedRow property.
                GridViewRow row = dtgridview_SubContractor.SelectedRow;

                //MessageLabel.Text = "Editing CompanyID : " + row.Cells[1].Text + ".";
                txtbox_UserId.Text = row.Cells[2].Text;         // load User ID
                txtbox_UserId.Enabled = false;
                txtbox_CompanyID.Text = row.Cells[1].Text; // load Company Id
                txtbox_CompanyID.Enabled = false;
                loadAddressTxtboxes(Int32.Parse(row.Cells[1].Text));  // load address by company id
                txtbox_CompanyName.Text = row.Cells[3].Text.Replace("&amp;", "&").Replace("&nbsp;", "");    // Load COmpany Name
                txtbox_CompanyEmail.Text = row.Cells[4].Text;       // load Company EMail
                dp_CompanyAccountStatus.SelectedIndex = Int32.Parse(row.Cells[6].Text); // load Account Status
                txtbox_ABN.Text = row.Cells[8].Text.Replace("&nbsp;", "");

                if (company_type.ContainsKey(row.Cells[5].Text)) // select the type of Sub-Contractor
                {
                    dp_CompanyType.SelectedIndex = company_type[row.Cells[5].Text];
                }

                dt = obj.phoneNumberOfCompany(int.Parse(row.Cells[1].Text));
                if (dt == null)
                {
                    showErrorMessage("Mobile Number error: " + obj.ErrorString, false);
                }
                else
                {
                    TextBox_Mobile.Text = dt.Rows[0]["MobileNumber"].ToString();
                    TextBox_landline.Text = dt.Rows[0]["LandlineNumber"].ToString();
                }

                btnUpdateSubContractorDetails.Enabled = true;
                btnUpdateSubContractorDetails.Focus();
            }
            catch (Exception ex)
            {
                showErrorMessage(" Please contact administrator. Error :"+ex.Message, false);
            }
        }

        protected void dtgridview_SubContractor_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            try
            {
                GridViewRow row = dtgridview_SubContractor.Rows[e.NewSelectedIndex];
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

        private void loadAddressTxtboxes(int id)
        {
            try
            {
                obj = new ViewSub_Contractor_Controller();
                dt = new DataTable();
                dt = obj.loadAddress(id);
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
                    showErrorMessage(obj.ErrorString, false);
            }
            catch (Exception ex)
            {
                showErrorMessage(ex.Message, false);
            }
        }
    }
}