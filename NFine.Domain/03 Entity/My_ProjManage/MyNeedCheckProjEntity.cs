using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

using System.Threading.Tasks;
using NFine.Domain._01_Infrastructure.IMy_ProjMange;

namespace NFine.Domain._03_Entity.My_ProjManage
{
    public class MyNeedCheckProjEntity:IMyEntity<MyNeedCheckProjEntity>, ICreate, IModify, IDelete
    {
        public string FID { get; set; }
        public DateTime FStarDate { get; set; }
        public DateTime FEndDate { get; set; }
        public int FWeek { get; set; }
        public string FPlanContent { get; set; }
        [DefaultValue("")]
        public string FFinshInfo { get; set; }
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
