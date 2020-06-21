using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using Web_Farmacia.Clases;

namespace Web_Farmacia.Models
{
    public class Metodo_Producto
    {
        MySqlCommand cmd;
        MySqlConnection con;

        public Metodo_Producto()
        {

        }
        public Boolean guardar(Producto pro)
        {
            try
            {
                using (con = Conexion.conectar())
                {
                    using (cmd = new MySqlCommand())
                    {
                        cmd.CommandText = "SP_C_Tabla_Producto";
                        //cmd.CommandText = string.Format("insert into tbl_producto(nombre,id_categoria,
                        //stock,descripcion,codigo,precio,imagen)" +
                        //    "values('{0}',{1},{2},'{3}','{4}','{5}','{6}')", pro.Nombre, pro.Id_categoria, 
                        //pro.Stock, pro.Descripcion, pro.Codigo, pro.Precio, pro.Imagen);
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Connection = con;

                        cmd.Parameters.AddWithValue("_nombre", pro.Nombre);
                        cmd.Parameters.AddWithValue("_id_categoria", pro.Id_categoria);
                        cmd.Parameters.AddWithValue("_stock", pro.Stock);
                        cmd.Parameters.AddWithValue("_descripcion", pro.Descripcion);
                        cmd.Parameters.AddWithValue("_codigo", pro.Codigo);
                        cmd.Parameters.AddWithValue("_precio", pro.Precio);
                        cmd.Parameters.AddWithValue("_imagen", pro.Imagen);

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

        public List<Producto> listar()
        {
            try
            {
                MySqlDataReader rd;
                List<Producto> lista = new List<Producto>();

                using (con = Conexion.conectar())
                {
                    using (cmd = new MySqlCommand())
                    {
                        cmd.CommandText = "SP_A_Tabla_Producto";
                        //cmd.CommandText = "Select tbl_producto.id_producto, tbl_producto.nombre, 
                        //tbl_producto.id_categoria, tbl_categoria.nombre AS 'categoria', tbl_producto.stock, 
                        //tbl_producto.descripcion, tbl_producto.codigo, tbl_producto.precio, 
                        //tbl_producto.imagen from tbl_producto INNER JOIN tbl_categoria 
                        //ON tbl_producto.id_categoria = tbl_categoria.id_categoria";
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Connection = con;

                        rd = cmd.ExecuteReader();

                        while (rd.Read())
                        {
                            lista.Add(new Producto
                            {
                                Id_producto = rd.GetInt32("id_producto"),
                                Nombre = rd.GetString("nombre"),
                                Id_categoria = rd.GetInt32("id_categoria"),
                                Nom_categoria = rd.GetString("categoria"),
                                Stock = rd.GetInt32("stock"),
                                Descripcion = rd.GetString("descripcion"),
                                Codigo = rd.GetString("codigo"),
                                Precio = rd.GetDouble("precio"),
                                Imagen = rd.GetString("imagen")
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
                        cmd.CommandText = "SP_E_Tabla_Producto";
                        //cmd.CommandText = string.Format("Delete from tbl_producto where id_producto = {0}", id);
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Connection = con;

                        cmd.Parameters.AddWithValue("_id_producto", id);

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

        public Boolean actualizar(Producto pro)
        {
            try
            {
                using (con = Conexion.conectar())
                {
                    using (cmd = new MySqlCommand())
                    {
                        //if(pro.Imagen==null)
                        //{
                        //    cmd.CommandText = string.Format("update tbl_producto set nombre='{0}',id_categoria = '{1}',stock='{2}',descripcion='{3}',codigo='{4}',precio='{5}' where id_producto ='{6}'"
                        //   , pro.Nombre, pro.Id_categoria, pro.Stock, pro.Descripcion, pro.Codigo, pro.Precio, pro.Id_producto);
                        //}
                        //else
                        //{
                        //    cmd.CommandText = string.Format("update tbl_producto set nombre='{0}',id_categoria = '{1}',stock='{2}',descripcion='{3}',codigo='{4}',precio='{5}',imagen='{6}' where id_producto ='{7}'"
                        //  , pro.Nombre, pro.Id_categoria, pro.Stock, pro.Descripcion, pro.Codigo, pro.Precio, pro.Imagen, pro.Id_producto);
                        //}

                        cmd.CommandText = "SP_M_Tabla_Producto";
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Connection = con;

                        cmd.Parameters.AddWithValue("_nombre", pro.Nombre);
                        cmd.Parameters.AddWithValue("_id_categoria", pro.Id_categoria);
                        cmd.Parameters.AddWithValue("_stock", pro.Stock);
                        cmd.Parameters.AddWithValue("_descripcion", pro.Descripcion);
                        cmd.Parameters.AddWithValue("_codigo", pro.Codigo);
                        cmd.Parameters.AddWithValue("_precio", pro.Precio);
                        cmd.Parameters.AddWithValue("_imagen", pro.Imagen);
                        cmd.Parameters.AddWithValue("_id_producto", pro.Id_producto);

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

        public Producto obtener(int ? id)
        {
            try
            {
                MySqlDataReader rd;
                Producto pro = new Producto();

                using (con = Conexion.conectar())
                {
                    using (cmd = new MySqlCommand())
                    {
                        //cmd.CommandText = string.Format("Select * from tbl_producto where id_producto='{0}'", id);
                        cmd.CommandText = "SP_O_Tabla_Producto";
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Connection = con;

                        cmd.Parameters.AddWithValue("_id_producto", id);

                        rd = cmd.ExecuteReader();

                        while (rd.Read())
                        {

                            pro.Id_producto = rd.GetInt32("id_producto");
                            pro.Nombre = rd.GetString("nombre");
                            pro.Id_categoria = rd.GetInt32("id_categoria");
                            pro.Stock = rd.GetInt32("stock");
                            pro.Descripcion = rd.GetString("descripcion");
                            pro.Codigo = rd.GetString("codigo");
                            pro.Precio = rd.GetDouble("precio");
                            pro.Imagen = rd.GetString("imagen");

                        }

                        rd.Close();
                    
                    }
                }

                return pro;
            }
            catch (Exception)
            {
                return null;
            }

        }

        public Boolean subirArchivo(string ruta, HttpPostedFileBase file)
        {
            try
            {
                file.SaveAs(ruta);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            
           
        }

        public List<Producto> buscar(string nombre, string categoria)
        {
            try
            {
                MySqlDataReader rd;
                List<Producto> lista = new List<Producto>();

                using (con = Conexion.conectar())
                {
                    using (cmd = new MySqlCommand())
                    {
                        cmd.CommandText = "SP_B_Tabla_Producto";
                        //cmd.CommandText = string.Format("Select tbl_producto.id_producto, tbl_producto.nombre, tbl_producto.id_categoria, tbl_categoria.nombre AS 'categoria', tbl_producto.stock, tbl_producto.descripcion, tbl_producto.codigo, tbl_producto.precio, tbl_producto.imagen from tbl_producto INNER JOIN tbl_categoria ON tbl_producto.id_categoria = tbl_categoria.id_categoria WHERE tbl_producto.nombre LIKE '%{0}%' and tbl_producto.id_categoria LIKE '%{1}%'", nombre,categoria);
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Connection = con;

                        cmd.Parameters.AddWithValue("_nombre",nombre);
                        cmd.Parameters.AddWithValue("_id_categoria", categoria);

                        rd = cmd.ExecuteReader();

                        while (rd.Read())
                        {
                            lista.Add(new Producto
                            {
                                Id_producto = rd.GetInt32("id_producto"),
                                Nombre = rd.GetString("nombre"),
                                Id_categoria = rd.GetInt32("id_categoria"),
                                Nom_categoria = rd.GetString("categoria"),
                                Stock = rd.GetInt32("stock"),
                                Descripcion = rd.GetString("descripcion"),
                                Codigo = rd.GetString("codigo"),
                                Precio = rd.GetDouble("precio"),
                                Imagen = rd.GetString("imagen")
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

    }
}