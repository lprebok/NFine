using System;
using NFine.Data;
using NFine.Domain._04_IRepository.My_ProjManage;
using NFine.Domain._03_Entity.My_ProjManage;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFine.Repository.My_ProjManage
{
    public class ProjInfoRepository:RepositoryBase<MY_ProjInfo>,IMyProjRepository
    {
        public string InsertLog(MY_ProjInfo myEntity)
        {
            string strInfo = "";
            myEntity.Create();
            try
            {
                strInfo = new RepositoryBase().Insert(myEntity) == 1 ? "保存成功！" : "保存失败！";
            }
            catch (Exception err)
            {
                strInfo = err.Message;
            }
            return strInfo;
        }

        public string UpdateInfo(MY_ProjInfo myEntity)
        {
            string strInfo = "";

            return strInfo;
        }

        public string CheckInfo(string strBill)
        {
            string strInfo = "";

            return strInfo;
        }

        public string DeleteInfo(string strBill)
        {
            string strInfo = "";

            return strInfo;
        }
    }
}
