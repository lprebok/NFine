using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NFine.Domain._04_IRepository.My_ProjManage;
using NFine.Data.Repository;

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





    }
}
