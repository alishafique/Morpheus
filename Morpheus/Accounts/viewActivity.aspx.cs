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
    public partial class viewActivity : System.Web.UI.Page
    {
        DataTable dt;
        viewActivity_Controller objView;
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
                            dashboardmenu1.Visible = false;
                            companySideMenu1.Visible = true;
                            employeeDashMenu1.Visible = false;
                            loadActivitiesCreatedByCompany();
                            btnUpdateActivity.Enabled = false;
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


        private void loadActivitiesCreatedByCompany()
        {
            try
            {
                dt = new DataTable();
                objView = new viewActivity_Controller();
                dt = objView.viewActivitiesCreatedByCompany(int.Parse(Session["userid"].ToString()));
                if (dt != null)
                {
                    dtgridview_viewActivity.DataSource = dt;
                    dtgridview_viewActivity.DataBind();
                }
                else
                {
                    showErrorMessage(objView.ErrorString, false);
                }
            }
            catch(Exception ex)
            {
                showErrorMessage(ex.Message, false);
            }
        }


        protected void dtgridview_viewActivity_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dtgridview_viewActivity.PageIndex = e.NewPageIndex;
            loadActivitiesCreatedByCompany();
        }

        protected void dtgridview_viewActivity_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                loadEmployees();
                GridViewRow row = dtgridview_viewActivity.SelectedRow;
               textbox_activityID.Text= row.Cells[2].Text;
                textbox_createdBy.Text = "";
               
               Dp_AssignTo.SelectedValue = row.Cells[2].Text;
               
                txtbox_ActivityName.Text = row.Cells[3].Text;
                TextBox_site.Text = row.Cells[4].Text;
               dp_ActivityType.SelectedValue = row.Cells[5].Text;
                TextBox_Description.Text = row.Cells[6].Text;
                btnUpdateActivity.Enabled = true;
                
            }
            catch (Exception ex)
            {
                showErrorMessage(ex.Message, false);
            }
        }

        private void loadEmployees()
        {
            try
            {
                Dp_AssignTo.Items.Clear();
               
                dt = new DataTable();
                objView = new viewActivity_Controller();
                dt = objView.listEmployeesByCompany(int.Parse(Session["userid"].ToString()));
                if (dt != null)
                {
                    string _text = "";
                    string _value = "";
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        _text = dt.Rows[i]["emp_name"].ToString() + " - " + dt.Rows[i]["email"].ToString();
                        _value = dt.Rows[i]["UserId"].ToString();
                        Dp_AssignTo.Items.Add(new ListItem() { Text = _text, Value = _value });
                    }
                }
                else
                {
                    showErrorMessage(objView.ErrorString, false);
                }


            }
            catch (Exception ex)
            {
                showErrorMessage(ex.Message, false);
            }
        }

        protected void dtgridview_viewActivity_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            try
            {

                GridViewRow row = dtgridview_viewActivity.Rows[e.NewSelectedIndex];
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

        protected void btnUpdateActivity_Click(object sender, EventArgs e)
        {
            try
            {
                Activity objAct = new Activity();
                objView = new viewActivity_Controller();
                objAct.assigneduserID = int.Parse(Dp_AssignTo.SelectedValue);
                objAct.activity_Name = txtbox_ActivityName.Text;
                objAct.activity_Location = TextBox_site.Text;
                objAct.activity_Type = dp_ActivityType.SelectedValue;
                objAct.activity_Description = TextBox_Description.Text;
                objAct.activity_Status = textbox_Status.Text;

                objView.UpdateActivityByCompany(objAct, int.Parse(textbox_activityID.Text));



            }
            catch (Exception ex)
            {
                showErrorMessage(ex.Message, false);
            }
        }


        // show error messages
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