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
                            listEmployees.Enabled = false;
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
               textbox_activityID.Text= row.Cells[1].Text;

                for(int i=0;i<listEmployees.Items.Count;i++)
                {
                    string[] temp = listEmployees.Items[i].Text.Split('-');
                    if ( temp[1].Trim() == row.Cells[2].Text)
                    {
                        listEmployees.Items[i].Selected = true;
                    }
                }
                string[] tempUrl = row.Cells[9].Text.Split(',');
                foreach (ListItem item in cbFormsList.Items)
                {
                    for (int i = 0; i < tempUrl.Length; i++)
                    {
                        if (item.Value == tempUrl[i])
                        {
                            item.Selected = true;
                        }
                    }
                    
                }

                // listEmployees.SelectedIndex = listEmployees.FindControl(row.Cells[2].Text);
                txtbox_ActivityName.Text = row.Cells[3].Text;
                TextBox_site.Text = row.Cells[4].Text;
               dp_ActivityType.SelectedValue = row.Cells[5].Text;
                TextBox_Description.Text = row.Cells[6].Text;
                TextBox_startDate.Text = row.Cells[7].Text;
                btnUpdateActivity.Enabled = true;
                listEmployees.Focus();
                
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
                listEmployees.Items.Clear();
               
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
                        _value = dt.Rows[i]["UserId"].ToString();//+" - "+ dt.Rows[i]["EmployeeId"].ToString();
                        listEmployees.Items.Add(new ListItem() { Text = _text, Value = _value });
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
               
                objAct.activity_Name = txtbox_ActivityName.Text;
                objAct.activity_Location = TextBox_site.Text;
                objAct.activity_Type = dp_ActivityType.SelectedValue;
                objAct.activity_Description = TextBox_Description.Text;
                objAct.activity_Status = textbox_Status.Text;
                objAct.StartDate = TextBox_startDate.Text;
                string formsArrayURL = "";
                foreach (ListItem item in cbFormsList.Items)
                {
                    if (item.Selected)
                    {
                        formsArrayURL += item.Value + ",";
                    }
                }

                objAct.FormsURL = formsArrayURL.TrimEnd(','); ;
                for (int i = 0; i < listEmployees.Items.Count; i++)
                {

                    if (listEmployees.Items[i].Selected)
                    {
                        if (objView.UpdateActivityByCompany(objAct, int.Parse(textbox_activityID.Text), int.Parse(listEmployees.Items[i].Value)))
                        {
                            showErrorMessage("Updated.", true);
                            loadActivitiesCreatedByCompany();
                            clearforms();
                        }

                        else
                            showErrorMessage(objView.ErrorString, false);
                    }
                }

               

            }
            catch (Exception ex)
            {
                showErrorMessage(ex.Message, false);
            }
        }

        private void clearforms()
        {
            textbox_activityID.Text = "";
            TextBox_Description.Text = "";
            TextBox_site.Text = "";
            dp_ActivityType.SelectedIndex = -1;
            textbox_Status.Text = "";
            TextBox_startDate.Text = "";
            txtbox_ActivityName.Text = "";
            foreach (ListItem item in cbFormsList.Items)
            {
                item.Selected = false;
            }

            listEmployees.ClearSelection();

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

        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string item = e.Row.Cells[3].Text;
                foreach (Button button in e.Row.Cells[10].Controls.OfType<Button>())
                {
                    if (button.CommandName == "Delete")
                    {
                        button.Attributes["onclick"] = "if(!confirm('Do you want to delete " + item + "?')){ return false; };";
                    }
                }
            }
        }
        protected void OnRowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            objView = new viewActivity_Controller();
            GridViewRow row = dtgridview_viewActivity.Rows[e.RowIndex];

            int activityID = int.Parse(row.Cells[1].Text);

            // delete here
            if (objView.deleteCompanyCreatedActivity(activityID))
                showErrorMessage("Activity deleted.", true);
            else
                showErrorMessage(objView.ErrorString, false);

            
            loadActivitiesCreatedByCompany();
        }
    }
}