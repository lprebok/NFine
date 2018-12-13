using NFine.Domain._01_Infrastructure.IMy_ProjMange;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFine.Domain._03_Entity.MY_Person
{
    public class myPersonEntity : IMyEntity<myPersonEntity>
    {
        //[Column("FID")]
        public int F_Id { get; set; }
        public string FName { get; set; }
        public string FSex { get; set; }
        public int FAge { get; set; }
        public string FAdress { get; set; }

    }
}
