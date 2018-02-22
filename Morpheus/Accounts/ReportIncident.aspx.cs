using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Controller;
using System.Data;
using System.IO;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Morpheus
{
    public partial class ReportIncident : System.Web.UI.Page
    {
        reportIncident_Controller obj;
        DataTable dt;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!this.IsPostBack)
                {
                    txtbox_dateTimePicker.Text = DateTime.Now.ToString();
                    lblUserName.Text = Session["UserName"].ToString();
                    if (Session["UserTypeID"].ToString() == "1")
                    {
                        dashboardmenu1.Visible = true;
                        companySideMenu1.Visible = false;
                        employeeDashMenu1.Visible = false;
                        txtbox_ReportedBy.Text = (Session["UserName"].ToString());

                    }
                    else if (Session["UserTypeID"].ToString() == "2")
                    {
                        dashboardmenu1.Visible = false;
                        companySideMenu1.Visible = true;
                        employeeDashMenu1.Visible = false;
                        txtbox_ReportedBy.Text = (Session["UserName"].ToString());
                    }
                    else if (Session["UserTypeID"].ToString() == "3")
                    {
                        dashboardmenu1.Visible = false;
                        companySideMenu1.Visible = false;
                        employeeDashMenu1.Visible = true;
                        txtbox_ReportedBy.Text = (Session["UserName"].ToString());
                    }
                }
            }
            catch (Exception)
            {
                Response.Redirect("login.aspx");
            }
        }

        protected void btnSubmitReport_Click(object sender, EventArgs e)
        {
            try
            {
                obj = new reportIncident_Controller();
                dt = new DataTable();

                IncidentReport objIncdentReport = new IncidentReport()
                {
                    ReportedBy = int.Parse(Session["userid"].ToString()),
                    Severitylevel = dp_severityLevel.SelectedItem.ToString(),
                    Description = txtbox_Description.Text,
                    Status = "unseen",
                    reportDateTime = DateTime.Parse(txtbox_dateTimePicker.Text),
                    Location = txtbox_siteName.Text,
                    ActionTaken = txtbox_actionTaken.Text
                };

                if (Session["UserTypeID"].ToString() == "3")
                {
                    dt = obj.selectReportedToIncidentId(int.Parse(Session["userid"].ToString()));

                    if (dt != null)
                    {
                        objIncdentReport.ReportedTo = int.Parse(dt.Rows[0]["createdByCompanyId"].ToString());
                    }
                    else
                    {
                        showErrorMessage(obj.ErrorString, false);
                    }
                }
                else
                {
                    Response.Redirect("login.aspx");
                }

                int result = obj.insertIncidentReport(objIncdentReport);

                if (result > 0)
                {
                    if (fUploadCtrl.HasFile)
                    {
                        bool filesUploaded = SaveFiles(result);
                        if (filesUploaded)
                        {
                            showErrorMessage("Reported Successfully.", true);
                            clearTextbox();
                        }
                        else
                        {
                            //todo: log error here
                            showErrorMessage("Report submitted but Unable to upload Image", false);
                            fUploadCtrl.Enabled = false;
                            clearTextbox();
                        }
                    }
                    else
                    {
                        showErrorMessage("Reported Successfully.", true);
                        clearTextbox();
                    }
                }
                else
                    showErrorMessage("Unable to create Incident report: " + obj.ErrorString, false);
                
            }
            catch (Exception ex)
            {
                showErrorMessage(ex.Message + " Please contact administrator.", false);
            }
        }

        private void clearTextbox()
        {
            txtbox_ReportedBy.Text = (Session["UserName"].ToString());
            txtbox_dateTimePicker.Text = DateTime.Now.ToString();
            dp_severityLevel.SelectedIndex = 0;
            txtbox_siteName.Text = "";
            txtbox_Description.Text = "";
            txtbox_actionTaken.Text = ""; 
        }
        private bool SaveFiles(int incidentID)
        {
            try
            {
                if (fUploadCtrl.PostedFiles.Count > 2)
                {
                    showErrorMessage("Maximum 2 files allowed.", false);

                    return false;
                }
                else
                {
                    Evidence_Controller evidenceController = new Evidence_Controller();

                    foreach (HttpPostedFile file in fUploadCtrl.PostedFiles)
                    {
                        string fileName = Guid.NewGuid().ToString();
                        string ext = Path.GetExtension(file.FileName);
                        int fileSize = file.ContentLength;
                        Evidence evidence = new Evidence(incidentID, fileName + ext);
                        Stream stream = file.InputStream;
                        if (fileSize < 1000000)
                            file.SaveAs(Server.MapPath(".") + "\\upload\\" + fileName + ext);
                        else
                            GenerateThumbnails(0.5, stream, Server.MapPath(".") + "\\upload\\" + fileName + ext);

                        evidenceController.insertIncidentReport(evidence);
                    }

                    return true;
                }
            }
            catch (Exception e)
            {
                // Log error to error file
                showErrorMessage(e.Message + " Could not upload file. Please contact administrator.", false);
                return false;
            }
        }

        private void GenerateThumbnails(double scaleFactor, Stream sourcePath, string targetPath)
        {
            try
            {
                using (var image = System.Drawing.Image.FromStream(sourcePath))
                {
                    var newWidth = (int)(image.Width * scaleFactor);
                    var newHeight = (int)(image.Height * scaleFactor);
                    var thumbnailImg = new Bitmap(newWidth, newHeight);
                    var thumbGraph = Graphics.FromImage(thumbnailImg);
                    thumbGraph.CompositingQuality = CompositingQuality.HighQuality;
                    thumbGraph.SmoothingMode = SmoothingMode.HighQuality;
                    thumbGraph.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    var imageRectangle = new Rectangle(0, 0, newWidth, newHeight);
                    thumbGraph.DrawImage(image, imageRectangle);
                    thumbnailImg.Save(targetPath, image.RawFormat);
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
    }
}