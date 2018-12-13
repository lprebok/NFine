using System;
using NFine.Code;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFine.Domain._01_Infrastructure.IMy_ProjMange
{
    public class IMyEntity<TEntity>
    {
        public void Create()
        {
            var entity = this as ICreate;
            entity.FWriteDate = DateTime.Now;
            entity.FCancelDate = DateTime.Now;
            entity.FCheckDate = DateTime.Now;
            entity.FCheckFlag = 0;
            entity.FCancelFlag = 0;
            //var LoginInfo = OperatorProvider.Provider.GetCurrent();
            //if (LoginInfo != null)
            //{
            //    entity.FWritePeople = LoginInfo.UserId;
            //    entity.FCheckPeople = LoginInfo.UserId;
            //    entity.FCancelPeople = LoginInfo.UserId;
            //}
            entity.FWritePeople = "Admin";
            entity.FCheckPeople = "Admin";
            entity.FCancelPeople = "Admin";
        }

        public void Modify(string keyValue)
        {
            var entity = this as IModify;
            entity.FWriteDate = DateTime.Now;
            var LoginInfo = OperatorProvider.Provider.GetCurrent();
            if (LoginInfo != null)
            {
                entity.FWritePeople = LoginInfo.UserId;
            }
        }

        public void Remove()
        {
            var entity = this as IDelete;
            entity.FCancelDate = DateTime.Now;
            entity.FCancelFlag = 1;
            var LoginInfo = OperatorProvider.Provider.GetCurrent();
            if (LoginInfo != null)
            {
                entity.FCancelPeople = LoginInfo.UserId;
            }
        }


    }
}
