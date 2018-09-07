using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Seguro
{
    public partial class defualt : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

            }
        }

        protected void btnDownApp_Click(object sender, EventArgs e)
        {
            try
            {
                string FilePath = Server.MapPath("~/Android/Segurov1.1.apk");
                Response.AppendHeader("content-disposition", "attachment; filename=" + Path.GetFileName(FilePath));
                Response.ContentType = "application/vnd.android.package-archive";
                Response.WriteFile(FilePath);
            }
            catch(Exception ex)
            {

            }
        }
    }
}