using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NFine.Data;
using NFine.Domain._04_IRepository.My_ProjManage;
using NFine.Domain._03_Entity.My_ProjManage;
using System.Data;
using NFine.Domain.Entity.SystemManage;
using NFine.Code;
using NFine.Data.Repository;

namespace NFine.Repository.My_ProjManage
{
    public class MyNeedCheckProjRepository:RepositoryBase<MyNeedCheckProjEntity>, IMyNeedCheckProjRepository
    {
        IMyCommonFuncRepository myCommService = new MyCommonFuncRepository();
        ISqlHelper sqlHelpService = new SqlHelper();
        public string InsertLog(MyNeedCheckProjEntity myEntity)
        {
            string strInfo = "";
            myEntity.Create();
            try
            {
                strInfo = new RepositoryBase().Insert(myEntity) == 1 ? "保存成功！" : "保存失败！";
            }
            catch (Exception err)
            {
                strInfo = err.Message;
            }
            return strInfo;
        }

        public void SubmitForm(MyNeedCheckProjEntity userEntity, UserLogOnEntity userLogOnEntity, string keyValue)
        {
            using (var db = new RepositoryBase().BeginTrans())
            {
                if (string.IsNullOrWhiteSpace(userEntity.FFinshInfo) == true)
                {
                    userEntity.FFinshInfo = "";
                }
                if (!string.IsNullOrEmpty(keyValue))
                {
                    userEntity.FID = keyValue;
                    db.Update(userEntity);
                }
                else
                {
                    userEntity.Create();
                    //userEntity.FBillNO = userEntity.FID;
                    string tmpstrWeek = myCommService.GetWeeks(userEntity.FStarDate, userEntity.FEndDate);
                    userEntity.FWeek = int.Parse(tmpstrWeek == "" ? "0" : tmpstrWeek);
                    userLogOnEntity.F_Id = userEntity.FID.ToString();
                    userLogOnEntity.F_UserId = userEntity.FWritePeople;
                    userLogOnEntity.F_UserSecretkey = Md5.md5(Common.CreateNo(), 16).ToLower();
                    //userLogOnEntity.F_UserPassword = Md5.md5(DESEncrypt.Encrypt(Md5.md5(userLogOnEntity.F_UserPassword, 32).ToLower(), userLogOnEntity.F_UserSecretkey).ToLower(), 32).ToLower();
                    db.Insert(userEntity);
                    db.Insert(userLogOnEntity);
                }
                db.Commit();
            }
        }

        /// <summary>
        /// 验证是否存在
        /// </summary>
        /// <param name="strBill"></param>
        /// <returns></returns>
        public string BillIsChecked(string strBill)
        {
            string strInfo = "";
            MyNeedCheckProjEntity mppEntity = FindEntity(t => t.FID == strBill && t.FCheckFlag == 1);
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

        public DataTable GetProjList(string dtStarDate, string dtEndDate)
        {
            string strCmd = " SELECT mncp.FID,mncp.FWeek ,mncp.FStarDate ,mncp.FEndDate ,mncp.FPlanContent ,mncp.FFinshInfo ,mncp.FCheckFlag" +
            " FROM dbo.MY_NeedCheckProject AS mncp "+
            " WHERE mncp.FCancelFlag = 0 AND mncp.FStarDate >= @StarDate AND mncp.FEndDate <= @EndDate";
            SqlParameter[] para = { new SqlParameter("@StarDate",SqlDbType.DateTime),
                                    new SqlParameter("@EndDate",SqlDbType.DateTime)};
            para[0].Value = DateTime.Parse(string.IsNullOrWhiteSpace(dtStarDate)==true?DateTime.Now.AddDays(-7).ToShortDateString():dtStarDate);
            para[1].Value= DateTime.Parse(string.IsNullOrWhiteSpace(dtEndDate) == true ? DateTime.Now.AddDays(-7).ToShortDateString() : dtEndDate);
            return sqlHelpService.ExecuteReturnDataTable(CommandType.Text,strCmd,para);
        }

        public string CheckOrUnCheck(string strBillNO, int iCheckFlag)
        {
            string strResult = "";
            OperatorModel cuModel = OperatorProvider.Provider.GetCurrent();
            string strSqlCmd = "";
            if (iCheckFlag == 0 || iCheckFlag == 1)
            {
                strSqlCmd = " UPDATE dbo.MY_NeedCheckProject SET FCheckFlag=@CheckFlag, " +
                    "FCheckPeople=@FPeople,FCheckDate=GETDATE() WHERE FID=@BillNO ";
                SqlParameter[] para = { new SqlParameter("@CheckFlag",SqlDbType.Int),
                                        new SqlParameter("@FPeople",SqlDbType.VarChar),
                                        new SqlParameter("@BillNO",SqlDbType.VarChar)};
                para[0].Value = iCheckFlag;
                para[1].Value = cuModel.UserCode;
                para[2].Value = strBillNO;
                sqlHelpService.ExecuteScalar(CommandType.Text, strSqlCmd, para);
            }
            else
            {
                strSqlCmd = " UPDATE dbo.MY_NeedCheckProject SET FCancelFlag=1,FCancelPeople=@FPeople,FCancelDate=GETDATE() " +
                    " WHERE FID=@BillNO ";
                SqlParameter[] para = { new SqlParameter("@FPeople",SqlDbType.VarChar),
                                        new SqlParameter("@BillNO",SqlDbType.VarChar)};
                para[0].Value = cuModel.UserCode;
                para[1].Value = strBillNO;
                sqlHelpService.ExecuteScalar(CommandType.Text, strSqlCmd, para);
            }
            strResult = iCheckFlag == 0 ? "反审核" : iCheckFlag == 1 ? "审核" : "作废" + "成功！";
            return strResult;
        }



    }
}
