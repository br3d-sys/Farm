using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using Web_Farmacia.Clases;

namespace Web_Farmacia.Models
{
    public class Metodo_Usuario
    {
        MySqlCommand cmd;
        MySqlConnection con;

        public Metodo_Usuario()
        {

        }
        public Boolean guardar(Usuario usu)
        {
            //try
            //{
                using (con = Conexion.conectar())
                {
                    using (cmd = new MySqlCommand())
                    {
                        cmd.CommandText = "SP_A_Tabla_Usuario";
                        //cmd.CommandText = string.Format("insert into tbl_categoria(nombre,descripcion)" +
                        //    "values('{0}','{1}')", cat.Nombre, cat.Descripcion);
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Connection = con;

                        cmd.Parameters.AddWithValue("_nombre", usu.Nombre);
                        cmd.Parameters.AddWithValue("_usuario", usu.Nom_usuario);
                        cmd.Parameters.AddWithValue("_contrasena", usu.Password);
                        cmd.Parameters.AddWithValue("_documento", usu.Documento);
                        cmd.Parameters.AddWithValue("_n_documento", usu.N_documento);
                        cmd.Parameters.AddWithValue("_correo", usu.Correo);
                        cmd.Parameters.AddWithValue("_celular", usu.Celular);
                        cmd.Parameters.AddWithValue("_direccion", usu.Direccion);
                        cmd.Parameters.AddWithValue("_id_cargo", usu.Id_cargo);

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

        public List<Usuario> listar()
        {
            //try
            //{

                MySqlDataReader rd;
                List<Usuario> lista = new List<Usuario>();

                using (con = Conexion.conectar())
                {
                    using (cmd = new MySqlCommand())
                    {
                        cmd.CommandText = "SP_C_Tabla_Usuario";
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Connection = con;

                        rd = cmd.ExecuteReader();

                        while (rd.Read())
                        {
                            lista.Add(new Usuario
                            {
                                Id_usuario = rd.GetInt32("id_usuario"),
                                Nombre = rd.GetString("nombre"),
                                Nom_usuario = rd.GetString("usuario"),
                                Documento = rd.GetString("documento"),
                                N_documento = rd.GetString("n_documento"),
                                Correo = rd.GetString("correo"),
                                Celular = rd.GetString("celular"),
                                Direccion = rd.GetString("direccion"),
                                Id_cargo = rd.GetInt32("id_cargo"),
                                Nom_cargo = rd.GetString("cargo")
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
                        cmd.CommandText = "SP_E_Tabla_Usuario";
                        //cmd.CommandText = string.Format("Delete from tbl_categoria where id_categoria = {0}", id);
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Connection = con;

                        cmd.Parameters.AddWithValue("_id_usuario", id);

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

        public Boolean actualizar(Usuario usu)
        {
            try
            {
                using (con = Conexion.conectar())
                {
                    using (cmd = new MySqlCommand())
                    {
                        cmd.CommandText = "SP_M_Tabla_Usuario";
                        //  cmd.CommandText = string.Format("update tbl_categoria set nombre='{0}',
                        //descripcion ='{1}' where id_categoria ='{2}'"
                        //, cat.Nombre, cat.Descripcion, cat.Id_categoria);
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Connection = con;

                        cmd.Parameters.AddWithValue("_nombre", usu.Nombre);
                        cmd.Parameters.AddWithValue("_usuario", usu.Nom_usuario);
                        cmd.Parameters.AddWithValue("_contrasena", usu.Password);
                        cmd.Parameters.AddWithValue("_documento", usu.Documento);
                        cmd.Parameters.AddWithValue("_n_documento", usu.N_documento);
                        cmd.Parameters.AddWithValue("_correo", usu.Correo);
                        cmd.Parameters.AddWithValue("_celular", usu.Celular);
                        cmd.Parameters.AddWithValue("_direccion", usu.Direccion);
                        cmd.Parameters.AddWithValue("_id_cargo", usu.Id_cargo);
                        cmd.Parameters.AddWithValue("_id_usuario", usu.Id_usuario);


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

        public Usuario obtener(int? id)
        {
            try
            {
                MySqlDataReader rd;
                Usuario usu = new Usuario();

                using (con = Conexion.conectar())
                {
                    using (cmd = new MySqlCommand())
                    {
                        cmd.CommandText = "SP_O_Tabla_Usuario";
                        //cmd.CommandText = string.Format("Select * from tbl_categoria where id_categoria='{0}'", id);
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Connection = con;

                        cmd.Parameters.AddWithValue("_id_usuario", id);

                        rd = cmd.ExecuteReader();

                        while (rd.Read())
                        {
                            usu.Id_usuario = rd.GetInt32("id_usuario");
                            usu.Nombre = rd.GetString("nombre");
                            usu.Nom_usuario = rd.GetString("usuario");
                            usu.Password = rd.GetString("contrasena");
                            usu.Documento = rd.GetString("documento");
                            usu.N_documento = rd.GetString("n_documento");
                            usu.Correo = rd.GetString("correo");
                            usu.Celular = rd.GetString("celular");
                            usu.Direccion = rd.GetString("direccion");
                            usu.Id_cargo = rd.GetInt32("id_cargo");
                        }

                        rd.Close();

                    }
                }

                return usu;
            }
            catch (Exception)
            {
                return null;
            }

        }
    }
}