using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Seguro.Accounts.UserControls
{
    public partial class EmployeeSideMenu : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LinkButton_ReportIncident_Click(object sender, EventArgs e)
        {
            Response.Redirect("ReportIncident.aspx");
        }

        protected void LinkButton_ViewActivity_Click(object sender, EventArgs e)
        {
            Response.Redirect("viewEmployeeActivity.aspx");
        }
    }
}