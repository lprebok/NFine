﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NFine.Domain._03_Entity.My_ProjManage;
using NFine.Application.My_ProjManage;
using NFine.Code;

namespace NFine.Web.Areas.My_ProjManage.Controllers
{
    public class ProjInfoController : Controller
    {
        private ProjInfoApp projApp = new ProjInfoApp();
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
        public ActionResult GetGridJson(string keyword)
        {
            var data = projApp.GetList(keyword);
            //string str = data.ToJson();
            return Content(data.ToJson());
        }





    }
}