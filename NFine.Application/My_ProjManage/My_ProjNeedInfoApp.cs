using NFine.Application.SystemManage;
using NFine.Code;
using NFine.Domain._03_Entity.My_ProjManage;
using NFine.Domain._04_IRepository.My_ProjManage;
using NFine.Domain.Entity.SystemManage;
using NFine.Repository.My_ProjManage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace NFine.Application.My_ProjManage
{
    public class My_ProjNeedInfoApp
    {
        public IMyProjNeedRepository myService = new My_projNeedInfoRepository();
        private ModuleApp moduleApp = new ModuleApp();
        private ModuleButtonApp moduleButtonApp = new ModuleButtonApp();

        public List<My_ProjNeedInfo> GetList(string keyword = "")
        {
            //var expression = ExtLinq.True<My_ProjNeedInfo>();
            //if (!string.IsNullOrEmpty(keyword))
            //{
            //    expression = expression.And(t => t.FProCode.Contains(keyword));
            //    expression = expression.Or(t => t.FDesc.Contains(keyword));
            //}
            //expression = expression.And(t => t.FCancelFlag == 0);
            //return myService.IQueryable(expression).OrderBy(t => t.FProCode).ToList();
            SqlParameter[] para = { new SqlParameter("@Para", SqlDbType.VarChar)};
            para[0].Value = keyword==null?"":keyword;
            return myService.FindList("select mpr.FID,mpr.FProCode,mpi.FName FProName,mpr.FDesc,mpr.FIsFinished,mpr.FApplyDate,mpr.FShouldDate," +
                " mpr.FActDate,mpr.FDetail,mpr.FWriteDate,mpr.FWritePeople,"+
                " mpr.FCancelDate, mpr.FCancelFlag, mpr.FCancelPeople, mpr.FCheckDate, mpr.FCheckFlag, mpr.FCheckPeople" +
                " from MY_ProjReqInfo as mpr " +
                " left join MY_ProjInfo as mpi on mpr.FProCode=mpi.FProCode " +
                " where (mpr.FDesc like '%'+@Para+'%' or mpi.FName like '%'+@Para+'%')" +
                " and mpr.FCancelFlag=0", para);
            
        }
        public string InsertProjInfo(My_ProjNeedInfo myEntity)
        {
            string strInfo = myService.InsertLog(myEntity);
            return strInfo;
        }
        public void DeleteForm(string keyValue)
        {
            myService.DeleteInfo(keyValue);
        }

        public My_ProjNeedInfo GetEntity(string strKeyValue)
        {
            return myService.FindEntity(strKeyValue);
        }

        public void SubmitForm(My_ProjNeedInfo userEntity, UserLogOnEntity userLogOnEntity, string keyValue)
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
