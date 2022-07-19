using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OrdenesServicio_WebApp.Models;
using System.Data.SqlClient;
using System.Data;

namespace OrdenesServicio_WebApp.Logica
{
    public class LO_Usuario
    {
        //Método para acceder a la tabla usuario
        public Usuario FindUser(string correo, string clave)
        {
            Usuario ObjUsuario = new Usuario();

            using (SqlConnection conexion = new SqlConnection("Data Source = DESKTOP-GE7QC6U; Initial Catalog = OrdenesServicio; Integrated Security=true"))
            {
                string query = "SELECT Nombre, Correo, Contrasenia, FkRol FROM Usuarios WHERE Correo=@pcorreo AND Contrasenia= @pclave";
                SqlCommand cmd = new SqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@pcorreo", correo);
                cmd.Parameters.AddWithValue("@pclave", clave);
                cmd.CommandType= CommandType.Text;

                conexion.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        ObjUsuario = new Usuario()
                        {
                            Nombre = dr["Nombre"].ToString(),
                            Correo = dr["Correo"].ToString(),
                            Password = dr["Contrasenia"].ToString(),
                            IdRol = (Rol) dr["FkRol"],
                        };
                    }
                }
            }

                return ObjUsuario;
            //Si es que encontró al usuario
        }
    }
}