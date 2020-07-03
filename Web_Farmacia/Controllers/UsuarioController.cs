using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_Farmacia.Clases;
using Web_Farmacia.Models;

namespace Web_Farmacia.Controllers
{
    public class UsuarioController : Controller
    {
        Usuario v_usu = new Usuario();
        
        // GET: Usuario
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Consultar_Usuario()
        {
            List<Usuario> usu;
            Metodo_Usuario mu = new Metodo_Usuario();

            Info datos = new Info();

            //List<Object> todo = new List<Object>();

            usu = mu.listar();

            ViewBag.eliminar = TempData["Eliminar"];

            datos.Usu = usu;

            return View(datos);
        }
        [HttpPost]
        public ActionResult Consultar_Usuario(string nombre, string dni)
        {
            List<Usuario> usu;
            //List<Categoria> cat;
            Metodo_Usuario mu = new Metodo_Usuario();
            //Metodo_Categoria mc = new Metodo_Categoria();
            Info datos = new Info();
            //List<Object> todo = new List<Object>();

            usu = mu.listar();

            ViewBag.eliminar = TempData["Eliminar"];

            datos.Usu = usu;

            return View(datos);
        }

        public ActionResult eliminar(int id)
        {
            Metodo_Usuario mu = new Metodo_Usuario();
            if (mu.eliminar(id))
            {
                TempData["Eliminar"] = "Se eliminó Correctamente el Registro";
            }
            else
            {
                TempData["Eliminar"] = "No se eliminó Correctamente el Registro";
            }

            return RedirectToAction("Consultar_Usuario");
        }

        public ActionResult Modificar_Usuario(int? id)
        {
            List<Cargo> car = new List<Cargo>();
            Metodo_Usuario mu = new Metodo_Usuario();
            Metodo_Cargo mc = new Metodo_Cargo();

            if (id != null)
            {
                v_usu = mu.obtener(id);
                car = mc.listar();

                Info datos = new Info();
                datos.Obj_usu = v_usu;
                datos.Car = car;

                return View(datos);
            }
            else
            {
                return RedirectToAction("Consultar_Usuario");
            }



        }
        [HttpPost]
        public ActionResult Modificar_Usuario(int? id, string nombre, string usuario, string password, string documento, string n_documento, string correo, string celular, string direccion, int? id_cargo)
        {
            Metodo_Usuario mu = new Metodo_Usuario();
            Usuario usu = new Usuario();
            string message;
            SortedList<string, string> error = new SortedList<string, string>();

            if (id != null)
            {
                if (String.IsNullOrEmpty(nombre))
                {
                    error.Add("sp_nombre", "Ingrese el nombre del Usuario");
                }
                if (String.IsNullOrEmpty(usuario))
                {
                    error.Add("sp_usuario", "Ingrese el su usuario");
                }
                if (String.IsNullOrEmpty(password))
                {
                    error.Add("sp_password", "Ingrese el Password");
                }
                if (String.IsNullOrEmpty(documento))
                {
                    error.Add("sp_documento", "Selecciones el tipo de Documento");
                }
                if (String.IsNullOrEmpty(n_documento))
                {
                    error.Add("sp_n_documento", "Ingrese el N° del documento");
                }
                if (String.IsNullOrEmpty(correo))
                {
                    error.Add("sp_correo", "Ingrese el correo del usuario");
                }
                if (String.IsNullOrEmpty(direccion))
                {
                    error.Add("sp_direccion", "Ingrese la direccion del usuario");
                }
                if (id_cargo==null)
                {
                    error.Add("sp_id_cargo", "Seleccione el cargo del usuario");
                }

                //if(!String.IsNullOrEmpty(nombre) & categoria != null & precio != null & stock != null & !String.IsNullOrEmpty(codigo) & !String.IsNullOrEmpty(descripcion))
                //{
                if (error.Count == 0)
                {
                    usu.Id_usuario = id;
                    usu.Nombre = nombre == null ? "" : nombre;
                    usu.Nom_usuario = usuario == null ? "" : usuario;
                    usu.Password = password == null ? "" : password;
                    usu.Documento = documento == null ? "" : documento;
                    usu.N_documento = n_documento == null ? "" : n_documento;
                    usu.Correo = correo == null ? "" : correo;
                    usu.Celular = celular == null ? "" : celular;
                    usu.Direccion = direccion == null ? "" : direccion;
                    usu.Id_cargo = id_cargo == null ? 0 : id_cargo;
                   
                    if (mu.actualizar(usu))
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

            return RedirectToAction("Consultar_Usuario");
        }

        public ActionResult Registrar_Usuario()
        {
            List<Cargo> car = new List<Cargo>();
            Metodo_Cargo mc = new Metodo_Cargo();

            car = mc.listar();

            return View(car);
        }

        [HttpPost]
        public ActionResult Registrar_Usuario(string nombre, string usuario, string password, string documento, string n_documento, string correo, string celular, string direccion, int? id_cargo)
        {
            Usuario usu = new Usuario();
            Metodo_Usuario mu = new Metodo_Usuario();

            string message;
            SortedList<string, string> error = new SortedList<string, string>();

            if (String.IsNullOrEmpty(nombre))
            {
                error.Add("sp_nombre", "Ingrese el nombre del Usuario");
            }
            if (String.IsNullOrEmpty(usuario))
            {
                error.Add("sp_usuario", "Ingrese el su usuario");
            }
            if (String.IsNullOrEmpty(password))
            {
                error.Add("sp_password", "Ingrese el Password");
            }
            if (String.IsNullOrEmpty(documento))
            {
                error.Add("sp_documento", "Selecciones el tipo de Documento");
            }
            if (String.IsNullOrEmpty(n_documento))
            {
                error.Add("sp_n_documento", "Ingrese el N° del documento");
            }
            if (String.IsNullOrEmpty(correo))
            {
                error.Add("sp_correo", "Ingrese el correo del usuario");
            }
            if (String.IsNullOrEmpty(direccion))
            {
                error.Add("sp_direccion", "Ingrese la direccion del usuario");
            }
            if (id_cargo == null)
            {
                error.Add("sp_id_cargo", "Seleccione el cargo del usuario");
            }

            if (error.Count == 0)
            {
                usu.Nombre = nombre == null ? "" : nombre;
                usu.Nom_usuario = usuario == null ? "" : usuario;
                usu.Password = password == null ? "" : password;
                usu.Documento = documento == null ? "" : documento;
                usu.N_documento = n_documento == null ? "" : n_documento;
                usu.Correo = correo == null ? "" : correo;
                usu.Celular = celular == null ? "" : celular;
                usu.Direccion = direccion == null ? "" : direccion;
                usu.Id_cargo = id_cargo == null ? 0 : id_cargo;

                if (mu.guardar(usu))
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