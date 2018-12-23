using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NFine.Domain._03_Entity.My_ProjManage;
using System.Data.Entity.ModelConfiguration;

namespace NFine.Mapping.My_ProjManage
{
    public class My_projNeedMap:EntityTypeConfiguration<My_ProjNeedInfo>
    {
        public My_projNeedMap()
        {
            this.ToTable("MY_ProjReqInfo");
            this.HasKey(t => t.FID);
        }
    }
}
