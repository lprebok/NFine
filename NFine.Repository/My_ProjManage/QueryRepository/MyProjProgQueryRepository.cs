using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NFine.Data;
using NFine.Domain._03_Entity.My_ProjManage.QueryEntity;
using NFine.Domain._04_IRepository.My_ProjManage.IQueryRepository;

namespace NFine.Repository.My_ProjManage.QueryRepository
{
    public class MyProjProgQueryRepository:RepositoryBase<MyProjProgListEntity>,IMyProgProgQueryRepository
    {
        public List<MyProjProgListEntity> GetList(string keyword = "")
        {
            SqlParameter[] para = { new SqlParameter("@Para", SqlDbType.VarChar) };
            para[0].Value = keyword == null ? "" : keyword;
            return base.FindList("SELECT mppm.FCode ,mppm.FBillNO ,mppm.FWeek ,mppm.FProCode ,mppm.FLastBill ,mppm.FStarDate ,mppm.FEndDate ," +
            " mppm.FThisWorkContent, mppm.FNextWorkPlan, mppm2.FThisWorkContent AS FThisWeekGoal " +
            " FROM dbo.MY_ProjProgressMain AS mppm " +
            " LEFT JOIN dbo.MY_ProjProgressMain AS mppm2 ON mppm2.FCode = mppm.FCode AND mppm2.FLastBill = mppm.FBillNO AND mppm2.FCancelFlag = 0" +
            " ", para);
        }

    }
}
