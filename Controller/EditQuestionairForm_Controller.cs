using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    public class EditQuestionairForm_Controller
    {
        Connection con;
        DataTable dt;
        string strQuery;
        SqlCommand cmd;
        public string ErrorString;
        public EditQuestionairForm_Controller() { }
        public bool insertQuestionair(QuestionairQ10 obj, string mode)
        {
            try
            {
                con = new Connection();
                strQuery = "spManagequestionair";
                cmd = new SqlCommand(strQuery);
                cmd.Parameters.Add("@Mode", SqlDbType.VarChar).Value = mode;
                cmd.Parameters.Add("@formID", SqlDbType.UniqueIdentifier).Value = obj.FormID;
                cmd.Parameters.Add("@userid", SqlDbType.BigInt).Value = obj.CompantID;

                cmd.Parameters.Add("@Q1", SqlDbType.VarChar).Value = obj._Q1;
                cmd.Parameters.Add("@Q1Answer", SqlDbType.Bit).Value = obj._Q1Answer;
                cmd.Parameters.Add("@Q1ShowHide", SqlDbType.Bit).Value = obj._Q1ShowHide;

                cmd.Parameters.Add("@Q2", SqlDbType.VarChar).Value = obj._Q2;
                cmd.Parameters.Add("@Q2Answer", SqlDbType.Bit).Value = obj._Q2Answer;
                cmd.Parameters.Add("@Q2ShowHide", SqlDbType.Bit).Value = obj._Q2ShowHide;

                cmd.Parameters.Add("@Q3", SqlDbType.VarChar).Value = obj._Q3;
                cmd.Parameters.Add("@Q3Answer", SqlDbType.Bit).Value = obj._Q3Answer;
                cmd.Parameters.Add("@Q3ShowHide", SqlDbType.Bit).Value = obj._Q3ShowHide;

                cmd.Parameters.Add("@Q4", SqlDbType.VarChar).Value = obj._Q4;
                cmd.Parameters.Add("@Q4Answer", SqlDbType.Bit).Value = obj._Q4Answer;
                cmd.Parameters.Add("@Q4ShowHide", SqlDbType.Bit).Value = obj._Q4ShowHide;

                cmd.Parameters.Add("@Q5", SqlDbType.VarChar).Value = obj._Q5;
                cmd.Parameters.Add("@Q5Answer", SqlDbType.Bit).Value = obj._Q5Answer;
                cmd.Parameters.Add("@Q5ShowHide", SqlDbType.Bit).Value = obj._Q5ShowHide;

                cmd.Parameters.Add("@Q6", SqlDbType.VarChar).Value = obj._Q6;
                cmd.Parameters.Add("@Q6Answer", SqlDbType.Bit).Value = obj._Q6Answer;
                cmd.Parameters.Add("@Q6ShowHide", SqlDbType.Bit).Value = obj._Q6ShowHide;

                cmd.Parameters.Add("@Q7", SqlDbType.VarChar).Value = obj._Q7;
                cmd.Parameters.Add("@Q7Answer", SqlDbType.Bit).Value = obj._Q7Answer;
                cmd.Parameters.Add("@Q7ShowHide", SqlDbType.Bit).Value = obj._Q7ShowHide;

                cmd.Parameters.Add("@Q8", SqlDbType.VarChar).Value = obj._Q8;
                cmd.Parameters.Add("@Q8Answer", SqlDbType.Bit).Value = obj._Q8Answer;
                cmd.Parameters.Add("@Q8ShowHide", SqlDbType.Bit).Value = obj._Q8ShowHide;

                cmd.Parameters.Add("@Q9", SqlDbType.VarChar).Value = obj._Q9;
                cmd.Parameters.Add("@Q9Answer", SqlDbType.Bit).Value = obj._Q9Answer;
                cmd.Parameters.Add("@Q9ShowHide", SqlDbType.Bit).Value = obj._Q9ShowHide;

                cmd.Parameters.Add("@Q10", SqlDbType.VarChar).Value = obj._Q10;
                cmd.Parameters.Add("@Q10Answer", SqlDbType.Bit).Value = obj._Q10Answer;
                cmd.Parameters.Add("@Q10ShowHide", SqlDbType.Bit).Value = obj._Q10ShowHide;



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

        public bool UpdateQuestionair(QuestionairQ10 obj)
        {
            try
            {
                con = new Connection();
                strQuery = "spManagequestionair";
                cmd = new SqlCommand(strQuery);
                cmd.Parameters.Add("@Mode", SqlDbType.VarChar).Value = "UpdateQuestionair";
                cmd.Parameters.Add("@formID", SqlDbType.UniqueIdentifier).Value = obj.FormID;

                cmd.Parameters.Add("@Q1", SqlDbType.VarChar).Value = obj._Q1;
                cmd.Parameters.Add("@Q1Answer", SqlDbType.Bit).Value = obj._Q1Answer;
                cmd.Parameters.Add("@Q1ShowHide", SqlDbType.Bit).Value = obj._Q1ShowHide;

                cmd.Parameters.Add("@Q2", SqlDbType.VarChar).Value = obj._Q2;
                cmd.Parameters.Add("@Q2Answer", SqlDbType.Bit).Value = obj._Q2Answer;
                cmd.Parameters.Add("@Q2ShowHide", SqlDbType.Bit).Value = obj._Q2ShowHide;

                cmd.Parameters.Add("@Q3", SqlDbType.VarChar).Value = obj._Q3;
                cmd.Parameters.Add("@Q3Answer", SqlDbType.Bit).Value = obj._Q3Answer;
                cmd.Parameters.Add("@Q3ShowHide", SqlDbType.Bit).Value = obj._Q3ShowHide;

                cmd.Parameters.Add("@Q4", SqlDbType.VarChar).Value = obj._Q4;
                cmd.Parameters.Add("@Q4Answer", SqlDbType.Bit).Value = obj._Q4Answer;
                cmd.Parameters.Add("@Q4ShowHide", SqlDbType.Bit).Value = obj._Q4ShowHide;

                cmd.Parameters.Add("@Q5", SqlDbType.VarChar).Value = obj._Q5;
                cmd.Parameters.Add("@Q5Answer", SqlDbType.Bit).Value = obj._Q5Answer;
                cmd.Parameters.Add("@Q5ShowHide", SqlDbType.Bit).Value = obj._Q5ShowHide;

                cmd.Parameters.Add("@Q6", SqlDbType.VarChar).Value = obj._Q6;
                cmd.Parameters.Add("@Q6Answer", SqlDbType.Bit).Value = obj._Q6Answer;
                cmd.Parameters.Add("@Q6ShowHide", SqlDbType.Bit).Value = obj._Q6ShowHide;

                cmd.Parameters.Add("@Q7", SqlDbType.VarChar).Value = obj._Q7;
                cmd.Parameters.Add("@Q7Answer", SqlDbType.Bit).Value = obj._Q7Answer;
                cmd.Parameters.Add("@Q7ShowHide", SqlDbType.Bit).Value = obj._Q7ShowHide;

                cmd.Parameters.Add("@Q8", SqlDbType.VarChar).Value = obj._Q8;
                cmd.Parameters.Add("@Q8Answer", SqlDbType.Bit).Value = obj._Q8Answer;
                cmd.Parameters.Add("@Q8ShowHide", SqlDbType.Bit).Value = obj._Q8ShowHide;

                cmd.Parameters.Add("@Q9", SqlDbType.VarChar).Value = obj._Q9;
                cmd.Parameters.Add("@Q9Answer", SqlDbType.Bit).Value = obj._Q9Answer;
                cmd.Parameters.Add("@Q9ShowHide", SqlDbType.Bit).Value = obj._Q9ShowHide;

                cmd.Parameters.Add("@Q10", SqlDbType.VarChar).Value = obj._Q10;
                cmd.Parameters.Add("@Q10Answer", SqlDbType.Bit).Value = obj._Q10Answer;
                cmd.Parameters.Add("@Q10ShowHide", SqlDbType.Bit).Value = obj._Q10ShowHide;

                cmd.Parameters.Add("@Q11", SqlDbType.VarChar).Value = obj._Q11;
                cmd.Parameters.Add("@Q11Answer", SqlDbType.Bit).Value = obj._Q11Answer;
                cmd.Parameters.Add("@Q11ShowHide", SqlDbType.Bit).Value = obj._Q11ShowHide;

                cmd.Parameters.Add("@Q12", SqlDbType.VarChar).Value = obj._Q12;
                cmd.Parameters.Add("@Q12Answer", SqlDbType.Bit).Value = obj._Q12Answer;
                cmd.Parameters.Add("@Q12ShowHide", SqlDbType.Bit).Value = obj._Q12ShowHide;

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

        public DataTable LoadQuestionair(int userID)
        {
            try
            {
                dt = new DataTable();
                con = new Connection();
                strQuery = "spManagequestionair";
                cmd = new SqlCommand(strQuery);
                cmd.Parameters.Add("@Mode", SqlDbType.VarChar).Value = "LOADQUESTIONS";
                cmd.Parameters.Add("@userid", SqlDbType.BigInt).Value = userID;
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

    }
}
