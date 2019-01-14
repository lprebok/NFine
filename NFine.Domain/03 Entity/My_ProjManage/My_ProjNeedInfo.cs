using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NFine.Domain._01_Infrastructure.IMy_ProjMange;

namespace NFine.Domain._03_Entity.My_ProjManage
{
    public class My_ProjNeedInfo : IMyEntity<My_ProjNeedInfo>, ICreate, IModify, IDelete
    {
        public string FID { get; set; }
        /// <summary>
        /// 项目编码
        /// </summary>
        public string FProCode { get; set; }
        /// <summary>
        /// 项目需求人
        /// </summary>
        public string FApplyPeople { get; set; }
        /// <summary>
        /// 项目标题
        /// </summary>
        public string FDesc { get; set; }
        /// <summary>
        /// 项目说明
        /// </summary>
        public string FDetail { get; set; }
        /// <summary>
        /// 是否完成
        /// </summary>
        public int FIsFinished { get; set; }
        public string FRecivePeople { get; set; }
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
