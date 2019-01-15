using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NFine.Domain._03_Entity.MyDataManage;

namespace NFine.Mapping.MyDataMange
{
    public class MY_DataDictInfoMap : EntityTypeConfiguration<MY_DataDictInfoEntity>
    {
        public MY_DataDictInfoMap()
        {
            this.ToTable("MY_DataDictInfo");
            this.HasKey(t => t.FID);
        }
    }
}
