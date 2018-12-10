using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NFine.Application.My_Person;
using NFine.Domain._03_Entity.MY_Person;

namespace NFine.Web.Areas.my_person.Controllers
{
    public class PersonController : Controller
    {
        //
        // GET: /my_person/Person/
        myPersonApp perapp = new myPersonApp();
        public ActionResult Index()
        {
            myPersonEntity myModel = new myPersonEntity() { F_Id=1,FName="张龙",FAdress="中国",FAge=23,FSex="男"};
            perapp.AddLog(myModel);
            return View("Success!");
        }

    }
}
