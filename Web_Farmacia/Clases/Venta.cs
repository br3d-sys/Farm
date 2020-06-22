using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_Farmacia.Clases
{
    public class Venta
    {
        private int ? id_venta;
        private int? id_cliente;
        private DateTime fecha;
        private string t_comprobante;
        private string s_comprobante;
        private string n_comprobante;
        private int? total;
        private int? id_usuario;
        private string est_entrega;
        private string estado;

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

        public int? Id_cliente
        {
            get
            {
                return id_cliente;
            }

            set
            {
                id_cliente = value;
            }
        }

        public DateTime Fecha
        {
            get
            {
                return fecha;
            }

            set
            {
                fecha = value;
            }
        }

        public string T_comprobante
        {
            get
            {
                return t_comprobante;
            }

            set
            {
                t_comprobante = value;
            }
        }

        public string S_comprobante
        {
            get
            {
                return s_comprobante;
            }

            set
            {
                s_comprobante = value;
            }
        }

        public string N_comprobante
        {
            get
            {
                return n_comprobante;
            }

            set
            {
                n_comprobante = value;
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

        public int? Id_usuario
        {
            get
            {
                return id_usuario;
            }

            set
            {
                id_usuario = value;
            }
        }

        public string Est_entrega
        {
            get
            {
                return est_entrega;
            }

            set
            {
                est_entrega = value;
            }
        }

        public string Estado
        {
            get
            {
                return estado;
            }

            set
            {
                estado = value;
            }
        }
    }
}