using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace Controller
{

 
    public class Connection
    {
        public string connection_String = System.Configuration.ConfigurationManager.ConnectionStrings["morpheus_db"].ConnectionString;
        DataTable dt;
        public SqlConnection myConnection;
        public SqlDataReader DataReader;
        public SqlDataAdapter dataAdapter;
        public SqlCommand Command;
        public string strError;
        public Connection()
        {
        }

        private Boolean InsertUpdateData(SqlCommand cmd)
        {
            myConnection = new SqlConnection(connection_String);
            cmd.CommandType = CommandType.Text;
            cmd.Connection = myConnection;
            try
            {
                myConnection.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
               // Response.Write(ex.Message);
                return false;
            }
            finally
            {
                myConnection.Close();
                myConnection.Dispose();
            }
        }


        public Boolean InsertUpdateDataUsingSp(SqlCommand cmd)
        {
            myConnection = new SqlConnection(connection_String);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = myConnection;
            try
            {
                myConnection.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                strError = ex.Message;
                return false;
            }
            finally
            {
                myConnection.Close();
                myConnection.Dispose();
            }
        }

        public int InsertUpdateDataUsingSpWithReturn(SqlCommand cmd)
        {
            int i = 0;
            myConnection = new SqlConnection(connection_String);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = myConnection;
            try
            {
                myConnection.Open();
                int modified = Convert.ToInt32(cmd.ExecuteScalar());
                return modified;
            }
            catch (Exception ex)
            {
                strError = ex.Message;
                return i;
            }
            finally
            {
                myConnection.Close();
                myConnection.Dispose();
            }
        }

        public DataTable GetData(SqlCommand cmd)
        {
            dt = new DataTable();
            myConnection = new SqlConnection(connection_String);
            dataAdapter = new SqlDataAdapter();
            cmd.CommandType = CommandType.Text;
            cmd.Connection = myConnection;
            try
            {
                myConnection.Open();
                dataAdapter.SelectCommand = cmd;
                dataAdapter.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                strError = ex.Message;
                return null;
            }
            finally
            {
                myConnection.Close();
                dataAdapter.Dispose();
                myConnection.Dispose();
            }
        }

        public DataTable GetDataUsingSp(SqlCommand cmd)
        {
            dt = new DataTable();
            myConnection = new SqlConnection(connection_String);
            dataAdapter = new SqlDataAdapter();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = myConnection;
            try
            {
                myConnection.Open();
                dataAdapter.SelectCommand = cmd;
                dataAdapter.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                strError = ex.Message;
                return null;
            }
            finally
            {
                myConnection.Close();
                dataAdapter.Dispose();
                myConnection.Dispose();
            }
        }
    }
}
