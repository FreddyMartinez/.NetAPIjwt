using SistemaPOS.Dto.Utilidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaPOS.DAL.Base
{
    public class RepositorioP : IRepositorio
    {
        public string ConsultaSentencia(string tag, string usuario)
        {
            using (SqlConnection conn = new SqlConnection(Util.ObtenerCadenaConexion("POS_DB")))
            {
                try
                {
                    string funcion = @"SELECT desarrollador.fncSQLGetScriptTag(@TAG, @USUARIO,'#')";
                    SqlCommand cmd = new SqlCommand(funcion, conn);
                    cmd.Parameters.Add("@TAG", SqlDbType.VarChar);
                    cmd.Parameters["@TAG"].Value = tag;
                    cmd.Parameters.Add("@USUARIO", SqlDbType.VarChar);
                    cmd.Parameters["@USUARIO"].Value = "#" + usuario;

                    conn.Open();

                    string respuesta = cmd.ExecuteScalar().ToString();

                    conn.Close();

                    return respuesta;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }


        public DataTable EjecutaSentencia(string tag, string usuario)
        {
            string sentencia = ConsultaSentencia(tag, usuario);
            using (SqlConnection conn = new SqlConnection(Util.ObtenerCadenaConexion("POS_DB")))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand(sentencia, conn);

                    DataTable tblRespuesta = new DataTable();

                    conn.Open();

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.ReturnProviderSpecificTypes = true;
                    da.Fill(tblRespuesta);
                    da.Dispose();

                    conn.Close();

                    return tblRespuesta;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
    }
}
