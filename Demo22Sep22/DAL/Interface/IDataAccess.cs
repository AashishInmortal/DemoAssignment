using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface
{
    public interface IDataAccess
    {
        DataSet GetDataSet(string ProcNameORQuery, CommandType commandType, SqlParameter[] mySqlParam = null);
        DataTable GetDataTable(string ProcNameORQuery, CommandType commandType, SqlParameter[] mySqlParam = null);
        int ExecuteDMLQuery(string ProcNameORQuery, CommandType commandType, SqlParameter[] mySqlParam = null);
        object ExecuteScaler(string ProcNameORQuery, CommandType commandType, SqlParameter[] mySqlParam = null);
        SqlDataReader GetDataReader(string ProcNameORQuery, CommandType commandType, SqlParameter[] mySqlParam = null);
        string GetCurrectDateTime(string DateTimeFormat);
        string DateConvert(string inputDate);
    }
}
