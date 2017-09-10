using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Morpheus.Accounts
{
    public partial class superAdmin : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                try
                {
                    if (Session["UserName"].ToString() != "")
                    {
                        lblUserName.Text = Session["UserName"].ToString();
                        if (Session["UserTypeID"].ToString() == "1")
                        {
                            dashboardmenu1.Visible = true;
                            companySideMenu1.Visible = false;
                            employeeDashMenu1.Visible = false;
                        }
                        else if (Session["UserTypeID"].ToString() == "2")
                        {
                            dashboardmenu1.Visible = false;
                            companySideMenu1.Visible = true;
                            employeeDashMenu1.Visible = false;
                        }
                        else if (Session["UserTypeID"].ToString() == "3")
                        {
                            dashboardmenu1.Visible = false;
                            companySideMenu1.Visible = false;
                            employeeDashMenu1.Visible = true;
                        }
                    }
                    else
                    {
                        Response.Redirect("login.aspx");
                    }
                }
                catch
                {
                    Response.Redirect("login.aspx");
                }
            }
        }
    }
}