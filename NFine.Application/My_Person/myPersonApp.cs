using NFine.Domain.IRepository.SystemManage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NFine.Domain._04_IRepository.my_Person;
using NFine.Repository;

namespace NFine.Application.My_Person
{
    public class myPersonApp
    {
        private ImyPersonRepository service = new myPersonRepository();

        public int AddLog(Domain._03_Entity.MY_Person.myPersonEntity model)
        {
            service.Insert(model); 
            
            return 1;
        }


    }
}
