using NFine.Domain._03_Entity.MY_Person;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFine.Mapping.my_person
{
    public class myPersonMap:EntityTypeConfiguration<myPersonEntity>
    {
        public myPersonMap()
        {
            this.ToTable("MY_Person");
            this.HasKey(t => t.F_Id);
        }
    }
}
