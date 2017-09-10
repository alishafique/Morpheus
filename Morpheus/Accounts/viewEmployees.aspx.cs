﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Controller;
using System.Data;
using System.Globalization;
using System.Windows.Forms;
using System.Drawing;


namespace Morpheus.Accounts
{
    public partial class viewEmployees : System.Web.UI.Page
    {
        viewEmployees_Controller objEmp;
        DataTable dt;
        Employee objEmpData;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                try
                {
                    if (Session["UserName"].ToString() != "")
                    {
                        lblUserName.Text = Session["UserName"].ToString();
                        if (Session["UserTypeID"].ToString() == "2")
                        {
                            loadEmployee(int.Parse(Session["userid"].ToString()));
                            dashboardmenu1.Visible = false;
                            companySideMenu1.Visible = true;
                            employeeDashMenu1.Visible = false;
                            btnUpdateEmployeeProfile.Enabled = false;
                        }
                        if(Session["UserTypeID"].ToString() == "3")
                        {
                            loadEmployeeProfileByEmployee(int.Parse(Session["userid"].ToString()));
                            dashboardmenu1.Visible = false;
                            companySideMenu1.Visible = false;
                            employeeDashMenu1.Visible = true;
                            hideGrid.Visible = false;
                            btnUpdateEmployeeProfile.Enabled = true;
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

        protected void dtgridview_Employees_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dtgridview_Employees.PageIndex = e.NewPageIndex;
            loadEmployee(int.Parse(Session["userid"].ToString()));
        }

        protected void dtgridview_Employees_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                objEmp = new viewEmployees_Controller();
                dt = new DataTable();
                GridViewRow row = dtgridview_Employees.SelectedRow;
                TextBox_EmployeeId.Text= row.Cells[1].Text.Replace("&nbsp;", "");
                TextBox_userId.Text = row.Cells[2].Text.Replace("&nbsp;", "");
                TextBox_EmployeeName.Text = row.Cells[3].Text.Replace("&nbsp;", "");
                TextBox1_EmployeeEmail.Text = row.Cells[4].Text.Replace("&nbsp;", "");
                txtbox_dateTimePicker_DOB.Text = row.Cells[6].Text;
                TextBox_ABN.Text = row.Cells[7].Text.Replace("&nbsp;","");
                TextBox_TFN.Text = row.Cells[8].Text.Replace("&nbsp;", "");
                DropDownList_activeStatus.SelectedValue = row.Cells[9].Text.Replace("&nbsp;", "");
                dt = objEmp.loadAddressByEmployeeId(int.Parse(TextBox_EmployeeId.Text));

                if(dt != null)
                {
                    TextBox_StreetName.Text = dt.Rows[0]["Address"].ToString();
                    TextBox_Suburb.Text = dt.Rows[0]["suburb"].ToString();
                    TextBox_State.Text = dt.Rows[0]["state"].ToString();
                    TextBox_Postcode.Text= dt.Rows[0]["postcode"].ToString();
                    TextBox_License.Text = dt.Rows[0]["license"].ToString();
                    TextBox_Mobile.Text = dt.Rows[0]["mobile"].ToString();
                }
                else
                {
                    showErrorMessage("Unable to load Address with following error: "+objEmp.ErrorString, false);
                }
                
                btnUpdateEmployeeProfile.Enabled = true;
                btnUpdateEmployeeProfile.Focus();
            }
            catch(Exception ex)
            {
                showErrorMessage(ex.Message, false);
                clearTextBox();
                TextBox_EmployeeId.Text = "";
            }

        }

        protected void dtgridview_Employees_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            try
            {

                GridViewRow row = dtgridview_Employees.Rows[e.NewSelectedIndex];
                if (row.Cells[1].Text == "ANATR")
                {
                    e.Cancel = true;
                    showErrorMessage("You cannot select " + row.Cells[2].Text + ".", false);
                }
            }
            catch (Exception ex)
            {
                showErrorMessage(ex.Message + " Please contact administrator.", false);
            }

        }

        private string convertDate(string i)
        {
            //string i = row["date_of_birth"].ToString();
            DateTime dtDate = Convert.ToDateTime(i);
            string s = dtDate.Day + "/" + dtDate.Month + "/" + dtDate.Year;
            return s;
        }

        private void loadEmployeeProfileByEmployee(int empID)
        {
            try
            {
                dt = new DataTable();
                objEmp = new viewEmployees_Controller();
                dt = objEmp.employeeProfileByEmployeeID(empID);
                if (dt != null && dt.Rows.Count != 0)
                {
                    TextBox_EmployeeId.Text = dt.Rows[0]["EmployeeId"].ToString();
                    TextBox_userId.Text = dt.Rows[0]["UserId"].ToString();
                    TextBox_EmployeeName.Text = dt.Rows[0]["emp_name"].ToString();
                    TextBox1_EmployeeEmail.Text = dt.Rows[0]["email"].ToString();

                    txtbox_dateTimePicker_DOB.Text = convertDate(dt.Rows[0]["date_of_birth"].ToString());


                    TextBox_ABN.Text = dt.Rows[0]["ABN"].ToString();
                    TextBox_TFN.Text = dt.Rows[0]["TFN"].ToString();
                    hideEmployee.Visible = false;
                    
                    TextBox_StreetName.Text = dt.Rows[0]["Address"].ToString();
                    TextBox_Suburb.Text = dt.Rows[0]["suburb"].ToString();
                    TextBox_State.Text = dt.Rows[0]["state"].ToString();
                    TextBox_Postcode.Text = dt.Rows[0]["postcode"].ToString();
                    TextBox_License.Text = dt.Rows[0]["license"].ToString();
                    TextBox_Mobile.Text = dt.Rows[0]["mobile"].ToString();

                }
                else
                {
                    showErrorMessage(objEmp.ErrorString, false);
                }
            }
            catch(Exception ex)
            {
                showErrorMessage(ex.Message, false);
            }

        }
        
        private void loadEmployee(int companyId)
        {
            try
            {
                dt = new DataTable();
                objEmp = new viewEmployees_Controller();
                dt = objEmp.viewEmployeeByCompany(companyId);
               
                if (dt != null)
                {
                    
                    dtgridview_Employees.DataSource = dt;
                    dtgridview_Employees.DataBind();
                }
                else
                {
                    showErrorMessage(objEmp.ErrorString, false);
                }
                
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

        protected void btnUpdateEmployeeProfile_Click(object sender, EventArgs e)
        {
            try
            {
                if (TextBox_EmployeeId.Text != "")
                {
                    objEmpData = new Employee();
                    objEmp = new viewEmployees_Controller();
                    objEmpData.Emp_name = TextBox_EmployeeName.Text;
                    objEmpData.Date_of_birth = DateTime.Parse(this.txtbox_dateTimePicker_DOB.Text);

                    objEmpData.address = TextBox_StreetName.Text;
                    objEmpData.Suburb = TextBox_Suburb.Text;
                    objEmpData.State = TextBox_State.Text;
                    objEmpData.Postcode = TextBox_Postcode.Text;
                    objEmpData.A_BN = TextBox_ABN.Text;
                    objEmpData.T_FN = TextBox_TFN.Text;
                    objEmpData.Mobile = TextBox_Mobile.Text;
                    objEmpData.License = TextBox_License.Text;
                    if (objEmp.UpdateEmployeeProfileByCompany(objEmpData, int.Parse(TextBox_EmployeeId.Text)) == true)
                    {
                        if (Session["UserTypeID"].ToString() != "3")
                        {
                            if (objEmp.updateStatusOfEmployeeByCompany(int.Parse(TextBox_userId.Text), DropDownList_activeStatus.SelectedIndex) == true)
                            {
                                showErrorMessage("Updated Employee profile", true);
                                loadEmployee(int.Parse(Session["userid"].ToString()));
                                clearTextBox();
                            }
                            else
                            {
                                showErrorMessage(objEmp.ErrorString, false);
                            }
                        }
                        else
                        {
                            showErrorMessage("Updated Employee profile", true);
                        }
                    }
                    else
                    {
                        showErrorMessage(objEmp.ErrorString, false);
                    }
                }
                else
                {
                    showErrorMessage("Please select employee to Update to its Profile!!!!", false);
                }

            }
            catch (Exception ex)
            {
                showErrorMessage(ex.Message, false);
            }
        }

        private void clearTextBox()
        {
            TextBox_EmployeeId.Text = "";
            TextBox1_EmployeeEmail.Text = "";
            TextBox_EmployeeName.Text = "";
            txtbox_dateTimePicker_DOB.Text = "";
            TextBox_StreetName.Text = "";
            TextBox_Suburb.Text = "";
            TextBox_Postcode.Text = "";
            TextBox_State.Text = "";
            TextBox_EmployeeId.Text = "";
            DropDownList_activeStatus.SelectedIndex = 0;
            TextBox_ABN.Text = "";
            TextBox_TFN.Text = "";
            TextBox_Mobile.Text = "";
            TextBox_License.Text = "";
            TextBox_userId.Text = "";
            btnUpdateEmployeeProfile.Enabled = false;
        }

        protected void dtgridview_Employees_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                //if ((MessageBox.Show("Are you sure, you want to Delete the Employee Record!!", "Attention", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)) == System.Windows.Forms.DialogResult.Yes)
                //{
                    objEmp = new viewEmployees_Controller();
                    GridViewRow row = (GridViewRow)dtgridview_Employees.Rows[e.RowIndex];
                    int userid = int.Parse(row.Cells[2].Text);
                    if (objEmp.deleteEmployeeByCompany(userid) == true)
                    {
                        showErrorMessage(row.Cells[3].Text + " deleted", true);
                        loadEmployee(int.Parse(Session["userid"].ToString()));
                    }
                    else
                    {
                        showErrorMessage(objEmp.ErrorString, false);
                    }
                //}
            }
            catch(Exception ex)
            {
                showErrorMessage(ex.Message, false);
            }

        }
    }
}