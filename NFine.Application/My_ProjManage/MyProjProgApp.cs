using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NFine.Code;
using NFine.Domain._03_Entity.My_ProjManage;
using NFine.Domain._03_Entity.My_ProjManage.QueryEntity;
using NFine.Domain._04_IRepository.My_ProjManage;
using NFine.Domain._04_IRepository.My_ProjManage.IQueryRepository;
using NFine.Repository.My_ProjManage;
using NFine.Repository.My_ProjManage.QueryRepository;
using NFine.Data.Repository;
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
        private ISqlHelper sp = new SqlHelper();
        private ModuleApp moduleApp = new ModuleApp();
        private ModuleButtonApp moduleButtonApp = new ModuleButtonApp();

        public List<MyProjProgListEntity> GetList(string keyword = "")
        {
            return QueryService.GetList(keyword);
        }

        public DataTable GetProjList(string dtStar, string dtEnd, string KeyWorld = "")
        {
            return myService.GetProjList(dtStar, dtEnd, KeyWorld);
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

        /// <summary>
        /// 审核、反审核和作废单据
        /// </summary>
        /// <param name="strBillNO"></param>
        /// <param name="iCheckFlag"></param>
        /// <returns></returns>
        public string CheckOrUnCheck(string strBillNO, int iCheckFlag)
        {
            string strResult = "";
            OperatorModel cuModel = (new MyCommonFuncApp()).GetCurrentUser();
            string strSqlCmd = "";
            if (iCheckFlag == 0 || iCheckFlag == 1)
            {
                strSqlCmd = " UPDATE dbo.MY_ProjProgressMain SET FCheckFlag=@CheckFlag, " +
                    "FCheckPeople=@FPeople,FCheckDate=GETDATE() WHERE FBillNO=@BillNO ";
                SqlParameter[] para = { new SqlParameter("@CheckFlag",SqlDbType.Int),
                                        new SqlParameter("@FPeople",SqlDbType.VarChar),
                                        new SqlParameter("@BillNO",SqlDbType.VarChar)};
                para[0].Value = iCheckFlag;
                para[1].Value = cuModel.UserCode;
                para[2].Value = strBillNO;
                sp.ExecuteScalar(CommandType.Text, strSqlCmd, para);
            }
            else
            {
                strSqlCmd = " UPDATE dbo.MY_ProjProgressMain SET FCancelFlag=1,FCancelPeople=@FPeople,FCancelDate=GETDATE() "+
                    " WHERE FBillNO=@BillNO " ;
                SqlParameter[] para = { new SqlParameter("@FPeople",SqlDbType.VarChar),
                                        new SqlParameter("@BillNO",SqlDbType.VarChar)};
                para[0].Value = cuModel.UserCode;
                para[1].Value = strBillNO;
                sp.ExecuteScalar(CommandType.Text, strSqlCmd, para);
            }
            strResult = iCheckFlag==0?"反审核":iCheckFlag==1?"审核":"作废"+"成功！";
            return strResult;
        }

        /// <summary>
        /// 验证单据是否已经审核
        /// </summary>
        /// <param name="strBill"></param>
        /// <returns></returns>
        public string BillIsChecked(string strBill)
        {
            return myService.BillIsChecked(strBill);
        }


    }
}
