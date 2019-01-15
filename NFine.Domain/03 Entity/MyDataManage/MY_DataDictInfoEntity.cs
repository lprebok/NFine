using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NFine.Domain._01_Infrastructure.IMy_ProjMange;

namespace NFine.Domain._03_Entity.MyDataManage
{
    public class MY_DataDictInfoEntity : IMyEntity<MY_DataDictInfoEntity>, ICreate, IModify, IDelete
    {
        public string FID { get; set; }
        public string FTCode { get; set; }
        public string FColCode { get; set; }
        public string FColName { get; set; }
        public string FColType { get; set; }
        public string FDesc { get; set; }
        public string FSortCode { get; set; }
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
