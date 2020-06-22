using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_Farmacia.Clases
{
    public class Cliente
    {
        private int? id_cliente;
        private string nombre;
        private string t_documento;
        private string n_documento;
        private string direccion;
        private string celular;
        private string correo;
        private int? edad;
        private string sexo;
        private string est_civil;
        private string usuario;
        private string contraseña;

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

        public string T_documento
        {
            get
            {
                return t_documento;
            }

            set
            {
                t_documento = value;
            }
        }

        public string N_documento
        {
            get
            {
                return n_documento;
            }

            set
            {
                n_documento = value;
            }
        }

        public string Direccion
        {
            get
            {
                return direccion;
            }

            set
            {
                direccion = value;
            }
        }

        public string Celular
        {
            get
            {
                return celular;
            }

            set
            {
                celular = value;
            }
        }

        public string Correo
        {
            get
            {
                return correo;
            }

            set
            {
                correo = value;
            }
        }

        public int? Edad
        {
            get
            {
                return edad;
            }

            set
            {
                edad = value;
            }
        }

        public string Sexo
        {
            get
            {
                return sexo;
            }

            set
            {
                sexo = value;
            }
        }

        public string Est_civil
        {
            get
            {
                return est_civil;
            }

            set
            {
                est_civil = value;
            }
        }

        public string Usuario
        {
            get
            {
                return usuario;
            }

            set
            {
                usuario = value;
            }
        }

        public string Contraseña
        {
            get
            {
                return contraseña;
            }

            set
            {
                contraseña = value;
            }
        }
    }
}