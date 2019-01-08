using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NFine.Data;
using NFine.Data.Repository;
using NFine.Domain._03_Entity.My_ProjManage.QueryEntity;
using NFine.Domain._04_IRepository.My_ProjManage.IQueryRepository;

namespace NFine.Repository.My_ProjManage.QueryRepository
{
    public class MyProjProgQueryRepository: RepositoryBase<MyProjProgListEntity>,IMyProgProgQueryRepository
    {
        ISqlHelper sp = new SqlHelper();
        public List<MyProjProgListEntity> GetList(string keyword = "")
        {
            SqlParameter[] para = { new SqlParameter("@Para", SqlDbType.VarChar) };
            para[0].Value = keyword == null ? "" : keyword;
            return base.FindList("SELECT mppm.FCode ,mppm.FBillNO ,mppm.FWeek ,mppm.FProCode ,mppm.FLastBill ,mppm.FStarDate ,mppm.FEndDate ," +
            " mppm.FThisWorkContent, mppm.FNextWorkPlan, mppm2.FThisWorkContent AS FThisWeekGoal " +
            " FROM dbo.MY_ProjProgressMain AS mppm " +
            " LEFT JOIN dbo.MY_ProjProgressMain AS mppm2 ON mppm2.FCode = mppm.FCode AND mppm2.FLastBill = mppm.FBillNO AND mppm2.FCancelFlag = 0 " +
            " LEFT JOIN dbo.MY_ProjInfo AS mpi ON mpi.FProCode=mppm.FProCode " +
            " ", para);
        }

        public DataTable GetProjList(string KeyWorl = "")
        {
            return sp.ExecuteReturnDataTable(CommandType.Text, "SELECT mppm.FCode ,mppm.FBillNO ,mppm.FWeek ,mppm.FProCode ,mpi.FName AS FProName ,"+
            " mppm.FLastBill ,mppm.FStarDate ,mppm.FEndDate ,mu.FName AS FUserName ," +
            " mppm.FThisWorkContent, mppm.FNextWorkPlan, mppm2.FThisWorkContent AS FThisWeekGoal " +
            " FROM dbo.MY_ProjProgressMain AS mppm " +
            " LEFT JOIN dbo.MY_ProjProgressMain AS mppm2 ON mppm2.FCode = mppm.FCode AND mppm.FLastBill = mppm2.FBillNO AND mppm2.FCancelFlag = 0 " +
            " LEFT JOIN dbo.MY_ProjInfo AS mpi ON mpi.FProCode=mppm.FProCode " +
            " LEFT JOIN dbo.MY_User AS mu ON mu.FCode=mppm.FCode " +
            "  ", null);
        }





    }
}
