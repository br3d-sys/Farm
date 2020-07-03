using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web_Farmacia.Clases;
using MySql.Data.MySqlClient;

namespace Web_Farmacia.Models
{
    public class Metodo_Cargo
    {
        MySqlCommand cmd;
        MySqlConnection con;

        public Metodo_Cargo()
        {

        }
        public Boolean guardar(Cargo car)
        {
            try
            {
                using (con = Conexion.conectar())
                {
                    using (cmd = new MySqlCommand())
                    {
                        cmd.CommandText = "SP_A_Tabla_Cargo";
                        //cmd.CommandText = string.Format("insert into tbl_categoria(nombre,descripcion)" +
                        //    "values('{0}','{1}')", cat.Nombre, cat.Descripcion);
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Connection = con;

                        cmd.Parameters.AddWithValue("_nombre", car.Nombre);
                        cmd.Parameters.AddWithValue("_detalle", car.Detalle);

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
            catch (Exception ex)
            {
                return false;
            }

        }

        public List<Cargo> listar()
        {
            try
            {

                MySqlDataReader rd;
                List<Cargo> lista = new List<Cargo>();

                using (con = Conexion.conectar())
                {
                    using (cmd = new MySqlCommand())
                    {
                        cmd.CommandText = "SP_C_Tabla_Cargo";
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Connection = con;

                        rd = cmd.ExecuteReader();

                        while (rd.Read())
                        {
                            lista.Add(new Cargo
                            {
                                Id_cargo = rd.GetInt32("id_cargo"),
                                Nombre = rd.GetString("nombre"),
                                Detalle = rd.GetString("detalle"),

                            });
                        }

                        rd.Close();

                    }
                }

                return lista;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Boolean eliminar(int id)
        {
            try
            {
                using (con = Conexion.conectar())
                {
                    using (cmd = new MySqlCommand())
                    {
                        cmd.CommandText = "SP_E_Tabla_Cargo";
                        //cmd.CommandText = string.Format("Delete from tbl_categoria where id_categoria = {0}", id);
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Connection = con;

                        cmd.Parameters.AddWithValue("_id_cargo", id);

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

        public Boolean actualizar(Cargo car)
        {
            try
            {
                using (con = Conexion.conectar())
                {
                    using (cmd = new MySqlCommand())
                    {
                        cmd.CommandText = "SP_M_Tabla_Cargo";
                        //  cmd.CommandText = string.Format("update tbl_categoria set nombre='{0}',
                        //descripcion ='{1}' where id_categoria ='{2}'"
                        //, cat.Nombre, cat.Descripcion, cat.Id_categoria);
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Connection = con;

                        cmd.Parameters.AddWithValue("_nombre", car.Nombre);
                        cmd.Parameters.AddWithValue("_detalle", car.Detalle);
                        cmd.Parameters.AddWithValue("_id_cargo", car.Id_cargo);

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

        public Cargo obtener(int? id)
        {
            try
            {
                MySqlDataReader rd;
                Cargo car = new Cargo();

                using (con = Conexion.conectar())
                {
                    using (cmd = new MySqlCommand())
                    {
                        cmd.CommandText = "SP_O_Tabla_Cargo";
                        //cmd.CommandText = string.Format("Select * from tbl_categoria where id_categoria='{0}'", id);
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Connection = con;

                        cmd.Parameters.AddWithValue("_id_cargo", id);

                        rd = cmd.ExecuteReader();

                        while (rd.Read())
                        {
                            car.Id_cargo = rd.GetInt32("id_cargo");
                            car.Nombre = rd.GetString("nombre");
                            car.Detalle = rd.GetString("detalle");
                        }

                        rd.Close();

                    }
                }

                return car;
            }
            catch (Exception)
            {
                return null;
            }

        }
    }
}