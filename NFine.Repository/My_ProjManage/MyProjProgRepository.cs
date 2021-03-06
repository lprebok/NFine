﻿using NFine.Code;
using NFine.Data;
using NFine.Data.Repository;
using NFine.Domain._03_Entity.My_ProjManage;
using NFine.Domain._03_Entity.My_ProjManage.QueryEntity;
using NFine.Domain._04_IRepository.My_ProjManage;
using NFine.Domain.Entity.SystemManage;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFine.Repository.My_ProjManage
{
    public class MyProjProgRepository:RepositoryBase<MyProjProgEntity>,IMyProjProgRepository
    {
        private ISqlHelper sp = new SqlHelper();
        public string InsertLog(MyProjProgEntity myEntity)
        {
            string strInfo = "";
            myEntity.Create();
            myEntity.FBillNO = myEntity.FID;
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

        public void SubmitForm(MyProjProgEntity userEntity, UserLogOnEntity userLogOnEntity, string keyValue)
        {
            using (var db = new RepositoryBase().BeginTrans())
            {
                if (!string.IsNullOrEmpty(keyValue))
                {
                    db.Update(userEntity);
                }
                else
                {
                    userEntity.Create();
                    userEntity.FBillNO = userEntity.FID;
                    string tmpstrWeek = GetWeeks(userEntity.FStarDate, userEntity.FEndDate);
                    userEntity.FWeek = int.Parse(tmpstrWeek==""?"0":tmpstrWeek);
                    userEntity.FLastBill = GetLastBill(userEntity.FStarDate, userEntity.FEndDate,userEntity.FCode);
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
        /// 获取日期是第几周
        /// </summary>
        /// <param name="dtStarDate"></param>
        /// <param name="dtEndDate"></param>
        /// <returns></returns>
        private string GetWeeks(DateTime dtStarDate, DateTime dtEndDate)
        {
            string strWeeks = "";
            SqlParameter[] para = { new SqlParameter("@StarDate", SqlDbType.DateTime),
                                    new SqlParameter("@EndDate",SqlDbType.DateTime)};
            para[0].Value = dtStarDate;
            para[1].Value = dtEndDate;
            ISqlHelper sp = new SqlHelper();
            strWeeks = sp.ExecuteScalar(CommandType.StoredProcedure, "MY_Base_GetWeekOfDay", para).ToString();
            return strWeeks; 
        }

        /// <summary>
        /// 获取上条单据的记录
        /// </summary>
        /// <param name="dtStarDate"></param>
        /// <param name="dtEndDate"></param>
        /// <param name="strFCode"></param>
        /// <returns></returns>
        private string GetLastBill(DateTime dtStarDate, DateTime dtEndDate, string strFCode)
        {
            string strLastBill = "";
            SqlParameter[] para = { new SqlParameter("@StarDate", SqlDbType.DateTime),
                                    new SqlParameter("@EndDate",SqlDbType.DateTime),
                                    new SqlParameter("@FCode",SqlDbType.VarChar)};
            para[0].Value = dtStarDate;
            para[1].Value = dtEndDate;
            para[2].Value = strFCode;
            ISqlHelper sp = new SqlHelper();
            strLastBill = sp.ExecuteScalar(CommandType.StoredProcedure, "MY_ProjProg_GetLastBill", para).ToString();
            return strLastBill;
        }

        /// <summary>
        /// 作废单据
        /// </summary>
        /// <param name="strBill"></param>
        /// <returns></returns>
        public string DeleteInfo(string strBill)
        {
            string strInfo = "";
            SqlParameter[] para = { new SqlParameter("@Bill", System.Data.SqlDbType.VarChar) };
            para[0].Value = strBill;
            base.UpdateCheck(@"UPDATE dbo.MY_ProjProgressMain SET FCancelFlag=1 where FID=@Bill", para);
            //using (var db = new RepositoryBase())
            //{
            //    db.Delete<MY_ProjInfo>(t => t.FID == strBill);
            //}
            return strInfo;
        }

        /// <summary>
        /// 验证是否存在
        /// </summary>
        /// <param name="strBill"></param>
        /// <returns></returns>
        public string BillIsChecked(string strBill)
        {
            string strInfo = "";
            MyProjProgEntity mppEntity = FindEntity(t => t.FBillNO == strBill && t.FCheckFlag == 1);
            if (mppEntity==null||string.IsNullOrWhiteSpace(mppEntity.FBillNO) == true)
            {
                strInfo = "0";
            }
            else
            {
                strInfo = "1";
            }
            return strInfo;
        }

        public DataTable GetProjList(string dtStar, string dtEnd, string KeyWorld = "")
        {
            SqlParameter[] para = { new SqlParameter("@FKeyWorld",SqlDbType.VarChar),
                                    new SqlParameter("@FStarDate",SqlDbType.DateTime),
                                    new SqlParameter("@FEndDate",SqlDbType.DateTime)};
            para[0].Value = string.IsNullOrWhiteSpace(KeyWorld)==true?"":KeyWorld;
            para[1].Value = DateTime.Parse(string.IsNullOrEmpty(dtStar)==true?DateTime.Now.AddDays(-7).ToShortDateString():dtStar);
            para[2].Value = DateTime.Parse(string.IsNullOrEmpty(dtEnd) == true ? DateTime.Now.ToShortDateString() : dtEnd);
            return sp.ExecuteReturnDataTable(CommandType.Text, "SELECT mppm.FCode ,mppm.FBillNO ,mppm.FWeek ,mppm.FProCode ,mpi.FName AS FProName ," +
            " mppm.FLastBill ,mppm.FStarDate ,mppm.FEndDate ,mu.FName AS FUserName ," +
            " mppm.FThisWorkContent, mppm.FNextWorkPlan, mppm2.FThisWorkContent AS FThisWeekGoal,mppm.FCheckFlag " +
            " FROM dbo.MY_ProjProgressMain AS mppm " +
            " LEFT JOIN dbo.MY_ProjProgressMain AS mppm2 ON mppm2.FCode = mppm.FCode AND mppm.FLastBill = mppm2.FBillNO AND mppm2.FCancelFlag = 0 " +
            " LEFT JOIN dbo.MY_ProjInfo AS mpi ON mpi.FProCode=mppm.FProCode " +
            " LEFT JOIN dbo.MY_User AS mu ON mu.FCode=mppm.FCode " +
            " WHERE mppm.FCancelFlag=0 AND (mpi.FName LIKE '%'+@FKeyWorld+'%' OR mu.FName LIKE '%'+@FKeyWorld+'%')" +
            " AND mppm.FStarDate>=@FStarDate AND mppm.FEndDate<=@FEndDate", para);
        }


    }
}
