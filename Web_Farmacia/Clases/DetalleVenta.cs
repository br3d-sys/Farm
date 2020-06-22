using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_Farmacia.Clases
{
    public class DetalleVenta
    {
        private int? id_detalleventa;
        private int? id_producto;
        private int? id_venta;
        private int? cantidad;
        private int? precio;
        private int? total;

        public int? Id_detalleventa
        {
            get
            {
                return id_detalleventa;
            }

            set
            {
                id_detalleventa = value;
            }
        }

        public int? Id_producto
        {
            get
            {
                return id_producto;
            }

            set
            {
                id_producto = value;
            }
        }

        public int? Id_venta
        {
            get
            {
                return id_venta;
            }

            set
            {
                id_venta = value;
            }
        }

        public int? Cantidad
        {
            get
            {
                return cantidad;
            }

            set
            {
                cantidad = value;
            }
        }

        public int? Precio
        {
            get
            {
                return precio;
            }

            set
            {
                precio = value;
            }
        }

        public int? Total
        {
            get
            {
                return total;
            }

            set
            {
                total = value;
            }
        }
    }
}