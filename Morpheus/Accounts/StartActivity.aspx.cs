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
    public partial class StartActivity : System.Web.UI.Page
    {
        StartActivity_Controller obj;
        DataTable dt;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (Session["UserTypeID"].ToString() == "3")
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "getLocation()", true);
                        LoadActivity();
                        btnStart.Enabled = false;
                       if(Session["SuccessMsg"] != null)
                        {
                            bool result = obj.StartActivity(int.Parse(Session["ActivityId"].ToString()), "Completed", "form/StartCardQuestionair.aspx", "Started", Session["CLoc"].ToString());
                            if (result)
                            {
                                Session["SuccessMsg"] = null;
                                LoadActivity();
                                btnStart.Enabled = false;
                                showErrorMessage("Job Started.", true);
                            }
                            else
                                showErrorMessage(obj.ErrorString, false);
                        }
                    }
                    else
                        Response.Redirect("login.aspx");
                }
            }
            catch(Exception ex)
            {
                Response.Redirect("login.aspx");
            }
        }

        protected void btnStart_Click(object sender, EventArgs e)
        {
            try
            {
                Session["ActivityId"] = lblActivityID.Text;
                Response.Redirect("forms/StartCardQuestionair.aspx");
            }
            catch(Exception ex)
            {
                showErrorMessage(ex.Message, false);
            }
        }

        private void LoadActivity()
        {
            try
            {
                obj = new StartActivity_Controller();
                dt = obj.LoadActivityOfToday(int.Parse(Session["userid"].ToString()));
                if(dt!=null)
                {
                    dgvLoadTodaysActivity.DataSource = dt;
                    dgvLoadTodaysActivity.DataBind();
                    ViewState["ActivityOfDays"] = dt;
                }
                else
                {
                    showErrorMessage(obj.ErrorString, false);
                }
            }
            catch(Exception ex)
            {
                showErrorMessage(ex.Message,false);
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

        protected void dgvLoadTodaysActivity_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.ToString().ToUpper() == "START")
                {
                    Session["CLoc"] = currentlocation.Text;
                    lblActivityID.Text = e.CommandArgument.ToString();
                    dt = new DataTable();
                    dt = (DataTable)ViewState["ActivityOfDays"];
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (lblActivityID.Text == dr["ActivityID"].ToString())
                        {
                            lblCreatedByCompanyID.Text = dr["CreatedByCompanyID"].ToString();
                            lblActivity_Name.Text = dr["Activity_Name"].ToString();
                            lblActivity_Location.Text = dr["Activity_Location"].ToString();
                            lblActivity_Type.Text = dr["Activity_Type"].ToString();
                            lblActivity_Description.Text = dr["Activity_Description"].ToString();
                            lblActivity_Status.Text = dr["Activity_Status"].ToString();
                            lblStartDate.Text = DateTime.Parse(dr["startDate"].ToString()).ToShortDateString();
                            btnStart.Enabled = true;
                            btnStart.Focus();
                        }
                    }

                    Popup(true);
                }
                if (e.CommandName.ToString().ToUpper() == "END")
                {
                    lblActivityID.Text = e.CommandArgument.ToString();
                    obj = new StartActivity_Controller();
                    if (obj.EndActivity(int.Parse(lblActivityID.Text), "FINISHED"))
                    {
                        LoadActivity();
                        showErrorMessage("Job Finished Successfully.", true);
                    }
                    else
                        showErrorMessage(obj.ErrorString, false);
                }
            }
            catch (Exception ex)
            {
                showErrorMessage(ex.Message, false);
            }
        }

        protected void dgvLoadTodaysActivity_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            Button btnstart = (Button)e.Row.FindControl("btnStart");
            Button btnEnd = (Button)e.Row.FindControl("btnEnd");
            if (e.Row.Cells[3].Text.ToUpper() == "STARTED")
            {
                btnstart.Enabled = false;
                btnEnd.Enabled = true;
            }
            if (e.Row.Cells[3].Text.ToUpper() == "NOT-STARTED")
            {
                btnstart.Enabled = true;
                btnEnd.Enabled = false;
            }
            if(e.Row.Cells[3].Text.ToUpper() == "FINISHED")
            {
                btnstart.Enabled = false;
                btnEnd.Enabled = false;
            }
        }

        protected void dgvLoadTodaysActivity_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

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