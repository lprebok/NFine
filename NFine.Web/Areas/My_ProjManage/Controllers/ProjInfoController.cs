using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NFine.Domain._03_Entity.My_ProjManage;
using NFine.Application.My_ProjManage;

namespace NFine.Web.Areas.My_ProjManage.Controllers
{
    public class ProjInfoController : Controller
    {
        private ProjInfoApp projApp = new ProjInfoApp();
        // GET: My_ProjManage/ProjInfo
        public ActionResult Index()
        {
            MY_ProjInfo myEntity = new MY_ProjInfo() { FProCode="01",Fdesc="Test",FEndDate=DateTime.Parse("2018-12-31"),
            Fmaster="Admin",FName="My",FStarDate=DateTime.Parse("2018-12-01")};
            string strInfo = projApp.InsertProjInfo(myEntity);
            return View();
        }






    }
}