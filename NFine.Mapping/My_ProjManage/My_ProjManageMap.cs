using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NFine.Domain._03_Entity.My_ProjManage;
using System.Data.Entity.ModelConfiguration;
using System.Threading.Tasks;

namespace NFine.Mapping.My_ProjManage
{
    public class My_ProjManageMap:EntityTypeConfiguration<MY_ProjInfo>
    {
        public My_ProjManageMap()
        {
            this.ToTable("MY_ProjInfo");
            this.HasKey(t => t.FID);
        }
    }
}
