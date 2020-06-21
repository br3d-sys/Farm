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

        public ActionResult Modificar_Categoria(int ? id)
        {
            Categoria cat = new Categoria();
            Metodo_Categoria mc = new Metodo_Categoria();

            if (id != null)
            {
                cat = mc.obtener(id);
                return View(cat);
            }
            else
            {
                return RedirectToAction("Consultar_Categoria");
            }
            
        }
        [HttpPost]
        public ActionResult Modificar_Categoria(int ? id, string nombre, string descripcion)
        {
            Metodo_Categoria mc = new Metodo_Categoria();
            Categoria cat = new Categoria();
            string message;

            SortedList<string, string> datos = new SortedList<string, string>();

            if (id != null)
            {
                if (String.IsNullOrEmpty(nombre))
                {
                    datos.Add("sp_nombre", "Ingrese el nombre de la categoría");
                }
                if (String.IsNullOrEmpty(descripcion))
                {
                    datos.Add("sp_descripcion", "Ingrese la descripción de la Categoría");
                }

                if (datos.Count == 0)
                {
                    cat.Id_categoria = id;
                    cat.Nombre = nombre;
                    cat.Descripcion = descripcion;
            
                    if (mc.actualizar(cat))
                    {
                        message = "Se actualizaron los datos correctamente";
                    }
                    else
                    {
                        message = "No se pudo actualizar los datos";
                    }

                    return Json(new { message = message, success = true });
                }
                else
                {
                    return Json(new { message = "Necesita completar los datos necesarios", success = false, datos });
                }
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
            string message;

            SortedList<string, string> error = new SortedList<string, string>();

            if (String.IsNullOrEmpty(nombre))
            {
                error.Add("sp_nombre", "Ingrese el Nombre de la Categoría");
            }
            if (String.IsNullOrEmpty(descripcion))
            {
                error.Add("sp_descripcion", "Ingrese la Descripción");
            }

            if (error.Count == 0)
            {
                cat.Nombre = nombre;
                cat.Descripcion = descripcion;

                if (mc.guardar(cat))
                {
                    message = "Se guardaron los datos correctamente";
                }
                else
                {
                    message = "No se Guardaron los datos";
                }

                return Json(new {message = message, success = true });
            }
            else
            {
                return Json(new { message = "Necesita completar los campos necesarios", success = false, datos = error });
            }

            
        }
    }
}