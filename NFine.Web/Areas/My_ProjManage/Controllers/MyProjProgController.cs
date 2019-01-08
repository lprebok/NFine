using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NFine.Application.My_ProjManage;
using System.Web.Mvc;
using System.Data;
using NFine.Code;
using NFine.Domain._03_Entity.My_ProjManage;
using NFine.Domain.Entity.SystemManage;

namespace NFine.Web.Areas.My_ProjManage.Controllers
{
    public class MyProjProgController : ControllerBase
    {
        private MyProjProgApp projApp = new MyProjProgApp();
        // GET: My_ProjManage/MyProjProg
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetGridJson(string keyword)
        {
            var data = projApp.GetProjList(keyword);
            //string str = data.ToJson();
            return Content(data.ToJson());
        }

        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetFormJson(string keyValue)
        {
            var data = projApp.GetEntity(keyValue);
            return Content(data.ToJson());
        }

        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetUserJson()
        {
            var data = projApp.GetUserList();
            var treeList = new List<TreeSelectModel>();
            foreach (DataRow item in ((DataTable)data).Rows)
            {
                TreeSelectModel treeModel = new TreeSelectModel();
                treeModel.id = item["FCode"].ToString();
                treeModel.text = item["FName"].ToString();
                treeModel.parentId = "";
                treeModel.data = item;
                treeList.Add(treeModel);
            }
            string str = treeList.ToJson();
            return Content(treeList.ToJson());
        }

        [HttpPost]
        [HandlerAjaxOnly]
        [ValidateAntiForgeryToken]
        public ActionResult SubmitForm(MyProjProgEntity userEntity, UserLogOnEntity userLogOnEntity, string keyValue)
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