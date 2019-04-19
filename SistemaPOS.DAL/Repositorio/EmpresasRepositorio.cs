using SistemaPOS.DAL.Base;
using SistemaPOS.Dto.Modelos;
using SistemaPOS.Dto.Utilidades;
using System;
using System.Data;
using System.Data.SqlClient;

namespace SistemaPOS.DAL.Repositorio
{
    public class EmpresasRepositorio : RepositorioP
    {

        /*Métodos para pantalla de empresas*/
        #region Empresa  
        public DataTable CrudEmpresa(string tipoTrans, EmpresaDto empresa)
        {
            using (SqlConnection conn = new SqlConnection(Util.ObtenerCadenaConexion("POS_DB")))
            {
                try
                {
                    string spName = @"[desarrollador].[prcCteEmpresa]";
                    SqlCommand cmd = new SqlCommand(spName, conn);

                    SqlParameter transaccion = new SqlParameter("@p_transaccion", SqlDbType.VarChar);
                    transaccion.Value = tipoTrans;
                    SqlParameter idEmpresa = new SqlParameter("@p_id_empresa", SqlDbType.Int);
                    idEmpresa.Value = empresa.idEmpresa;
                    SqlParameter idCliente = new SqlParameter("@p_id_cliente", SqlDbType.Int);
                    idCliente.Value = empresa.idCliente;
                    SqlParameter nombre = new SqlParameter("@p_nombre", SqlDbType.VarChar);
                    nombre.Value = empresa.nombre;
                    SqlParameter nit = new SqlParameter("@p_nit", SqlDbType.VarChar);
                    nit.Value = empresa.nit;
                    SqlParameter digitoVerificacion = new SqlParameter("@p_digito_verificacion", SqlDbType.VarChar);
                    digitoVerificacion.Value = empresa.digitoVerificacion;
                    SqlParameter contacto = new SqlParameter("@p_contacto", SqlDbType.VarChar);
                    contacto.Value = empresa.contacto;
                    SqlParameter telefonoContacto = new SqlParameter("@p_telefono_contacto", SqlDbType.VarChar);
                    telefonoContacto.Value = empresa.telefonoContacto;
                    SqlParameter emailContacto = new SqlParameter("@p_email_contacto", SqlDbType.VarChar);
                    emailContacto.Value = empresa.emailContacto;
                    SqlParameter activo = new SqlParameter("@p_activo", SqlDbType.Int);
                    activo.Value = Convert.ToInt16(empresa.activo);
                    SqlParameter usuario = new SqlParameter("@p_usuario", SqlDbType.VarChar);
                    usuario.Value = "POS";

                    cmd.Parameters.Add(transaccion);
                    cmd.Parameters.Add(idEmpresa);
                    cmd.Parameters.Add(idCliente);
                    cmd.Parameters.Add(nombre);
                    cmd.Parameters.Add(nit);
                    cmd.Parameters.Add(digitoVerificacion);
                    cmd.Parameters.Add(contacto);
                    cmd.Parameters.Add(telefonoContacto);
                    cmd.Parameters.Add(emailContacto);
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

        public DataTable CrudSucursalEmpresa(string tipoTrans, SucursalEmpresaDto sucursalEmpresa)
        {
            using (SqlConnection conn = new SqlConnection(Util.ObtenerCadenaConexion("POS_DB")))
            {
                try
                {
                    string spName = @"[desarrollador].[prcCteEmpresa]";
                    SqlCommand cmd = new SqlCommand(spName, conn);

                    SqlParameter transaccion = new SqlParameter("@p_transaccion", SqlDbType.VarChar);
                    transaccion.Value = tipoTrans;
                    SqlParameter idSucursal = new SqlParameter("@p_id_sucursal", SqlDbType.Int);
                    idSucursal.Value = sucursalEmpresa.idSucursal;
                    SqlParameter idTipoSucursal = new SqlParameter("@p_id_tipo_sucursal", SqlDbType.Int);
                    idTipoSucursal.Value = sucursalEmpresa.idTipoSucursal;
                    SqlParameter idEmpresa = new SqlParameter("@p_id_empresa", SqlDbType.Int);
                    idEmpresa.Value = sucursalEmpresa.idEmpresa;
                    SqlParameter nombre = new SqlParameter("@p_nombre", SqlDbType.VarChar);
                    nombre.Value = sucursalEmpresa.nombre;                    
                    SqlParameter direccion = new SqlParameter("@p_direccion", SqlDbType.VarChar);
                    direccion.Value = sucursalEmpresa.direccion;
                    SqlParameter barrio = new SqlParameter("@p_id_barrio", SqlDbType.VarChar);
                    barrio.Value = sucursalEmpresa.barrio;
                    SqlParameter telefono = new SqlParameter("@p_telefono", SqlDbType.VarChar);
                    telefono.Value = sucursalEmpresa.telefono;
                    SqlParameter email = new SqlParameter("@p_email", SqlDbType.VarChar);
                    email.Value = sucursalEmpresa.email;
                    SqlParameter contacto = new SqlParameter("@p_contacto", SqlDbType.VarChar);
                    contacto.Value = sucursalEmpresa.contacto;
                    SqlParameter telefonoContacto = new SqlParameter("@p_telefono_contacto", SqlDbType.VarChar);
                    telefonoContacto.Value = sucursalEmpresa.telefonoContacto;
                    SqlParameter emailContacto = new SqlParameter("@p_email_contacto", SqlDbType.VarChar);
                    emailContacto.Value = sucursalEmpresa.emailContacto;
                    SqlParameter activo = new SqlParameter("@p_activo", SqlDbType.Int);
                    activo.Value = Convert.ToInt16(sucursalEmpresa.activo);
                    SqlParameter usuario = new SqlParameter("@p_usuario", SqlDbType.VarChar);
                    usuario.Value = "POS";

                    cmd.Parameters.Add(transaccion);
                    cmd.Parameters.Add(idSucursal);
                    cmd.Parameters.Add(idTipoSucursal);
                    cmd.Parameters.Add(idEmpresa);
                    cmd.Parameters.Add(nombre);
                    cmd.Parameters.Add(direccion);
                    cmd.Parameters.Add(barrio);
                    cmd.Parameters.Add(telefono);
                    cmd.Parameters.Add(email);
                    cmd.Parameters.Add(contacto);
                    cmd.Parameters.Add(telefonoContacto);
                    cmd.Parameters.Add(emailContacto);
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
        public DataTable ConsultaTipoSucursal()
        {
            return EjecutaSentencia(Constantes.TAG_TIPO_SUCURSAL, "DESARROLLADOR", "");
        }

        public DataTable ConsultarEmpresasCliente(string idCliente)
        {
            return EjecutaSentencia(Constantes.TAG_EMPRESA_CLIENTE, "DESARROLLADOR", idCliente);
        }
        
        #endregion
    }
}
