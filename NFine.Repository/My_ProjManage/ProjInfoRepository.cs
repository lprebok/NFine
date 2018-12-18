using System;
using NFine.Data;
using System.Data.Common;
using System.Data.SqlClient;
using NFine.Domain._04_IRepository.My_ProjManage;
using NFine.Domain._03_Entity.My_ProjManage;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NFine.Domain.Entity.SystemManage;
using NFine.Code;

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
            SqlParameter[] para = { new SqlParameter("@Bill",System.Data.SqlDbType.VarChar) };
            para[0].Value = strBill;
            base.UpdateCheck(@"update MY_ProjInfo set FCancelFlag=1 where FID=@Bill", para);
            //using (var db = new RepositoryBase())
            //{
            //    db.Delete<MY_ProjInfo>(t => t.FID == strBill);
            //}
            return strInfo;
        }

        public void SubmitForm(MY_ProjInfo userEntity, UserLogOnEntity userLogOnEntity, string keyValue)
        {
            using (var db = new RepositoryBase().BeginTrans())
            {
                if (!string.IsNullOrEmpty(keyValue))
                {
                    db.Update(userEntity);
                }
                else
                {
                    userLogOnEntity.F_Id = userEntity.FID.ToString();
                    userLogOnEntity.F_UserId = userEntity.FWritePeople;
                    userLogOnEntity.F_UserSecretkey = Md5.md5(Common.CreateNo(), 16).ToLower();
                    //userLogOnEntity.F_UserPassword = Md5.md5(DESEncrypt.Encrypt(Md5.md5(userLogOnEntity.F_UserPassword, 32).ToLower(), userLogOnEntity.F_UserSecretkey).ToLower(), 32).ToLower();
                    db.Insert(userEntity);
                    db.Insert(userLogOnEntity);
                }
                db.Commit();
            }
        }








    }
}
