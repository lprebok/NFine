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
    public class MyNeedCheckProjController : ControllerBase
    {
        private MyNeedCheckProjApp myApp = new MyNeedCheckProjApp();

        // GET: My_ProjManage/MyNeedCheckProj
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetGridJson(string FStarDate, string FEndData)
        {
            var data = myApp.GetProjList(FStarDate, FEndData);
            //string str = data.ToJson();
            return Content(data.ToJson());
        }

        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetFormJson(string keyValue)
        {
            var data = myApp.GetEntity(keyValue);
            return Content(data.ToJson());
        }

        [HttpPost]
        [HandlerAjaxOnly]
        [ValidateAntiForgeryToken]
        public ActionResult SubmitForm(MyNeedCheckProjEntity userEntity, UserLogOnEntity userLogOnEntity, string keyValue)
        {
            myApp.SubmitForm(userEntity, userLogOnEntity, keyValue);
            return Success("操作成功。");
        }

        [HttpPost]
        [HandlerAuthorize]
        [HandlerAjaxOnly]
        public ActionResult BillIsChecked(string keyValue)
        {
            string strInfo = myApp.BillIsChecked(keyValue);
            return Success(strInfo);
        }

        [HttpPost]
        [HandlerAuthorize]
        [HandlerAjaxOnly]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteForm(string keyValue)
        {
            //projApp.DeleteForm(keyValue);
            myApp.CheckOrUnCheck(keyValue, -1);
            return Success("删除成功！");
        }

        [HttpPost]
        [HandlerAuthorize]
        [HandlerAjaxOnly]
        [ValidateAntiForgeryToken]
        public ActionResult CheckForm(string keyValue)
        {
            //projApp.DeleteForm(keyValue);
            myApp.CheckOrUnCheck(keyValue, 1);
            return Success("审核成功！");
        }

        [HttpPost]
        [HandlerAuthorize]
        [HandlerAjaxOnly]
        [ValidateAntiForgeryToken]
        public ActionResult UncheckForm(string keyValue)
        {
            //projApp.DeleteForm(keyValue);
            myApp.CheckOrUnCheck(keyValue, 0);
            return Success("反审核成功！");
        }


    }
}