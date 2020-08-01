using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_Farmacia.Clases
{
    public class Cargo
    {
        private int? id_cargo;
        private string nombre;
        private string detalle;

        public int? Id_cargo
        {
            get
            {
                return id_cargo;
            }

            set
            {
                id_cargo = value;
            }
        }

        public string Nombre
        {
            get
            {
                return nombre;
            }

            set
            {
                nombre = value;
            }
        }

        public string Detalle
        {
            get
            {
                return detalle;
            }

            set
            {
                detalle = value;
            }
        }
    }
}