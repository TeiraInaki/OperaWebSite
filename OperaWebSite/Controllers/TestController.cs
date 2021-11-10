using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OperaWebSite.Controllers
{
    public class TestController : Controller
    {
        //Las rutas las resuelvo con rutas personalizadas
        public ActionResult Login(string name, string role)
        {
            //Name y role se crean en ejecucion (no existian)
            //El ViewBag se usa para pasar datos del controlador a la vista
            ViewBag.Name = name;
            ViewBag.Role = role;

            return View();
        }

        public ActionResult SearchByTitle(string title)
        {
            ViewBag.Title = title;

            return View();
        }
    }
}