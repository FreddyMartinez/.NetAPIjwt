using SistemaPOS.DAL.Base;
using SistemaPOS.Dto.Modelos;
using SistemaPOS.Dto.Utilidades;
using System;
using System.Data;
using System.Data.SqlClient;

namespace SistemaPOS.DAL.Repositorio
{
    public class ClienteRepositorio : RepositorioP
    {

        /*Métodos para pantalla de empresas*/
        #region Cliente  
        public DataTable CrudCliente(string tipoTrans, ClienteDto cliente)
        {
            using (SqlConnection conn = new SqlConnection(Util.ObtenerCadenaConexion("POS_DB")))
            {
                try
                {
                    string spName = @"[dbo].[prcCteCliente]";
                    SqlCommand cmd = new SqlCommand(spName, conn);

                    SqlParameter transaccion = new SqlParameter("@p_transaccion", SqlDbType.VarChar);
                    transaccion.Value = tipoTrans;
                    SqlParameter idCliente = new SqlParameter("@p_id_cliente ", SqlDbType.Int);
                    idCliente.Value = cliente.idCliente;
                    SqlParameter nombre = new SqlParameter("@p_nombres", SqlDbType.VarChar);
                    nombre.Value = cliente.nombre;
                    SqlParameter apellido = new SqlParameter("@p_apellidos", SqlDbType.VarChar);
                    apellido.Value = cliente.apellido;
                    SqlParameter tipoDocumento = new SqlParameter("@p_id_tipo_documento", SqlDbType.Int);
                    tipoDocumento.Value = cliente.tipoDocumento;
                    SqlParameter documento = new SqlParameter("@p_documento", SqlDbType.VarChar);
                    documento.Value = cliente.documento;
                    SqlParameter email = new SqlParameter("@p_email", SqlDbType.VarChar);
                    email.Value = cliente.email;
                    SqlParameter telefono = new SqlParameter("@p_telefono", SqlDbType.VarChar);
                    telefono.Value = cliente.telefono;
                    SqlParameter direccion = new SqlParameter("@p_direccion", SqlDbType.VarChar);
                    direccion.Value = cliente.direccion;
                    SqlParameter barrio = new SqlParameter("@p_id_barrio", SqlDbType.VarChar);
                    barrio.Value = cliente.barrio;
                    SqlParameter clientePrincipal = new SqlParameter("@p_id_cliente_principal", SqlDbType.Int);
                    clientePrincipal.Value = cliente.clientePrincipal;
                    SqlParameter clienteReferidor = new SqlParameter("@p_id_cliente_referidor", SqlDbType.Int);
                    clienteReferidor.Value = cliente.clienteReferidor;
                    SqlParameter activo = new SqlParameter("@p_activo", SqlDbType.Int);
                    activo.Value = Convert.ToInt16(cliente.activo);
                    SqlParameter usuario = new SqlParameter("@p_usuario", SqlDbType.VarChar);
                    usuario.Value = cliente.usuario;

                    cmd.Parameters.Add(transaccion);
                    cmd.Parameters.Add(idCliente);
                    cmd.Parameters.Add(nombre);
                    cmd.Parameters.Add(apellido);
                    cmd.Parameters.Add(tipoDocumento);
                    cmd.Parameters.Add(documento);
                    cmd.Parameters.Add(email);
                    cmd.Parameters.Add(telefono);
                    cmd.Parameters.Add(direccion);
                    cmd.Parameters.Add(barrio);
                    cmd.Parameters.Add(clientePrincipal);
                    cmd.Parameters.Add(clienteReferidor);
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
  
        #endregion

        #region Lookups
        public DataTable ConsultaTipoDocumento()
        {
            return EjecutaSentencia(Constantes.TAG_ID_DOCUMENTO, "dbo", "");
        }

        public DataTable ConsultarClientePrincipal()
        {
            return EjecutaSentencia(Constantes.TAG_CLIENTE_PRINCIPAL, "dbo", "");
        }

        public DataTable ConsultarClienteReferidor()
        {
            return EjecutaSentencia(Constantes.TAG_CLIENTE_REFERIDOR, "dbo", "");
        }
        #endregion
    }
}
