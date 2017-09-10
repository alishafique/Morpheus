using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Morpheus.Accounts.UserControls
{
    public partial class SideNavigationMenu : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void lnkbtn_Addcompany_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddCompanyAccount.aspx");
        }
        protected void lnkBtn_VeiwCompany_Click(object sender, EventArgs e)
        {
            Response.Redirect("viewCompanies.aspx");
        }

        protected void lnkbtn_ReportIncident_Click(object sender, EventArgs e)
        {
            Response.Redirect("ReportIncident.aspx");
        }

        protected void lnkbtn_viewIncidentReports_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewIncidentReports.aspx");
        }

        protected void LinkButton_ActivateCompany_Click(object sender, EventArgs e)
        {
            Response.Redirect("ActivateDeactivateCompanyAccount.aspx");
        }
    }
}