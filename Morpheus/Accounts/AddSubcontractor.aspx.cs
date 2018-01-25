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
    public partial class AddSubcontractor : System.Web.UI.Page
    {
        DataTable dt;
        AddSubcontractor_Controller obj;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!this.IsPostBack)
                {
                    loadDropBoxOnPageLoad();
                    if (Session["UserTypeID"].ToString() != "2")
                    {
                        Response.Redirect("login.aspx");
                    }
                }
            }
            catch (Exception)
            {
                Response.Redirect("login.aspx");
            }
        }

        private void loadDropBoxOnPageLoad()
        {
            obj = new AddSubcontractor_Controller();
            dt = new DataTable();
            // Membership DropBox
            //dt = obj.loadMemberShipPlanes();
            //if (dt != null)
            //{
            //    Dp_MemberShipPlan.DataSource = dt;
            //    dt.Columns.Add("FullDesc", typeof(string), "membership_level + ' - ' + description");
            //    Dp_MemberShipPlan.DataTextField = "FullDesc";
            //    Dp_MemberShipPlan.DataValueField = "membership_id";
            //    Dp_MemberShipPlan.DataBind();
            //}
            //else
            //{
            //    showErrorMessage(obj.ErrorString, false);
            //}
            //CompanyType dropbox load from db
            dt = obj.LoadCompanyTypes();
            if (dt != null)
            {
                dp_CompanyType.DataSource = dt;
                dp_CompanyType.DataTextField = "type_name";
                dp_CompanyType.DataValueField = "company_Type_id";
                dp_CompanyType.DataBind();
            }
            else
            {
                showErrorMessage(obj.ErrorString, false);
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
        protected void TextValidate(object source, ServerValidateEventArgs e)
        {
            e.IsValid = (e.Value.Length >= 6 && e.Value.Length <= 15);
        }

        protected void btnAddSubContractor_Click(object sender, EventArgs e)
        {

        }
    }
}