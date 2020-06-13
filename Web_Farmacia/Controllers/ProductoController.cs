using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_Farmacia.Clases;
using Web_Farmacia.Models;

namespace Web_Farmacia.Controllers
{
    public class ProductoController : Controller
    {
        Producto pro = new Producto();
        // GET: Producto
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Consultar_Producto()
        {
            List<Producto> prod;
            List<Categoria> cat;
            Metodo_Producto mp = new Metodo_Producto();
            Metodo_Categoria mc = new Metodo_Categoria();
            Info datos = new Info();
            
            //List<Object> todo = new List<Object>();
            
            cat = mc.listar();
            prod = mp.listar();

            ViewBag.eliminar = TempData["Eliminar"];
            ViewBag.modificar = TempData["Modificar"];

            datos.Prod = prod;
            datos.Cat = cat;
            
            //todo.Add(prod);
            //todo.Add(cat);
            

            return View(datos);
        }
        [HttpPost]
        public ActionResult Consultar_Producto(string nombre, string categoria)
        {
            List<Producto> prod;
            List<Categoria> cat;
            Metodo_Producto mp = new Metodo_Producto();
            Metodo_Categoria mc = new Metodo_Categoria();

            Info datos = new Info();
            //List<Object> todo = new List<Object>();

            cat = mc.listar();
            prod = mp.buscar(nombre, categoria);

            ViewBag.eliminar = TempData["Eliminar"];
            ViewBag.modificar = TempData["Modificar"];

            datos.Prod = prod;
            datos.Cat = cat;

            //todo.Add(prod);
            //todo.Add(cat);

            return View(datos);
        }

        public ActionResult eliminar(int id)
        {
            Metodo_Producto mp = new Metodo_Producto();
            if (mp.eliminar(id))
            {
                TempData["Eliminar"]="Se eliminó Correctamente el Registro";
            }
            else
            {
                TempData["Eliminar"] = "No se eliminó Correctamente el Registro";
            }

            return RedirectToAction("Consultar_Producto");
        }

        public ActionResult Modificar_Producto(int id)
        {
            
            Metodo_Producto mp = new Metodo_Producto();
            Metodo_Categoria mc = new Metodo_Categoria();
            List<Categoria> cat = new List<Categoria>();

            cat = mc.listar();
            pro = mp.obtener(id);

            Info datos = new Info();
            datos.Cat = cat;
            datos.Obj_prod = pro;

            return View(datos);
        }
        [HttpPost]
        public ActionResult Modificar_Producto(int id, string nombre, int ? categoria, Double ? precio, int ? stock, string codigo, string descripcion, HttpPostedFileBase imagen)
        {
            Metodo_Producto mp = new Metodo_Producto();
            Producto pro = new Producto();
            string subir;

            //if(!String.IsNullOrEmpty(nombre) & categoria != null & precio != null & stock != null & !String.IsNullOrEmpty(codigo) & !String.IsNullOrEmpty(descripcion))
            //{
                pro.Id_producto = id;
                pro.Nombre = nombre;
                pro.Id_categoria = categoria;
                pro.Precio = precio;
                pro.Stock = stock;
                pro.Codigo = codigo;
                pro.Descripcion = descripcion;
                pro.Imagen = null;

                if(imagen != null)
                {
                    pro.Imagen = imagen.FileName;
                    subir = Server.MapPath("~/Content/Imagenes/");
                    subir += imagen.FileName;

                    if (mp.subirArchivo(subir, imagen))
                    {
                        TempData["Img"] = "Se guardó la imagen";
                    }
                    else
                    {
                        TempData["Img"] = "No se Guardó la imagen";
                    }

                }

                if (mp.actualizar(pro))
                {
                    TempData["Modificar"] = "Se actualizaron los datos correctamente";
                }
                else
                {
                    TempData["Modificar"] = "No se pudo actualizar los datos";
                }

                return RedirectToAction("Consultar_Producto");
            //}
            //else
            //{
            //    ViewBag.message = "Ingrese los datos necesarios";
            //    //retornar datos anteriores con la misma vista
            //    return RedirectToAction("Modificar_Producto";
            //}

            
        }

        public ActionResult Registrar_Producto()
        {
            Metodo_Categoria mc = new Metodo_Categoria();
            List<Categoria> cat = new List<Categoria>();

            cat = mc.listar();

            return View(cat);
        }

        [HttpPost]
        public ActionResult Registrar_Producto(string nombre, int ? categoria, Double ? precio, int ? stock, string codigo, string descripcion, HttpPostedFileBase imagen)
        {
                Producto pro = new Producto();
                Metodo_Producto mp = new Metodo_Producto();
                Metodo_Categoria mc = new Metodo_Categoria();
                List<Categoria> cat = new List<Categoria>();

                string subir;
                cat = mc.listar();

            if(!String.IsNullOrEmpty(nombre) & categoria != null & precio != null & stock != null & !String.IsNullOrEmpty(codigo) & !String.IsNullOrEmpty(descripcion))
            {
                

                pro.Nombre = nombre;
                pro.Id_categoria = categoria;
                pro.Precio = precio;
                pro.Stock = stock;
                pro.Codigo = codigo;
                pro.Descripcion = descripcion;
                pro.Imagen = imagen.FileName;

                subir= Server.MapPath("~/Content/Imagenes/");
                subir += imagen.FileName;

                
            
                if (mp.guardar(pro) && mp.subirArchivo(subir, imagen))
                {
                    ViewBag.message = "Se guardaron los datos correctamente";
                }
                else
                {
                    ViewBag.message = "No se Guardaron lo datos";
                }

                return Json(new {message = ViewBag.message, success = true });
            }
            else
            {
                ViewBag.message = "Ingrese los datos necesarios";
                return Json(new { message = ViewBag.message, success = true });
            }

           
        }
    }
}