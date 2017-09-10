using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Morpheus.Accounts.UserControls
{
    public partial class rightTopMenu : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["UserTypeID"].ToString() == "1")
                {
                    LinkButton_profile.Visible = false;
                    LinkButton_EmployeeProfile.Visible = false;
                   // changePassword.Visible = true;
                    //AdminChangePassword.Visible = true;
                }
                if(Session["UserTypeID"].ToString() == "2")
                {
                    LinkButton_profile.Visible = true;
                    LinkButton_EmployeeProfile.Visible = false;
                   // changePassword.Visible = true;
                    //AdminChangePassword.Visible = false;
                }
                if (Session["UserTypeID"].ToString() == "3")
                {
                    LinkButton_profile.Visible = false;
                    LinkButton_EmployeeProfile.Visible = true;
                   // changePassword.Visible = true;
                    //changePassword.Visible = false;
                   // AdminChangePassword.Visible = false;
                }
            }
            catch (Exception)
            {
                Response.Redirect("~/Accounts/login.aspx", false);
            }
            
        }

        protected void btnLogOut_Click(object sender, EventArgs e)
        {
            Session["userid"] = null;
            Session["UserName"] = null;
            Session["UserTypeID"] = null;
            Response.Cache.SetNoStore();
            Session.Abandon();
            Response.Redirect("~/Accounts/login.aspx", false);
        }

        

        protected void LinkButton_Profile_Click(object sender, EventArgs e)
        {
            if (Session["UserTypeID"].ToString() == "2")
            {
                Response.Redirect("viewCompanyProfile.aspx");
            }
        }

        protected void LinkButton_EmployeeProfile_Click(object sender, EventArgs e)
        {
            if (Session["UserTypeID"].ToString() == "3")
            {
                Response.Redirect("viewEmployees.aspx");
            }
        }

        protected void changePassword_Click(object sender, EventArgs e)
        {
                Response.Redirect("changePassword.aspx");
        }

        //protected void AdminChangePassword_Click(object sender, EventArgs e)
        //{
        //    Response.Redirect("changePassword.aspx");
        //}

        //protected void EmployeeChangePassword_Click(object sender, EventArgs e)
        //{
        //    Response.Redirect("changePassword.aspx");
        //}
    }
}