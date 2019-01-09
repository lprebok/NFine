using NFine.Domain._03_Entity.My_ProjManage;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFine.Mapping.My_ProjManage
{
    public class MyNeedCheckProjMap:EntityTypeConfiguration<MyNeedCheckProjEntity>
    {
        public MyNeedCheckProjMap()
        {
            this.ToTable("MY_NeedCheckProject");
            this.HasKey(t=>t.FID);
        }
    }
}
