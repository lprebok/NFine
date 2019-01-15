using NFine.Domain._03_Entity.MyDataManage;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFine.Mapping.MyDataMange
{
    public class MY_DataDictionaryMap : EntityTypeConfiguration<MY_DataDictionaryEntity>
    {
        public MY_DataDictionaryMap()
        {
            this.ToTable("MY_DataDictionary");
            this.HasKey(t=>t.FID);
        }
    }
}
