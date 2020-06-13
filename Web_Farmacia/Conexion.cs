using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace Web_Farmacia
{
    public class Conexion
    {
        MySqlConnection con;

        public Conexion()
        {
            con = new MySqlConnection("server=localhost;database=ventas_farmacia;Uid=root;pwd=;");
        }

        public static MySqlConnection conectar()
        {
            Conexion cn = new Conexion();
            cn.con.Open();
            return cn.con;
        }
    }
}