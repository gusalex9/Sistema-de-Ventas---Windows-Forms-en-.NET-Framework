using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;
using CapaEntidad;

namespace CapaDatos
{
    public class CDUsuario
    {
        //Metodo que nos permita listar todos los usuarios de nuestra base de datos.
        public List<Usuario> Lista()
        {
            List<Usuario> lista = new List<Usuario>();
            //Conectarme a la base de datos
            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                //Hacer la peticion hacia la base de datos
                try
                {
                    string query = "select IdUsuario, Documento, NombreCompleto, Correo, Clave, Estado from USUARIO";
                    //Ejecutar el comando
                    SqlCommand cmd = new SqlCommand(query, oconexion);
                    cmd.CommandType = CommandType.Text;

                    //Abri la conexion
                    oconexion.Open();

                    //Ejecutar el sqlDataReader
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Usuario()
                            {
                                IdUsuario = Convert.ToInt32(dr["IdUsuario"]),
                                Documento = (string)dr["Documento"],
                                NombreCompleto = (string)dr["NombreCompleto"],
                                Correo = (string)dr["Correo"],
                                Clave = (string)dr["Clave"],
                                Estado = Convert.ToBoolean(dr["Estado"])
                            }); 
                        }
                    }
                }
                catch (Exception ex)
                {
                    lista = new List<Usuario>();
                }
            }
            return lista;   
        }
    }
}
