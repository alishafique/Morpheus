using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace Controller
{
   
    public class frmManageincidentReportTypes_Controller
    {
        DataTable dt;
        Connection con;
        SqlCommand cmd;
        String strQuery;
        public string ErrorString;
        public frmManageincidentReportTypes_Controller() { }

        public DataTable loadCompanyTypes()
        {
            try
            {
                dt = new DataTable();
                con = new Connection();
                strQuery = "spManageIncidentReportTypes";
                cmd = new SqlCommand(strQuery);
                cmd.Parameters.Add("@Mode", SqlDbType.VarChar).Value = "ViewCompany";
                dt = con.GetDataUsingSp(cmd);
                if (dt != null)
                    return dt;
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
        public DataTable LoadIncidentRptTypes()
        {
            try
            {
                dt = new DataTable();
                con = new Connection();
                strQuery = "spManageIncidentReportTypes";
                cmd = new SqlCommand(strQuery);
                cmd.Parameters.Add("@Mode", SqlDbType.VarChar).Value = "View";
                dt = con.GetDataUsingSp(cmd);
                if (dt != null)
                    return dt;
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


        public bool AddIncidentRptType(string RptType, string RptDescription, string RptCompany)
        {
            try
            {
                con = new Connection();
                strQuery = "spManageIncidentReportTypes";
                cmd = new SqlCommand(strQuery);
                cmd.Parameters.Add("@Mode", SqlDbType.VarChar).Value = "Insert";
                cmd.Parameters.Add("@RptTpye", SqlDbType.VarChar).Value = RptType;
                cmd.Parameters.Add("@RptDescription", SqlDbType.VarChar).Value = RptDescription;
                cmd.Parameters.Add("@RptCompany", SqlDbType.VarChar).Value = RptCompany;
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

        public bool UpdateRptType(int rptId, string Rpttype, string Rptdesc, int comptype)
        {
            try
            {
                con = new Connection();
                strQuery = "spManageIncidentReportTypes";
                cmd = new SqlCommand(strQuery);
                cmd.Parameters.Add("@Mode", SqlDbType.VarChar).Value = "Update";
                cmd.Parameters.Add("@id", SqlDbType.BigInt).Value = rptId;
                cmd.Parameters.Add("@RptTpye", SqlDbType.VarChar).Value = Rpttype;
                cmd.Parameters.Add("@RptDescription", SqlDbType.VarChar).Value = Rptdesc;
                cmd.Parameters.Add("@RptCompany", SqlDbType.BigInt).Value = comptype;
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

        public bool DeleteRptType(int RptId)
        {
            try
            {
                con = new Connection();
                strQuery = "spManageIncidentReportTypes";
                cmd = new SqlCommand(strQuery);
                cmd.Parameters.Add("@Mode", SqlDbType.VarChar).Value = "Delete";
                cmd.Parameters.Add("@id", SqlDbType.BigInt).Value = RptId;
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

    }
}
