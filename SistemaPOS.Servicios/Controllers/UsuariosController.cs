using ProyectoPOS.BLL;
using SistemaPOS.Dto.Excepciones;
using SistemaPOS.Dto.Mensajes;
using SistemaPOS.Dto.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;

namespace SistemaPOS.Servicios.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("Usuarios")]
    public class UsuariosController: ApiController
    {
        UsuariosNegocio usuariosNegocio;
        
        /// <summary>
        /// Método que consulta la lista de perfiles existentes en el sistema.
        /// </summary>
        /// <returns>Lista de menú</returns>
        /// Autor:          fmartinez
        /// Fecha Creación: 12-03-2019
        [HttpPost]
        [Route("consultarPerfiles")]
        [ResponseType(typeof(Mensaje))]
        public IHttpActionResult ConsultarPerfil()
        {
            try
            {
                usuariosNegocio = new UsuariosNegocio();
                List<PerfilDto> res = usuariosNegocio.ConsultarPerfil();

                return Content(HttpStatusCode.OK, new Mensaje() { codigoRespuesta = Catalogo.OK, mensajeRespuesta = "", objetoRespuesta = res });
            }
            catch (ExcepcionOperacion exOp)
            {
                return Content(HttpStatusCode.InternalServerError, new Mensaje() { codigoRespuesta = Catalogo.ERROR, mensajeRespuesta = Catalogo.FALLO_CONSULTA_MENU + exOp.Message });
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError, new Mensaje() { codigoRespuesta = Catalogo.ERROR, mensajeRespuesta = Catalogo.FALLO_CONSULTA_MENU + ex.Message });
            }
        }

        /// <summary>
        /// Método que permite crear un nuevo perfil.
        /// </summary>
        /// <returns>Lista de menú</returns>
        /// Autor:          fmartinez
        /// Fecha Creación: 13-03-2019
        [HttpPost]
        [Route("crearPerfil")]
        [ResponseType(typeof(Mensaje))]
        public IHttpActionResult CrearPerfil([FromBody] PerfilDto perfil)
        {
            try
            {
                usuariosNegocio = new UsuariosNegocio();
                string res = usuariosNegocio.CreaModificaPerfil("I", perfil);

                return Content(HttpStatusCode.OK, new Mensaje() { codigoRespuesta = Catalogo.OK, mensajeRespuesta = "", objetoRespuesta = res });
            }
            catch (ExcepcionOperacion exOp)
            {
                return Content(HttpStatusCode.InternalServerError, new Mensaje() { codigoRespuesta = Catalogo.ERROR, mensajeRespuesta = Catalogo.FALLO_CONSULTA_MENU + exOp.Message });
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError, new Mensaje() { codigoRespuesta = Catalogo.ERROR, mensajeRespuesta = Catalogo.FALLO_CONSULTA_MENU + ex.Message });
            }
        }

        /// <summary>
        /// Método que permite modificar la información de un perfil.
        /// </summary>
        /// <returns>Lista de menú</returns>
        /// Autor:          fmartinez
        /// Fecha Creación: 13-03-2019
        [HttpPost]
        [Route("modificarPerfil")]
        [ResponseType(typeof(Mensaje))]
        public IHttpActionResult ModificarPerfil([FromBody] PerfilDto perfil)
        {
            try
            {
                usuariosNegocio = new UsuariosNegocio();
                string res = usuariosNegocio.CreaModificaPerfil("U", perfil);

                return Content(HttpStatusCode.OK, new Mensaje() { codigoRespuesta = Catalogo.OK, mensajeRespuesta = "", objetoRespuesta = res });
            }
            catch (ExcepcionOperacion exOp)
            {
                return Content(HttpStatusCode.InternalServerError, new Mensaje() { codigoRespuesta = Catalogo.ERROR, mensajeRespuesta = Catalogo.FALLO_CONSULTA_MENU + exOp.Message });
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError, new Mensaje() { codigoRespuesta = Catalogo.ERROR, mensajeRespuesta = Catalogo.FALLO_CONSULTA_MENU + ex.Message });
            }
        }

        /// <summary>
        /// Método que permite modificar la información de un perfil.
        /// </summary>
        /// <returns>Lista de menú</returns>
        /// Autor:          fmartinez
        /// Fecha Creación: 13-03-2019
        [HttpPost]
        [Route("eliminarPerfil")]
        [ResponseType(typeof(Mensaje))]
        public IHttpActionResult EliminarPerfil([FromBody] PerfilDto perfil)
        {
            try
            {
                usuariosNegocio = new UsuariosNegocio();
                string res = usuariosNegocio.CreaModificaPerfil("D", perfil);

                return Content(HttpStatusCode.OK, new Mensaje() { codigoRespuesta = Catalogo.OK, mensajeRespuesta = "", objetoRespuesta = res });
            }
            catch (ExcepcionOperacion exOp)
            {
                return Content(HttpStatusCode.InternalServerError, new Mensaje() { codigoRespuesta = Catalogo.ERROR, mensajeRespuesta = Catalogo.FALLO_CONSULTA_MENU + exOp.Message });
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError, new Mensaje() { codigoRespuesta = Catalogo.ERROR, mensajeRespuesta = Catalogo.FALLO_CONSULTA_MENU + ex.Message });
            }
        }

        /// <summary>
        /// Método que consulta la lista de permisoPermisoPerfiles existentes en el sistema.
        /// </summary>
        /// <returns>Lista de menú</returns>
        /// Autor:          fmartinez
        /// Fecha Creación: 12-03-2019
        [HttpPost]
        [Route("consultarPermisosPerfil")]
        [ResponseType(typeof(Mensaje))]
        public IHttpActionResult ConsultarPermisoPerfil([FromBody] ParametroConsultaDto perfil)
        {
            try
            {
                usuariosNegocio = new UsuariosNegocio();
                List<PermisoPerfilDto> res = usuariosNegocio.ConsultarPermisoPerfil(Convert.ToInt32(perfil.parametro));

                return Content(HttpStatusCode.OK, new Mensaje() { codigoRespuesta = Catalogo.OK, mensajeRespuesta = "", objetoRespuesta = res });
            }
            catch (ExcepcionOperacion exOp)
            {
                return Content(HttpStatusCode.InternalServerError, new Mensaje() { codigoRespuesta = Catalogo.ERROR, mensajeRespuesta = Catalogo.FALLO_CONSULTA_MENU + exOp.Message });
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError, new Mensaje() { codigoRespuesta = Catalogo.ERROR, mensajeRespuesta = Catalogo.FALLO_CONSULTA_MENU + ex.Message });
            }
        }

        /// <summary>
        /// Método que permite crear un nuevo permisoPerfil.
        /// </summary>
        /// <returns>Lista de menú</returns>
        /// Autor:          fmartinez
        /// Fecha Creación: 21-03-2019
        [HttpPost]
        [Route("crearPermisoPerfil")]
        [ResponseType(typeof(Mensaje))]
        public IHttpActionResult CrearPermisoPerfil([FromBody] PermisoPerfilDto permisoPermisoPerfil)
        {
            try
            {
                usuariosNegocio = new UsuariosNegocio();
                string res = usuariosNegocio.CreaModificaPermisoPerfil("I", permisoPermisoPerfil);

                return Content(HttpStatusCode.OK, new Mensaje() { codigoRespuesta = Catalogo.OK, mensajeRespuesta = "", objetoRespuesta = res });
            }
            catch (ExcepcionOperacion exOp)
            {
                return Content(HttpStatusCode.InternalServerError, new Mensaje() { codigoRespuesta = Catalogo.ERROR, mensajeRespuesta = Catalogo.FALLO_CONSULTA_MENU + exOp.Message });
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError, new Mensaje() { codigoRespuesta = Catalogo.ERROR, mensajeRespuesta = Catalogo.FALLO_CONSULTA_MENU + ex.Message });
            }
        }

        /// <summary>
        /// Método que permite modificar la información de un permisoPerfil.
        /// </summary>
        /// <returns>Lista de menú</returns>
        /// Autor:          fmartinez
        /// Fecha Creación: 21-03-2019
        [HttpPost]
        [Route("modificarPermisoPerfil")]
        [ResponseType(typeof(Mensaje))]
        public IHttpActionResult ModificarPermisoPerfil([FromBody] PermisoPerfilDto permisoPermisoPerfil)
        {
            try
            {
                usuariosNegocio = new UsuariosNegocio();
                string res = usuariosNegocio.CreaModificaPermisoPerfil("U", permisoPermisoPerfil);

                return Content(HttpStatusCode.OK, new Mensaje() { codigoRespuesta = Catalogo.OK, mensajeRespuesta = "", objetoRespuesta = res });
            }
            catch (ExcepcionOperacion exOp)
            {
                return Content(HttpStatusCode.InternalServerError, new Mensaje() { codigoRespuesta = Catalogo.ERROR, mensajeRespuesta = Catalogo.FALLO_CONSULTA_MENU + exOp.Message });
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError, new Mensaje() { codigoRespuesta = Catalogo.ERROR, mensajeRespuesta = Catalogo.FALLO_CONSULTA_MENU + ex.Message });
            }
        }

        /// <summary>
        /// Método que permite modificar la información de un permisoPerfil.
        /// </summary>
        /// <returns>Lista de menú</returns>
        /// Autor:          fmartinez
        /// Fecha Creación: 21-03-2019
        [HttpPost]
        [Route("eliminarPermisoPerfil")]
        [ResponseType(typeof(Mensaje))]
        public IHttpActionResult EliminarPermisoPerfil([FromBody] PermisoPerfilDto permisoPermisoPerfil)
        {
            try
            {
                usuariosNegocio = new UsuariosNegocio();
                string res = usuariosNegocio.CreaModificaPermisoPerfil("D", permisoPermisoPerfil);

                return Content(HttpStatusCode.OK, new Mensaje() { codigoRespuesta = Catalogo.OK, mensajeRespuesta = "", objetoRespuesta = res });
            }
            catch (ExcepcionOperacion exOp)
            {
                return Content(HttpStatusCode.InternalServerError, new Mensaje() { codigoRespuesta = Catalogo.ERROR, mensajeRespuesta = Catalogo.FALLO_CONSULTA_MENU + exOp.Message });
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError, new Mensaje() { codigoRespuesta = Catalogo.ERROR, mensajeRespuesta = Catalogo.FALLO_CONSULTA_MENU + ex.Message });
            }
        }

        /// <summary>
        /// Método que permite consultar la lista de ids de clientes.
        /// </summary>
        /// <returns>Lista de clientes</returns>
        /// Autor:          fmartinez
        /// Fecha Creación: 19-03-2019
        [HttpPost]
        [Route("consultaClientes")]
        [ResponseType(typeof(Mensaje))]
        public IHttpActionResult ConsultaClientes()
        {
            try
            {
                usuariosNegocio = new UsuariosNegocio();
                List<ObjetoGenericoDto> res = usuariosNegocio.ConsultaClientes();

                return Content(HttpStatusCode.OK, new Mensaje() { codigoRespuesta = Catalogo.OK, mensajeRespuesta = "", objetoRespuesta = res });
            }
            catch (ExcepcionOperacion exOp)
            {
                return Content(HttpStatusCode.InternalServerError, new Mensaje() { codigoRespuesta = Catalogo.ERROR, mensajeRespuesta = Catalogo.FALLO_CONSULTA_MENU + exOp.Message });
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError, new Mensaje() { codigoRespuesta = Catalogo.ERROR, mensajeRespuesta = Catalogo.FALLO_CONSULTA_MENU + ex.Message });
            }
        }
        
        /// <summary>
        /// Método que consulta la lista de Roles existentes en el sistema.
        /// </summary>
        /// <returns>Lista de menú</returns>
        /// Autor:          fmartinez
        /// Fecha Creación: 12-03-2019
        [HttpPost]
        [Route("consultarRoles")]
        [ResponseType(typeof(Mensaje))]
        public IHttpActionResult ConsultarRol()
        {
            try
            {
                usuariosNegocio = new UsuariosNegocio();
                List<RolDto> res = usuariosNegocio.ConsultarRol();

                return Content(HttpStatusCode.OK, new Mensaje() { codigoRespuesta = Catalogo.OK, mensajeRespuesta = "", objetoRespuesta = res });
            }
            catch (ExcepcionOperacion exOp)
            {
                return Content(HttpStatusCode.InternalServerError, new Mensaje() { codigoRespuesta = Catalogo.ERROR, mensajeRespuesta = Catalogo.FALLO_CONSULTA_MENU + exOp.Message });
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError, new Mensaje() { codigoRespuesta = Catalogo.ERROR, mensajeRespuesta = Catalogo.FALLO_CONSULTA_MENU + ex.Message });
            }
        }

        /// <summary>
        /// Método que permite crear un nuevo Rol.
        /// </summary>
        /// <returns>Lista de menú</returns>
        /// Autor:          fmartinez
        /// Fecha Creación: 13-03-2019
        [HttpPost]
        [Route("crearRol")]
        [ResponseType(typeof(Mensaje))]
        public IHttpActionResult CrearRol([FromBody] RolDto rol)
        {
            try
            {
                usuariosNegocio = new UsuariosNegocio();
                string res = usuariosNegocio.CreaModificaRol("I", rol);

                return Content(HttpStatusCode.OK, new Mensaje() { codigoRespuesta = Catalogo.OK, mensajeRespuesta = "", objetoRespuesta = res });
            }
            catch (ExcepcionOperacion exOp)
            {
                return Content(HttpStatusCode.InternalServerError, new Mensaje() { codigoRespuesta = Catalogo.ERROR, mensajeRespuesta = Catalogo.FALLO_CONSULTA_MENU + exOp.Message });
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError, new Mensaje() { codigoRespuesta = Catalogo.ERROR, mensajeRespuesta = Catalogo.FALLO_CONSULTA_MENU + ex.Message });
            }
        }

        /// <summary>
        /// Método que permite modificar la información de un Rol.
        /// </summary>
        /// <returns>Lista de menú</returns>
        /// Autor:          fmartinez
        /// Fecha Creación: 13-03-2019
        [HttpPost]
        [Route("modificarRol")]
        [ResponseType(typeof(Mensaje))]
        public IHttpActionResult ModificarRol([FromBody] RolDto rol)
        {
            try
            {
                usuariosNegocio = new UsuariosNegocio();
                string res = usuariosNegocio.CreaModificaRol("U", rol);

                return Content(HttpStatusCode.OK, new Mensaje() { codigoRespuesta = Catalogo.OK, mensajeRespuesta = "", objetoRespuesta = res });
            }
            catch (ExcepcionOperacion exOp)
            {
                return Content(HttpStatusCode.InternalServerError, new Mensaje() { codigoRespuesta = Catalogo.ERROR, mensajeRespuesta = Catalogo.FALLO_CONSULTA_MENU + exOp.Message });
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError, new Mensaje() { codigoRespuesta = Catalogo.ERROR, mensajeRespuesta = Catalogo.FALLO_CONSULTA_MENU + ex.Message });
            }
        }

        /// <summary>
        /// Método que permite modificar la información de un Rol.
        /// </summary>
        /// <returns>Lista de menú</returns>
        /// Autor:          fmartinez
        /// Fecha Creación: 13-03-2019
        [HttpPost]
        [Route("eliminarRol")]
        [ResponseType(typeof(Mensaje))]
        public IHttpActionResult EliminarRol([FromBody] RolDto rol)
        {
            try
            {
                usuariosNegocio = new UsuariosNegocio();
                string res = usuariosNegocio.CreaModificaRol("D", rol);

                return Content(HttpStatusCode.OK, new Mensaje() { codigoRespuesta = Catalogo.OK, mensajeRespuesta = "", objetoRespuesta = res });
            }
            catch (ExcepcionOperacion exOp)
            {
                return Content(HttpStatusCode.InternalServerError, new Mensaje() { codigoRespuesta = Catalogo.ERROR, mensajeRespuesta = Catalogo.FALLO_CONSULTA_MENU + exOp.Message });
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError, new Mensaje() { codigoRespuesta = Catalogo.ERROR, mensajeRespuesta = Catalogo.FALLO_CONSULTA_MENU + ex.Message });
            }
        }

        /// <summary>
        /// Método que consulta la lista de Perfiles del Rol existentes en el sistema.
        /// </summary>
        /// <returns>Lista de perfiles-rol</returns>
        /// Autor:          fmartinez
        /// Fecha Creación: 22-03-2019
        [HttpPost]
        [Route("consultarPerfilesRol")]
        [ResponseType(typeof(Mensaje))]
        public IHttpActionResult ConsultarPerfilRol([FromBody] ParametroConsultaDto rol)
        {
            try
            {
                usuariosNegocio = new UsuariosNegocio();
                List<PerfilRolDto> res = usuariosNegocio.ConsultarPerfilesRol(Convert.ToInt32(rol.parametro));

                return Content(HttpStatusCode.OK, new Mensaje() { codigoRespuesta = Catalogo.OK, mensajeRespuesta = "", objetoRespuesta = res });
            }
            catch (ExcepcionOperacion exOp)
            {
                return Content(HttpStatusCode.InternalServerError, new Mensaje() { codigoRespuesta = Catalogo.ERROR, mensajeRespuesta = Catalogo.FALLO_CONSULTA_MENU + exOp.Message });
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError, new Mensaje() { codigoRespuesta = Catalogo.ERROR, mensajeRespuesta = Catalogo.FALLO_CONSULTA_MENU + ex.Message });
            }
        }

        /// <summary>
        /// Método que permite crear un nuevo Perfil-Rol.
        /// </summary>
        /// <returns>resultado operación</returns>
        /// Autor:          fmartinez
        /// Fecha Creación: 22-03-2019
        [HttpPost]
        [Route("crearPerfilRol")]
        [ResponseType(typeof(Mensaje))]
        public IHttpActionResult CrearPerfilRol([FromBody] PerfilRolDto rol)
        {
            try
            {
                usuariosNegocio = new UsuariosNegocio();
                string res = usuariosNegocio.CreaModificaPerfilRol("I", rol);

                return Content(HttpStatusCode.OK, new Mensaje() { codigoRespuesta = Catalogo.OK, mensajeRespuesta = "", objetoRespuesta = res });
            }
            catch (ExcepcionOperacion exOp)
            {
                return Content(HttpStatusCode.InternalServerError, new Mensaje() { codigoRespuesta = Catalogo.ERROR, mensajeRespuesta = Catalogo.FALLO_CONSULTA_MENU + exOp.Message });
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError, new Mensaje() { codigoRespuesta = Catalogo.ERROR, mensajeRespuesta = Catalogo.FALLO_CONSULTA_MENU + ex.Message });
            }
        }

        /// <summary>
        /// Método que permite modificar la información de un PerfilRol.
        /// </summary>
        /// <returns>resultado operación</returns>
        /// Autor:          fmartinez
        /// Fecha Creación: 22-03-2019
        [HttpPost]
        [Route("modificarPerfilRol")]
        [ResponseType(typeof(Mensaje))]
        public IHttpActionResult ModificarPerfilRol([FromBody] PerfilRolDto rol)
        {
            try
            {
                usuariosNegocio = new UsuariosNegocio();
                string res = usuariosNegocio.CreaModificaPerfilRol("U", rol);

                return Content(HttpStatusCode.OK, new Mensaje() { codigoRespuesta = Catalogo.OK, mensajeRespuesta = "", objetoRespuesta = res });
            }
            catch (ExcepcionOperacion exOp)
            {
                return Content(HttpStatusCode.InternalServerError, new Mensaje() { codigoRespuesta = Catalogo.ERROR, mensajeRespuesta = Catalogo.FALLO_CONSULTA_MENU + exOp.Message });
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError, new Mensaje() { codigoRespuesta = Catalogo.ERROR, mensajeRespuesta = Catalogo.FALLO_CONSULTA_MENU + ex.Message });
            }
        }

        /// <summary>
        /// Método que permite modificar la información de un PerfilRol.
        /// </summary>
        /// <returns>resultado operación</returns>
        /// Autor:          fmartinez
        /// Fecha Creación: 13-03-2019
        [HttpPost]
        [Route("eliminarPerfilRol")]
        [ResponseType(typeof(Mensaje))]
        public IHttpActionResult EliminarPerfilRol([FromBody] PerfilRolDto rol)
        {
            try
            {
                usuariosNegocio = new UsuariosNegocio();
                string res = usuariosNegocio.CreaModificaPerfilRol("D", rol);

                return Content(HttpStatusCode.OK, new Mensaje() { codigoRespuesta = Catalogo.OK, mensajeRespuesta = "", objetoRespuesta = res });
            }
            catch (ExcepcionOperacion exOp)
            {
                return Content(HttpStatusCode.InternalServerError, new Mensaje() { codigoRespuesta = Catalogo.ERROR, mensajeRespuesta = Catalogo.FALLO_CONSULTA_MENU + exOp.Message });
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError, new Mensaje() { codigoRespuesta = Catalogo.ERROR, mensajeRespuesta = Catalogo.FALLO_CONSULTA_MENU + ex.Message });
            }
        }

        /// <summary>
        /// Método que consulta la lista de usuarios existentes en el sistema.
        /// </summary>
        /// <returns>Lista de perfiles-rol</returns>
        /// Autor:          fmartinez
        /// Fecha Creación: 23-03-2019
        [HttpPost]
        [Route("consultarUsuarios")]
        [ResponseType(typeof(Mensaje))]
        public IHttpActionResult ConsultarUsuarios()
        {
            try
            {
                usuariosNegocio = new UsuariosNegocio();
                List<UsuarioDto> res = usuariosNegocio.ConsultarUsuarios();

                return Content(HttpStatusCode.OK, new Mensaje() { codigoRespuesta = Catalogo.OK, mensajeRespuesta = "", objetoRespuesta = res });
            }
            catch (ExcepcionOperacion exOp)
            {
                return Content(HttpStatusCode.InternalServerError, new Mensaje() { codigoRespuesta = Catalogo.ERROR, mensajeRespuesta = Catalogo.FALLO_CONSULTA_MENU + exOp.Message });
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError, new Mensaje() { codigoRespuesta = Catalogo.ERROR, mensajeRespuesta = Catalogo.FALLO_CONSULTA_MENU + ex.Message });
            }
        }

        /// <summary>
        /// Método que permite crear un nuevo usuario.
        /// </summary>
        /// <returns>resultado operación</returns>
        /// Autor:          fmartinez
        /// Fecha Creación: 22-03-2019
        [HttpPost]
        [Route("crearUsuario")]
        [ResponseType(typeof(Mensaje))]
        public IHttpActionResult CrearUsuarios([FromBody] UsuarioDto usuario)
        {
            try
            {
                usuariosNegocio = new UsuariosNegocio();
                string res = usuariosNegocio.CreaModificaUsuario("I", usuario);

                return Content(HttpStatusCode.OK, new Mensaje() { codigoRespuesta = Catalogo.OK, mensajeRespuesta = "", objetoRespuesta = res });
            }
            catch (ExcepcionOperacion exOp)
            {
                return Content(HttpStatusCode.InternalServerError, new Mensaje() { codigoRespuesta = Catalogo.ERROR, mensajeRespuesta = Catalogo.FALLO_CONSULTA_MENU + exOp.Message });
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError, new Mensaje() { codigoRespuesta = Catalogo.ERROR, mensajeRespuesta = Catalogo.FALLO_CONSULTA_MENU + ex.Message });
            }
        }

        /// <summary>
        /// Método que permite modificar la información de un usuario.
        /// </summary>
        /// <returns>resultado operación</returns>
        /// Autor:          fmartinez
        /// Fecha Creación: 23-03-2019
        [HttpPost]
        [Route("modificarUsuario")]
        [ResponseType(typeof(Mensaje))]
        public IHttpActionResult ModificarUsuarios([FromBody] UsuarioDto rol)
        {
            try
            {
                usuariosNegocio = new UsuariosNegocio();
                string res = usuariosNegocio.CreaModificaUsuario("U", rol);

                return Content(HttpStatusCode.OK, new Mensaje() { codigoRespuesta = Catalogo.OK, mensajeRespuesta = "", objetoRespuesta = res });
            }
            catch (ExcepcionOperacion exOp)
            {
                return Content(HttpStatusCode.InternalServerError, new Mensaje() { codigoRespuesta = Catalogo.ERROR, mensajeRespuesta = Catalogo.FALLO_CONSULTA_MENU + exOp.Message });
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError, new Mensaje() { codigoRespuesta = Catalogo.ERROR, mensajeRespuesta = Catalogo.FALLO_CONSULTA_MENU + ex.Message });
            }
        }

        /// <summary>
        /// Método que permite eliminar un usuario.
        /// </summary>
        /// <returns>resultado operación</returns>
        /// Autor:          fmartinez
        /// Fecha Creación: 23-03-2019
        [HttpPost]
        [Route("eliminarUsuario")]
        [ResponseType(typeof(Mensaje))]
        public IHttpActionResult EliminarUsuario([FromBody] UsuarioDto usuario)
        {
            try
            {
                usuariosNegocio = new UsuariosNegocio();
                string res = usuariosNegocio.CreaModificaUsuario("D", usuario);

                return Content(HttpStatusCode.OK, new Mensaje() { codigoRespuesta = Catalogo.OK, mensajeRespuesta = "", objetoRespuesta = res });
            }
            catch (ExcepcionOperacion exOp)
            {
                return Content(HttpStatusCode.InternalServerError, new Mensaje() { codigoRespuesta = Catalogo.ERROR, mensajeRespuesta = Catalogo.FALLO_CONSULTA_MENU + exOp.Message });
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError, new Mensaje() { codigoRespuesta = Catalogo.ERROR, mensajeRespuesta = Catalogo.FALLO_CONSULTA_MENU + ex.Message });
            }
        }

        /// <summary>
        /// Método que consulta la lista de selección de tipos de rol.
        /// </summary>
        /// <returns>Tipos de rol</returns>
        /// Autor:          fmartinez
        /// Fecha Creación: 30-03-2019
        [HttpPost]
        [Route("consultarTiposRol")]
        [ResponseType(typeof(Mensaje))]
        public IHttpActionResult ConsultarTiposRol()
        {
            try
            {
                usuariosNegocio = new UsuariosNegocio();
                List<ObjetoGenericoDto> resp = usuariosNegocio.ConsultarTiposRol();

                return Content(HttpStatusCode.OK, new Mensaje() { codigoRespuesta = Catalogo.OK, mensajeRespuesta = "", objetoRespuesta = resp });
            }
            catch (ExcepcionOperacion exOp)
            {
                return Content(HttpStatusCode.InternalServerError, new Mensaje() { codigoRespuesta = Catalogo.ERROR, mensajeRespuesta = Catalogo.FALLO_CONSULTA_PERMISO + exOp.Message });
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError, new Mensaje() { codigoRespuesta = Catalogo.ERROR, mensajeRespuesta = Catalogo.FALLO_CONSULTA_PERMISO + ex.Message });
            }
        }

        /// <summary>
        /// Método que consulta la lista de selección de tipos de rol.
        /// </summary>
        /// <returns>Tipos de documento</returns>
        /// Autor:          fmartinez
        /// Fecha Creación: 30-03-2019
        [HttpPost]
        [Route("consultarTiposDocumento")]
        [ResponseType(typeof(Mensaje))]
        public IHttpActionResult ConsultarTiposDocumento()
        {
            try
            {
                usuariosNegocio = new UsuariosNegocio();
                List<ObjetoGenericoDto> resp = usuariosNegocio.ConsultarTiposDocumento();

                return Content(HttpStatusCode.OK, new Mensaje() { codigoRespuesta = Catalogo.OK, mensajeRespuesta = "", objetoRespuesta = resp });
            }
            catch (ExcepcionOperacion exOp)
            {
                return Content(HttpStatusCode.InternalServerError, new Mensaje() { codigoRespuesta = Catalogo.ERROR, mensajeRespuesta = Catalogo.FALLO_CONSULTA_PERMISO + exOp.Message });
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError, new Mensaje() { codigoRespuesta = Catalogo.ERROR, mensajeRespuesta = Catalogo.FALLO_CONSULTA_PERMISO + ex.Message });
            }
        }
        /// <summary>
        /// Método que permite cambia la clave del usuario.
        /// </summary>
        /// <returns>resultado operación</returns>
        /// Autor:          aalamo
        /// Fecha Creación: 06-04-2019
        [HttpPost]
        [Route("cambioClave")]
        [ResponseType(typeof(Mensaje))]
        public IHttpActionResult CambiarClave([FromBody] UsuarioDto usuario)
        {
            try
            {
                usuariosNegocio = new UsuariosNegocio();
                string res = usuariosNegocio.CambiarClave(usuario);

                return Content(HttpStatusCode.OK, new Mensaje() { codigoRespuesta = Catalogo.OK, mensajeRespuesta = "", objetoRespuesta = res });
            }
            catch (ExcepcionOperacion exOp)
            {
                return Content(HttpStatusCode.InternalServerError, new Mensaje() { codigoRespuesta = Catalogo.ERROR, mensajeRespuesta = Catalogo.FALLO_CONSULTA_MENU + exOp.Message });
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError, new Mensaje() { codigoRespuesta = Catalogo.ERROR, mensajeRespuesta = Catalogo.FALLO_CONSULTA_MENU + ex.Message });
            }
        }
    }
}