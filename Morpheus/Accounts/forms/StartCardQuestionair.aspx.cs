using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Controller;

namespace Morpheus.Accounts
{
    public partial class survey : System.Web.UI.Page
    {
        StartCardQuestionair_Controller obj;
        DataTable dt;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["UserName"].ToString() != "")
                {
                    if(!IsPostBack)
                    {
                        txtTask.Text = Session["ActivityId"].ToString();
                        txtemployee.Text = Session["UserName"].ToString();
                        txtstartdate.Text = DateTime.Now.ToString();
                        LoadQuestionair(int.Parse(Session["userid"].ToString()));
                    }       
                }
                else
                {
                    Response.Redirect("login.aspx");
                }
            }
            catch(Exception ex)
            {
                Response.Redirect("login.aspx");
            }
        }

        
        protected void btnSubmitSurvey_Click(object sender, EventArgs e)
        {
            try
            {

                if(CheckDesireAnswer())
                {
                   Session["SuccessMsg"] = "Congratulations your job has been started";
                   Response.Redirect("../StartActivity.aspx");
                }
                else
                {
                    showErrorMessage("Please inform your supervisor, as you have selected one of the answer as No.", false);
                }
            }
            catch(Exception ex)
            {
                showErrorMessage(ex.Message, false);
            }
        }

        private bool CheckDesireAnswer()
        {
            try
            {
                dt = new DataTable();
                dt = (DataTable)ViewState["qdt"];
                int ct = 1;
                string quest = "Q";
                string questAns = "Answer";
                string showHide = "ShowHide";
                string LabelQuestion = "lblQ";
                string expAnswer = "Q" + ct + "VisibleYes";
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataColumn col in dt.Columns)
                        {
                            foreach (DataRow row in dt.Rows)
                            {
                                if (col.ColumnName != "formID" && col.ColumnName != "compantID" && !(col.ColumnName.Contains(questAns)) && !(col.ColumnName.Contains(showHide)))
                                {
                                    Label txtbo = (Label)PlaceHolder1.FindControl(LabelQuestion + ct.ToString());
                                    RadioButton rd = (RadioButton)PlaceHolder1.FindControl("rdYesQ" + ct.ToString());
                                    if (col.ColumnName == quest + ct && txtbo.ID.ToString() == LabelQuestion + ct)
                                    {
                                        //txtbo.Text = row[col.ColumnName].ToString();
                                        if (rd.Checked.ToString() != row["Q" + ct.ToString() + "Answer"].ToString())
                                        {
                                            return false;
                                        }
                                 
                                    }
                                    ct++;
                                }
                            }
                        }
                    }
                    return true;
                }
                else
                {
                    showErrorMessage(obj._errorMsg, false);
                    return false;
                }
            }
            catch(Exception ex)
            {
                showErrorMessage(ex.Message, false);
                return false;
            }
            
        }

        private void showHideRows(DataTable dt)
        {
            try
            {
                int ct = 1;
                string quest = "Q";
                string questAns = "Answer";
                string showHide = "ShowHide";
                string LabelQuestion = "lblQ";
                string expAnswer = "Q" + ct + "VisibleYes";
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataColumn col in dt.Columns)
                        {
                            foreach (DataRow row in dt.Rows)
                            {
                                string rowId = "rowQ"+ct.ToString();
                                HtmlTableRow rowTr = (HtmlTableRow)PlaceHolder1.FindControl(rowId);
                                if (col.ColumnName != "formID" && col.ColumnName != "compantID" && !(col.ColumnName.Contains(questAns)) && !(col.ColumnName.Contains(showHide)))
                                {
                                    if (row["Q" + ct.ToString() + "ShowHide"].ToString() == "True")
                                    {
                                        rowTr.Visible = true;
                                    }
                                    else
                                    {
                                        rowTr.Visible = false;
                                    }
                                    ct++;
                                }
                            }
                        }

                    }
                }    

                
            }
            catch(Exception ex)
            {
                showErrorMessage(ex.Message, false);
            }

        }

        private void LoadQuestionair(int userid)
        {
            try
            {
                obj = new StartCardQuestionair_Controller();
                dt = new DataTable();
                dt = obj.LoadQuestionair(userid);
                ViewState["qdt"] = dt;
                int ct = 1;
                string quest = "Q";
                string questAns = "Answer";
                string showHide = "ShowHide";
                string LabelQuestion = "lblQ";
                string expAnswer = "Q" + ct + "VisibleYes";
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataColumn col in dt.Columns)
                        {
                            foreach (DataRow row in dt.Rows)
                            {
                                if (col.ColumnName != "formID" && col.ColumnName != "compantID" && !(col.ColumnName.Contains(questAns)) && !(col.ColumnName.Contains(showHide)))
                                {
                                    Label txtbo = (Label)PlaceHolder1.FindControl(LabelQuestion + ct.ToString());
                                    CheckBox chk = (CheckBox)PlaceHolder1.FindControl("chkboxQ" + ct.ToString());
                                    if (col.ColumnName == quest + ct && txtbo.ID.ToString() == LabelQuestion + ct)
                                        txtbo.Text = row[col.ColumnName].ToString();
                                    ct++;
                                }
                            }
                        }

                    }

                    showHideRows(dt);
                }
                else
                    showErrorMessage(obj._errorMsg, false);

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
            }
            else
            {
                lblErrorMsg.Text = message;
                errorMsg.Style.Add("display", "block");
                successMsg.Style.Add("display", "none");
            }

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("../StartActivity.aspx");
        }
    }
}