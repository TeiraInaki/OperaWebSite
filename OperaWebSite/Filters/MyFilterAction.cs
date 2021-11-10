using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OperaWebSite.Filters
{
    public class MyFilterAction : ActionFilterAttribute
    {
        //Filtro de accion - ocurre antes
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //Capturo de que controlador me piden la accion
            var controller = filterContext.RouteData.Values["controller"];
            //Capturo que accion me estan pidiendo
            var action = filterContext.RouteData.Values["action"];


            Debug.WriteLine(controller + " " + action + " Paso por OnActionExecuting");
        }

        //Filtro de accion - ocurre despues
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            //Capturo de que controlador me piden la accion
            // Ruta: controller/accion/parametros
            var controller = filterContext.RouteData.Values["controller"];
            //Capturo que accion me estan pidiendo
            var action = filterContext.RouteData.Values["action"];


            Debug.WriteLine(controller + " " + action + " Paso por OnActionExecuted");
        }
    }
}