using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Controller;
using System.Data;
using System.Windows.Forms;
using System.Text;
using Morpheus.Accounts.Reports;
using Microsoft.Reporting.WebForms;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;

namespace Morpheus.Accounts
{
    public partial class viewEditCompanyIncidentReports : System.Web.UI.Page
    {
        DataTable dt;
        viewEditCompanyIncidentReports_Controller obj;
        Dictionary<string, Int16> severanityLevel = new Dictionary<string, Int16>();
        private int _USERID;
        private int _reportID;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (Session["UserTypeID"].ToString() == "2")
                    {
                        loadReports(int.Parse(Session["userid"].ToString()));
                        LoadSubContractorReports();
                        btnUpdateReport.Enabled = false;
                        btnUpdateReport.Visible = false;
                        
                    }
                    else if (Session["UserTypeID"].ToString() == "4")
                    {
                        loadReports(int.Parse(Session["userid"].ToString()));                       
                        btnUpdateReport.Enabled = false;
                        btnUpdateReport.Visible = false;
                    }
                    else
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

        protected void Page_Init(object sender, EventArgs e)
        {
            if (Session["report"] != null)
            {
               
            }
        }

        private void loadReports(int userID)
        {
            try
            {
                obj = new viewEditCompanyIncidentReports_Controller();
                dt = obj.loadIncidentReportsByCompany(userID);
                if (dt != null && dt.Rows.Count != 0)
                {
                    dtgridview_IncidentReports.DataSource = dt;
                    dtgridview_IncidentReports.DataBind();
                    ViewState["dtReport"] = dt;
                }
                else if (dt.Rows.Count == 0)
                    showErrorMessage("No reports", true);
                else
                    showErrorMessage(obj.ErrorString, false);
            }
            catch(Exception ex)
            {
                showErrorMessage(ex.Message, false);
            }
        }

        private void LoadSubContractorReports()
        {
            try
            {
                obj = new viewEditCompanyIncidentReports_Controller();
                DataTable dtSubConList = new DataTable();
                dt = new DataTable();
                dtSubConList = obj.LoadSubContractors(int.Parse(Session["userid"].ToString()));

                for (int i = 0; i < dtSubConList.Rows.Count; i++)
                {
                    DataTable dtTemp = new DataTable();
                    dtTemp = obj.loadIncidentReportsByCompany(int.Parse(dtSubConList.Rows[i]["UserId"].ToString()));
                    dt.Merge(dtTemp);
                    dt.AcceptChanges();
                }

                if (dt != null && dt.Rows.Count != 0)
                {
                    gdIncidentSubcontractor.DataSource = dt;
                    gdIncidentSubcontractor.DataBind();
                }
                else if(dt.Rows.Count != 0)
                {
                    showErrorMessage(obj.ErrorString, false);
                }
            }
            catch(Exception ex)
            {
                showErrorMessage(ex.Message, false);
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

        protected void dtgridview_IncidentReports_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                dtgridview_IncidentReports.PageIndex = e.NewPageIndex;
                loadReports(int.Parse(Session["userid"].ToString()));
            }
            catch (Exception ex)
            {
                showErrorMessage(ex.Message, false);
            }
        }

        protected void dtgridview_IncidentReports_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void dtgridview_IncidentReports_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                dt = new DataTable();
                ViewIncidentReprots_Controller objInc = new ViewIncidentReprots_Controller();
                obj = new viewEditCompanyIncidentReports_Controller();
                GridViewRow row = dtgridview_IncidentReports.SelectedRow;      
                ViewState.Add("_reportID", row.Cells[1].Text);
                loadCrystalReport(int.Parse(row.Cells[1].Text), int.Parse(Session["userid"].ToString()));
                TextBox_ReportId.Text = row.Cells[1].Text;
                dt = objInc.loadImagesOfReport(int.Parse(row.Cells[1].Text)); //loading images 
                if (dt != null && dt.Rows.Count != 0)
                {
                    List<Image> pictureBoxList = new List<Image>();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        Image picture = new Image();
                        picture.ImageUrl = "upload/" + dt.Rows[i]["imageName"].ToString();
                        picture.Width = 484;
                        pictureBoxList.Add(picture);
                    }

                    foreach (Image p in pictureBoxList)
                    {
                        pnlDisplayImage.Controls.Add(p);
                    }
                }

                btnUpdateReport.Focus();
                if (!obj.UpdateIncidentReportStatus(int.Parse(TextBox_ReportId.Text), int.Parse(Session["userid"].ToString())))// Update Status
                {
                    showErrorMessage(obj.ErrorString, false);
                }
                Popup(true);
            }
            catch (Exception ex)
            {
                showErrorMessage(ex.Message, false);
            }
        }

        protected void dtgridview_IncidentReports_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            try
            {

                GridViewRow row = dtgridview_IncidentReports.Rows[e.NewSelectedIndex];
                if (row.Cells[1].Text == "ANATR")
                {
                    e.Cancel = true;
                    showErrorMessage("You cannot select " + row.Cells[2].Text + ".", false);
                }
            }
            catch (Exception ex)
            {
                showErrorMessage(ex.Message + " Please contact administrator.", false);
            }
        }

        protected void btnUpdateReport_Click(object sender, EventArgs e)
        {

        }

        //To show message after performing operations
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

        protected void btnClose_Click(object sender, EventArgs e)
        {
            loadReports(int.Parse(Session["userid"].ToString()));
        }

        protected void gdIncidentSubcontractor_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                dt = new DataTable();
                ViewIncidentReprots_Controller objInc = new ViewIncidentReprots_Controller();
                obj = new viewEditCompanyIncidentReports_Controller();
                GridViewRow row = gdIncidentSubcontractor.SelectedRow;
                ViewState.Add("_reportID", row.Cells[1].Text);
                loadCrystalReport(int.Parse(row.Cells[1].Text), int.Parse(row.Cells[11].Text));
                TextBox_ReportId.Text = row.Cells[1].Text;
                dt = objInc.loadImagesOfReport(int.Parse(row.Cells[1].Text)); //loading images 
                if (dt != null && dt.Rows.Count != 0)
                {
                    List<Image> pictureBoxList = new List<Image>();

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        Image picture = new Image();
                        picture.ImageUrl = "upload/" + dt.Rows[i]["imageName"].ToString();
                        picture.Width = 484;
                        pictureBoxList.Add(picture);
                    }

                    foreach (Image p in pictureBoxList)
                    {
                        pnlDisplayImage.Controls.Add(p);
                    }
                }

                btnUpdateReport.Focus();
                if (!obj.UpdateIncidentReportStatus(int.Parse(TextBox_ReportId.Text), int.Parse(Session["userid"].ToString())))// Update Status
                {
                    showErrorMessage(obj.ErrorString, false);
                }
                Popup(true);
            }
            catch (Exception ex)
            {
                showErrorMessage(ex.Message, false);
            }
        }

        protected void gdIncidentSubcontractor_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            try
            {
                GridViewRow row = gdIncidentSubcontractor.Rows[e.NewSelectedIndex];
                if (row.Cells[1].Text == "ANATR")
                {
                    e.Cancel = true;
                    showErrorMessage("You cannot select " + row.Cells[2].Text + ".", false);
                }
            }
            catch (Exception ex)
            {
                showErrorMessage(ex.Message + " Please contact administrator.", false);
            }
        }

        protected void dtgridview_IncidentReports_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.Cells[10].Text == "unseen")
            {
                e.Row.CssClass = "danger";
            }
        }

        protected void gdIncidentSubcontractor_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.Cells[10].Text == "unseen")
                e.Row.CssClass = "danger";
        }

        private void loadCrystalReport(int reportID, int USERID)
        {
            try
            {
                obj = new viewEditCompanyIncidentReports_Controller();
                rptViewer.ProcessingMode = ProcessingMode.Local;
                dsIncidentReport dsCustomers = LoadReport(reportID, USERID);
          
                ReportDataSource datasource = new ReportDataSource("IncidentReportDS", dsCustomers.Tables[0]);
                rptViewer.LocalReport.DataSources.Clear();
                rptViewer.LocalReport.DataSources.Add(datasource);
            }
            catch(Exception ex)
            {
                showErrorMessage(ex.Message, false);
            }
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                string deviceInfo = "";
                string mimeType = "";
                string encoding = "";
                string fileNameExtension = "";
                string[] streams = null;
                Warning[] warnings = null;
                byte[] bytes;
                FileStream fs;
                string fileName = string.Empty;
                if (fileName == "")
                {
                    fileName = ViewState["_reportID"].ToString();
                }
                else
                    fileName = "Seguroincidentreport";
                if (rdPdf.Checked)
                {
                    bytes = this.rptViewer.LocalReport.Render("PDF", deviceInfo, out mimeType, out encoding, out fileNameExtension, out streams, out warnings);
                    Response.Buffer = true;
                    Response.Clear();
                    Response.ContentType = mimeType;
                    Response.AddHeader("content-disposition", "attachment; filename=" + fileName + "." + "pdf");
                    Response.BinaryWrite(bytes); // create the filepdf
                    Response.Flush(); // send it to the client to download
                }
              
            }
            catch(Exception ex)
            {
                showErrorMessage(ex.Message, false);
            }
        }
        public dsIncidentReport LoadReport(int reportID, int ReportedTo)
        {
            try
            {
                string conString = ConfigurationManager.ConnectionStrings["morpheus_db"].ConnectionString;
                SqlCommand cmd = new SqlCommand("spLoadReport");
                cmd.Parameters.Add("@ReportedTo", SqlDbType.BigInt).Value = ReportedTo;
                cmd.Parameters.Add("@ReportID", SqlDbType.BigInt).Value = reportID;
                using (SqlConnection con = new SqlConnection(conString))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;                 
                        sda.SelectCommand = cmd;
                        using (dsIncidentReport dsIncRpt = new dsIncidentReport())
                        {
                            sda.Fill(dsIncRpt, "LoadReport");
                            return dsIncRpt;
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                showErrorMessage(ex.Message, false);
                return null;
            }
        }
    }
}