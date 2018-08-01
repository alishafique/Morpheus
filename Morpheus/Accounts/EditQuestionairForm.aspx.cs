using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Controller;

namespace Morpheus.Accounts.forms
{
    public partial class EditQuestionairForm : System.Web.UI.Page
    {
        EditQuestionairForm_Controller obj;
        DataTable dt;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["UserTypeID"].ToString() == "2")
                {
                    if (!IsPostBack)
                    {
                        LoadQuestionair(int.Parse(Session["userid"].ToString()));
                    }
                }
                else
                    Response.Redirect("login.aspx");
            }
            catch(Exception ex)
            {
                Response.Redirect("login.aspx");
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                obj = new EditQuestionairForm_Controller();
                QuestionairQ10 objQuestionair = new QuestionairQ10()
                {
                    CompantID = int.Parse(Session["userid"].ToString()),
                    _Q1 = txtQuestion1.Text,
                    _Q1Answer = (Q1VisibleYes.Checked) ? true : false,

                    _Q1ShowHide = (chkboxQ1.Checked) ? true : false,

                    _Q2 = txtQuestion2.Text,
                    _Q2Answer = (Q2VisibleYes.Checked) ? true : false,
                    _Q2ShowHide = (chkboxQ2.Checked) ? true : false,

                    _Q3 = txtQuestion3.Text,
                    _Q3Answer = (Q3VisibleYes.Checked) ? true : false,
                    _Q3ShowHide = (chkboxQ3.Checked) ? true : false,

                    _Q4 = txtQuestion4.Text,
                    _Q4Answer = (Q4VisibleYes.Checked) ? true : false,
                    _Q4ShowHide = (chkboxQ4.Checked) ? true : false,

                    _Q5 = txtQuestion5.Text,
                    _Q5Answer = (Q5VisibleYes.Checked) ? true : false,
                    _Q5ShowHide = (chkboxQ5.Checked) ? true : false,

                    _Q6 = txtQuestion6.Text,
                    _Q6Answer = (Q6VisibleYes.Checked) ? true : false,
                    _Q6ShowHide = (chkboxQ6.Checked) ? true : false,

                    _Q7 = txtQuestion7.Text,
                    _Q7Answer = (Q7VisibleYes.Checked) ? true : false,
                    _Q7ShowHide = (chkboxQ7.Checked) ? true : false,

                    _Q8 = txtQuestion8.Text,
                    _Q8Answer = (Q8VisibleYes.Checked) ? true : false,
                    _Q8ShowHide = (chkboxQ8.Checked) ? true : false,

                    _Q9 = txtQuestion9.Text,
                    _Q9Answer = (Q9VisibleYes.Checked) ? true : false,
                    _Q9ShowHide = (chkboxQ9.Checked) ? true : false,

                    _Q10 = txtQuestion10.Text,
                    _Q10Answer = (Q10VisibleYes.Checked) ? true : false,
                    _Q10ShowHide = (chkboxQ10.Checked) ? true : false,

                    _Q11 = txtQuestion11.Text,
                    _Q11Answer = (Q11VisibleYes.Checked) ? true : false,
                    _Q11ShowHide = (chkboxQ11.Checked) ? true : false,

                    _Q12 = txtQuestion12.Text,
                    _Q12Answer = (Q12VisibleYes.Checked) ? true : false,
                    _Q12ShowHide = (chkboxQ12.Checked) ? true : false,

                };
                if (lblformID.Text == "")
                {              
                    objQuestionair.FormID = Guid.NewGuid();
                    if (obj.insertQuestionair(objQuestionair, "Insert"))
                    {
                        showErrorMessage("Questionair Inserted Successfully.", true);
                        LoadQuestionair(int.Parse(Session["userid"].ToString()));
                    }
                    else
                        showErrorMessage(obj.ErrorString, false);
                }
                else
                {
                    objQuestionair.FormID = Guid.Parse((lblformID.Text));
                    if (obj.UpdateQuestionair(objQuestionair))
                    {
                        showErrorMessage("Questionair Updated Successfully.", true);
                        LoadQuestionair(int.Parse(Session["userid"].ToString()));
                    }
                    else
                        showErrorMessage(obj.ErrorString, false);
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
                obj = new EditQuestionairForm_Controller();
                dt = new DataTable();
                dt = obj.LoadQuestionair(userid);
                int ct = 1;
                string quest = "Q";
                string questAns = "Answer";
                string showHide = "ShowHide";
                string textboxname = "txtQuestion";
                string expAnswer = "Q"+ct+"VisibleYes";


                if (dt != null)
                {
                    if(dt.Rows.Count > 0)
                    {
                        foreach (DataColumn col in dt.Columns)
                        {
                            foreach (DataRow row in dt.Rows)
                            {
                                lblformID.Text = row["formID"].ToString();
                                if (col.ColumnName != "formID" && col.ColumnName != "compantID" && !(col.ColumnName.Contains(questAns)) && !(col.ColumnName.Contains(showHide)))
                                {
                                   TextBox txtbo = (TextBox)PlaceHolder1.FindControl(textboxname + ct.ToString());
                                    RadioButton rdYes = (RadioButton)PlaceHolder1.FindControl("Q" + ct.ToString() + "VisibleYes");
                                    RadioButton rdNo = (RadioButton)PlaceHolder1.FindControl("Q" + ct.ToString() + "VisibleNo");
                                    CheckBox chk = (CheckBox)PlaceHolder1.FindControl("chkboxQ"+ct.ToString());
                                    if (col.ColumnName == quest + ct && txtbo.ID.ToString() == textboxname + ct)
                                    {
                                        txtbo.Text = row[col.ColumnName].ToString();
                                        if(row["Q"+ct.ToString()+ "Answer"].ToString() == "True")  rdYes.Checked = true; else rdNo.Checked = true;

                                        if (row["Q" + ct.ToString() + "ShowHide"].ToString() == "True") chk.Checked = true; else chk.Checked = false;

                                    }
                                    ct++;
                                }
                                
                            }
                        }
                       
                    }
                }
                else
                    showErrorMessage(obj.ErrorString, false);
                
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
    }
}