using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace NFine.Domain._04_IRepository.My_ProjManage
{
    public interface IMyCommonFuncRepository
    {
        /// <summary>
        /// 获取人员信息
        /// </summary>
        /// <returns></returns>
        DataTable GetPersonList();

        string GetWeeks(DateTime dtStarDate, DateTime dtEndDate);



    }
}
