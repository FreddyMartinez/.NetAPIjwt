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
        public DataTable ConsultarMenu()
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
                     transaccion.Value = "C";
                    SqlParameter idmenu = new SqlParameter("@p_id_menu", SqlDbType.Int);
                    idmenu.Value = -1;
                    SqlParameter tag = new SqlParameter("@p_tag", SqlDbType.VarChar);
                    tag.Value = "";
                    SqlParameter nombre = new SqlParameter("@p_nombre", SqlDbType.VarChar);
                    nombre.Value = "";
                    SqlParameter descripcion = new SqlParameter("@p_descripcion", SqlDbType.VarChar);
                    descripcion.Value = "";
                    SqlParameter rutaicono = new SqlParameter("@p_ruta_icono", SqlDbType.VarChar);
                    rutaicono.Value = "";
                    SqlParameter activo = new SqlParameter("@p_activo", SqlDbType.Int);
                    activo.Value = 1;
                    SqlParameter usuario = new SqlParameter("@p_usuario", SqlDbType.VarChar);
                    usuario.Value = "POS";

                    //add the parameters to the SqlCommand object
                    cmd.Parameters.Add(transaccion);
                    cmd.Parameters.Add(idmenu);
                    cmd.Parameters.Add(tag);
                    cmd.Parameters.Add(nombre);
                    cmd.Parameters.Add(descripcion);
                    cmd.Parameters.Add(rutaicono);
                    cmd.Parameters.Add(activo);
                    cmd.Parameters.Add(usuario);

                    DataTable tblMenu = new DataTable();

                    conn.Open();
                    
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.ReturnProviderSpecificTypes = true;
                    da.Fill(tblMenu);
                    da.Dispose();
                    
                    conn.Close();

                    return tblMenu;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
    }
}
