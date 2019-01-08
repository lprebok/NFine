using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFine.Data.Repository
{
    public interface ISqlHelper
    {
        DataSet ExecuteReturnDataSet(CommandType cmdType, string cmdText, params SqlParameter[] commandParameters);
        DataTable ExecuteReturnDataTable(CommandType cmdType, string cmdText, params SqlParameter[] commandParameters);
        object ExecuteScalar(CommandType cmdType, string cmdText, params SqlParameter[] commandParameters);
    }
}
