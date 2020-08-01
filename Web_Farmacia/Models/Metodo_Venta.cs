using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web_Farmacia.Clases;
using MySql.Data.MySqlClient;

namespace Web_Farmacia.Models
{
    public class Metodo_Venta
    {
        MySqlCommand cmd;
        MySqlConnection con;

        public Metodo_Venta()
        {

        }
        public int guardar(Venta ven)
        {
            int valor=0;
            MySqlDataReader rd;
            //try
            //{
            using (con = Conexion.conectar())
            {
                using (cmd = new MySqlCommand())
                {
                    cmd.CommandText = "SP_A_Tabla_Ventas";
                    //cmd.CommandText = string.Format("insert into tbl_categoria(nombre,descripcion)" +
                    //    "values('{0}','{1}')", cat.Nombre, cat.Descripcion);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Connection = con;

                    cmd.Parameters.AddWithValue("_id_cliente", ven.Id_cliente);
                    cmd.Parameters.AddWithValue("_fecha", ven.Fecha);
                    cmd.Parameters.AddWithValue("_t_comprobante", ven.T_comprobante);
                    cmd.Parameters.AddWithValue("_serie_com", ven.S_comprobante);
                    cmd.Parameters.AddWithValue("_nro_com", ven.N_comprobante);
                    cmd.Parameters.AddWithValue("_total", ven.Total);
                    cmd.Parameters.AddWithValue("_id_usuario", ven.Id_usuario);
                    cmd.Parameters.AddWithValue("_est_entrega", ven.Est_entrega);
                    cmd.Parameters.AddWithValue("_estado", ven.Estado);

                    rd = cmd.ExecuteReader();

                    while (rd.Read())
                    {
                        valor = rd.GetInt32("@nuevoId");
                    }
                    rd.Close();
                }
            }
            return valor;

            //}
            //catch (Exception ex)
            //{
            //    return false;
            //}
            
        }

        public List<Venta> listar()
        {
            //try
            //{

            MySqlDataReader rd;
            List<Venta> lista = new List<Venta>();

            using (con = Conexion.conectar())
            {
                using (cmd = new MySqlCommand())
                {
                    cmd.CommandText = "SP_C_Tabla_Ventas";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Connection = con;

                    rd = cmd.ExecuteReader();

                    while (rd.Read())
                    {
                        lista.Add(new Venta
                        {
                            Id_venta = rd.GetInt32("id_ventas"),
                            Id_usuario = rd.GetInt32("id_usuario"),
                            Id_cliente = rd.GetInt32("id_cliente"),
                            Cliente = rd.GetString("cliente"),
                            Fecha = rd.GetDateTime("fecha"),
                            T_comprobante = rd.GetString("t_comprobante"),
                            S_comprobante = rd.GetString("serie_com"),
                            N_comprobante = rd.GetString("nro_com"),
                            Nom_usuario = rd.GetString("usuario"),
                            Total = rd.GetDouble("total"),
                            Est_entrega = rd.GetString("est_entrega"),
                            Estado= rd.GetString("estado"),
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
                        cmd.CommandText = "SP_E_Tabla_Ventas";
                        //cmd.CommandText = string.Format("Delete from tbl_categoria where id_categoria = {0}", id);
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Connection = con;

                        cmd.Parameters.AddWithValue("_id_ventas", id);

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

        public Boolean actualizar(Venta ven)
        {
            try
            {
                using (con = Conexion.conectar())
                {
                    using (cmd = new MySqlCommand())
                    {
                        cmd.CommandText = "SP_M_Tabla_Ventas";
                        //  cmd.CommandText = string.Format("update tbl_categoria set nombre='{0}',
                        //descripcion ='{1}' where id_categoria ='{2}'"
                        //, cat.Nombre, cat.Descripcion, cat.Id_categoria);
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Connection = con;

                        cmd.Parameters.AddWithValue("_id_cliente", ven.Id_cliente);
                        cmd.Parameters.AddWithValue("_fecha", ven.Fecha);
                        cmd.Parameters.AddWithValue("_t_comprobante", ven.T_comprobante);
                        cmd.Parameters.AddWithValue("_serie_com", ven.S_comprobante);
                        cmd.Parameters.AddWithValue("_nro_com", ven.N_comprobante);
                        cmd.Parameters.AddWithValue("_total", ven.Total);
                        cmd.Parameters.AddWithValue("_id_usuario", ven.Id_usuario);
                        cmd.Parameters.AddWithValue("_est_entrega", ven.Est_entrega);
                        cmd.Parameters.AddWithValue("_estado", ven.Estado);
                        cmd.Parameters.AddWithValue("_id_ventas", ven.Id_venta);


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

        public Venta obtener(int? id)
        {
            try
            {
                MySqlDataReader rd;
                Venta ven = new Venta();

                using (con = Conexion.conectar())
                {
                    using (cmd = new MySqlCommand())
                    {
                        cmd.CommandText = "SP_O_Tabla_Ventas";
                        //cmd.CommandText = string.Format("Select * from tbl_categoria where id_categoria='{0}'", id);
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Connection = con;

                        cmd.Parameters.AddWithValue("_id_usuario", id);

                        rd = cmd.ExecuteReader();

                        while (rd.Read())
                        {
                            ven.Id_venta = rd.GetInt32("id_ventas");
                            ven.Id_usuario = rd.GetInt32("id_usuario");
                            ven.Id_cliente = rd.GetInt32("id_cliente");
                            ven.Fecha = rd.GetDateTime("fecha");
                            ven.T_comprobante = rd.GetString("t_comprobante");
                            ven.S_comprobante = rd.GetString("serie_com");
                            ven.N_comprobante = rd.GetString("nro_com");
                            ven.Total = rd.GetDouble("total");
                            ven.Est_entrega = rd.GetString("est_entrega");
                            ven.Estado = rd.GetString("estado");


                        }

                        rd.Close();

                    }
                }

                return ven;
            }
            catch (Exception)
            {
                return null;
            }

        }
    }
}