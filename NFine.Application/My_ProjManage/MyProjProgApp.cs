using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NFine.Domain._03_Entity.My_ProjManage;
using NFine.Domain._03_Entity.My_ProjManage.QueryEntity;
using NFine.Domain._04_IRepository.My_ProjManage;
using NFine.Domain._04_IRepository.My_ProjManage.IQueryRepository;
using NFine.Repository.My_ProjManage;
using NFine.Repository.My_ProjManage.QueryRepository;
using System.Threading.Tasks;
using NFine.Application.SystemManage;
using System.Data.SqlClient;
using System.Data;
using NFine.Domain.Entity.SystemManage;

namespace NFine.Application.My_ProjManage
{
    public class MyProjProgApp
    {
        public IMyProjProgRepository myService = new MyProjProgRepository();
        private IMyProgProgQueryRepository QueryService = new MyProjProgQueryRepository();
        private IMyCommonFuncRepository mfrService = new MyCommonFuncRepository();
        private ModuleApp moduleApp = new ModuleApp();
        private ModuleButtonApp moduleButtonApp = new ModuleButtonApp();

        public List<MyProjProgListEntity> GetList(string keyword = "")
        {
            return QueryService.GetList(keyword);
        }

        public DataTable GetProjList(string KeyWorld = "")
        {
            return QueryService.GetProjList(KeyWorld);
        }

        public MyProjProgEntity GetEntity(string strKeyValue)
        {
            return myService.FindEntity(strKeyValue);
        }

        public void DeleteForm(string keyValue)
        {
            myService.DeleteInfo(keyValue);
        }

        /// <summary>
        /// 获取人员信息
        /// </summary>
        /// <returns></returns>
        public DataTable GetUserList()
        {
            return mfrService.GetPersonList();
        }

        public void SubmitForm(MyProjProgEntity userEntity, UserLogOnEntity userLogOnEntity, string keyValue)
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
