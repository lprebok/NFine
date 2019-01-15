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
using NFine.Data.Repository;

namespace NFine.Application.My_ProjManage
{
    public class My_ProjNeedInfoApp
    {
        public IMyProjNeedRepository myService = new My_projNeedInfoRepository();
        private ModuleApp moduleApp = new ModuleApp();
        private ModuleButtonApp moduleButtonApp = new ModuleButtonApp();
        private ISqlHelper sp = new SqlHelper();

        public List<MyProjNeedInfoList> GetList(string keyword = "")
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
            IMyProjNeedInfoListRepository myProjNeedList = new MyProjNeedInfoListRepository();
            return myProjNeedList.FindList("select mpr.FID,mpr.FProCode,mpi.FName FProName,mpr.FApplyPeople,mpr.FDesc,mpr.FIsFinished," +
                "mpr.FApplyDate,mpr.FShouldDate,mpr.FActDate,mu.FName AS FRecvName " +
                " from MY_ProjReqInfo as mpr " +
                " left join MY_ProjInfo as mpi on mpr.FProCode=mpi.FProCode " +
                " LEFT JOIN dbo.MY_User AS mu ON mu.FCode=mpr.FRecivePeople " +
                " where (mpr.FDesc like '%'+@Para+'%' or mpi.FName like '%'+@Para+'%')" +
                " and mpr.FCancelFlag=0", para);
            
        }

        public DataTable GetEntityList(string strStarDate, string strEndDate, string keyword = "")
        {
            string strCMD = "select mpr.FID,mpr.FProCode,mpi.FName FProName,mpr.FApplyPeople,mpr.FDesc,mpr.FIsFinished," +
                "mpr.FApplyDate,mpr.FShouldDate,mpr.FActDate,mpr.FCheckFlag ,mu.FName AS FRecvName" +
                " from MY_ProjReqInfo as mpr " +
                " left join MY_ProjInfo as mpi on mpr.FProCode=mpi.FProCode " +
                " LEFT JOIN dbo.MY_User AS mu ON mu.FCode=mpr.FRecivePeople " +
                " where (mpr.FDesc like '%'+@FProInfo+'%' or mpi.FName like '%'+@FProInfo+'%') " +
                " AND mpr.FApplyDate>=@StarDate AND mpr.FApplyDate<+@EndDate " +
                " and mpr.FCancelFlag=0";
            SqlParameter[] para = { new SqlParameter("@FProInfo",SqlDbType.VarChar),
                                    new SqlParameter("@StarDate",SqlDbType.DateTime),
                                    new SqlParameter("@EndDate",SqlDbType.DateTime)};
            para[0].Value = keyword;
            para[1].Value = DateTime.Parse(string.IsNullOrWhiteSpace(strStarDate) == true ? DateTime.Now.AddMonths(-1).ToShortDateString() : strStarDate);
            para[2].Value = DateTime.Parse(string.IsNullOrWhiteSpace(strEndDate) == true ? DateTime.Now.ToShortDateString() : strEndDate);
            return myService.GetQueryTable(strCMD,para);
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
            userEntity.FActDate = DateTime.Parse("2030-12-31 23:59:59");
            userEntity.FIsFinished = 0;
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
                strSqlCmd = " UPDATE dbo.MY_ProjReqInfo SET FCheckFlag=@CheckFlag,FCheckPeople=@FPeople,FCheckDate=GETDATE() " +
                    "WHERE FID=@BillNO " ;
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
                strSqlCmd = " UPDATE dbo.MY_ProjReqInfo SET FCancelFlag=1,FCancelPeople=@FPeople,FCancelDate=GETDATE()  " +
                    " WHERE FID=@BillNO ";
                SqlParameter[] para = { new SqlParameter("@FPeople",SqlDbType.VarChar),
                                        new SqlParameter("@BillNO",SqlDbType.VarChar)};
                para[0].Value = cuModel.UserCode;
                para[1].Value = strBillNO;
                sp.ExecuteScalar(CommandType.Text, strSqlCmd, para);
            }
            strResult = iCheckFlag == 0 ? "反审核" : iCheckFlag == 1 ? "审核" : "作废" + "成功！";
            return strResult;
        }

        /// <summary>
        /// 验证单据是否已经审核
        /// </summary>
        /// <param name="strBill"></param>
        /// <returns></returns>
        public string BillIsChecked(string strBill)
        {
            string strInfo = "";
            My_ProjNeedInfo mppEntity = myService.FindEntity(t => t.FID == strBill && t.FCheckFlag == 1);
            if (mppEntity == null || string.IsNullOrWhiteSpace(mppEntity.FID) == true)
            {
                strInfo = "0";
            }
            else
            {
                strInfo = "1";
            }
            return strInfo;
        }

        /// <summary>
        /// 结束需求
        /// </summary>
        /// <param name="strBillNO"></param>
        /// <returns></returns>
        public string EndProjReq(string strBillNO,int iFlag)
        {
            string strInfo = "";
            string strCmd = " UPDATE dbo.MY_ProjReqInfo SET FIsFinished=@iFlag WHERE FID=@BillNO ";
            SqlParameter[] para = { new SqlParameter("@BillNO", SqlDbType.VarChar),
                                    new SqlParameter("@iFlag", SqlDbType.Int)};
            para[0].Value = strBillNO;
            para[1].Value = iFlag;
            try
            {
                sp.ExecuteScalar(CommandType.Text, strCmd, para);
                strInfo = "操作成功！";
            }
            catch(Exception err)
            {
                strInfo = err.Message.ToString();
            }
            return strInfo;
        }




    }
}
