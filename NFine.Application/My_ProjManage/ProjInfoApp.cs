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
using System.Data;
using System.Data.SqlClient;

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
            myEntity.FEndDate = DateTime.Parse("2030-12-31 23:59:59");
            myEntity.FEndFlag = 0;
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
            userEntity.FEndDate = DateTime.Parse("2030-12-31 23:59:59");
            userEntity.FEndFlag = 0;
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

        public DataTable GetProList(string dtStar, string dtEnd,string keyword = "")
        {
            string strCmd = "SELECT mpi.FID ,mpi.FProCode ,mpi.FName ,mpi.FDesc ,mpi.FProType ,mpbd.FName AS FProTypeInfo,"+
                " mpi.FStarDate ,mpi.FEndDate ,mpi.FEndFlag ,mpi.FMaster ,mpi.FCheckFlag "+
                " FROM dbo.MY_ProjInfo AS mpi " +
                " LEFT JOIN dbo.MY_ProBaseData AS mpbd ON mpbd.FCode = mpi.FProType AND mpbd.FType = 'MY0001' " +
                " WHERE(mpi.FProCode LIKE '%' + @FProInfo + '%' OR mpi.FName LIKE '%' + @FProInfo + '%') " +
                " AND mpi.FStarDate >= @StarDate AND mpi.FStarDate <= @EndDate AND mpi.FCancelFlag = 0";
            SqlParameter[] para = { new SqlParameter("@FProInfo",SqlDbType.VarChar),
                                    new SqlParameter("@StarDate",SqlDbType.DateTime),
                                    new SqlParameter("@EndDate",SqlDbType.DateTime)};
            para[0].Value = keyword;
            para[1].Value = DateTime.Parse(string.IsNullOrWhiteSpace(dtStar)==true?DateTime.Now.AddMonths(-1).ToShortDateString():dtStar);
            para[2].Value = DateTime.Parse(string.IsNullOrWhiteSpace(dtEnd) == true ? DateTime.Now.ToShortDateString() : dtEnd);
            return myService.GetQueryTable(strCmd,para);
        }









    }
}
