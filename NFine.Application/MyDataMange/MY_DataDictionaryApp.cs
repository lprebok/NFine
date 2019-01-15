using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NFine.Data;
using NFine.Domain._03_Entity.MyDataManage;
using NFine.Domain._04_IRepository.MyDataMange;
using NFine.Repository.MyDataMange;

namespace NFine.Application.MyDataMange
{
    public class MY_DataDictionaryApp
    {
        IMY_DataDictionaryRepository myService = new MY_DataDictionaryRepository();

        public List<MY_DataDictionaryEntity> GetEntityList()
        {
            return myService.IQueryable().ToList();
        }





    }
}
