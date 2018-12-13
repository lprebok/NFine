using NFine.Domain._01_Infrastructure.IMy_ProjMange;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFine.Domain._03_Entity.My_ProjManage
{
    public class MY_ProjInfo: IMyEntity<MY_ProjInfo>,ICreate,IModify,IDelete
    {
        public int FID { get; set; }
        public string FProCode { get; set; }
        public string FName { get; set; }
        public string Fdesc { get; set; }
        public DateTime FStarDate { get; set; }
        public DateTime FEndDate { get; set; }
        public string Fmaster { get; set; }

        public string FWritePeople { get; set; }
        public DateTime? FWriteDate { get; set; }
        public int FCheckFlag { get; set; }
        public string FCheckPeople { get; set; }
        public DateTime? FCheckDate { get; set; }
        public int FCancelFlag { get; set; }
        public string FCancelPeople { get; set; }
        public DateTime? FCancelDate { get; set; }
    }
}
