using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaPOS.Dto.Utilidades;

namespace SistemaPOS.DAL.Repositorio
{
    public class SeguridadRepositorio
    {
        public string ConsultarMenu()
        {
            using (SqlConnection conn = new SqlConnection(Util.ObtenerCadenaConexion("POS_DB")))
            {
                try
                {
                    //set stored procedure name && SqlCommand object
                    string spName = @"[pos].[prcSegMenu]";
                    SqlCommand cmd = new SqlCommand(spName, conn);

                    //SqlParameters
                    SqlParameter transaccion = new SqlParameter("@p_transaccion", SqlDbType.VarChar);
                     transaccion.Value = 1;
                    SqlParameter idmenu = new SqlParameter("@p_id_menu", SqlDbType.VarChar);
                    idmenu.Value = 1;
                    SqlParameter tag = new SqlParameter("@p_tag", SqlDbType.VarChar);
                    tag.Value = 1;
                    SqlParameter nombre = new SqlParameter("@p_nombre", SqlDbType.VarChar);
                    nombre.Value = 1;
                    SqlParameter descripcion = new SqlParameter("@p_descripcion", SqlDbType.VarChar);
                    descripcion.Value = 1;
                    SqlParameter rutaicono = new SqlParameter("@p_ruta_icono", SqlDbType.VarChar);
                    rutaicono.Value = 1;
                    SqlParameter activo = new SqlParameter("@p_activo", SqlDbType.VarChar);
                    activo.Value = 1;
                    SqlParameter usuario = new SqlParameter("@p_usuario", SqlDbType.VarChar);
                    usuario.Value = 1;

                    //add the parameters to the SqlCommand object
                    cmd.Parameters.Add(transaccion);
                    cmd.Parameters.Add(idmenu);
                    cmd.Parameters.Add(tag);
                    cmd.Parameters.Add(nombre);
                    cmd.Parameters.Add(descripcion);
                    cmd.Parameters.Add(rutaicono);
                    cmd.Parameters.Add(activo);
                    cmd.Parameters.Add(usuario);

                    //open connection
                    conn.Open();

                    //set the SqlCommand type to stored procedure and execute
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader dr = cmd.ExecuteReader();

                    Console.WriteLine(Environment.NewLine + "Retrieving data from database..." + Environment.NewLine);
                    Console.WriteLine("Retrieved records:");

                    //check if there are records
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            var empID = dr.GetInt32(0);
                        }
                    }

                    //close data reader
                    dr.Close();

                    //close connection
                    conn.Close();


                }
                catch (Exception)
                {
                    throw;
                }
            }
            return "funciona";
        }
    }
}
