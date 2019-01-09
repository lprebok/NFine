using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using NFine.Data;
using NFine.Data.Repository;
using NFine.Domain._03_Entity.My_ProjManage;
using NFine.Domain.Entity.SystemManage;

namespace NFine.Domain._04_IRepository.My_ProjManage
{
     public interface IMyNeedCheckProjRepository: IRepositoryBase<MyNeedCheckProjEntity>
    {
        string InsertLog(MyNeedCheckProjEntity myEntity);
        void SubmitForm(MyNeedCheckProjEntity userEntity, UserLogOnEntity userLogOnEntity, string keyValue);
        string BillIsChecked(string strBill);
        string CheckOrUnCheck(string strBillNO, int iCheckFlag);
        DataTable GetProjList(string dtStarDate, string dtEndDate);

    }
}
