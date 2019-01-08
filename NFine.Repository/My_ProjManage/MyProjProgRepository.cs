using NFine.Code;
using NFine.Data;
using NFine.Domain._03_Entity.My_ProjManage;
using NFine.Domain._04_IRepository.My_ProjManage;
using NFine.Domain.Entity.SystemManage;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFine.Repository.My_ProjManage
{
    public class MyProjProgRepository:RepositoryBase<MyProjProgEntity>,IMyProjProgRepository
    {
        public void SubmitForm(MyProjProgEntity userEntity, UserLogOnEntity userLogOnEntity, string keyValue)
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
        /// <summary>
        /// 作废单据
        /// </summary>
        /// <param name="strBill"></param>
        /// <returns></returns>
        public string DeleteInfo(string strBill)
        {
            string strInfo = "";
            SqlParameter[] para = { new SqlParameter("@Bill", System.Data.SqlDbType.VarChar) };
            para[0].Value = strBill;
            base.UpdateCheck(@"UPDATE dbo.MY_ProjProgressMain SET FCancelFlag=1 where FID=@Bill", para);
            //using (var db = new RepositoryBase())
            //{
            //    db.Delete<MY_ProjInfo>(t => t.FID == strBill);
            //}
            return strInfo;
        }

    }
}
