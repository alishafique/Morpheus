using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Controller;

namespace Seguro.Accounts.UserControls
{
    public partial class compnaySideMenuControl : System.Web.UI.UserControl
    {
        frmActivateDeActivatePlugins_Controller obj;
        DataTable dt;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["UserTypeID"].ToString() == "2")
                {
                    showHide();
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("login.aspx");
            }
            
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddEmployeeAccount.aspx");
        }

        protected void LinkButton_ViewEmployees_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewEmployeeList.aspx");
        }

        protected void LinkButton_CreateActivity_Click(object sender, EventArgs e)
        {
            Response.Redirect("createActivity.aspx");
        }

        protected void LinkButton_ViewActivities_Click(object sender, EventArgs e)
        {
            Response.Redirect("viewActivity.aspx");
        }

        private void showHide()
        {
            try
            {
                obj = new frmActivateDeActivatePlugins_Controller();
                dt = new DataTable();
                dt = obj.LoadCompanyPlugins(int.Parse(Session["userid"].ToString()));
                if(dt != null)
                {
                    if (dt.Rows[0]["subContractor"].ToString().ToUpper() == "FALSE")
                        SubContractorShowhide.Style.Add("display", "none");
                    else
                        SubContractorShowhide.Style.Add("display", "block");

                    if (dt.Rows[0]["activity"].ToString().ToUpper() == "FALSE")
                        ActivityPlugin.Style.Add("display","none");
                    else
                        ActivityPlugin.Style.Add("display", "block");

                    if (dt.Rows[0]["incident"].ToString().ToUpper() == "FALSE")
                        IncidentPlugin.Style.Add("display", "none");
                    else
                        IncidentPlugin.Style.Add("display", "block");

                    if (dt.Rows[0]["forms"].ToString().ToUpper() == "FALSE")
                        FormBuilderPlugin.Style.Add("display", "none");
                    else
                        FormBuilderPlugin.Style.Add("display", "block");

                    if (dt.Rows[0]["roster"].ToString().ToUpper() == "FALSE")
                        RosterPlugin.Style.Add("display", "none");
                    else
                        RosterPlugin.Style.Add("display", "block");
                }
            }
            catch(Exception ex)
            {
                Response.Redirect("login.aspx");
            }
        }
    }
}