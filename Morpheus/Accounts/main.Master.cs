using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using Infragistics.Web.UI.EditorControls;
using Controller;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Morpheus.Accounts
{
    public partial class superAdmin : System.Web.UI.MasterPage
    {
        Main_Controller obj;
        DataTable dt;
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
                            HidebuttonFull();
                        }
                        else if (Session["UserTypeID"].ToString() == "2")
                        {
                            dashboardmenu1.Visible = false;
                            companySideMenu1.Visible = true;
                            employeeDashMenu1.Visible = false;
                            LoadCompanyLogo(int.Parse(Session["userid"].ToString()));
                        }
                        else if (Session["UserTypeID"].ToString() == "3")
                        {
                            dashboardmenu1.Visible = false;
                            companySideMenu1.Visible = false;
                            employeeDashMenu1.Visible = true;
                            //HidebuttonFull();
                            int comID = GetCompanyIdOfEmployee(int.Parse(Session["userid"].ToString()));
                            if(comID >0)
                            {
                                LoadCompanyLogo(comID);
                                HidebuttonFull();
                            }
                           
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

        protected void btnUploadLogo_Click(object sender, EventArgs e)
        {
            try
            {
                if (fUpLogo.HasFile)
                {
                    obj = new Main_Controller();
                    dt = new DataTable();
                    int _CompanyId = int.Parse(Session["userid"].ToString().Trim());
                    HttpPostedFile postedFile = fUpLogo.PostedFile;
                    string filename = _CompanyId + "_CompanyLogo";//
                                                                       
                    string fileExtension = Path.GetExtension(fUpLogo.FileName);
                    int fileSize = postedFile.ContentLength;
                    if (fileExtension.ToLower() == ".jpg" || fileExtension.ToLower() == ".gif"
                        || fileExtension.ToLower() == ".png" || fileExtension.ToLower() == ".bmp")
                    {

                        string directoryName = _CompanyId.ToString(); // all data will be saved using userID of employee
                        string fullDirectoryPath = Server.MapPath(@"~/data/" + directoryName + "/");
                        string fileNameWithPath = Server.MapPath("~/data/" + directoryName + "/" + filename + "." + fileExtension);
                        string pathTosave = "~/data/" + directoryName + "/" + filename + "." + fileExtension;
                        if (!Directory.Exists(fullDirectoryPath))
                            Directory.CreateDirectory(fullDirectoryPath);

                        dt = obj.CompanyLogo(_CompanyId); // get company logo url from db
                        if (dt.Rows.Count > 0)
                        {
                            if (!File.Exists(Server.MapPath(dt.Rows[0]["CompanyLogo"].ToString())))
                            {
                                if (obj.UpdateCompanyLogo(pathTosave, _CompanyId))
                                {
                                    Stream stream = postedFile.InputStream;
                                    if (fileSize < 1000000)
                                        fUpLogo.SaveAs(fileNameWithPath);
                                    else
                                        GenerateThumbnails(0.5, stream, fileNameWithPath);
                 
                                    impPrev.ImageUrl = pathTosave + "?rand=" + Guid.NewGuid();
                                    //showErrorMessage("Profile picture changed successfully", true);
                                }
                                else
                                    lblError.Text = "unable to save files";
                            }
                            else
                            {
                                File.Delete(Server.MapPath(dt.Rows[0]["CompanyLogo"].ToString()));
                                if (obj.UpdateCompanyLogo(pathTosave, _CompanyId))
                                {
                                    Stream stream = postedFile.InputStream;
                                    if (fileSize < 1000000)
                                        fUpLogo.SaveAs(fileNameWithPath);
                                    else
                                        GenerateThumbnails(0.5, stream, fileNameWithPath);
                             
                                    impPrev.ImageUrl = pathTosave + "?rand=" + Guid.NewGuid(); ;
                                    //showErrorMessage("Profile picture changed successfully", true);
                                    Hidebutton();


                                }
                                else
                                    lblError.Text = "unable to save files";
                            }
                        }
                    }
                    else
                        lblError.Text = "Only images (.jpg, .png, .gif and .bmp) can be uploaded";
                }
                else
                    lblError.Text = "No Logo Selected.";

            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }

        private void Hidebutton()
        {
            fUpLogo.Visible = false;
            btnUploadLogo.Visible = false;
            btnEditlogo.Visible = true;
        }
        private void HidebuttonFull()
        {
            fUpLogo.Visible = false;
            btnUploadLogo.Visible = false;
            btnEditlogo.Visible = false;
        }
        private void GenerateThumbnails(double scaleFactor, Stream sourcePath, string targetPath)
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
        private void LoadCompanyLogo(int CompanyId)
        {
            try
            {
                dt = new DataTable();
                obj = new Main_Controller();
                dt = obj.CompanyLogo(CompanyId);
                if (dt != null)
                {
                    if (dt.Rows.Count > 0 && dt.Rows[0]["CompanyLogo"].ToString() != "")
                    {
                       impPrev.ImageUrl = dt.Rows[0]["CompanyLogo"].ToString();
                       Hidebutton();
                    }
                    else
                    {
                        fUpLogo.Visible = true;
                        btnUploadLogo.Visible = true;
                        btnEditlogo.Visible = false;
                    }
                }
                else
                    lblError.Text = obj.ErrorString;
                
            }
            catch(Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }
        protected void btnEditlogo_Click(object sender, EventArgs e)
        {
            try
            {
                fUpLogo.Visible = true;
                btnUploadLogo.Visible = true;
                btnEditlogo.Visible = false;
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }

        private int GetCompanyIdOfEmployee(int employeeId)
        {
            try
            {
                obj = new Main_Controller();
                dt = new DataTable();
                dt = obj.GetCompanyIdOfEmployee(employeeId);
                if(dt != null)
                {
                    return int.Parse(dt.Rows[0]["user_id"].ToString());
                }
                else
                {
                    lblError.Text = obj.ErrorString;
                    return 0;
                }
            }
            catch(Exception ex)
            {
                lblError.Text = ex.Message;
                return 0;
            }
        }
    }
}