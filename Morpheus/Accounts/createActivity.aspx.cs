﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Controller;
using System.Data;
using System.Globalization;

namespace Morpheus
{
    public partial class createActivity : System.Web.UI.Page
    {
        DataTable dt;
        createActivity_Controller objCreateAct;
        Activity objAct;
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
                            textbox_createdBy.Text = Session["userid"].ToString()+ "-" +Session["UserName"].ToString();
                            loadEmployees();
                            textbox_Status.Text = "Not-Started";
                        }
                        else if(Session["UserTypeID"].ToString() == "4")
                        {
                            textbox_createdBy.Text = Session["userid"].ToString() + "-" + Session["UserName"].ToString();
                            loadEmployees();
                            textbox_Status.Text = "Not-Started";
                        }
                        else
                            Response.Redirect("login.aspx");
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

        private void loadEmployees()
        {
            try
            {
                dt = new DataTable();
                objCreateAct = new createActivity_Controller();
                dt = objCreateAct.listEmployeesByCompany(int.Parse(Session["userid"].ToString()));
                if(dt != null)
                {
                    string _text = "";
                    string _value = "";
                    for(int i =0; i<dt.Rows.Count;i++)
                    {
                        _text = dt.Rows[i]["emp_name"].ToString()+" - "+ dt.Rows[i]["email"].ToString();
                        _value = dt.Rows[i]["UserId"].ToString();//+" - "+ dt.Rows[i]["EmployeeId"].ToString();
                        listEmployees.Items.Add(new ListItem() { Text = _text, Value = _value });
                    }
                }
                else
                {
                    showErrorMessage(objCreateAct.ErrorString, false);
                }

           
            }
            catch (Exception ex)
            {
                showErrorMessage(ex.Message, false);
            }
        }

        private void clearForm()
        {
           //textbox_createdBy.Text = "";
            //Dp_AssignTo.SelectedIndex = 0;
            txtbox_ActivityName.Text = "";
            TextBox_site.Text = "";
            dp_ActivityType.SelectedIndex = 0;
            TextBox_Description.Text = "";
            objAct.activity_Status = "";
            listEmployees.ClearSelection();
        }
        protected void btnAddActivity_Click(object sender, EventArgs e)
        {
            try
            {
                objAct = new Activity();
                objCreateAct = new createActivity_Controller();
                int[] listAssing = new int[listEmployees.Items.Count];
                string[] getID = textbox_createdBy.Text.Split('-');
                string formsArrayURL = "";
                objAct.companyCreatedID = int.Parse(getID[0]);// Created by Company's ID

               // string[] selectAssignedTo = listEmployees.SelectedValue.Split('-');
                //objAct.assigneduserID = int.Parse(selectAssignedTo[0]); // Assigned to Employee's Id
                objAct.activity_Name = txtbox_ActivityName.Text;
                objAct.activity_Location = TextBox_site.Text;
                objAct.activity_Type = dp_ActivityType.SelectedValue;
                objAct.activity_Description = TextBox_Description.Text;
                objAct.activity_Status = textbox_Status.Text;
                objAct.StartDate = startDateTime.Text;

                foreach (ListItem item in cbFormsList.Items)
                {
                    if (item.Selected)
                    {
                        formsArrayURL += item.Value+",";
                    }
                }

                objAct.FormsURL = formsArrayURL.TrimEnd(','); ;
                for (int i = 0; i < listEmployees.Items.Count; i++)
                    {
                        if (listEmployees.Items[i].Selected)
                        {
                        if (objCreateAct.createActivityByCompany(objAct, int.Parse(listEmployees.Items[i].Value)) > 0)
                            showErrorMessage("Activity has been created and assigned to Employee.", true);
                        else
                            showErrorMessage(objCreateAct.ErrorString, false);
                        }
                    }
                    
                    clearForm();
       
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
    }
}