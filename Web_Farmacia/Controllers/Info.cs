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
    }
}