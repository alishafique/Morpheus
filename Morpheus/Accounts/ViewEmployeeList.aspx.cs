using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Controller;

namespace Seguro.Accounts
{
    public partial class ViewEmployeeList : System.Web.UI.Page
    {
        viewEmployees_Controller objEmp;
        DataTable dt;
        Employee objEmpData;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                try
                {
                    if (Session["UserName"].ToString() != "")
                    {
       
                        if (Session["UserTypeID"].ToString() == "2")
                        {
                            loadEmployee(int.Parse(Session["userid"].ToString()));
                            btnUpdateEmployeeProfile.Enabled = false;
                        }
                        if (Session["UserTypeID"].ToString() == "3")
                        {
                            loadEmployeeProfileByEmployee(int.Parse(Session["userid"].ToString()));
                            loadProfileImage(int.Parse(Session["userid"].ToString()));
                            hideGrid.Visible = false;
                            btnUpdateEmployeeProfile.Enabled = true;
                            loadEmployeeDocuments();
                        }
                        if (Session["UserTypeID"].ToString() == "4")
                        {
                            loadEmployee(int.Parse(Session["userid"].ToString()));
                            btnUpdateEmployeeProfile.Enabled = false;
                        }
                    }
                    else
                    {
                        Response.Redirect("login.aspx");
                    }
                }
                catch (Exception)
                {
                    Response.Redirect("login.aspx");
                }
            }
        }

        protected void dtgridview_Employees_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dtgridview_Employees.PageIndex = e.NewPageIndex;
            loadEmployee(int.Parse(Session["userid"].ToString()));
        }

        protected void dtgridview_Employees_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                objEmp = new viewEmployees_Controller();
                dt = new DataTable();
                GridViewRow row = dtgridview_Employees.SelectedRow;
                TextBox_EmployeeId.Text = row.Cells[1].Text.Replace("&nbsp;", "");
                TextBox_userId.Text = row.Cells[2].Text.Replace("&nbsp;", "");
                loadProfileImage(int.Parse(TextBox_userId.Text));
                TextBox_EmployeeName.Text = row.Cells[3].Text.Replace("&nbsp;", "").Replace("&#39;","'");
                TextBox1_EmployeeEmail.Text = row.Cells[4].Text.Replace("&nbsp;", "");
                txtbox_dateTimePicker_DOB.Text = row.Cells[6].Text;
                TextBox_ABN.Text = row.Cells[7].Text.Replace("&nbsp;", "");
                TextBox_TFN.Text = row.Cells[8].Text.Replace("&nbsp;", "");
                DropDownList_activeStatus.SelectedValue = row.Cells[9].Text.Replace("&nbsp;", "").Replace("&#39;", "'");
                dt = objEmp.loadAddressByEmployeeId(int.Parse(TextBox_EmployeeId.Text));

                if (dt != null)
                {
                    TextBox_StreetName.Text = dt.Rows[0]["Address"].ToString();
                    TextBox_Suburb.Text = dt.Rows[0]["suburb"].ToString();
                    TextBox_State.Text = dt.Rows[0]["state"].ToString();
                    TextBox_Postcode.Text = dt.Rows[0]["postcode"].ToString();
                    TextBox_License.Text = dt.Rows[0]["license"].ToString();
                    TextBox_Mobile.Text = dt.Rows[0]["mobile"].ToString();
                }
                else
                {
                    showErrorMessage("Unable to load Address with following error: " + objEmp.ErrorString, false);
                }

                btnUpdateEmployeeProfile.Enabled = true;
                btnUpdateEmployeeProfile.Focus();
                loadEmployeeDocuments();
            }
            catch (Exception ex)
            {
                showErrorMessage(ex.Message, false);
                clearTextBox();
                TextBox_EmployeeId.Text = "";
            }

        }

        protected void dtgridview_Employees_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            try
            {

                GridViewRow row = dtgridview_Employees.Rows[e.NewSelectedIndex];
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

        private string convertDate(string i)
        {
            //string i = row["date_of_birth"].ToString();
            DateTime dtDate = Convert.ToDateTime(i);
            string s = dtDate.Day + "/" + dtDate.Month + "/" + dtDate.Year;
            return s;
        }

        private void loadEmployeeProfileByEmployee(int empID)
        {
            try
            {
                dt = new DataTable();
                objEmp = new viewEmployees_Controller();
                dt = objEmp.employeeProfileByEmployeeID(empID);
                if (dt != null && dt.Rows.Count != 0)
                {
                    TextBox_EmployeeId.Text = dt.Rows[0]["EmployeeId"].ToString();
                    TextBox_userId.Text = dt.Rows[0]["UserId"].ToString();
                    TextBox_EmployeeName.Text = dt.Rows[0]["emp_name"].ToString();
                    TextBox1_EmployeeEmail.Text = dt.Rows[0]["email"].ToString();
                    txtbox_dateTimePicker_DOB.Text = convertDate(dt.Rows[0]["date_of_birth"].ToString());
                    TextBox_ABN.Text = dt.Rows[0]["ABN"].ToString();
                    TextBox_TFN.Text = dt.Rows[0]["TFN"].ToString();
                    hideEmployee.Visible = false;
                    TextBox_StreetName.Text = dt.Rows[0]["Address"].ToString();
                    TextBox_Suburb.Text = dt.Rows[0]["suburb"].ToString();
                    TextBox_State.Text = dt.Rows[0]["state"].ToString();
                    TextBox_Postcode.Text = dt.Rows[0]["postcode"].ToString();
                    TextBox_License.Text = dt.Rows[0]["license"].ToString();
                    TextBox_Mobile.Text = dt.Rows[0]["mobile"].ToString();
                }
                else
                    showErrorMessage(objEmp.ErrorString, false);
            }
            catch (Exception ex)
            {
                showErrorMessage(ex.Message, false);
            }

        }

        private void loadEmployee(int companyId)
        {
            try
            {
                dt = new DataTable();
                objEmp = new viewEmployees_Controller();
                dt = objEmp.viewEmployeeByCompany(companyId);
                dt.Columns.Add("active_status1", typeof(string));
                if (dt != null)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        //dt.Rows[i]["Age"] = getAge(dt.Rows[i]["DOB"].ToString());
                        if (dt.Rows[i]["active_status"] + string.Empty == "1")
                            dt.Rows[i]["active_status1"] = "Active";
                        else
                            dt.Rows[i]["active_status1"] = "Disabled";
                    }
                    dtgridview_Employees.DataSource = dt;
                    dtgridview_Employees.DataBind();
                }
                else
                {
                    showErrorMessage(objEmp.ErrorString, false);
                }

            }
            catch (Exception ex)
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

        protected void btnUpdateEmployeeProfile_Click(object sender, EventArgs e)
        {
            try
            {
                if (TextBox_EmployeeId.Text != "")
                {
                    objEmpData = new Employee();
                    objEmp = new viewEmployees_Controller();
                    objEmpData.Emp_name = TextBox_EmployeeName.Text;
                    objEmpData.Date_of_birth = DateTime.ParseExact(txtbox_dateTimePicker_DOB.Text, "d/M/yyyy", CultureInfo.InvariantCulture);

                    objEmpData.address = TextBox_StreetName.Text;
                    objEmpData.Suburb = TextBox_Suburb.Text;
                    objEmpData.State = TextBox_State.Text;
                    objEmpData.Postcode = TextBox_Postcode.Text;
                    objEmpData.A_BN = TextBox_ABN.Text;
                    objEmpData.T_FN = TextBox_TFN.Text;
                    objEmpData.Mobile = TextBox_Mobile.Text;
                    objEmpData.License = TextBox_License.Text;
                    if (objEmp.UpdateEmployeeProfileByCompany(objEmpData, int.Parse(TextBox_EmployeeId.Text)) == true)
                    {
                        if (Session["UserTypeID"].ToString() != "3") 
                        {
                            // company Updating Employee's Status i.e. Activate or Deactivate
                            if (objEmp.updateStatusOfEmployeeByCompany(int.Parse(TextBox_userId.Text), DropDownList_activeStatus.SelectedIndex) == true)
                            {
                                showErrorMessage("Updated Employee profile", true);
                                loadEmployee(int.Parse(Session["userid"].ToString()));
                                clearTextBox();
                                imgprw.ImageUrl = "";
                                grdViewDocuments.DataSource = null;
                                grdViewDocuments.DataBind();
                            }
                            else
                                showErrorMessage(objEmp.ErrorString, false);
                        }
                        else
                            showErrorMessage("Updated Employee profile", true);
                    }
                    else
                        showErrorMessage(objEmp.ErrorString, false);
                    if (profileUploadCtr.HasFile)
                        LinkButton1_Click(sender, e);
                }
                else
                    showErrorMessage("Please select employee to Update to its Profile!!!!", false);

            }
            catch (Exception ex)
            {
                showErrorMessage(ex.Message, false);
            }
        }

        private void clearTextBox()
        {
            TextBox_EmployeeId.Text = "";
            TextBox1_EmployeeEmail.Text = "";
            TextBox_EmployeeName.Text = "";
            txtbox_dateTimePicker_DOB.Text = "";
            TextBox_StreetName.Text = "";
            TextBox_Suburb.Text = "";
            TextBox_Postcode.Text = "";
            TextBox_State.Text = "";
            TextBox_EmployeeId.Text = "";
            DropDownList_activeStatus.SelectedIndex = 0;
            TextBox_ABN.Text = "";
            TextBox_TFN.Text = "";
            TextBox_Mobile.Text = "";
            TextBox_License.Text = "";
            TextBox_userId.Text = "";
            btnUpdateEmployeeProfile.Enabled = false;
        }

        protected void dtgridview_Employees_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                //if ((MessageBox.Show("Are you sure, you want to Delete the Employee Record!!", "Attention", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)) == System.Windows.Forms.DialogResult.Yes)
                //{
                objEmp = new viewEmployees_Controller();
                GridViewRow row = (GridViewRow)dtgridview_Employees.Rows[e.RowIndex];
                int userid = int.Parse(row.Cells[2].Text);
                if (objEmp.deleteEmployeeByCompany(userid) == true)
                {
                    showErrorMessage(row.Cells[3].Text + " deleted", true);
                    loadEmployee(int.Parse(Session["userid"].ToString()));
                }
                else
                {
                    showErrorMessage(objEmp.ErrorString, false);
                }
                //}
            }
            catch (Exception ex)
            {
                showErrorMessage(ex.Message, false);
            }

        }

        public string GetImage(object img)
        {
            return "data:image/jpg;base64," + Convert.ToBase64String((byte[])img);
        }

        private void loadProfileImage(int userid)
        {
            try
            {
                dt = new DataTable();
                objEmp = new viewEmployees_Controller();
                dt = objEmp.loadEmployeePrfileImageURL(userid);
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                        imgprw.ImageUrl = dt.Rows[0]["profile_imageURL"].ToString() + "?rand=" + Guid.NewGuid();
                }
                else
                {
                    showErrorMessage(objEmp.ErrorString, false);
                }
            }
            catch (Exception ex)
            {
                showErrorMessage(ex.Message, false);
            }

        }

        // Upload Employee's Profile image
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            try
            {

                if (profileUploadCtr.HasFile)
                {
                    objEmp = new viewEmployees_Controller();
                    dt = new DataTable();
                    HttpPostedFile postedFile = profileUploadCtr.PostedFile;
                    string filename = TextBox_userId.Text + "_Profile";//
                                                                       // Stream temp = Path.GetFileName(postedFile.FileName);
                    string fileExtension = Path.GetExtension(profileUploadCtr.FileName);
                    int fileSize = postedFile.ContentLength;
                    if (fileExtension.ToLower() == ".jpg" || fileExtension.ToLower() == ".gif"
                        || fileExtension.ToLower() == ".png" || fileExtension.ToLower() == ".bmp")
                    {

                        string directoryName = TextBox_userId.Text; // all data will be saved using userID of employee
                        string fullDirectoryPath = Server.MapPath(@"~/data/" + directoryName + "/");
                        string fileNameWithPath = Server.MapPath("~/data/" + directoryName + "/" + filename + "." + fileExtension);
                        string pathTosave = "~/data/" + directoryName + "/" + filename + "." + fileExtension;
                        if (!Directory.Exists(fullDirectoryPath))
                        {
                            Directory.CreateDirectory(fullDirectoryPath);
                        }

                        //string[] imgNam = fileNameWithPath.Split('/');
                        dt = objEmp.loadEmployeePrfileImageURL(int.Parse(TextBox_userId.Text));
                        if (dt.Rows.Count > 0)
                        {
                            if (!File.Exists(Server.MapPath(dt.Rows[0]["profile_imageURL"].ToString())))
                            {
                                if (objEmp.UpdateProfileEmployeeImage(pathTosave, int.Parse(TextBox_userId.Text)))
                                {
                                    Stream stream = postedFile.InputStream;
                                    if (fileSize < 1000000)
                                    {
                                        profileUploadCtr.SaveAs(fileNameWithPath);
                                    }
                                    else
                                    {
                                        GenerateThumbnails(0.5, stream, fileNameWithPath);
                                    }
                                    imgprw.ImageUrl = pathTosave + "?rand=" + Guid.NewGuid();
                                    showErrorMessage("Profile picture changed successfully", true);
                                }
                                else
                                {
                                    showErrorMessage("unable to save files", false);
                                }
                            }
                            else
                            {
                                File.Delete(Server.MapPath(dt.Rows[0]["profile_imageURL"].ToString()));
                                if (objEmp.UpdateProfileEmployeeImage(pathTosave, int.Parse(TextBox_userId.Text)))
                                {
                                    Stream stream = postedFile.InputStream;
                                    if (fileSize < 1000000)
                                    {
                                        profileUploadCtr.SaveAs(fileNameWithPath);
                                    }
                                    else
                                    {
                                        GenerateThumbnails(0.5, stream, fileNameWithPath);
                                    }
                                    imgprw.ImageUrl = pathTosave + "?rand=" + Guid.NewGuid(); ;
                                    showErrorMessage("Profile picture changed successfully", true);
                                }
                                else
                                {
                                    showErrorMessage("unable to save files", false);
                                }
                            }
                        }
                    }
                    else
                    {
                        showErrorMessage("Only images (.jpg, .png, .gif and .bmp) can be uploaded", false);
                    }
                }
                else
                {
                    showErrorMessage("No file selected", false);
                    profileUploadCtr.Focus();
                }
            }
            catch (Exception ex)
            {
                showErrorMessage(ex.Message, false);
            }
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

        protected void btnUploadDocuments_Click(object sender, EventArgs e)
        {
            try
            {
                if (FtCdocuments.HasFile)
                {
                    objEmp = new viewEmployees_Controller();
                    dt = new DataTable();
                    HttpPostedFile postedFile = FtCdocuments.PostedFile;
                    string filename = txtDocumentName.Text;
                    string fileExtension = Path.GetExtension(filename);
                    int fileSize = postedFile.ContentLength;
                    Stream stream = postedFile.InputStream;
                    BinaryReader binaryReader = new BinaryReader(stream);
                    Byte[] bytes = binaryReader.ReadBytes((int)stream.Length);
                    dt = objEmp.spUploadImage(filename, fileSize, bytes, int.Parse(TextBox_userId.Text), "document");

                    if (dt != null)
                    {
                        loadProfileImage(int.Parse(TextBox_userId.Text));
                        showErrorMessage("Uploaded Document image", true);
                    }
                    else
                    {
                        showErrorMessage(objEmp.ErrorString, false);
                    }
                }
                else
                {
                    showErrorMessage("No file selected", false);
                    profileUploadCtr.Focus();
                }
            }
            catch (Exception ex)
            {
                showErrorMessage(ex.Message, false);
            }
        }

        private void loadEmployeeDocuments()
        {
            try
            {
                dt = new DataTable();
                objEmp = new viewEmployees_Controller();
                dt = objEmp.spLoadEmployeeDocuments(int.Parse(TextBox_EmployeeId.Text));
                if (dt != null)
                {
                    grdViewDocuments.DataSource = dt;
                    grdViewDocuments.DataBind();
                }
                else
                {
                    showErrorMessage(objEmp.ErrorString, false);
                }

            }
            catch (Exception ex)
            {
                showErrorMessage(ex.Message, false);
            }
        }

        protected void removeDocument_Click(object sender, EventArgs e)
        {
            try
            {
                objEmp = new viewEmployees_Controller();
                LinkButton lnkRemove = (LinkButton)sender;
                string val = lnkRemove.CommandArgument;
                if (objEmp.DeletDocumentByEmployee(int.Parse(val)))
                {
                    showErrorMessage("Document Deleted Successfully.", true);
                    loadEmployeeDocuments();
                }
                else
                    showErrorMessage(objEmp.ErrorString, false);
            }
            catch (Exception ex)
            {
                showErrorMessage(ex.Message, false);
            }
        }
        protected void DownloadFile(object sender, EventArgs e)
        {
            try
            {
                string filePath = (sender as LinkButton).CommandArgument;
                if (File.Exists(Server.MapPath(filePath)))
                {
                    Response.ContentType = ContentType;
                    Response.AppendHeader("Content-Disposition", "attachment; filename=" + Path.GetFileName(filePath));
                    Response.WriteFile(filePath);
                    Response.End();
                }
                else
                {
                    showErrorMessage("No document Exist", false);
                }
            }
            catch(Exception ex)
            {
                showErrorMessage(ex.Message, false);
            }
        }

        protected void btnApprove_Click(object sender, EventArgs e)
        {
            try
            {
                objEmp = new viewEmployees_Controller();
                LinkButton lnkApprove = (LinkButton)sender;
                string documentID = lnkApprove.CommandArgument;
                if (objEmp.UpdateDocumentStatus(int.Parse(documentID), "Approved"))
                {
                    showErrorMessage("Document Updated Successfully.", true);
                    loadEmployeeDocuments();
                }
                else
                    showErrorMessage(objEmp.ErrorString, false);
            }
            catch (Exception ex)
            {
                showErrorMessage(ex.Message, false);
            }
        }

        protected void btnReject_Click(object sender, EventArgs e)
        {
            try
            {
                objEmp = new viewEmployees_Controller();
                LinkButton lnkApprove = (LinkButton)sender;
                string documentID = lnkApprove.CommandArgument;
                if (objEmp.UpdateDocumentStatus(int.Parse(documentID), "Reject"))
                {
                    showErrorMessage("Document Updated Successfully.", true);
                    loadEmployeeDocuments();
                }
                else
                    showErrorMessage(objEmp.ErrorString, false);
            }
            catch (Exception ex)
            {
                showErrorMessage(ex.Message, false);
            }
        }
    }
}