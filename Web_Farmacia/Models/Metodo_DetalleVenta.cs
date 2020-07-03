using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web_Farmacia.Clases;
using MySql.Data.MySqlClient;

namespace Web_Farmacia.Models
{
    public class Metodo_DetalleVenta
    {

        MySqlCommand cmd;
        MySqlConnection con;

        public Metodo_DetalleVenta()
        {

        }
        public Boolean guardar(DetalleVenta dven)
        {
            //try
            //{
            using (con = Conexion.conectar())
            {
                using (cmd = new MySqlCommand())
                {
                    cmd.CommandText = "SP_A_Detalle_Ventas";
                    //cmd.CommandText = string.Format("insert into tbl_categoria(nombre,descripcion)" +
                    //    "values('{0}','{1}')", cat.Nombre, cat.Descripcion);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Connection = con;

                    cmd.Parameters.AddWithValue("_id_producto", dven.Id_producto);
                    cmd.Parameters.AddWithValue("_id_ventas", dven.Id_venta);
                    cmd.Parameters.AddWithValue("_cantidad", dven.Cantidad);
                    cmd.Parameters.AddWithValue("_precio", dven.Precio);
                    cmd.Parameters.AddWithValue("_total", dven.Total);

                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            //}
            //catch (Exception ex)
            //{
            //    return false;
            //}

        }

        public List<DetalleVenta> listar()
        {
            //try
            //{

            MySqlDataReader rd;
            List<DetalleVenta> lista = new List<DetalleVenta>();

            using (con = Conexion.conectar())
            {
                using (cmd = new MySqlCommand())
                {
                    cmd.CommandText = "SP_C_Detalle_Ventas";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Connection = con;

                    rd = cmd.ExecuteReader();

                    while (rd.Read())
                    {
                        lista.Add(new DetalleVenta
                        {
                            Id_detalleventa = rd.GetInt32("id_detalleventas"),
                            Id_producto = rd.GetInt32("id_producto"),
                            Id_venta = rd.GetInt32("id_ventas"),
                            Cantidad = rd.GetInt32("cantidad"),
                            Precio = rd.GetDouble("precio"),
                            Total = rd.GetDouble("total")
                        
                        });
                    }

                    rd.Close();

                }
            }

            return lista;
            //}
            //catch (Exception)
            //{
            //    return null;
            //}
        }

        public Boolean eliminar(int id)
        {
            try
            {
                using (con = Conexion.conectar())
                {
                    using (cmd = new MySqlCommand())
                    {
                        cmd.CommandText = "SP_E_Detalle_Ventas";
                        //cmd.CommandText = string.Format("Delete from tbl_categoria where id_categoria = {0}", id);
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Connection = con;

                        cmd.Parameters.AddWithValue("_id_detalleventas", id);

                        if (cmd.ExecuteNonQuery() > 0)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Boolean actualizar(DetalleVenta dven)
        {
            try
            {
                using (con = Conexion.conectar())
                {
                    using (cmd = new MySqlCommand())
                    {
                        cmd.CommandText = "SP_M_Detalle_Ventas";
                        //  cmd.CommandText = string.Format("update tbl_categoria set nombre='{0}',
                        //descripcion ='{1}' where id_categoria ='{2}'"
                        //, cat.Nombre, cat.Descripcion, cat.Id_categoria);
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Connection = con;

                        cmd.Parameters.AddWithValue("_id_detalleventas", dven.Id_detalleventa);
                        cmd.Parameters.AddWithValue("_id_producto", dven.Id_producto);
                        cmd.Parameters.AddWithValue("_id_ventas", dven.Id_venta);
                        cmd.Parameters.AddWithValue("_cantidad", dven.Cantidad);
                        cmd.Parameters.AddWithValue("_precio", dven.Precio);
                        cmd.Parameters.AddWithValue("_total", dven.Total);

                        if (cmd.ExecuteNonQuery() > 0)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }

                    }

                }
            }
            catch (Exception)
            {

                return false;
            }

        }

    }
}