using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using OperaWebSite.Models;
using OperaWebSite.Data;
using System.Data.Entity;

namespace OperaWebSite.Controllers
{
    public class OperaController : Controller
    {
        //Creo instancia del DbContext
        private OperaDBContext context = new OperaDBContext();
        
        // GET: Opera
        public ActionResult Index()
        {
            //Traigo todas las operas usando EF

            var operas = context.Operas.ToList();

            //El controller retorna una vista "Index" con la lista de operas
            return View("Index", operas);
        }

        //Creamos dos métodos para la inserción de la opera en la DB

        //Primer create por GET para teronar la vista de registro
        
        [HttpGet] //El get es implicito, es opcional
        public ActionResult Create()
        {
            //Creo la isntancia opera sin valores
            Opera opera = new Opera();

            //Retorno la vista create que tiene el objeto opera
            return View("Create", opera);
        }

        //Segundo Create es por Post (inserta en la BD)
        //Cuando el usario en la vista Create hace click en enviar va por el httppost
        [HttpPost]
        public ActionResult Create(Opera opera)
        {
            //Chequea que las propiedades de mi instancia cumplan las validaciones especificadas
            if (ModelState.IsValid)
            {
                context.Operas.Add(opera);
                context.SaveChanges();
                //Llama la accion Index definida previamente (lista toda la tabla)
                return RedirectToAction("Index");
            }
            //Vuelve al metodo de cargar datos, si el ModelState no es valido
            return View("Create", opera);
        }

        //GET (implicito)
        //Ruta: Opera/Detail/id
        public ActionResult Detail(int id)
        {
            Opera opera = context.Operas.Find(id);

            if (opera != null)
            {
                return View("Detail", opera);
            }
            else
            {
                return HttpNotFound();
            }
        }
        //DELETE por GET para enviar una vista al cliente con los detalles de la opera seleccionada y que pueda decidir si quiere o no eliminarlo. Si confirma --> delete por post.
        //Ruta: Opera/Delete/id
        public ActionResult Delete(int id)
        {
            Opera opera = context.Operas.Find(id);

            if (opera != null)
            {
                return View("Delete", opera);
            }
            else 
            {
                return HttpNotFound();
            }
        }

        //Si se confirma
        //Ruta: Opera/DeleteConfirmed/id
        [HttpPost]
        public ActionResult DeleteConfirmed(int id)
        {
            Opera opera = context.Operas.Find(id);

            context.Operas.Remove(opera);
            context.SaveChanges();

            return RedirectToAction("Index");
        }

        //EDITAR (en 2 partes)
        //GET, RUTA /Opera/Edit/id

        public ActionResult Edit(int id)
        {
            Opera opera = context.Operas.Find(id);

            if (opera != null)
            {
                return View("Edit", opera);
            }
            else
            {
                return HttpNotFound();
            }
        }

        [HttpPost]
        public ActionResult Edit(Opera opera)
        {
            if (ModelState.IsValid)
            {
                context.Entry(opera).State = EntityState.Modified;
                context.SaveChanges();

                return RedirectToAction("Index");
            }
            else return View("Edit", opera);
        }

    }
}