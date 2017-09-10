﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
   public class viewEmployees_Controller
    {
        private DataTable dt;
        private Connection con;
        private string strQuery;
        private SqlCommand cmd;
        public string ErrorString;
        public viewEmployees_Controller()
        { }

        public DataTable viewEmployeeByCompany(int comapnyId)
        {
            try
            {
                dt = new DataTable();
                con = new Connection();
                strQuery = "viewEmployeeByCompany";
                cmd = new SqlCommand(strQuery);
                cmd.Parameters.Add("@createdByCompanyId", SqlDbType.BigInt).Value = comapnyId;
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
            catch(Exception ex)
            {
                ErrorString = ex.Message;
                return null;
            }
        }

        public DataTable employeeProfileByEmployeeID(int userid)
        {
            try
            {
                dt = new DataTable();
                con = new Connection();
                strQuery = "employeeProfileByEmployeeID";
                cmd = new SqlCommand(strQuery);
                cmd.Parameters.Add("@userid", SqlDbType.BigInt).Value = userid;
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

        public DataTable loadAddressByEmployeeId(int employeeId)
        {
            try
            {
                dt = new DataTable();
                con = new Connection();
                strQuery = "loadAddressByEmployeeId";
                cmd = new SqlCommand(strQuery);
                cmd.Parameters.Add("@EmployeeId", SqlDbType.BigInt).Value = employeeId;
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
            catch(Exception ex)
            {
                ErrorString = ex.Message;
                return null;
            }
        }

        public bool UpdateEmployeeProfileByCompany(Employee emp, int employeeId)
        {
            try
            {
                con = new Connection();
                strQuery = "updateEmployeeProfileByCompany";
                cmd = new SqlCommand(strQuery);
                cmd.Parameters.Add("@emp_name", SqlDbType.VarChar).Value = emp.Emp_name;
                cmd.Parameters.Add("@date_of_birth", SqlDbType.Date).Value = emp.Date_of_birth;
                cmd.Parameters.Add("@Address", SqlDbType.VarChar).Value = emp.address;
                cmd.Parameters.Add("@suburb", SqlDbType.VarChar).Value = emp.Suburb;
                cmd.Parameters.Add("@state", SqlDbType.VarChar).Value = emp.State;
                cmd.Parameters.Add("@postcode", SqlDbType.VarChar).Value = emp.Postcode;
                cmd.Parameters.Add("@ABN", SqlDbType.VarChar).Value = emp.A_BN;
                cmd.Parameters.Add("@TFN", SqlDbType.VarChar).Value = emp.T_FN;
                cmd.Parameters.Add("@EmployeeId", SqlDbType.BigInt).Value = employeeId;
                cmd.Parameters.Add("@mobile", SqlDbType.VarChar).Value = emp.Mobile;
                cmd.Parameters.Add("@license", SqlDbType.VarChar).Value = emp.License;
                if (con.InsertUpdateDataUsingSp(cmd) == true)
                    return true;
                else
                {
                    ErrorString = con.strError;
                    return false;
                }

            }
            catch (Exception ex)
            {
                ErrorString = ex.Message;
                return false;
            }

        }

        public bool updateStatusOfEmployeeByCompany(int userId, int stat)
        {
            try
            {
                con = new Connection();
                strQuery = "updateStatusOfEmployeeByCompany";
                cmd = new SqlCommand(strQuery);
                cmd.Parameters.Add("@user_id", SqlDbType.BigInt).Value = userId;
                cmd.Parameters.Add("@status", SqlDbType.Int).Value = stat;
                if(con.InsertUpdateDataUsingSp(cmd) == true)
                {
                    return true;
                }
                else
                {
                    ErrorString = con.strError;
                    return false;
                }

            }
            catch (Exception ex)
            {
                ErrorString = ex.Message;
                return false;
            }
        }

        public bool deleteEmployeeByCompany(int userId)
        {
            try
            {
                con = new Connection();
                strQuery = "deleteEmployeeByCompany";
                cmd = new SqlCommand(strQuery);
                cmd.Parameters.Add("@UserId", SqlDbType.BigInt).Value = userId;
                if (con.InsertUpdateDataUsingSp(cmd) == true)
                {
                    return true;
                }
                else
                {
                    ErrorString = con.strError;
                    return false;
                }

            }
            catch (Exception ex)
            {
                ErrorString = ex.Message;
                return false;
            }
        }
    }
}
