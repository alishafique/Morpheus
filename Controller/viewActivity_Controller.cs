﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Data;
using System.Data.SqlClient;

namespace Controller
{
    public class viewActivity_Controller
    {
        DataTable dt;
        Connection con;
        SqlCommand cmd;
        String strQuery;
        public string ErrorString;
        public viewActivity_Controller() { }

        public DataTable viewActivitiesCreatedByCompany(int comID)
        {
            try
            {
                dt = new DataTable();
                con = new Connection();
                strQuery = "viewActivitiesCreatedByCompany";
                cmd = new SqlCommand(strQuery);
                cmd.Parameters.Add("@companyId", SqlDbType.BigInt).Value = comID;
                dt = con.GetDataUsingSp(cmd);
                if (dt != null)
                {
                    return dt;
                }
                else
                {
                    ErrorString = con.strError;
                    return null;
                }
            }
            catch (Exception ex)
            {
                ErrorString = ex.Message;
                return null;
            }
        }
        public DataTable listEmployeesByCompany(int userID)
        {
            try
            {
                dt = new DataTable();
                con = new Connection();
                strQuery = "listEmployeesByCompany";
                cmd = new SqlCommand(strQuery);
                cmd.Parameters.Add("@userid", SqlDbType.BigInt).Value = userID;
                dt = con.GetDataUsingSp(cmd);
                if (dt != null)
                {
                    return dt;
                }
                else
                {
                    ErrorString = con.strError;
                    return null;
                }
            }
            catch (Exception ex)
            {
                ErrorString = ex.Message;
                return null;
            }
        }

        public bool UpdateActivityByCompany(Activity objAct, int ActivityId)
        {
            try
            {
                con = new Connection();
                strQuery = "UpdateActivityByCompany";
                cmd = new SqlCommand(strQuery);
                cmd.Parameters.Add("@actID", SqlDbType.BigInt).Value = ActivityId;
                cmd.Parameters.Add("@userID", SqlDbType.BigInt).Value = objAct.assigneduserID;
                cmd.Parameters.Add("@Activity_Name", SqlDbType.VarChar).Value = objAct.activity_Name;
                cmd.Parameters.Add("@Activity_Location", SqlDbType.VarChar).Value = objAct.activity_Location;
                cmd.Parameters.Add("@Activity_Type", SqlDbType.DateTime).Value = objAct.activity_Type;
                cmd.Parameters.Add("@Activity_Description", SqlDbType.BigInt).Value = objAct.activity_Description;
                cmd.Parameters.Add("@Activity_Status", SqlDbType.VarChar).Value = objAct.activity_Status;
                
                if (con.InsertUpdateDataUsingSp(cmd) == true)
                    return true;
                else
                {
                    ErrorString = con.strError;
                    return false;
                }
            }
            catch(Exception ex)
            {
                ErrorString = ex.Message;
                return false;
            }
        }

    }
}
