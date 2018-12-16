using NFine.Code;
using NFine.Data;
using NFine.Domain._03_Entity.MY_Person;
using NFine.Domain._03_Entity.My_ProjManage;
using NFine.Domain.Entity.SystemManage;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NFine.Domain._04_IRepository.my_Person
{
    public interface ImyPersonRepository : IRepositoryBase<myPersonEntity>
    {
       

    }
}
