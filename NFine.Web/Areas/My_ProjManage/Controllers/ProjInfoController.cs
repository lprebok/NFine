using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.Mvc;
using NFine.Domain._03_Entity.My_ProjManage;
using NFine.Application.My_ProjManage;
using NFine.Code;
using NFine.Domain.Entity.SystemManage;

namespace NFine.Web.Areas.My_ProjManage.Controllers
{
    public class ProjInfoController : ControllerBase
    {
        private ProjInfoApp projApp = new ProjInfoApp();
        private MyCommonFuncApp commApp = new MyCommonFuncApp();
        // GET: My_ProjManage/ProjInfo
        public ActionResult Index()
        {
            //MY_ProjInfo myEntity = new MY_ProjInfo() { FProCode="02",Fdesc="Test01",FEndDate=DateTime.Parse("2018-05-31"),
            //Fmaster="Admin1",FName="My1",FStarDate=DateTime.Parse("2018-05-01"),FID=2};
            //string strInfo = projApp.InsertProjInfo(myEntity);
            return View();
        }

        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetGridJson(string keyword,string strStarDate,string strEndDate)
        {
            var data = projApp.GetProList(strStarDate, strEndDate,keyword);
            //string str = data.ToJson();
            return Content(data.ToJson());
        }

        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetProType()
        {
            var data = commApp.GetProType();
            return Content(commApp.DataTableToJson(data));
        }

        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetBaseInfo()
        {
            var data = projApp.GetList();
            var treeList = new List<TreeSelectModel>();
            foreach (MY_ProjInfo item in data)
            {
                TreeSelectModel treeModel = new TreeSelectModel();
                treeModel.id = item.FProCode;
                treeModel.text = item.FName;
                treeModel.parentId = "";
                treeModel.data = item;
                treeList.Add(treeModel);
            }
            return Content(treeList.TreeSelectJson());
        }

        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetFormJson(string keyValue)
        {
            var data = projApp.GetEntity(keyValue);
            return Content(data.ToJson());
        }

        [HttpPost]
        [HandlerAjaxOnly]
        [ValidateAntiForgeryToken]
        public ActionResult SubmitForm(MY_ProjInfo userEntity, UserLogOnEntity userLogOnEntity, string keyValue)
        {
            projApp.SubmitForm(userEntity, userLogOnEntity, keyValue);
            return Success("操作成功。");
        }

        [HttpPost]
        [HandlerAuthorize]
        [HandlerAjaxOnly]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteForm(string keyValue)
        {
            projApp.DeleteForm(keyValue);
            return Success("删除成功。");
        }











    }
}