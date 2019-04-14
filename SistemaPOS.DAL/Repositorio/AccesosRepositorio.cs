using System;
using System.Data;
using System.Data.SqlClient;
using SistemaPOS.Dto.Utilidades;
using SistemaPOS.Dto.Modelos;
using SistemaPOS.DAL.Base;

namespace SistemaPOS.DAL.Repositorio
{
    public class AccesosRepositorio : RepositorioP
    {

        public DataTable IngresoAplitativo(string usuario, string clave)
        {
            using (SqlConnection conn = new SqlConnection(Util.ObtenerCadenaConexion("POS_DB")))
            {
                try
                {
                    string spName = @"[desarrollador].[prcSegUsuarioValido]";
                    SqlCommand cmd = new SqlCommand(spName, conn);

                    cmd.Parameters.Add("@p_usuario", SqlDbType.VarChar);
                    cmd.Parameters["@p_usuario"].Value = usuario;
                    cmd.Parameters.Add("@p_clave", SqlDbType.VarChar);
                    cmd.Parameters["@p_clave"].Value = clave;
                    
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

        public bool ValidaUsuario(string usuario, string clave)
        {
            using (SqlConnection conn = new SqlConnection(Util.ObtenerCadenaConexion("POS_DB")))
            {
                try
                {
                    string funcion = @"select [desarrollador].[fncSegUsuarioValido](@USUARIO, @CLAVE)";
                    SqlCommand cmd = new SqlCommand(funcion, conn);
                    cmd.Parameters.Add("@USUARIO", SqlDbType.VarChar);
                    cmd.Parameters["@USUARIO"].Value = usuario;
                    cmd.Parameters.Add("@CLAVE", SqlDbType.VarChar);
                    cmd.Parameters["@CLAVE"].Value = clave;

                    conn.Open();

                    bool respuesta = cmd.ExecuteScalar().ToString() == "1" ? true : false;

                    conn.Close();

                    return respuesta;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public DataTable CrudMenu(string tipoTrans, MenuDto menu)
        {
            using (SqlConnection conn = new SqlConnection(Util.ObtenerCadenaConexion("POS_DB")))
            {
                try
                {
                    string spName = @"[desarrollador].[prcSegMenu]";
                    SqlCommand cmd = new SqlCommand(spName, conn);
                    
                    SqlParameter transaccion = new SqlParameter("@p_transaccion", SqlDbType.VarChar);
                     transaccion.Value = tipoTrans;
                    SqlParameter idmenu = new SqlParameter("@p_id_menu", SqlDbType.Int);
                    idmenu.Value = menu.id;
                    SqlParameter tag = new SqlParameter("@p_tag", SqlDbType.VarChar);
                    tag.Value = menu.tag;
                    SqlParameter nombre = new SqlParameter("@p_nombre", SqlDbType.VarChar);
                    nombre.Value = menu.nombre;
                    SqlParameter descripcion = new SqlParameter("@p_descripcion", SqlDbType.VarChar);
                    descripcion.Value = menu.descripcion;
                    SqlParameter rutaicono = new SqlParameter("@p_ruta_icono", SqlDbType.VarChar);
                    rutaicono.Value = menu.icono;
                    SqlParameter activo = new SqlParameter("@p_activo", SqlDbType.Int);
                    activo.Value = Convert.ToInt16(menu.activo);
                    SqlParameter usuario = new SqlParameter("@p_usuario", SqlDbType.VarChar);
                    usuario.Value = "POS";
                    
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

        public DataTable CrudGrupo(string tipoTrans, GrupoDto grupo)
        {
            using (SqlConnection conn = new SqlConnection(Util.ObtenerCadenaConexion("POS_DB")))
            {
                try
                {
                    string spName = @"[desarrollador].[prcSegGrupo]";
                    SqlCommand cmd = new SqlCommand(spName, conn);
                    
                    SqlParameter transaccion = new SqlParameter("@p_transaccion", SqlDbType.VarChar);
                    transaccion.Value = tipoTrans;
                    SqlParameter idgrupo = new SqlParameter("@p_id_grupo", SqlDbType.Int);
                    idgrupo.Value = grupo.id;
                    SqlParameter tag = new SqlParameter("@p_tag", SqlDbType.VarChar);
                    tag.Value = grupo.tag;
                    SqlParameter nombre = new SqlParameter("@p_nombre", SqlDbType.VarChar);
                    nombre.Value = grupo.nombre;
                    SqlParameter descripcion = new SqlParameter("@p_descripcion", SqlDbType.VarChar);
                    descripcion.Value = grupo.descripcion;
                    SqlParameter rutaicono = new SqlParameter("@p_ruta_icono", SqlDbType.VarChar);
                    rutaicono.Value = grupo.icono;
                    SqlParameter idmenu = new SqlParameter("@p_id_menu", SqlDbType.Int);
                    idmenu.Value = grupo.idMenu;
                    SqlParameter activo = new SqlParameter("@p_activo", SqlDbType.Int);
                    activo.Value = Convert.ToInt16(grupo.activo);
                    SqlParameter usuario = new SqlParameter("@p_usuario", SqlDbType.VarChar);
                    usuario.Value = "POS";
                    
                    cmd.Parameters.Add(transaccion);
                    cmd.Parameters.Add(idgrupo);
                    cmd.Parameters.Add(tag);
                    cmd.Parameters.Add(nombre);
                    cmd.Parameters.Add(descripcion);
                    cmd.Parameters.Add(rutaicono);
                    cmd.Parameters.Add(idmenu);
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

        public DataTable CrudPermiso(string tipoTrans, PermisoDto permiso)
        {
            using (SqlConnection conn = new SqlConnection(Util.ObtenerCadenaConexion("POS_DB")))
            {
                try
                {
                    string spName = @"[desarrollador].[prcSegPermiso]";
                    SqlCommand cmd = new SqlCommand(spName, conn);
                    
                    SqlParameter transaccion = new SqlParameter("@p_transaccion", SqlDbType.VarChar);
                    transaccion.Value = tipoTrans;
                    SqlParameter idPermiso = new SqlParameter("@p_id_permiso", SqlDbType.Int);
                    idPermiso.Value = permiso.id;
                    SqlParameter idTipoPermiso = new SqlParameter("@p_id_tipo_permiso", SqlDbType.Int);
                    idTipoPermiso.Value = permiso.idTipo;
                    SqlParameter tag = new SqlParameter("@p_tag", SqlDbType.VarChar);
                    tag.Value = permiso.tag;
                    SqlParameter idInterno = new SqlParameter("@p_id_interno", SqlDbType.Int);
                    idInterno.Value = permiso.idInterno;
                    SqlParameter nombre = new SqlParameter("@p_nombre", SqlDbType.VarChar);
                    nombre.Value = permiso.nombre;
                    SqlParameter descripcion = new SqlParameter("@p_descripcion", SqlDbType.VarChar);
                    descripcion.Value = permiso.descripcion;
                    SqlParameter ruta = new SqlParameter("@p_ruta", SqlDbType.VarChar);
                    ruta.Value = permiso.ruta;
                    SqlParameter rutaicono = new SqlParameter("@p_ruta_icono", SqlDbType.VarChar);
                    rutaicono.Value = permiso.icono;
                    SqlParameter idgrupo = new SqlParameter("@p_id_grupo", SqlDbType.Int);
                    idgrupo.Value = permiso.idGrupo;
                    SqlParameter activo = new SqlParameter("@p_activo", SqlDbType.Int);
                    activo.Value = Convert.ToInt16(permiso.activo);
                    SqlParameter usuario = new SqlParameter("@p_usuario", SqlDbType.VarChar);
                    usuario.Value = "POS";
                    
                    cmd.Parameters.Add(transaccion);
                    cmd.Parameters.Add(idPermiso);
                    cmd.Parameters.Add(idTipoPermiso);
                    cmd.Parameters.Add(tag);
                    cmd.Parameters.Add(idInterno);
                    cmd.Parameters.Add(nombre);
                    cmd.Parameters.Add(descripcion);
                    cmd.Parameters.Add(ruta);
                    cmd.Parameters.Add(rutaicono);
                    cmd.Parameters.Add(idgrupo);
                    cmd.Parameters.Add(activo);
                    cmd.Parameters.Add(usuario);

                    DataTable tblPermiso = new DataTable();

                    conn.Open();

                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.ReturnProviderSpecificTypes = true;
                    da.Fill(tblPermiso);
                    da.Dispose();

                    conn.Close();

                    return tblPermiso;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public DataTable ConsultaMenuLateral(string usuario)
        {
            return EjecutaSentencia(Constantes.TAG_MENU_LATERAL, usuario, "");
        }


        public DataTable ConsultaTipoMenu(string usuario)
        {
            return EjecutaSentencia(Constantes.TAG_TIPO_MENU, usuario, "");
        }


        public DataTable ConsultaTipoGrupo(string usuario)
        {
            return EjecutaSentencia(Constantes.TAG_TIPO_GRUPO, usuario, "");
        }
        
        public DataTable ConsultaTipoPermiso(string usuario)
        {
            return EjecutaSentencia(Constantes.TAG_TIPO_PERMISO, usuario, "");
        }
    }
}
