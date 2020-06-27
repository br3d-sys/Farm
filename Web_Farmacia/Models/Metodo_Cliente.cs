using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web_Farmacia.Clases;
using MySql.Data.MySqlClient;

namespace Web_Farmacia.Models
{
    public class Metodo_Cliente
    {
        MySqlCommand cmd;
        MySqlConnection con;

        public Metodo_Cliente()
        {

        }
        public Boolean guardar(Cliente cli)
        {
            try
            {
                using (con = Conexion.conectar())
                {
                    using (cmd = new MySqlCommand())
                    {
                        cmd.CommandText = "SP_A_Tabla_Cliente";
                        //cmd.CommandText = string.Format("insert into tbl_categoria(nombre,descripcion)" +
                        //    "values('{0}','{1}')", cat.Nombre, cat.Descripcion);
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Connection = con;

                        cmd.Parameters.AddWithValue("_nombre", cli.Nombre);
                        cmd.Parameters.AddWithValue("_t_documento", cli.T_documento);
                        cmd.Parameters.AddWithValue("_n_documento", cli.N_documento);
                        cmd.Parameters.AddWithValue("_direccion", cli.Direccion);
                        cmd.Parameters.AddWithValue("_celular", cli.Celular);
                        cmd.Parameters.AddWithValue("_correo", cli.Correo);
                        cmd.Parameters.AddWithValue("_edad", cli.Edad);
                        cmd.Parameters.AddWithValue("_sexo", cli.Sexo);
                        cmd.Parameters.AddWithValue("_est_civil", cli.Est_civil);
                        cmd.Parameters.AddWithValue("_usuario", cli.Usuario);
                        cmd.Parameters.AddWithValue("_contraseña", cli.Contraseña);

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

        public List<Cliente> listar()
        {
            //try
            //{

                MySqlDataReader rd;
                List<Cliente> lista = new List<Cliente>();

                using (con = Conexion.conectar())
                {
                    using (cmd = new MySqlCommand())
                    {
                        cmd.CommandText = "SP_C_Tabla_Cliente";
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Connection = con;

                        rd = cmd.ExecuteReader();

                        while (rd.Read())
                        {
                            lista.Add(new Cliente
                            {
                                Id_cliente = rd.GetInt32("id_cliente"),
                                Nombre = rd.GetString("nombre"),
                                T_documento = rd.GetString("t_documento"),
                                N_documento = rd.GetValue(3) == DBNull.Value?String.Empty: rd.GetString("n_documento"),
                                //Direccion = rd.GetString("direccion")==null?"": rd.GetString("direccion"),
                                //Celular = rd.GetString("celular") == null ? "" : rd.GetString("celular"),
                                //Correo = rd.GetString("correo") == null ? "" : rd.GetString("correo"),
                                //Edad = rd.GetInt32("edad") == 0 ? 0 : rd.GetInt32("edad"),
                                //Sexo = rd.GetString("sexo") == null ? "" : rd.GetString("sexo"),
                                //Est_civil = rd.GetString("est_civil") == null ? "" : rd.GetString("est_civil")
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
                        cmd.CommandText = "SP_E_Tabla_Cliente";
                        //cmd.CommandText = string.Format("Delete from tbl_categoria where id_categoria = {0}", id);
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Connection = con;

                        cmd.Parameters.AddWithValue("_id_cliente", id);

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

        public Boolean actualizar(Cliente cli)
        {
            try
            {
                using (con = Conexion.conectar())
                {
                    using (cmd = new MySqlCommand())
                    {
                        cmd.CommandText = "SP_M_Tabla_Cliente";
                        //  cmd.CommandText = string.Format("update tbl_categoria set nombre='{0}',
                        //descripcion ='{1}' where id_categoria ='{2}'"
                        //, cat.Nombre, cat.Descripcion, cat.Id_categoria);
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Connection = con;

                        cmd.Parameters.AddWithValue("_nombre", cli.Nombre);
                        cmd.Parameters.AddWithValue("_t_documento", cli.T_documento);
                        cmd.Parameters.AddWithValue("_n_documento", cli.N_documento);
                        cmd.Parameters.AddWithValue("_direccion", cli.Direccion);
                        cmd.Parameters.AddWithValue("_celular", cli.Celular);
                        cmd.Parameters.AddWithValue("_correo", cli.Correo);
                        cmd.Parameters.AddWithValue("_edad", cli.Edad);
                        cmd.Parameters.AddWithValue("_sexo", cli.Sexo);
                        cmd.Parameters.AddWithValue("_est_civil", cli.Est_civil);
                        cmd.Parameters.AddWithValue("_usuario", cli.Usuario);
                        cmd.Parameters.AddWithValue("_contraseña", cli.Contraseña);
                        cmd.Parameters.AddWithValue("_id_cliente", cli.Id_cliente);


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

        public Cliente obtener(int? id)
        {
            try
            {
                MySqlDataReader rd;
                Cliente cli = new Cliente();

                using (con = Conexion.conectar())
                {
                    using (cmd = new MySqlCommand())
                    {
                        cmd.CommandText = "SP_O_Tabla_Cliente";
                        //cmd.CommandText = string.Format("Select * from tbl_categoria where id_categoria='{0}'", id);
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Connection = con;

                        cmd.Parameters.AddWithValue("_id_cliente", id);

                        rd = cmd.ExecuteReader();

                        while (rd.Read())
                        {
                            cli.Id_cliente = rd.GetInt32("id_cliente");
                            cli.Nombre = rd.GetString("nombre");
                            cli.T_documento = rd.GetString("t_documento");
                            cli.N_documento = rd.GetString("n_documento");
                            cli.Direccion = rd.GetString("direccion");
                            cli.Celular = rd.GetString("celular");
                            cli.Correo = rd.GetString("correo");
                            cli.Edad = rd.GetInt32("edad");
                            cli.Sexo = rd.GetString("sexo");
                            cli.Est_civil = rd.GetString("est_civil");
                            cli.Usuario = rd.GetString("usuario");
                            cli.Contraseña = rd.GetString("contraseña");
                        }

                        rd.Close();

                    }
                }

                return cli;
            }
            catch (Exception)
            {
                return null;
            }

        }
    }
}