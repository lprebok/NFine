using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NFine.Domain._04_IRepository.My_ProjManage;
using NFine.Data.Repository;
using System.Data.SqlClient;

namespace NFine.Repository.My_ProjManage
{
    public class MyCommonFuncRepository:IMyCommonFuncRepository
    {
        private ISqlHelper sp = new SqlHelper();

        /// <summary>
        /// 获取人员信息
        /// </summary>
        /// <returns></returns>
        public DataTable GetPersonList()
        {
            return sp.ExecuteReturnDataTable(CommandType.Text, "SELECT mu.FCode ,mu.FName FROM dbo.MY_User AS mu WHERE mu.FCancelFlag = 0",null);
        }

        public string GetWeeks(DateTime dtStarDate, DateTime dtEndDate)
        {
            string strWeeks = "";
            SqlParameter[] para = { new SqlParameter("@StarDate", SqlDbType.DateTime),
                                    new SqlParameter("@EndDate",SqlDbType.DateTime)};
            para[0].Value = dtStarDate;
            para[1].Value = dtEndDate;
            ISqlHelper sp = new SqlHelper();
            strWeeks = sp.ExecuteScalar(CommandType.StoredProcedure, "MY_Base_GetWeekOfDay", para).ToString();
            return strWeeks;
        }

        public DataTable GetQueryDataTable(string strCMD, SqlParameter[] para)
        {
            ISqlHelper sp = new SqlHelper();
            return sp.ExecuteReturnDataTable(CommandType.Text,strCMD, para);
        }

        public DataSet GetQueryDataSet(string strCMD, SqlParameter[] para)
        {
            ISqlHelper sp = new SqlHelper();
            return sp.ExecuteReturnDataSet(CommandType.Text, strCMD, para);
        }



    }
}
