using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_Farmacia.Clases;
using Web_Farmacia.Models;

namespace Web_Farmacia.Controllers
{
    public class ClienteController : Controller
    {
        Cliente cli = new Cliente();
        // GET: Cliente
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Consultar_Cliente()
        {
            List<Cliente> cli;
            Metodo_Cliente mc = new Metodo_Cliente();

            Info datos = new Info();

            //List<Object> todo = new List<Object>();

            cli = mc.listar();

            ViewBag.eliminar = TempData["Eliminar"];

            datos.Cli = cli;

            return View(datos);
        }
        //[HttpPost]
        //public ActionResult Consultar_Cliente(string nombre, string dni)
        //{
        //    List<Cliente> cli;
        //    //List<Categoria> cat;
        //    Metodo_Cliente mc = new Metodo_Cliente();
        //    //Metodo_Categoria mc = new Metodo_Categoria();
        //    Info datos = new Info();
        //    //List<Object> todo = new List<Object>();

        //    cli = mc.listar();

        //    ViewBag.eliminar = TempData["Eliminar"];
            
        //    datos.Cli = cli;
            
        //    return View(datos);
        //}

        public ActionResult eliminar(int id)
        {
            Metodo_Cliente mc = new Metodo_Cliente();
            if (mc.eliminar(id))
            {
                TempData["Eliminar"] = "Se eliminó Correctamente el Registro";
            }
            else
            {
                TempData["Eliminar"] = "No se eliminó Correctamente el Registro";
            }

            return RedirectToAction("Consultar_Producto");
        }

        public ActionResult Modificar_Cliente(int? id)
        {

            Metodo_Cliente mc = new Metodo_Cliente();

            if (id != null)
            {
                cli = mc.obtener(id);

                Info datos = new Info();
                datos.Obj_cli = cli;

                return View(datos);
            }
            else
            {
                return RedirectToAction("Consultar_Producto");
            }



        }
        [HttpPost]
        public ActionResult Modificar_Cliente(int? id, string nombre, string t_documento, string n_documento, string direccion, string celular, string correo, int? edad, string sexo, string est_civil, string usuario, string contraseña)
        {
            Metodo_Cliente mc = new Metodo_Cliente();
            Cliente cli = new Cliente();
            string message;
            SortedList<string, string> error = new SortedList<string, string>();

            if (id != null)
            {
                if (String.IsNullOrEmpty(nombre))
                {
                    error.Add("sp_nombre", "Ingrese el nombre del Cliente");
                }
                if (String.IsNullOrEmpty(t_documento))
                {
                    error.Add("sp_t_documento", "Seleccione el tipo de documento");
                }
                if (String.IsNullOrEmpty(n_documento))
                {
                    error.Add("sp_n_documento", "Ingrese el Número del Documento");
                }
              
                //if(!String.IsNullOrEmpty(nombre) & categoria != null & precio != null & stock != null & !String.IsNullOrEmpty(codigo) & !String.IsNullOrEmpty(descripcion))
                //{
                if (error.Count == 0)
                {
                    cli.Id_cliente = id;
                    cli.Nombre = nombre;
                    cli.T_documento = t_documento;
                    cli.N_documento = n_documento;
                    cli.Direccion = direccion;
                    cli.Celular = celular;
                    cli.Correo = correo;
                    cli.Edad = edad;
                    cli.Sexo = sexo;
                    cli.Est_civil = est_civil;
                    cli.Usuario = usuario;
                    cli.Contraseña = contraseña;
                    
                    if (mc.actualizar(cli))
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

            return RedirectToAction("Consultar_Cliente");
        }

        public ActionResult Registrar_Cliente()
        {
            
            return View();
        }

        [HttpPost]
        public JsonResult Registrar_Cliente(string nombre, string t_documento, string n_documento, string direccion, string celular, string correo, int? edad, string sexo, string est_civil, string usuario, string contraseña)
        {
            Cliente cli = new Cliente();
            Metodo_Cliente mc = new Metodo_Cliente();

            string message;
            SortedList<string, string> error = new SortedList<string, string>();

            if (String.IsNullOrEmpty(nombre))
            {
                error.Add("sp_nombre", "Ingrese el nombre del Cliente");
            }
            if (String.IsNullOrEmpty(t_documento))
            {
                error.Add("sp_t_documento", "Seleccione el tipo de documento");
            }
            if (String.IsNullOrEmpty(n_documento))
            {
                error.Add("sp_n_documento", "Ingrese el Número del Documento");
            }
            
            if (error.Count == 0)
            {
                cli.Nombre = nombre;
                cli.T_documento = t_documento;
                cli.N_documento = n_documento;
                cli.Direccion = direccion;
                cli.Celular = celular;
                cli.Correo = correo;
                cli.Edad = edad;
                cli.Sexo = sexo;
                cli.Est_civil = est_civil;
                cli.Usuario = usuario;
                cli.Contraseña = contraseña;

                if (mc.guardar(cli))
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