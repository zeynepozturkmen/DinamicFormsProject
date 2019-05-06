using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DinamikFormYonetimi.Models;

namespace DinamikFormYonetimi.Controllers
{
    public class HomeController : Controller
    {
        FormDBEntities db = new FormDBEntities();
       
        public ActionResult Index()
        {
     
            return View();
        }
    }
}