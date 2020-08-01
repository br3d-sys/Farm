using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_Farmacia.Clases;
using Web_Farmacia.Models;

namespace Web_Farmacia.Controllers
{
    public class CargoController : Controller
    {
        Cargo v_car = new Cargo();
        // GET: Cliente
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Consultar_Cargo()
        {
            List<Cargo> car;
            Metodo_Cargo mc = new Metodo_Cargo();

            Info datos = new Info();

            //List<Object> todo = new List<Object>();

            car = mc.listar();

            ViewBag.eliminar = TempData["Eliminar"];

            datos.Car = car;

            return View(datos);
        }

        public ActionResult eliminar(int id)
        {
            Metodo_Cargo mc = new Metodo_Cargo();
            if (mc.eliminar(id))
            {
                TempData["Eliminar"] = "Se eliminó Correctamente el Registro";
            }
            else
            {
                TempData["Eliminar"] = "No se eliminó Correctamente el Registro";
            }

            return RedirectToAction("Consultar_Cargo");
        }

        public ActionResult Modificar_Cargo(int? id)
        {

            Metodo_Cargo mc = new Metodo_Cargo();

            if (id != null)
            {
                v_car = mc.obtener(id);

                Info datos = new Info();
                datos.Obj_car = v_car;

                return View(datos);
            }
            else
            {
                return RedirectToAction("Consultar_Cargo");
            }



        }
        [HttpPost]
        public ActionResult Modificar_Cargo(int? id, string nombre, string detalle)
        {
            Metodo_Cargo mc = new Metodo_Cargo();
            Cargo car = new Cargo();
            string message;
            SortedList<string, string> error = new SortedList<string, string>();

            if (id != null)
            {
                if (String.IsNullOrEmpty(nombre))
                {
                    error.Add("sp_nombre", "Ingrese el nombre del Cliente");
                }
                if (String.IsNullOrEmpty(detalle))
                {
                    error.Add("sp_detalle", "Ingrese la descripción del cargo");
                }

                //if(!String.IsNullOrEmpty(nombre) & categoria != null & precio != null & stock != null & !String.IsNullOrEmpty(codigo) & !String.IsNullOrEmpty(descripcion))
                //{
                if (error.Count == 0)
                {
                    car.Id_cargo = id;
                    car.Nombre = nombre == null ? "" : nombre;
                    car.Detalle = detalle == null ? "" : detalle;
                    
                    if (mc.actualizar(car))
                    {
                        message = "Se actualizaron los datos correctamente";
                    }
                    else
                    {
                        message = "No se logró actualizar lo datos";
                    }

                    return Json(new { message = message, success = true });
                }
                else
                {
                    message = "Ingrese los datos necesarios";
                    return Json(new { message = message, success = false, datos = error });
                }


                //--------------------------------------------------------------

            }

            return RedirectToAction("Consultar_Cargo");
        }

        public ActionResult Registrar_Cargo()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Registrar_Cargo(string nombre, string detalle)
        {
            Cargo car = new Cargo();
            Metodo_Cargo mc = new Metodo_Cargo();

            string message;
            SortedList<string, string> error = new SortedList<string, string>();

            if (String.IsNullOrEmpty(nombre))
            {
                error.Add("sp_nombre", "Ingrese el nombre del Cargo");
            }
            if (String.IsNullOrEmpty(detalle))
            {
                error.Add("sp_detalle", "Ingrese la descripción del cargo");
            }

            if (error.Count == 0)
            {
                car.Nombre = nombre == null ? "" : nombre;
                car.Detalle = detalle == null ? "" : detalle;

                if (mc.guardar(car))
                {
                    message = "Se guardaron los datos correctamente";
                }
                else
                {
                    message = "No se Guardaron lo datos";
                }

                return Json(new { message = message, success = true });
            }
            else
            {
                message = "Ingrese los datos necesarios";
                return Json(new { message = message, success = false, datos = error });
            }


        }
    }
}