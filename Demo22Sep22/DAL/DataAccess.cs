using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interface;
using Microsoft.Extensions.Configuration;

namespace DAL
{
    public class DataAccess:IDataAccess
    {
        SqlConnection mycon;
        private readonly IConfiguration configuration;
        public DataAccess(IConfiguration _configuration)
        {
            configuration = _configuration;
        }
       

        // This function is used for Open the Connection
        void OpenConnection()
        {
            if (mycon == null)
            {
                mycon = new SqlConnection(configuration.GetConnectionString("SqlConnString"));
            }
            if (mycon.State == ConnectionState.Closed)
            {
                mycon.Open();
            }
        }

        /************************************************************************************************/
        // This function is used for Close the connection
        void CloseConnection()
        {
            if (mycon != null)
            {
                if (mycon.State == ConnectionState.Open)
                {
                    mycon.Close();

                }
            }
        }

        public DataSet GetDataSet(string ProcNameORQuery, CommandType commandType, SqlParameter[] mySqlParam = null)
        {
            DataSet myds = new DataSet();
            OpenConnection();
            SqlCommand mycmd = new SqlCommand();
            mycmd.CommandType = commandType;
            mycmd.Connection = mycon;
            mycmd.CommandText = ProcNameORQuery;
            mycmd.CommandTimeout = 5 * 60;
            if (mySqlParam != null)
                mycmd.Parameters.AddRange(mySqlParam);
            SqlDataAdapter myda = new SqlDataAdapter(mycmd);
            myda.Fill(myds);
            CloseConnection();
            return myds;
        }

        public DataTable GetDataTable(string ProcNameORQuery, CommandType commandType, SqlParameter[] mySqlParam = null)
        {
            DataTable mydt = new DataTable();
            OpenConnection();
            SqlCommand mycmd = new SqlCommand();
            mycmd.CommandType = commandType;
            mycmd.Connection = mycon;
            mycmd.CommandText = ProcNameORQuery;
            mycmd.CommandTimeout = 5 * 60;
            if (mySqlParam != null)
                mycmd.Parameters.AddRange(mySqlParam);
            SqlDataAdapter myda = new SqlDataAdapter(mycmd);
            myda.Fill(mydt);
            CloseConnection();
            return mydt;
        }

        /**********************************************************************************/

        //In this function we will pass sqlParameters array from business logic and 
        //In this way it would be used reusable and any parameters and any value we can pass
        //in this function
        //This function is also used for any DMLQuery(Insert,Update,Delete)

        public int ExecuteDMLQuery(string ProcNameORQuery, CommandType commandType, SqlParameter[] mySqlParam = null)
        {
            OpenConnection();
            SqlCommand mycmd = new SqlCommand();
            mycmd.CommandType = commandType;
            mycmd.Connection = mycon;
            mycmd.CommandText = ProcNameORQuery;
            mycmd.CommandTimeout = 6 * 60;
            if (mySqlParam != null)
                mycmd.Parameters.AddRange(mySqlParam);
            //HttpContext.Current.Response.Write("Ya i m here ");    
            int retvalue = mycmd.ExecuteNonQuery();
            // here we are checking that return parameter is passed or not 
            // if passed then return the returned value otherwise return affected rows 
            if (mycmd.Parameters.Contains("ReturnValue"))
            {
                retvalue = Convert.ToInt32(mycmd.Parameters["ReturnValue"].Value);
                //HttpContext.Current.Response.Write("ya value is find");    
            }
            mycmd.Cancel();
            mycmd.Dispose();
            CloseConnection();
            return retvalue;
        }

        /*****************************************************************************************************/
        public object ExecuteScaler(string ProcNameORQuery, CommandType commandType, SqlParameter[] mySqlParam = null)
        {
            object retValue;
            OpenConnection();
            SqlCommand mycmd = new SqlCommand();
            mycmd.CommandType = commandType;
            mycmd.Connection = mycon;
            mycmd.CommandText = ProcNameORQuery;
            if (mySqlParam != null)
                mycmd.Parameters.AddRange(mySqlParam);
            retValue = mycmd.ExecuteScalar();
            CloseConnection();
            return retValue;
        }

        public SqlDataReader GetDataReader(string ProcNameORQuery, CommandType commandType, SqlParameter[] mySqlParam = null)
        {
            OpenConnection();
            SqlCommand mycmd = new SqlCommand();
            mycmd.CommandType = commandType;
            mycmd.Connection = mycon;
            mycmd.CommandText = ProcNameORQuery;
            if (mySqlParam != null)
                mycmd.Parameters.AddRange(mySqlParam);
            SqlDataReader mydr = mycmd.ExecuteReader(CommandBehavior.CloseConnection);
            return mydr;
        }

        public string GetCurrectDateTime(string DateTimeFormat)
        {
            string qstr = "SELECT GETDATE()";
            object cDateTime = ExecuteScaler(qstr, CommandType.Text);
            return string.Format("{0:" + DateTimeFormat + "}", cDateTime);
        }

        public string DateConvert(string inputDate)
        {
            string retdate = "";
            if (inputDate == "01/01/1900" || inputDate == null || inputDate == "1/1/1900 12:00:00 AM" || inputDate == "1/1/1900")
            {
                retdate = "";
            }
            else if (inputDate != "")
            {
                string[] c_date1 = inputDate.Split(' ');

                char[] ch = { '/' };
                string[] arrdate = c_date1[0].Split(ch);
                if (arrdate.Length >= 3)
                {
                    if (arrdate[1].Length == 1)
                        arrdate[1] = "0" + arrdate[1];
                    if (arrdate[0].Length == 1)
                        arrdate[0] = "0" + arrdate[0];

                    retdate = arrdate[1] + "/" + arrdate[0] + "/" + arrdate[2];
                }
            }

            return retdate;
        }
    }//end class
}
