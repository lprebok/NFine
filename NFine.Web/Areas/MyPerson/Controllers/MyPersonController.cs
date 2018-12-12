using NFine.Application.My_Person;
using NFine.Domain._03_Entity.MY_Person;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NFine.Web.Areas.MyPerson.Controllers
{
    public class MyPersonController : Controller
    {
        // GET: MyPerson/MyPerson
        myPersonApp perapp = new myPersonApp();
        public ActionResult Index()
        {
            string strError = "";
            try
            {
                myPersonEntity myModel = new myPersonEntity() { F_Id = 1, FName = "张龙", FAdress = "中国", FAge = 23, FSex = "男" };
                perapp.AddLog(myModel);
                strError = "Success!";
            }
            catch (Exception err)
            {
                strError = err.Message.ToString();
            }
            ViewBag.FResult = strError;
            return View();
        }

        public ViewResult Test()
        {
            string strError = "";
            try
            {
                myPersonEntity myModel = new myPersonEntity() { F_Id = 10, FName = "张龙", FAdress = "中国", FAge = 23, FSex = "男" };
                perapp.AddLog(myModel);
                strError = "Success!";
            }
            catch (Exception err)
            {
                strError = err.Message.ToString();
                strError.AsQueryable();
            }
            ViewBag.FResult = strError;
            return View();
                
        }






    }
}