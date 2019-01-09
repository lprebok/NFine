using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NFine.Data;
using NFine.Code;
using System.Threading.Tasks;

namespace NFine.Application.My_ProjManage
{
    public class MyCommonFuncApp
    {
        /// <summary>
        /// 获取当前登录用户
        /// </summary>
        /// <returns></returns>
        public OperatorModel GetCurrentUser()
        {
            return OperatorProvider.Provider.GetCurrent();
        }






    }
}
