using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NFine.Domain._01_Infrastructure.IMy_ProjMange;

namespace NFine.Domain._03_Entity.My_ProjManage
{
    public class MyProjNeedInfoList:IMyEntity<MyProjNeedInfoList>
    {
        public string FID { get; set; }
        /// <summary>
        /// 项目编码
        /// </summary>
        public string FProCode { get; set; }
        public string FProName { get; set; }
        /// <summary>
        /// 项目标题
        /// </summary>
        public string FDesc { get; set; }
        /// <summary>
        /// 项目说明
        /// </summary>
        //public string FDetail { get; set; }
        /// <summary>
        /// 是否完成
        /// </summary>
        public int FIsFinished { get; set; }
        /// <summary>
        /// 需求提出日期
        /// </summary>
        public DateTime FApplyDate { get; set; }
        /// <summary>
        /// 应该完成日期
        /// </summary>
        public DateTime FShouldDate { get; set; }
        /// <summary>
        /// 实际完成日期
        /// </summary>
        public DateTime FActDate { get; set; }
    }
}
