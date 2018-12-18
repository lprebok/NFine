using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NFine.Domain._03_Entity.My_ProjManage;
using NFine.Domain._04_IRepository.My_ProjManage;
using NFine.Repository.My_ProjManage;
using System.Threading.Tasks;
using NFine.Application.SystemManage;
using NFine.Code;
using NFine.Domain.Entity.SystemManage;

namespace NFine.Application.My_ProjManage
{
    public class ProjInfoApp
    {
        public IMyProjRepository myService = new ProjInfoRepository();
        private ModuleApp moduleApp = new ModuleApp();
        private ModuleButtonApp moduleButtonApp = new ModuleButtonApp();

        public List<MY_ProjInfo> GetList(string keyword = "")
        {
            var expression = ExtLinq.True<MY_ProjInfo>();
            if (!string.IsNullOrEmpty(keyword))
            {
                expression = expression.And(t => t.FName.Contains(keyword));
                expression = expression.Or(t => t.FProCode.Contains(keyword));
            }
            expression = expression.And(t => t.FCancelFlag == 0);
            return myService.IQueryable(expression).OrderBy(t => t.FProCode).ToList();
        }
        public string InsertProjInfo(MY_ProjInfo myEntity)
        {
            string strInfo = myService.InsertLog(myEntity);
            return strInfo;
        }
        public void DeleteForm(string keyValue)
        {
            myService.DeleteInfo(keyValue);
        }

        public MY_ProjInfo GetEntity(string strKeyValue)
        {
            return myService.FindEntity(strKeyValue);
        }

        public void SubmitForm(MY_ProjInfo userEntity, UserLogOnEntity userLogOnEntity, string keyValue)
        {
            if (!string.IsNullOrEmpty(keyValue))
            {
                userEntity.Modify(keyValue);
            }
            else
            {
                userEntity.Create();
            }
            myService.SubmitForm(userEntity, userLogOnEntity, keyValue);
        }











    }
}
