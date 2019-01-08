using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NFine.Domain._03_Entity.My_ProjManage;
using System.Threading.Tasks;
using NFine.Data;
using NFine.Domain.Entity.SystemManage;

namespace NFine.Domain._04_IRepository.My_ProjManage
{
    public interface IMyProjProgRepository: IRepositoryBase<MyProjProgEntity>
    {
        void SubmitForm(MyProjProgEntity userEntity, UserLogOnEntity userLogOnEntity, string keyValue);
        string DeleteInfo(string strBill);
    }
}
