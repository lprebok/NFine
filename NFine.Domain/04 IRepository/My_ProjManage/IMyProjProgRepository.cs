using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NFine.Domain._03_Entity.My_ProjManage;
using System.Threading.Tasks;
using NFine.Data;
using NFine.Domain.Entity.SystemManage;
using System.Data;

namespace NFine.Domain._04_IRepository.My_ProjManage
{
    public interface IMyProjProgRepository: IRepositoryBase<MyProjProgEntity>
    {
        void SubmitForm(MyProjProgEntity userEntity, UserLogOnEntity userLogOnEntity, string keyValue);
        string DeleteInfo(string strBill);
        /// <summary>
        /// 验证单据是否已经审核
        /// </summary>
        /// <param name="strBill"></param>
        /// <returns></returns>
        string BillIsChecked(string strBill);
        DataTable GetProjList(string dtStar, string dtEnd, string KeyWorl = "");
    }
}
