using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web_Farmacia.Clases;

namespace Web_Farmacia.Controllers
{
    public class Info
    {
        private List<Producto> prod;
        private List<Categoria> cat;
        private Producto obj_prod;
        private List<Cliente> cli;
        private Cliente obj_cli;
        private List<Usuario> usu;
        private Usuario obj_usu;
        private List<Cargo> car;
        private Cargo obj_car;
        private List<Venta> ven;
        private Venta obj_ven;

        public Info()
        {

        }

        public List<Producto> Prod
        {
            get
            {
                return prod;
            }

            set
            {
                prod = value;
            }
        }

        public List<Categoria> Cat
        {
            get
            {
                return cat;
            }

            set
            {
                cat = value;
            }
        }

        public Producto Obj_prod
        {
            get
            {
                return obj_prod;
            }

            set
            {
                obj_prod = value;
            }
        }

        public List<Cliente> Cli
        {
            get
            {
                return cli;
            }

            set
            {
                cli = value;
            }
        }

        public Cliente Obj_cli
        {
            get
            {
                return obj_cli;
            }

            set
            {
                obj_cli = value;
            }
        }

        public List<Usuario> Usu
        {
            get
            {
                return usu;
            }

            set
            {
                usu = value;
            }
        }

        public Usuario Obj_usu
        {
            get
            {
                return obj_usu;
            }

            set
            {
                obj_usu = value;
            }
        }

        public List<Cargo> Car
        {
            get
            {
                return car;
            }

            set
            {
                car = value;
            }
        }

        public Cargo Obj_car
        {
            get
            {
                return obj_car;
            }

            set
            {
                obj_car = value;
            }
        }

        public List<Venta> Ven
        {
            get
            {
                return ven;
            }

            set
            {
                ven = value;
            }
        }

        public Venta Obj_ven
        {
            get
            {
                return obj_ven;
            }

            set
            {
                obj_ven = value;
            }
        }
    }
}