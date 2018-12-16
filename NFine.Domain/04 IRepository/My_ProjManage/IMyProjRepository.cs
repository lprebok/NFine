using System;
using NFine.Data;
using NFine.Domain._03_Entity.My_ProjManage;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NFine.Domain.Entity.SystemManage;

namespace NFine.Domain._04_IRepository.My_ProjManage
{
    public interface IMyProjRepository:IRepositoryBase<MY_ProjInfo>
    {
        string InsertLog(MY_ProjInfo myEntity);

        string UpdateInfo(MY_ProjInfo myEntity);

        string CheckInfo(string strBill);

        string DeleteInfo(string strBill);

        void SubmitForm(MY_ProjInfo userEntity, UserLogOnEntity userLogOnEntity, string keyValue);




    }
}
