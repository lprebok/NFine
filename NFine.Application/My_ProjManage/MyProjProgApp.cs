using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NFine.Domain._03_Entity.My_ProjManage;
using NFine.Domain._04_IRepository.My_ProjManage;
using NFine.Repository.My_ProjManage;
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
        private ModuleApp moduleApp = new ModuleApp();
        private ModuleButtonApp moduleButtonApp = new ModuleButtonApp();

        public List<MyProjProgEntity> GetList(string keyword = "")
        {
            SqlParameter[] para = { new SqlParameter("@Para", SqlDbType.VarChar) };
            para[0].Value = keyword == null ? "" : keyword;
            return myService.FindList("SELECT mppm.FCode ,mppm.FBillNO ,mppm.FWeek ,mppm.FProCode ,mppm.FLastBill ,mppm.FStarDate ,mppm.FEndDate ," +
            " mppm.FThisWorkContent, mppm.FNextWorkPlan, mppm2.FThisWorkContent AS FThisWeekGoal " +
            " FROM dbo.MY_ProjProgressMain AS mppm " +
            " LEFT JOIN dbo.MY_ProjProgressMain AS mppm2 ON mppm2.FCode = mppm.FCode AND mppm2.FLastBill = mppm.FBillNO AND mppm2.FCancelFlag = 0" +
            " ", para);
        }

        public MyProjProgEntity GetEntity(string strKeyValue)
        {
            return myService.FindEntity(strKeyValue);
        }

        public void DeleteForm(string keyValue)
        {
            myService.DeleteInfo(keyValue);
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
