﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NFine.Application.My_ProjManage;
using System.Web.Mvc;
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
            var data = projApp.GetList(keyword);
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