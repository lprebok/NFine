using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NFine.Domain._01_Infrastructure;
using NFine.Application.MyDataMange;
using NFine.Domain._03_Entity.MyDataManage;
using NFine.Code;

namespace NFine.Web.Areas.MyDataManage.Controllers
{
    public class MyDataMangeController : ControllerBase
    {
        MY_DataDictionaryApp myDictApp = new MY_DataDictionaryApp();
        // GET: MyDataManage/MyDataMange
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetTreeSelectJson()
        {
            var data = myDictApp.GetEntityList();
            var treeList = new List<TreeSelectModel>();
            foreach (MY_DataDictionaryEntity item in data)
            {
                TreeSelectModel treeModel = new TreeSelectModel();
                treeModel.id = item.FCode;
                treeModel.text = item.FName;
                treeModel.parentId = item.FParentCode;
                treeList.Add(treeModel);
            }
            return Content(treeList.TreeSelectJson());
        }

        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetTreeJson()
        {
            var data = myDictApp.GetEntityList();
            var treeList = new List<TreeViewModel>();
            foreach (MY_DataDictionaryEntity item in data)
            {
                TreeViewModel tree = new TreeViewModel();
                bool hasChildren = data.Count(t => t.FParentCode == item.FCode) == 0 ? false : true;
                tree.id = item.FCode;
                tree.text = item.FName;
                tree.value = item.FCode;
                tree.parentId = item.FParentCode;
                tree.isexpand = true;
                tree.complete = true;
                tree.hasChildren = hasChildren;
                treeList.Add(tree);
            }
            string str = treeList.TreeViewJson2();
            return Content(treeList.TreeViewJson2());
        }







    }
}