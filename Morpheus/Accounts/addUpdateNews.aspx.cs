using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Controller;

namespace Morpheus.Accounts
{
    public partial class addUpdateNews : System.Web.UI.Page
    {
        addUpdateNews_Controller obj;
        DataTable dt;
        private string ErrorStr ="";
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (Session["UserTypeID"].ToString() == "1")
                    {
                        LoadNews();
                    }
                    else
                    {
                        Response.Redirect("login.aspx");
                    }
                }
            }
            catch(Exception ex)
            {
                Response.Redirect("login.aspx");
            }
        }

        private void LoadNews()
        {
            try
            {
                obj = new addUpdateNews_Controller();
                dt = new DataTable();
                dt = obj.LoadNews();
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            if (dt.Rows[i]["id"].ToString() == "1")
                            {
                                lblNews1PostTitle.Text = dt.Rows[i]["postTitle"].ToString();
                                lblNewsDetail1.Value = dt.Rows[i]["newsDescription"].ToString();
                                imgNews1.ImageUrl = dt.Rows[i]["postImage"].ToString() + "?rand=" + Guid.NewGuid();
                                ViewState["imgNews1"] = dt.Rows[i]["postImage"].ToString();

                            }
                            if (dt.Rows[i]["id"].ToString() == "2")
                            {
                                lblNews2PostTitle.Text = dt.Rows[i]["postTitle"].ToString();
                                lblNewsDetail2.Value = dt.Rows[i]["newsDescription"].ToString();
                                imgNews2.ImageUrl = dt.Rows[i]["postImage"].ToString() + "?rand=" + Guid.NewGuid();
                                ViewState["imgNews2"] = dt.Rows[i]["postImage"].ToString();
                            }
                            if (dt.Rows[i]["id"].ToString() == "3")
                            {
                                lblNews3PostTitle.Text = dt.Rows[i]["postTitle"].ToString();
                                lblNewsDetail3.Value = dt.Rows[i]["newsDescription"].ToString();
                                imgNews3.ImageUrl = dt.Rows[i]["postImage"].ToString() + "?rand=" + Guid.NewGuid();
                                ViewState["imgNews3"] = dt.Rows[i]["postImage"].ToString();
                            }
                            if (dt.Rows[i]["id"].ToString() == "4")
                            {
                                lblNews4PostTitle.Text = dt.Rows[i]["postTitle"].ToString();
                                lblNewsDetail4.Value = dt.Rows[i]["newsDescription"].ToString();
                                imgNews4.ImageUrl = dt.Rows[i]["postImage"].ToString() + "?rand=" + Guid.NewGuid();
                                ViewState["imgNews4"] = dt.Rows[i]["postImage"].ToString();
                            }
                        }
                    }
                }
                else
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
                string script = @"setTimeout(function(){document.getElementById('" + errorMsg.ClientID + "').style.display='none';},8000);";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "somekey", script, true);
            }
            else
            {
                lblErrorMsg.Text = message;
                errorMsg.Style.Add("display", "block");
                successMsg.Style.Add("display", "none");
                string script = @"setTimeout(function(){document.getElementById('" + errorMsg.ClientID + "').style.display='none';},8000);";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "somekey", script, true);
            }

        }

        private bool UpdateNews(int NewsId, string postTitle, string postDesc, string postImg)
        {
            try
            {
                obj = new addUpdateNews_Controller();
                if (obj.UpdateNews(NewsId, postTitle, postDesc, postImg))
                    return true;
                else
                {
                    ErrorStr = obj.ErrorString;
                    return false;
                }
            }
            catch(Exception ex)
            {
                showErrorMessage(ex.Message, false);
                return false;
            }
        }

        protected void btnNews1_Click(object sender, EventArgs e)
        {
            string fileUploaded = Uploadnews(fctrNews1, 1, imgNews1, ViewState["imgNews1"].ToString());
            if (fileUploaded != "")
            {
                if (UpdateNews(1, lblNews1PostTitle.Text, lblNewsDetail1.Value, fileUploaded))
                    showErrorMessage("News 1 Updated Succesfully", true);
                else
                    showErrorMessage(ErrorStr, false);
            }
            else
            {
                showErrorMessage("Unable to upload image.", false);
            }
        }

        protected void btnNews2_Click(object sender, EventArgs e)
        {
            string fileUploaded = Uploadnews(fctrNews2, 2, imgNews2, ViewState["imgNews2"].ToString());
            if (fileUploaded != "")
            {
                if (UpdateNews(2, lblNews2PostTitle.Text, lblNewsDetail2.Value, fileUploaded))
                    showErrorMessage("News 2 Updated Succesfully", true);
                else
                    showErrorMessage(ErrorStr, false);
            }
            else
            {
                showErrorMessage("Unable to upload image 2.", false);
            }
        }

        protected void btnNews3_Click(object sender, EventArgs e)
        {
            string fileUploaded = Uploadnews(fctrNews3, 3, imgNews3, ViewState["imgNews3"].ToString());
            if (fileUploaded != "")
            {
                if (UpdateNews(3, lblNews3PostTitle.Text, lblNewsDetail3.Value, fileUploaded))
                    showErrorMessage("News 3 Updated Succesfully", true);
                else
                    showErrorMessage(ErrorStr, false);
            }
            else
            {
                showErrorMessage("Unable to upload image 3.", false);
            }
        }

        protected void btnNews4_Click(object sender, EventArgs e)
        {
            string fileUploaded = Uploadnews(fctrNews4, 4, imgNews4, ViewState["imgNews4"].ToString());
            if (fileUploaded != "")
            {
                if (UpdateNews(4, lblNews4PostTitle.Text, lblNewsDetail4.Value, fileUploaded))
                    showErrorMessage("News 4 Updated Succesfully", true);
                else
                    showErrorMessage(ErrorStr, false);
            }
            else
            {
                showErrorMessage("Unable to upload image 4.", false);
            }
        }

        private string Uploadnews(FileUpload ftpCtr, int newsPostNumber, Image img , string imgURL)
        {
            try
            {
                if (ftpCtr.HasFile)
                {
                    obj = new addUpdateNews_Controller();

                    HttpPostedFile postedFile = ftpCtr.PostedFile;
                    string filename = newsPostNumber + "_" + Guid.NewGuid();

                    string fileExtension = Path.GetExtension(ftpCtr.FileName);
                    int fileSize = postedFile.ContentLength;
                    if (fileExtension.ToLower() == ".jpg" || fileExtension.ToLower() == ".gif"
                        || fileExtension.ToLower() == ".png" || fileExtension.ToLower() == ".bmp" || fileExtension.ToLower() == ".jpeg")
                    {

                        string directoryName = "News"; // all data will be saved using userID of employee
                        string fullDirectoryPath = Server.MapPath(@"~/data/" + directoryName + "/");
                        string fileNameWithPath = Server.MapPath("~/data/" + directoryName + "/" + filename + fileExtension);
                        string pathTosave = "~/data/" + directoryName + "/" + filename + fileExtension;
                        if (!Directory.Exists(fullDirectoryPath))
                            Directory.CreateDirectory(fullDirectoryPath);

                        if (!File.Exists(Server.MapPath(imgURL)))
                        {
                            ftpCtr.SaveAs(fileNameWithPath);
                        }
                        else
                        {
                            File.Delete(Server.MapPath(imgURL));
                            ftpCtr.SaveAs(fileNameWithPath);
                        }

                        img.ImageUrl = pathTosave + "?rand=" + Guid.NewGuid();

                        return pathTosave;
                    }
                    else
                    {
                        showErrorMessage("Only images (.jpg, .png, .gif and .bmp) can be uploaded", false);
                        return "";
                    }

                }
                else if (imgURL != "")
                {
                    return imgURL;
                }
                else
                {
                    showErrorMessage("No file selected", false);
                    return "";
                }

            }
            catch (Exception ex)
            {
                showErrorMessage(ex.Message, false);
                return "";
            }
        }
    }
}