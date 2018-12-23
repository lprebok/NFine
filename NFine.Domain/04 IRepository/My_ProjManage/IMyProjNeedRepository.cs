using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NFine.Domain.Entity.SystemManage;
using NFine.Data;
using NFine.Domain._03_Entity.My_ProjManage;

namespace NFine.Domain._04_IRepository.My_ProjManage
{
    public interface IMyProjNeedRepository:IRepositoryBase<My_ProjNeedInfo>
    {

        string InsertLog(My_ProjNeedInfo myEntity);

        string UpdateInfo(My_ProjNeedInfo myEntity);

        string CheckInfo(string strBill);

        string DeleteInfo(string strBill);

        void SubmitForm(My_ProjNeedInfo userEntity, UserLogOnEntity userLogOnEntity, string keyValue);


    }
}
