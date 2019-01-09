using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NFine.Domain._03_Entity.My_ProjManage;
using NFine.Domain._04_IRepository.My_ProjManage;
using NFine.Domain.Entity.SystemManage;
using NFine.Repository.My_ProjManage;

namespace NFine.Application.My_ProjManage
{
    public class MyNeedCheckProjApp
    {
        private IMyNeedCheckProjRepository myService = new MyNeedCheckProjRepository();

        public string InsertLog(MyNeedCheckProjEntity myEntity)
        {
            return myService.InsertLog(myEntity);
        }

        public void SubmitForm(MyNeedCheckProjEntity userEntity, UserLogOnEntity userLogOnEntity, string keyValue)
        {
            myService.SubmitForm(userEntity,userLogOnEntity,keyValue);
        }

        public DataTable GetProjList(string dtStarDate, string dtEndDate)
        {
            return myService.GetProjList(dtStarDate,dtEndDate);
        }

        public MyNeedCheckProjEntity GetEntity(string strKeyValue)
        {
            return myService.FindEntity(strKeyValue);
        }





    }
}
