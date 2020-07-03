using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_Farmacia.Clases
{
    public class Usuario
    {
        private int? id_usuario;
        private string nombre;
        private string nom_usuario;
        private string password;
        private string documento;
        private string n_documento;
        private string correo;
        private string celular;
        private string direccion;
        private int? id_cargo;
        private string nom_cargo;

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

        public string Nom_usuario
        {
            get
            {
                return nom_usuario;
            }

            set
            {
                nom_usuario = value;
            }
        }

        public string Password
        {
            get
            {
                return password;
            }

            set
            {
                password = value;
            }
        }

        public string Documento
        {
            get
            {
                return documento;
            }

            set
            {
                documento = value;
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

        public string Nom_cargo
        {
            get
            {
                return nom_cargo;
            }

            set
            {
                nom_cargo = value;
            }
        }
    }
}