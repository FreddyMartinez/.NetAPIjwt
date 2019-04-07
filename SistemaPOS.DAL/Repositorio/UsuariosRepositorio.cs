using SistemaPOS.DAL.Base;
using SistemaPOS.Dto.Modelos;
using SistemaPOS.Dto.Utilidades;
using System;
using System.Data;
using System.Data.SqlClient;

namespace SistemaPOS.DAL.Repositorio
{
    public class UsuariosRepositorio : RepositorioP
    {
        /*Métodos del Perfil*/
        #region Perfil
        public DataTable CrudPerfil(string tipoTrans, PerfilDto perfil)
        {
            using (SqlConnection conn = new SqlConnection(Util.ObtenerCadenaConexion("POS_DB")))
            {
                try
                {
                    string spName = @"[desarrollador].[prcSegPerfil]";
                    SqlCommand cmd = new SqlCommand(spName, conn);

                    SqlParameter transaccion = new SqlParameter("@p_transaccion", SqlDbType.VarChar);
                    transaccion.Value = tipoTrans;
                    SqlParameter idperfil = new SqlParameter("@p_id_perfil", SqlDbType.Int);
                    idperfil.Value = perfil.id;
                    SqlParameter nombre = new SqlParameter("@p_nombre", SqlDbType.VarChar);
                    nombre.Value = perfil.nombre;
                    SqlParameter descripcion = new SqlParameter("@p_descripcion", SqlDbType.VarChar);
                    descripcion.Value = perfil.descripcion;
                    SqlParameter idcliente = new SqlParameter("@p_id_cliente", SqlDbType.VarChar);
                    idcliente.Value = perfil.idCliente;
                    SqlParameter activo = new SqlParameter("@p_activo", SqlDbType.Int);
                    activo.Value = Convert.ToInt16(perfil.activo);
                    SqlParameter usuario = new SqlParameter("@p_usuario", SqlDbType.VarChar);
                    usuario.Value = "POS";

                    cmd.Parameters.Add(transaccion);
                    cmd.Parameters.Add(idperfil);
                    cmd.Parameters.Add(nombre);
                    cmd.Parameters.Add(descripcion);
                    cmd.Parameters.Add(idcliente);
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

        public DataTable CrudPermisosPerfil(string tipoTrans, PermisoPerfilDto permisoPerfil)
        {
            using (SqlConnection conn = new SqlConnection(Util.ObtenerCadenaConexion("POS_DB")))
            {
                try
                {
                    string spName = @"[desarrollador].[prcSegPerfilPermiso]";
                    SqlCommand cmd = new SqlCommand(spName, conn);

                    SqlParameter transaccion = new SqlParameter("@p_transaccion", SqlDbType.VarChar);
                    transaccion.Value = tipoTrans;
                    SqlParameter idperfil = new SqlParameter("@p_id_perfil", SqlDbType.Int);
                    idperfil.Value = permisoPerfil.idPerfil;
                    SqlParameter idpermiso = new SqlParameter("@p_id_permiso", SqlDbType.VarChar);
                    idpermiso.Value = permisoPerfil.idPermiso;
                    SqlParameter activo = new SqlParameter("@p_activo", SqlDbType.Int);
                    activo.Value = Convert.ToInt16(permisoPerfil.activo);
                    SqlParameter usuario = new SqlParameter("@p_usuario", SqlDbType.VarChar);
                    usuario.Value = "POS";

                    cmd.Parameters.Add(transaccion);
                    cmd.Parameters.Add(idperfil);
                    cmd.Parameters.Add(idpermiso);
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

        /*Métodos para pantalla de Rol*/
        #region Rol  
        public DataTable CrudRol(string tipoTrans, RolDto rol)
        {
            using (SqlConnection conn = new SqlConnection(Util.ObtenerCadenaConexion("POS_DB")))
            {
                try
                {
                    string spName = @"[desarrollador].[prcSegRol]";
                    SqlCommand cmd = new SqlCommand(spName, conn);

                    SqlParameter transaccion = new SqlParameter("@p_transaccion", SqlDbType.VarChar);
                    transaccion.Value = tipoTrans;
                    SqlParameter idperfil = new SqlParameter("@p_id_rol", SqlDbType.Int);
                    idperfil.Value = rol.id;
                    SqlParameter nombre = new SqlParameter("@p_nombre", SqlDbType.VarChar);
                    nombre.Value = rol.nombre;
                    SqlParameter descripcion = new SqlParameter("@p_descripcion", SqlDbType.VarChar);
                    descripcion.Value = rol.descripcion;
                    SqlParameter idcliente = new SqlParameter("@p_id_cliente", SqlDbType.VarChar);
                    idcliente.Value = rol.idCliente;
                    SqlParameter activo = new SqlParameter("@p_activo", SqlDbType.Int);
                    activo.Value = Convert.ToInt16(rol.activo);
                    SqlParameter usuario = new SqlParameter("@p_usuario", SqlDbType.VarChar);
                    usuario.Value = "POS";

                    cmd.Parameters.Add(transaccion);
                    cmd.Parameters.Add(idperfil);
                    cmd.Parameters.Add(nombre);
                    cmd.Parameters.Add(descripcion);
                    cmd.Parameters.Add(idcliente);
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

        public DataTable CrudPerfilRol(string tipoTrans, PerfilRolDto perfilrol)
        {
            using (SqlConnection conn = new SqlConnection(Util.ObtenerCadenaConexion("POS_DB")))
            {
                try
                {
                    string spName = @"[desarrollador].[prcSegRolPerfil]";
                    SqlCommand cmd = new SqlCommand(spName, conn);

                    SqlParameter transaccion = new SqlParameter("@p_transaccion", SqlDbType.VarChar);
                    transaccion.Value = tipoTrans;
                    SqlParameter idrol = new SqlParameter("@p_id_rol", SqlDbType.Int);
                    idrol.Value = perfilrol.idRol;
                    SqlParameter idperfil = new SqlParameter("@p_id_perfil", SqlDbType.VarChar);
                    idperfil.Value = perfilrol.idPerfil;
                    SqlParameter activo = new SqlParameter("@p_activo", SqlDbType.Int);
                    activo.Value = Convert.ToInt16(perfilrol.activo);
                    SqlParameter usuario = new SqlParameter("@p_usuario", SqlDbType.VarChar);
                    usuario.Value = "POS";

                    cmd.Parameters.Add(transaccion);
                    cmd.Parameters.Add(idrol);
                    cmd.Parameters.Add(idperfil);
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
        public DataTable ConsultaClientes(string usuario)
        {
            return EjecutaSentencia(Constantes.TAG_ID_CLIENTES, usuario);
        }

        public DataTable ConsultarTiposRol(string usuario)
        {
            return EjecutaSentencia(Constantes.TAG_ID_ROL, usuario);
        }

        public DataTable ConsultarTiposDocumento(string usuario)
        {
            return EjecutaSentencia(Constantes.TAG_ID_DOCUMENTO, usuario);
        }
        #endregion

        public DataTable CrudUsuarios(string tipoTrans, UsuarioDto user)
        {
            using (SqlConnection conn = new SqlConnection(Util.ObtenerCadenaConexion("POS_DB")))
            {
                try
                {
                    string spName = @"[desarrollador].[prcSegUsuario]";
                    SqlCommand cmd = new SqlCommand(spName, conn);

                    SqlParameter transaccion = new SqlParameter("@p_transaccion", SqlDbType.VarChar);
                    transaccion.Value = tipoTrans;
                    SqlParameter usuario = new SqlParameter("@p_usuario", SqlDbType.VarChar);
                    usuario.Value = user.usuario;
                    SqlParameter tipodocumento = new SqlParameter("@p_id_tipo_documento", SqlDbType.Int);
                    tipodocumento.Value = user.tipoDocumento;
                    SqlParameter documento = new SqlParameter("@p_documento", SqlDbType.VarChar);
                    documento.Value = user.documento;
                    SqlParameter nombres = new SqlParameter("@p_nombres", SqlDbType.VarChar);
                    nombres.Value = user.nombre;
                    SqlParameter apellidos = new SqlParameter("@p_apellidos", SqlDbType.VarChar);
                    apellidos.Value = user.apellidos;
                    SqlParameter correo = new SqlParameter("@p_email", SqlDbType.VarChar);
                    correo.Value = user.email;
                    SqlParameter telefono = new SqlParameter("@p_tel_contacto", SqlDbType.VarChar);
                    telefono.Value = user.telefono;
                    SqlParameter clave = new SqlParameter("@p_clave", SqlDbType.VarChar);
                    clave.Value = user.clave;
                    SqlParameter rol = new SqlParameter("@p_id_rol ", SqlDbType.Int);
                    rol.Value = user.rol;
                    SqlParameter cliente = new SqlParameter("@p_id_cliente ", SqlDbType.Int);
                    cliente.Value = user.cliente;
                    SqlParameter activo = new SqlParameter("@p_activo", SqlDbType.Int);
                    activo.Value = Convert.ToInt16(user.activo);
                    SqlParameter usuarioGestion = new SqlParameter("@p_usuario_gestion", SqlDbType.VarChar);
                    usuarioGestion.Value = "POS";

                    cmd.Parameters.Add(transaccion);
                    cmd.Parameters.Add(usuario);
                    cmd.Parameters.Add(tipodocumento);
                    cmd.Parameters.Add(documento);
                    cmd.Parameters.Add(nombres);
                    cmd.Parameters.Add(apellidos);
                    cmd.Parameters.Add(correo);
                    cmd.Parameters.Add(telefono);
                    cmd.Parameters.Add(clave);
                    cmd.Parameters.Add(rol);
                    cmd.Parameters.Add(cliente);
                    cmd.Parameters.Add(activo);
                    cmd.Parameters.Add(usuarioGestion);

                    DataTable tblUsuario = new DataTable();

                    conn.Open();

                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.ReturnProviderSpecificTypes = true;
                    da.Fill(tblUsuario);
                    da.Dispose();

                    conn.Close();

                    return tblUsuario;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
    }
}
