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
    public partial class viewEmployeeActivity : System.Web.UI.Page
    {
        DataTable dt;
        viewEmployeeActivity_Controller obj;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                try
                {
                    if (Session["UserName"].ToString() != "")
                    {
                       if (Session["UserTypeID"].ToString() == "3")
                        {
                            loadEmployeesActivity(int.Parse(Session["userid"].ToString()));
                            btnStart.Enabled = false;
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

        private void loadEmployeesActivity(int userID)
        {
            try
            {
                dt = new DataTable();
                obj = new viewEmployeeActivity_Controller();
                dt = obj.viewEmployeeActivities(userID);
                if (dt != null)
                {
                    dtViewEmployeeActivity.DataSource = dt;
                    dtViewEmployeeActivity.DataBind();
                }
                else
                {
                    showErrorMessage(obj.ErrorString, false);
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

        protected void dtViewEmployeeActivity_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GridViewRow row = dtViewEmployeeActivity.SelectedRow;
                lblActivityID.Text = row.Cells[1].Text;
                lblCreatedByCompanyID.Text = row.Cells[2].Text;
                lblActivity_Name.Text = row.Cells[3].Text;
                lblActivity_Location.Text = row.Cells[4].Text; 
                lblActivity_Type.Text= row.Cells[5].Text;
                lblActivity_Description.Text= row.Cells[6].Text;
                lblActivity_Status.Text= row.Cells[7].Text;
                lblStartDate.Text= row.Cells[8].Text;
                btnStart.Enabled = true;
                btnStart.Focus();

            }
            catch (Exception ex)
            {
                showErrorMessage(ex.Message, false);
            }
        }

        protected void dtViewEmployeeActivity_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {

        }

        protected void btnStart_Click(object sender, EventArgs e)
        {
            
        }
    }
}