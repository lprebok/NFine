using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NFine.Application.My_ProjManage;
using NFine.Code;
using NFine.Domain._03_Entity.My_ProjManage;
using NFine.Domain.Entity.SystemManage;

namespace NFine.Web.Areas.My_ProjManage.Controllers
{
    public class MyProjNeedInfoController : ControllerBase
    {
        My_ProjNeedInfoApp projApp = new My_ProjNeedInfoApp();
        MyCommonFuncApp commApp = new MyCommonFuncApp();
        // GET: My_ProjManage/MyProjNeedInfo
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetGridJson(string keyword,string strStarDate,string strEndDate)
        {
            var data = projApp.GetEntityList(strStarDate, strEndDate,keyword);
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
        public ActionResult SubmitForm(My_ProjNeedInfo userEntity, UserLogOnEntity userLogOnEntity, string keyValue)
        {
            projApp.SubmitForm(userEntity, userLogOnEntity, keyValue);
            return Success("操作成功。");
        }

        [HttpPost]
        [HandlerAuthorize]
        [HandlerAjaxOnly]
        //[ValidateAntiForgeryToken]
        public ActionResult CheckForm(string keyValue)
        {
            //projApp.DeleteForm(keyValue);
            projApp.CheckOrUnCheck(keyValue, 1);
            return Success("审核成功！");
        }

        [HttpPost]
        [HandlerAuthorize]
        [HandlerAjaxOnly]
        //[ValidateAntiForgeryToken]
        public ActionResult UncheckForm(string keyValue)
        {
            //projApp.DeleteForm(keyValue);
            projApp.CheckOrUnCheck(keyValue, 0);
            return Success("反审核成功！");
        }

        [HttpPost]
        [HandlerAuthorize]
        [HandlerAjaxOnly]
        //[ValidateAntiForgeryToken]
        public ActionResult DeleteForm(string keyValue)
        {
            projApp.CheckOrUnCheck(keyValue,-1);
            return Success("作废成功！");
        }

        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetUserJson()
        {
            var vData = commApp.GetProjManger();
            return Content(commApp.DataTableToJson(vData));
        }

        [HttpPost]
        [HandlerAuthorize]
        [HandlerAjaxOnly]
        public ActionResult BillIsChecked(string keyValue)
        {
            string strInfo = projApp.BillIsChecked(keyValue);
            return Success(strInfo);
        }

        [HttpPost]
        [HandlerAuthorize]
        [HandlerAjaxOnly]
        public ActionResult EndProjReq(string keyValue)
        {
            string strInfo = projApp.EndProjReq(keyValue,1);
            return Success(strInfo);
        }

        [HttpPost]
        [HandlerAuthorize]
        [HandlerAjaxOnly]
        public ActionResult StarProjReq(string keyValue)
        {
            string strInfo = projApp.EndProjReq(keyValue,0);
            return Success(strInfo);
        }


    }
}