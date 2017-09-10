using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Morpheus.Accounts.UserControls
{
    public partial class compnaySideMenuControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddEmployeeAccount.aspx");
        }

        protected void LinkButton_ViewEmployees_Click(object sender, EventArgs e)
        {
            Response.Redirect("viewEmployees.aspx");
        }

        protected void LinkButton_CreateActivity_Click(object sender, EventArgs e)
        {
            Response.Redirect("createActivity.aspx");
        }

        protected void LinkButton_ViewActivities_Click(object sender, EventArgs e)
        {
            Response.Redirect("viewActivity.aspx");
        }
    }
}