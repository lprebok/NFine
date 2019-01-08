using NFine.Domain._01_Infrastructure.IMy_ProjMange;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFine.Domain._03_Entity.My_ProjManage
{
    public class MyProjProgEntity : IMyEntity<MY_ProjInfo>, ICreate, IModify, IDelete
    {
        public string FID { get; set; }
        public string FBillNO { get; set; }
        public string FCode { get; set; }
        public string FProCode { get; set; }
        [NotMapped]
        public string FProName { get; set; }
        public string FLastBill { get; set; }
        public int FWeek { get; set; }
        public DateTime FStarDate { get; set; }
        public DateTime FEndDate { get; set; }
        [NotMapped]
        public string FThisWeekGoal { get; set; }
        public string FThisWorkContent { get; set; }
        public string FNextWorkPlan { get; set; }
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
