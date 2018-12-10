using NFine.Data;
using NFine.Domain._03_Entity.MY_Person;
using NFine.Domain._04_IRepository.my_Person;
using NFine.Domain.IRepository.SystemManage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFine.Repository
{
    public class myPersonRepository: RepositoryBase<myPersonEntity>, ImyPersonRepository
    {
       
    }
}
