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
    public partial class frmViewMessages : System.Web.UI.Page
    {
        frmViewMessages_Controller obj;
        DataTable dt;
        protected void Page_Load(object sender, EventArgs e)
        {
                try
                {
                    if (Session["UserName"].ToString() != "")
                    {
                        if (Session["UserTypeID"].ToString() == "1")
                            LoadMessages();
                    }
                    else
                        Response.Redirect("login.aspx");
                }
                catch (Exception)
                {
                    Response.Redirect("login.aspx");
                }
        }


        private void LoadMessages()
        {
            try
            {
                obj = new frmViewMessages_Controller();
                dt = new DataTable();
                dt = obj.ViewContactUsMessages();
                if (dt != null)
                {
                    gridView_ContactUsMessages.DataSource = dt;
                    gridView_ContactUsMessages.DataBind();
                }
                else
                {
                    showErrorMessage(obj.ErrorString, false);
                }

            }
            catch (Exception ex)
            {
                showErrorMessage("Unable to load Messages: Error= "+ ex.Message, false);
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

        protected void gridViewContactUsMessages_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "ShowPopup")
            {
                LinkButton btndetails = (LinkButton)e.CommandSource;
                GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;
                txtbox_ID.Text = gridView_ContactUsMessages.DataKeys[gvrow.RowIndex].Value.ToString();
                // DataRow dr = dt.Select("CustomerID=" + GridViewData.DataKeys[gvrow.RowIndex].Value.ToString())[0];
                txtName.Text = HttpUtility.HtmlDecode(gvrow.Cells[2].Text);
                txtEmail.Text = HttpUtility.HtmlDecode(gvrow.Cells[3].Text);
                txtPhone.Text = HttpUtility.HtmlDecode(gvrow.Cells[4].Text);
                txtMessage.Text = HttpUtility.HtmlDecode(gvrow.Cells[5].Text);
                txtbox_DateTime.Text = HttpUtility.HtmlDecode(gvrow.Cells[6].Text);
                Popup(true);
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