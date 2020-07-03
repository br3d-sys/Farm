using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_Farmacia.Clases;
using Web_Farmacia.Models;

namespace Web_Farmacia.Controllers
{
    public class VentaController : Controller
    {
        Venta v_ven = new Venta();
        // GET: Cliente
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Consultar_Venta()
        {
            List<Venta> ven;
            Metodo_Venta mv = new Metodo_Venta();
            List<Cliente> cli;
            Metodo_Cliente mc = new Metodo_Cliente();

            Info datos = new Info();

            //List<Object> todo = new List<Object>();

            ven = mv.listar();
            cli = mc.listar();

            ViewBag.eliminar = TempData["Eliminar"];

            datos.Ven = ven;
            datos.Cli = cli;

            return View(datos);
        }
        [HttpPost]
        public ActionResult Consultar_Venta(int? id_cliente, DateTime fecha, string serie)
        {
            List<Venta> ven;
            //List<Categoria> cat;
            Metodo_Venta mv = new Metodo_Venta();
            //Metodo_Categoria mc = new Metodo_Categoria();
            Info datos = new Info();
            //List<Object> todo = new List<Object>();

            ven = mv.listar();

            ViewBag.eliminar = TempData["Eliminar"];

            datos.Ven = ven;

            return View(datos);
        }

        public ActionResult eliminar(int id)
        {
            Metodo_Venta mv = new Metodo_Venta();
            if (mv.eliminar(id))
            {
                TempData["Eliminar"] = "Se eliminó Correctamente el Registro";
            }
            else
            {
                TempData["Eliminar"] = "No se eliminó Correctamente el Registro";
            }

            return RedirectToAction("Consultar_Venta");
        }

        public ActionResult Modificar_Venta(int? id)
        {

            Metodo_Venta mv = new Metodo_Venta();

            if (id != null)
            {
                v_ven = mv.obtener(id);

                Info datos = new Info();
                datos.Obj_ven = v_ven;

                return View(datos);
            }
            else
            {
                return RedirectToAction("Consultar_Venta");
            }



        }
        [HttpPost]
        public ActionResult Modificar_Venta(int? id, int? id_cliente, DateTime fecha, string t_comprobante, string serie_com, string nro_com, int? total, int? id_usuario, string est_entrega, string estado)
        {
            Metodo_Venta mv = new Metodo_Venta();
            Venta ven = new Venta();
            string message;
            SortedList<string, string> error = new SortedList<string, string>();

            if (id != null)
            {
                if (id_cliente == null)
                {
                    error.Add("sp_id_cliente", "Seleccione el Cliente");
                }
                if (fecha == null)
                {
                    error.Add("sp_fecha", "Ingrese la fecha del pedido");
                }
                if (String.IsNullOrEmpty(t_comprobante))
                {
                    error.Add("sp_t_comprobante", "Seleccione el tipo de comprobante");
                }
                if (String.IsNullOrEmpty(serie_com))
                {
                    error.Add("sp_serie_com", "Ingrese la serie del comprobante");
                }
                if (String.IsNullOrEmpty(nro_com))
                {
                    error.Add("sp_nro_com", "Ingrese el N° del Comprobante");
                }
                if (total == null)
                {
                    error.Add("sp_total", "Calcule el Total");
                }
                if (id_usuario == null)
                {
                    error.Add("sp_id_usuario", "Necesita un usuario");
                }
                if (String.IsNullOrEmpty(est_entrega))
                {
                    error.Add("sp_est_entrega", "Seleccione el estado de la entrega");
                }
                if (String.IsNullOrEmpty(estado))
                {
                    error.Add("sp_estado", "Seleccione el estado del pedido");
                }

                //if(!String.IsNullOrEmpty(nombre) & categoria != null & precio != null & stock != null & !String.IsNullOrEmpty(codigo) & !String.IsNullOrEmpty(descripcion))
                //{
                if (error.Count == 0)
                {
                    ven.Id_venta = id;
                    ven.Id_cliente = id_cliente == null ? 0 : id_cliente;
                    ven.Fecha = fecha == null ? DateTime.Now : fecha;
                    ven.T_comprobante = t_comprobante == null ? "" : t_comprobante;
                    ven.S_comprobante = serie_com == null ? "" : serie_com;
                    ven.N_comprobante = nro_com == null ? "" : nro_com;
                    ven.Total = total == null ? 0 : total;
                    ven.Id_usuario = id_usuario == null ? 0 : id_usuario;
                    ven.Est_entrega = est_entrega == null ? "" : est_entrega;
                    ven.Estado = estado == null ? "" : estado;

                    if (mv.actualizar(ven))
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

            return RedirectToAction("Consultar_Venta");
        }

        public ActionResult Registrar_Venta()
        {
            List<Cliente> cli = new List<Cliente>();
            Metodo_Cliente mc = new Metodo_Cliente();
            Metodo_Producto mp = new Metodo_Producto();
            List<Producto> pro = new List<Producto>();
            Info datos = new Info();

            pro = mp.listar();
            cli = mc.listar();

            datos.Cli = cli;
            datos.Prod = pro;

            return View(datos);
        }

        [HttpPost]
        public JsonResult Registrar_Venta(int? id_cliente, DateTime? fecha, string t_comprobante, string serie_com, string nro_com, int? total_venta, int? id_usuario,
            string est_entrega, string estado, int?[] id_producto, int?[] cantidad, Double?[] precio, Double?[] art_total)
        {
            Venta ven = new Venta();
            DetalleVenta dven = new DetalleVenta();

            Metodo_Venta mv = new Metodo_Venta();
            Metodo_DetalleVenta mdv = new Metodo_DetalleVenta();

            int id_Venta;

            string message;
            SortedList<string, string> error = new SortedList<string, string>();

            if (id_cliente == null)
            {
                error.Add("sp_id_cliente", "Seleccione el Cliente");
            }
            if (fecha == null)
            {
                error.Add("sp_fecha", "Ingrese la fecha del pedido");
            }
            if (String.IsNullOrEmpty(t_comprobante))
            {
                error.Add("sp_t_comprobante", "Seleccione el tipo de comprobante");
            }
            if (String.IsNullOrEmpty(serie_com))
            {
                error.Add("sp_serie_com", "Ingrese la serie del comprobante");
            }
            if (String.IsNullOrEmpty(nro_com))
            {
                error.Add("sp_nro_com", "Ingrese el N° del Comprobante");
            }
            if (total_venta == null)
            {
                error.Add("sp_total_venta", "Calcule el Total");
            }
            if (id_usuario == null)
            {
                error.Add("sp_id_usuario", "Necesita un usuario");
            }
            if (String.IsNullOrEmpty(est_entrega))
            {
                error.Add("sp_est_entrega", "Seleccione el estado de la entrega");
            }
            if (String.IsNullOrEmpty(estado))
            {
                error.Add("sp_estado", "Seleccione el estado del pedido");
            }
            //------------------------------------------------------------------------
            if (id_producto == null | cantidad == null | precio == null | art_total == null)
            {
                error.Add("sp_detalle_productos", "Agregue los productos de compra correctamente");
            }

            if (error.Count == 0)
            {
                ven.Id_cliente = id_cliente == null ? 0 : id_cliente;
                ven.Fecha = fecha == null ? DateTime.Now : fecha;
                ven.T_comprobante = t_comprobante == null ? "" : t_comprobante;
                ven.S_comprobante = serie_com == null ? "" : serie_com;
                ven.N_comprobante = nro_com == null ? "" : nro_com;
                ven.Total = total_venta == null ? 0 : total_venta;
                ven.Id_usuario = id_usuario == null ? 0 : id_usuario;
                ven.Est_entrega = est_entrega == null ? "" : est_entrega;
                ven.Estado = estado == null ? "" : estado;

                id_Venta = mv.guardar(ven);

                if (id_Venta>0)
                {

                    message = "Se guardaron los datos de venta";

                    for(int i=0; id_producto.Length> i; i++)
                    {
                        dven.Id_producto = id_producto[i];
                        dven.Id_venta = id_Venta;
                        dven.Cantidad = cantidad[i];
                        dven.Precio = precio[i];
                        dven.Total = art_total[i];

                        if (mdv.guardar(dven))
                        {
                            message = ("Se guardó el producto hasta"+i);
                        }

                    }

                    

                }
                else
                {
                    message = "No se Guardaron lo datos de venta";
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