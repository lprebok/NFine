using NFine.Data;
using NFine.Domain._03_Entity.My_ProjManage.QueryEntity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFine.Domain._04_IRepository.My_ProjManage.IQueryRepository
{
    public interface IMyProgProgQueryRepository:IRepositoryBase<MyProjProgListEntity>
    {
        List<MyProjProgListEntity> GetList(string keyword = "");
        DataTable GetProjList(string KeyWorl = "");
    }
}
