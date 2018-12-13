using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NFine.Domain._03_Entity.My_ProjManage;
using NFine.Domain._04_IRepository.My_ProjManage;
using NFine.Repository.My_ProjManage;
using System.Threading.Tasks;

namespace NFine.Application.My_ProjManage
{
    public class ProjInfoApp
    {
        public IMyProjRepository myService = new ProjInfoRepository();

        public string InsertProjInfo(MY_ProjInfo myEntity)
        {
            string strInfo = myService.InsertLog(myEntity);
            return strInfo;
        }


    }
}
