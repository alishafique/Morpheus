using Controller;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;

namespace Seguro.Accounts
{
    public partial class AddEmployeeAccount : System.Web.UI.Page
    {
        DataTable dt;
        createEmployeeAccount_Controller objCreateEmployeeC;
        Employee objEmp;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAddCompany_Click(object sender, EventArgs e)
        {
            int usID = 0;
            try
            {
                if (chechUserName(txtbox_EmployeeEmail.Text) == false) // Make sure This Email is not taken
                {
                    if (IsValidEmail(txtbox_EmployeeEmail.Text) == true)
                    {
                        objEmp = new Employee();
                        objCreateEmployeeC = new createEmployeeAccount_Controller();
                        objEmp.Username = txtbox_EmployeeEmail.Text;
                        objEmp.Created_dateTime = DateTime.Now;

                        objEmp.Emp_name = txtbox_EmpName.Text;
                        objEmp.Date_of_birth = DateTime.ParseExact(txtbox_dateTimePicker_DOB.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                        objEmp.address = txtbox_Address1Street.Text;
                        objEmp.Suburb = txtbox_Address1Suburb.Text;
                        objEmp.State = txtbox_Address1State.Text;
                        objEmp.Postcode = txtbox_Address1Postcode.Text;
                        objEmp.Mobile = TextBox_Mobile.Text;
                        objEmp.License = TextBox_License.Text;
                        objEmp.A_BN = TextBox_ABN.Text;
                        objEmp.T_FN = TextBox_TFN.Text;


                        int createdByID = int.Parse(Session["userid"].ToString());
                        usID = objCreateEmployeeC.createUserAccountUserTable(3, txtbox_CompanyPassword.Text, objEmp);

                        if (usID != 0)
                        {
                            objEmp.UserID = usID; // User Id
                            if (objCreateEmployeeC.createEmployeeProfile(objEmp, createdByID) == true)
                            {
                                if (objCreateEmployeeC.sendNotification(objEmp.Username, objEmp.Emp_name, txtbox_CompanyPassword.Text, objEmp.Created_dateTime) == true)
                                {
                                    showErrorMessage("Successfully Created Employee Account. And notification is sent to Your Employee", true);
                                    clearForm();
                                }
                                else
                                    showErrorMessage(objCreateEmployeeC.ErrorString, false);                   
                            }
                            else
                            {
                                objCreateEmployeeC.deleteUserName(createdByID);
                                showErrorMessage(objCreateEmployeeC.ErrorString, false);
                            }
                        }
                        else
                        {
                            showErrorMessage(objCreateEmployeeC.ErrorString, false);
                        }
                    }
                }
                else
                {
                    showErrorMessage("Please select another UserName:", false);
                    txtbox_EmployeeEmail.Focus();
                }
            }
            catch (Exception ex)
            {
                showErrorMessage(ex.Message, false);
            }
        }

        protected void TextValidate(object source, ServerValidateEventArgs e)
        {
            e.IsValid = (e.Value.Length >= 6 && e.Value.Length <= 15);
        }
        public bool chechUserName(string username)
        {
            objCreateEmployeeC = new createEmployeeAccount_Controller();
            if (objCreateEmployeeC.checkUserName(username.Trim()) == true)
                return true;
            else
            {
                //showErrorMessage(objCreateEmployeeC.ErrorString,false);
                return false;
            }

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
                showErrorMessage("Please enter Valid Email address: ", false);
                txtbox_EmployeeEmail.Focus();
                return false;
            }
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

        private void clearForm()
        {
            txtbox_Address1Postcode.Text = "";
            txtbox_Address1State.Text = "";
            txtbox_Address1Street.Text = "";
            txtbox_Address1Suburb.Text = "";
            txtbox_CompanyPassword.Text = "";
            txtbox_CompanyRePassword.Text = "";
            txtbox_dateTimePicker_DOB.Text = "";
            txtbox_EmployeeEmail.Text = "";
            txtbox_EmpName.Text = "";
            TextBox_ABN.Text = "";
            TextBox_TFN.Text = "";
            TextBox_Mobile.Text = "";
            TextBox_License.Text = "";
        }

        [WebMethod]
        public static bool UserNameChecker(string newUserName)
        {
            AddEmployeeAccount objDb = new AddEmployeeAccount();
            if (newUserName == "")
                return true;
            if (objDb.chechUserName(newUserName) == true)
                return true;
            else
                return false;
        }
    }
}