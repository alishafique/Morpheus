using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Controller;

namespace Morpheus
{
    public partial class Home : System.Web.UI.Page
    {
        Home_Controller obj;
        DataTable dt;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {

                LoadNews();
                ClientScript.RegisterStartupScript(GetType(), "Javascript", "javascript:getMobileOperatingSystem(); ", true);

            }
        }

        private void LoadNews()
        {
            try
            {
                obj = new Home_Controller();
                dt = new DataTable();
                dt = obj.LoadNews();
                if(dt != null)
                {
                    if(dt.Rows.Count > 0)
                    {
                        for(int i =0;i<dt.Rows.Count;i++)
                        {
                            if(dt.Rows[i]["id"].ToString() == "1")
                            {
                                lblNews1PostTitle.Text = dt.Rows[i]["postTitle"].ToString();
                                if (dt.Rows[i]["newsDescription"].ToString().Length > 115)
                                    lblNews1Detail.Text = dt.Rows[i]["newsDescription"].ToString().Substring(0, 115) + "...";
                                else
                                    lblNews1Detail.Text = dt.Rows[i]["newsDescription"].ToString().Substring(0, 115);
                                lblNewsDetail1.Text = dt.Rows[i]["newsDescription"].ToString();
                                imgNews1.Src = dt.Rows[i]["postImage"].ToString();
                            }
                            if (dt.Rows[i]["id"].ToString() == "2")
                            {
                                lblNews2PostTitle.Text = dt.Rows[i]["postTitle"].ToString();
                                if (dt.Rows[i]["newsDescription"].ToString().Length > 115)
                                    lblNews2Detail.Text = dt.Rows[i]["newsDescription"].ToString().Substring(0, 115) + "...";
                                else
                                    lblNews2Detail.Text = dt.Rows[i]["newsDescription"].ToString().Substring(0, 115);
                                lblNewsDetail2.Text = dt.Rows[i]["newsDescription"].ToString();
                                imgNews2.Src = dt.Rows[i]["postImage"].ToString();
                            }
                            if (dt.Rows[i]["id"].ToString() == "3")
                            {
                                lblNews3PostTitle.Text = dt.Rows[i]["postTitle"].ToString();
                                lblNews3Detail.Text = dt.Rows[i]["newsDescription"].ToString();
                                lblNewsDetail3.Text = dt.Rows[i]["newsDescription"].ToString();
                                imgNews3.Src = dt.Rows[i]["postImage"].ToString();
                            }
                            if (dt.Rows[i]["id"].ToString() == "4")
                            {
                                lblNews4PostTitle.Text = dt.Rows[i]["postTitle"].ToString();
                                lblNews4Detail.Text = dt.Rows[i]["newsDescription"].ToString();
                                lblNewsDetail4.Text = dt.Rows[i]["newsDescription"].ToString();
                                imgNews4.Src = dt.Rows[i]["postImage"].ToString();
                            }
                        }
                    }
                }
            }
            catch(Exception ex)
            {

            }
        }
    }
}