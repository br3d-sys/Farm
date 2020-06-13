using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_Farmacia.Clases;
using Web_Farmacia.Models;

namespace Web_Farmacia.Controllers
{
    public class CategoriaController : Controller
    {
        // GET: Categoria
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Consultar_Categoria()
        {
            List<Categoria> lista;
            Metodo_Categoria mc = new Metodo_Categoria();

            lista = mc.listar();

            ViewBag.eliminar = TempData["Eliminar"];
            ViewBag.modificar = TempData["Modificar"];
        
            return View(lista);
        }
       
        public ActionResult eliminar(int id)
        {
            Metodo_Categoria mc = new Metodo_Categoria();
            if (mc.eliminar(id))
            {
                TempData.Add("Eliminar", "Se eliminó Correctamente el Registro");
            }
            else
            {
                TempData.Add("Eliminar", "No se eliminó Correctamente el Registro");
            }

            return RedirectToAction("Consultar_Categoria");
        }

        public ActionResult Modificar_Categoria(int id)
        {
            Categoria cat = new Categoria();
            Metodo_Categoria mc = new Metodo_Categoria();

            cat = mc.obtener(id);

            return View(cat);
        }
        [HttpPost]
        public ActionResult Modificar_Categoria(int id, string nombre, string descripcion)
        {
            Metodo_Categoria mc = new Metodo_Categoria();
            Categoria cat = new Categoria();
            
            cat.Id_categoria = id;
            cat.Nombre = nombre;
            cat.Descripcion = descripcion;
            
            if (mc.actualizar(cat))
            {
                TempData["Modificar"] = "Se actualizaron los datos correctamente";
            }
            else
            {
                TempData["Modificar"] = "No se pudo actualizar los datos";
            }

            return RedirectToAction("Consultar_Categoria");
        }

        public ActionResult Registrar_Categoria()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registrar_Categoria(string nombre, string descripcion)
        {
            Categoria cat = new Categoria();
            Metodo_Categoria mc = new Metodo_Categoria();

            cat.Nombre = nombre;
            cat.Descripcion = descripcion;

            if (mc.guardar(cat))
            {
                ViewBag.message = "Se guardaron los datos correctamente";
            }
            else
            {
                ViewBag.message = "No se Guardaron lo datos";
            }

            return Json(new {message = ViewBag.message, success = true });
        }
    }
}