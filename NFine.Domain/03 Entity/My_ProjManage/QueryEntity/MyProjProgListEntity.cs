using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFine.Domain._03_Entity.My_ProjManage.QueryEntity
{
    public class MyProjProgListEntity
    {
        public string FBillNO { get; set; }
        public string FCode { get; set; }
        public string FProCode { get; set; }
        public string FProName { get; set; }
        public string FLastBill { get; set; }
        public int FWeek { get; set; }
        public DateTime FStarDate { get; set; }
        public DateTime FEndDate { get; set; }
        public string FThisWeekGoal { get; set; }
        public string FThisWorkContent { get; set; }
        public string FNextWorkPlan { get; set; }


    }
}
