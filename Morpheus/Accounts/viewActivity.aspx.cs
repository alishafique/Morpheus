using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
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
                        if (Session["UserTypeID"].ToString() == "2")
                        {
                            loadActivitiesCreatedByCompany();
                            btnUpdateActivity.Enabled = false;
                            listEmployees.Enabled = false;
                            loadEmployees();
                            ViewDetail.Visible = false;
                            editActivity.Visible = false;
                        }
                        else if(Session["UserTypeID"].ToString() == "4")
                        {
                            loadActivitiesCreatedByCompany();
                            btnUpdateActivity.Enabled = false;
                            listEmployees.Enabled = false;
                        }
                        else
                            Response.Redirect("login.aspx");
                    }
                    else
                        Response.Redirect("login.aspx");
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
                    ViewState["dtActivity"] = dt;
                }
                else
                    showErrorMessage(objView.ErrorString, false);
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
                ViewDetail.Visible = false;
                editActivity.Visible = true;
                dt = new DataTable();
                dt = (DataTable)ViewState["dtActivity"];
                GridViewRow row = dtgridview_viewActivity.SelectedRow;
                textbox_activityID.Text = row.Cells[1].Text;

                foreach (DataRow dr in dt.Rows)
                {
                    if (textbox_activityID.Text == dr["ActivityID"].ToString())
                    {
                        for (int i = 0; i < listEmployees.Items.Count; i++)
                        {
                            string[] temp = listEmployees.Items[i].Text.Split('-');
                            if (temp[1].Trim() == dr["email"].ToString())
                                listEmployees.Items[i].Selected = true;
                        }

                        string[] tempUrl = dr["formsAttached"].ToString().Split(',');
                        foreach (ListItem item in cbFormsList.Items)
                        {
                            for (int i = 0; i < tempUrl.Length; i++)
                            {
                                if (item.Value == tempUrl[i])
                                    item.Selected = true;
                            }
                        }

                        txtbox_ActivityName.Text = dr["Activity_Name"].ToString();
                        TextBox_site.Text = dr["Activity_Location"].ToString();
                        dp_ActivityType.SelectedValue = dr["Activity_Type"].ToString();
                        TextBox_Description.Text = dr["Activity_Description"].ToString().Trim().Replace("&nbsp;", "");
                        TextBox_startDate.Text = DateTime.Parse(dr["startDate"].ToString()).ToShortDateString();
                        textbox_Status.Text = dr["Activity_Status"].ToString().Trim();
                        btnUpdateActivity.Enabled = true;
                        btnUpdateActivity.Focus();
                    }
                }
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
                    showErrorMessage(objView.ErrorString, false);
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
                objAct.activity_Description = TextBox_Description.Text.Trim();
                objAct.activity_Status = textbox_Status.Text.Trim();
                objAct.StartDate = DateTime.Parse(TextBox_startDate.Text);
                objAct.activity_Status = textbox_Status.Text;
                string formsArrayURL = "";
                foreach (ListItem item in cbFormsList.Items)
                {
                    if (item.Selected)
                        formsArrayURL += item.Value + ",";
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
                LinkButton lbDelete = (LinkButton)e.Row.FindControl("lbDelete");
                lbDelete.Attributes.Add("onclick", "return confirm('Are you sure to delete?');");
            }
        }
        protected void OnRowDeleting(object sender, GridViewDeleteEventArgs e)
        {
        }

        protected void dtgridview_viewActivity_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.ToString().ToUpper() == "DELETE")
                {
                    objView = new viewActivity_Controller();
                    int activityID = int.Parse(e.CommandArgument.ToString());
                    // delete here
                    if (objView.deleteCompanyCreatedActivity(activityID))
                        showErrorMessage("Activity deleted.", true);
                    else
                        showErrorMessage(objView.ErrorString, false);

                    loadActivitiesCreatedByCompany();
                }
                if (e.CommandName.ToString().ToUpper() == "VIEW")
                {
                    ViewDetail.Visible = true;
                    editActivity.Visible = false;
                    int activityID = int.Parse(e.CommandArgument.ToString());
                    objView = new viewActivity_Controller();
                    dt = new DataTable();
                    dt = objView.ViewActivityByActId(activityID);
                    if(dt!=null)
                    {
                        if(dt.Rows.Count > 0)
                        {
                            lblAName.Text = dt.Rows[0]["Activity_Name"].ToString();
                            lblActivityID.Text = activityID.ToString().Trim();
                            lblSite.Text = dt.Rows[0]["Activity_Location"].ToString();
                            lblType.Text = dt.Rows[0]["Activity_Type"].ToString();
                            lblDescription.Text = dt.Rows[0]["Activity_Description"].ToString();
                            lblAssignedToEmlpoyees.Text = dt.Rows[0]["email"].ToString();
                            lblStatus.Text = dt.Rows[0]["Activity_Status"].ToString(); 
                            lblStartDate.Text = DateTime.Parse(dt.Rows[0]["startDate"].ToString()).ToShortDateString();
                            lblForms.Text = dt.Rows[0]["formsAttached"].ToString();
                            lblStarted.Text = dt.Rows[0]["ActivityStartedDate"].ToString();
                            lblEnddateTime.Text= dt.Rows[0]["endDateTime"].ToString();
                            lblStartLocation.Text = dt.Rows[0]["CurrentLocation"].ToString();
                            lblFinishedLoc.Text = dt.Rows[0]["EndCurrentLocation"].ToString();
                            lblStartLocation.Focus();

                            if (lblStatus.Text == "FINISHED")
                                lblStatus.ForeColor = System.Drawing.Color.Green;
                            else if (lblStatus.Text == "Not-Started")
                                lblStatus.ForeColor = System.Drawing.Color.Orange;
                            else if (lblStatus.Text == "Started")
                                lblStatus.ForeColor = System.Drawing.Color.Green;
                        }

                        Popup(true);
                    }
                    else
                    {
                        showErrorMessage(objView.ErrorString, false);
                    }
                }
            }
            catch (Exception ex)
            {
                showErrorMessage(ex.Message, false);
            }
        }
        void Popup(bool isDisplay)
        {
            StringBuilder builder = new StringBuilder();
            if (isDisplay)
            {
                builder.Append("<script language=JavaScript> ShowPopup(); </script>\n");
                Page.ClientScript.RegisterStartupScript(this.GetType(), "ShowPopup", builder.ToString());
            }
            else
            {
                builder.Append("<script language=JavaScript> HidePopup(); </script>\n");
                Page.ClientScript.RegisterStartupScript(this.GetType(), "HidePopup", builder.ToString());
            }
        }
    }
}
