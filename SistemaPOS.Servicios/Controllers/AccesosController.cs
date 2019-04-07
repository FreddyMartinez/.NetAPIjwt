using System;
using System.Net;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using SistemaPOS.Dto.Excepciones;
using SistemaPOS.Dto.Mensajes;
using ProyectoPOS.BLL;
using SistemaPOS.Dto.Modelos;

namespace SistemaPOS.Servicios.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("Accesos")]
    public class AccesosController : ApiController
    {
        AccesosNegocio accesosNegocio;

        /// <summary>
        /// Método que expone la versión del Api. 
        /// </summary>
        /// <returns>Versión</returns>
        /// Autor:          fmartinez
        /// Fecha Creación: 16-02-2019
        [HttpGet]
        [Route("versionBack")]
        [ResponseType(typeof(Mensaje))]
        public IHttpActionResult ConsultaVersion()
        {
            try
            {
                string version = "1.1.0";
                return Content(HttpStatusCode.OK, new Mensaje() { codigoRespuesta = Catalogo.OK, mensajeRespuesta = "", objetoRespuesta = version });
            }
            catch (ExcepcionOperacion exOp)
            {
                return Content(HttpStatusCode.InternalServerError, new Mensaje() { codigoRespuesta = Catalogo.ERROR, mensajeRespuesta = exOp.Message });
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError, new Mensaje() { codigoRespuesta = Catalogo.ERROR, mensajeRespuesta = Catalogo.FALLO_CONSULTA + ex.Message });
            }
        }

        /// <summary>
        /// Método que valida las credenciales de acceso del usuario.
        /// </summary>
        /// <returns>Lista de menú</returns>
        /// Autor:          fmartinez
        /// Fecha Creación: 16-02-2019
        [HttpPost]
        [Route("login")]
        [ResponseType(typeof(Mensaje))]
        public IHttpActionResult IngresoAplitativo([FromBody] UsuarioDto usuario)
        {
            try
            {
                accesosNegocio = new AccesosNegocio();
                UsuarioDto res = accesosNegocio.IngresoAplitativo(usuario.usuario, usuario.clave);

                return Content(HttpStatusCode.OK, new Mensaje() { codigoRespuesta = Catalogo.OK, mensajeRespuesta = "", objetoRespuesta = res });
            }
            catch (ExcepcionOperacion exOp)
            {
                return Content(HttpStatusCode.InternalServerError, new Mensaje() { codigoRespuesta = Catalogo.ERROR, mensajeRespuesta = exOp.Message });
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError, new Mensaje() { codigoRespuesta = Catalogo.ERROR, mensajeRespuesta = ex.Message });
            }
        }

        /// <summary>
        /// Método que valida las credenciales de acceso del usuario.
        /// </summary>
        /// <returns>Lista de menú</returns>
        /// Autor:          fmartinez
        /// Fecha Creación: 16-02-2019
        [HttpPost]
        [Route("validaClave")]
        [ResponseType(typeof(Mensaje))]
        public IHttpActionResult ValidaUsuario([FromBody] UsuarioDto usuario)
        {
            try
            {
                accesosNegocio = new AccesosNegocio();
                bool res = accesosNegocio.ValidaUsuario(usuario.usuario, usuario.clave);

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
        /// Método que consulta la lista de ítems del menú.
        /// </summary>
        /// <returns>Lista de menú</returns>
        /// Autor:          fmartinez
        /// Fecha Creación: 16-02-2019
        [HttpPost]
        [Route("consultarMenu")]
        [ResponseType(typeof(Mensaje))]
        public IHttpActionResult ConsultarMenu()
        {
            try
            {
                accesosNegocio = new AccesosNegocio();
                List<MenuDto> res = accesosNegocio.ConsultarMenu();

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
        /// Método que crea un nuevo ítem del menú.
        /// </summary>
        /// <returns>Lista de menú</returns>
        /// Autor:          fmartinez
        /// Fecha Creación: 25-02-2019
        [HttpPost]
        [Route("crearMenu")]
        [ResponseType(typeof(Mensaje))]
        public IHttpActionResult CrearMenu([FromBody] MenuDto menu)
        {
            try
            {
                accesosNegocio = new AccesosNegocio();
                string res = accesosNegocio.CreaModificaMenu("I", menu);

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
        /// Método que modifica un ítem del menú.
        /// </summary>
        /// <returns>Resultado de la operación</returns>
        /// Autor:          fmartinez
        /// Fecha Creación: 25-02-2019
        [HttpPost]
        [Route("modificarMenu")]
        [ResponseType(typeof(Mensaje))]
        public IHttpActionResult ModificarMenu([FromBody] MenuDto menu)
        {
            try
            {
                accesosNegocio = new AccesosNegocio();
                string res = accesosNegocio.CreaModificaMenu("U", menu);

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
        /// Método que elimina un ítem del menú.
        /// </summary>
        /// <returns>Resultado de la operación</returns>
        /// Autor:          fmartinez
        /// Fecha Creación: 25-02-2019
        [HttpPost]
        [Route("eliminarMenu")]
        [ResponseType(typeof(Mensaje))]
        public IHttpActionResult EliminarMenu([FromBody] MenuDto menu)
        {
            try
            {
                accesosNegocio = new AccesosNegocio();
                string res = accesosNegocio.CreaModificaMenu("D", menu);

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
        /// Método que consulta la lista de grupos.
        /// </summary>
        /// <returns>Resultado de la operación</returns>
        /// Autor:          fmartinez
        /// Fecha Creación: 16-02-2019
        [HttpPost]
        [Route("consultarGrupo")]
        [ResponseType(typeof(Mensaje))]
        public IHttpActionResult ConsultarGrupo()
        {
            try
            {
                accesosNegocio = new AccesosNegocio();
                List<GrupoDto> res = accesosNegocio.ConsultarGrupo();

                return Content(HttpStatusCode.OK, new Mensaje() { codigoRespuesta = Catalogo.OK, mensajeRespuesta = "", objetoRespuesta = res });
            }
            catch (ExcepcionOperacion exOp)
            {
                return Content(HttpStatusCode.InternalServerError, new Mensaje() { codigoRespuesta = Catalogo.ERROR, mensajeRespuesta = Catalogo.FALLO_CONSULTA_GRUPO + exOp.Message });
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError, new Mensaje() { codigoRespuesta = Catalogo.ERROR, mensajeRespuesta = Catalogo.FALLO_CONSULTA_GRUPO + ex.Message });
            }
        }
        /// <summary>
        /// Método que crea un nuevo ítem grupo.
        /// </summary>
        /// <returns>Resultado de la operación</returns>
        /// Autor:          fmartinez
        /// Fecha Creación: 25-02-2019
        [HttpPost]
        [Route("crearGrupo")]
        [ResponseType(typeof(Mensaje))]
        public IHttpActionResult CrearGrupo([FromBody] GrupoDto grupo)
        {
            try
            {
                accesosNegocio = new AccesosNegocio();
                string res = accesosNegocio.CreaModificaGrupo("I", grupo);

                return Content(HttpStatusCode.OK, new Mensaje() { codigoRespuesta = Catalogo.OK, mensajeRespuesta = "", objetoRespuesta = res });
            }
            catch (ExcepcionOperacion exOp)
            {
                return Content(HttpStatusCode.InternalServerError, new Mensaje() { codigoRespuesta = Catalogo.ERROR, mensajeRespuesta = Catalogo.FALLO_CONSULTA_GRUPO + exOp.Message });
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError, new Mensaje() { codigoRespuesta = Catalogo.ERROR, mensajeRespuesta = Catalogo.FALLO_CONSULTA_GRUPO + ex.Message });
            }
        }

        /// <summary>
        /// Método que modifica un ítem grupo.
        /// </summary>
        /// <returns>Lista de menú</returns>
        /// Autor:          fmartinez
        /// Fecha Creación: 25-02-2019
        [HttpPost]
        [Route("modificarGrupo")]
        [ResponseType(typeof(Mensaje))]
        public IHttpActionResult ModificarGrupo([FromBody] GrupoDto grupo)
        {
            try
            {
                accesosNegocio = new AccesosNegocio();
                string res = accesosNegocio.CreaModificaGrupo("U", grupo);

                return Content(HttpStatusCode.OK, new Mensaje() { codigoRespuesta = Catalogo.OK, mensajeRespuesta = "", objetoRespuesta = res });
            }
            catch (ExcepcionOperacion exOp)
            {
                return Content(HttpStatusCode.InternalServerError, new Mensaje() { codigoRespuesta = Catalogo.ERROR, mensajeRespuesta = Catalogo.FALLO_CONSULTA_GRUPO + exOp.Message });
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError, new Mensaje() { codigoRespuesta = Catalogo.ERROR, mensajeRespuesta = Catalogo.FALLO_CONSULTA_GRUPO + ex.Message });
            }
        }

        /// <summary>
        /// Método que elimina un ítem de grupo.
        /// </summary>
        /// <returns>Lista de menú</returns>
        /// Autor:          fmartinez
        /// Fecha Creación: 25-02-2019
        [HttpPost]
        [Route("eliminarGrupo")]
        [ResponseType(typeof(Mensaje))]
        public IHttpActionResult EliminarGrupo([FromBody] GrupoDto grupo)
        {
            try
            {
                accesosNegocio = new AccesosNegocio();
                string res = accesosNegocio.CreaModificaGrupo("D", grupo);

                return Content(HttpStatusCode.OK, new Mensaje() { codigoRespuesta = Catalogo.OK, mensajeRespuesta = "", objetoRespuesta = res });
            }
            catch (ExcepcionOperacion exOp)
            {
                return Content(HttpStatusCode.InternalServerError, new Mensaje() { codigoRespuesta = Catalogo.ERROR, mensajeRespuesta = Catalogo.FALLO_CONSULTA_GRUPO + exOp.Message });
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError, new Mensaje() { codigoRespuesta = Catalogo.ERROR, mensajeRespuesta = Catalogo.FALLO_CONSULTA_GRUPO + ex.Message });
            }
        }

        /// <summary>
        /// Método que consulta la lista de ítems del menú.
        /// </summary>
        /// <returns>Lista de menú</returns>
        /// Autor:          fmartinez
        /// Fecha Creación: 16-02-2019
        [HttpPost]
        [Route("consultarPermiso")]
        [ResponseType(typeof(Mensaje))]
        public IHttpActionResult ConsultarPermiso()
        {
            try
            {
                accesosNegocio = new AccesosNegocio();
                List<PermisoDto> res = accesosNegocio.ConsultarPermiso();

                return Content(HttpStatusCode.OK, new Mensaje() { codigoRespuesta = Catalogo.OK, mensajeRespuesta = "", objetoRespuesta = res });
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
        /// Método que crea un nuevo ítem del menú.
        /// </summary>
        /// <returns>Lista de menú</returns>
        /// Autor:          fmartinez
        /// Fecha Creación: 25-02-2019
        [HttpPost]
        [Route("crearPermiso")]
        [ResponseType(typeof(Mensaje))]
        public IHttpActionResult CrearPermiso([FromBody] PermisoDto Permiso)
        {
            try
            {
                accesosNegocio = new AccesosNegocio();
                string res = accesosNegocio.CreaModificaPermiso("I", Permiso);

                return Content(HttpStatusCode.OK, new Mensaje() { codigoRespuesta = Catalogo.OK, mensajeRespuesta = "", objetoRespuesta = res });
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
        /// Método que modifica un ítem del menú.
        /// </summary>
        /// <returns>Resultado de la operación</returns>
        /// Autor:          fmartinez
        /// Fecha Creación: 25-02-2019
        [HttpPost]
        [Route("modificarPermiso")]
        [ResponseType(typeof(Mensaje))]
        public IHttpActionResult ModificarPermiso([FromBody] PermisoDto Permiso)
        {
            try
            {
                accesosNegocio = new AccesosNegocio();
                string res = accesosNegocio.CreaModificaPermiso("U", Permiso);

                return Content(HttpStatusCode.OK, new Mensaje() { codigoRespuesta = Catalogo.OK, mensajeRespuesta = "", objetoRespuesta = res });
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
        /// Método que elimina un ítem del menú.
        /// </summary>
        /// <returns>Resultado de la operación</returns>
        /// Autor:          fmartinez
        /// Fecha Creación: 25-02-2019
        [HttpPost]
        [Route("eliminarPermiso")]
        [ResponseType(typeof(Mensaje))]
        public IHttpActionResult EliminarPermiso([FromBody] PermisoDto Permiso)
        {
            try
            {
                accesosNegocio = new AccesosNegocio();
                string res = accesosNegocio.CreaModificaPermiso("D", Permiso);

                return Content(HttpStatusCode.OK, new Mensaje() { codigoRespuesta = Catalogo.OK, mensajeRespuesta = "", objetoRespuesta = res });
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
        /// Método que consulta la lista de selección de tipos de menú.
        /// </summary>
        /// <returns>Tipos de menú</returns>
        /// Autor:          fmartinez
        /// Fecha Creación: 04-03-2019
        [HttpPost]
        [Route("consultarTiposMenu")]
        [ResponseType(typeof(Mensaje))]
        public IHttpActionResult ConsultarTiposMenu()
        {
            try
            {
                accesosNegocio = new AccesosNegocio();
                List<ObjetoGenericoDto> resp = accesosNegocio.ConsultaTiposMenu();

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
        /// Método que consulta la lista de selección de tipos de menú.
        /// </summary>
        /// <returns>Tipos de menú</returns>
        /// Autor:          fmartinez
        /// Fecha Creación: 12-03-2019
        [HttpPost]
        [Route("consultarTiposGrupo")]
        [ResponseType(typeof(Mensaje))]
        public IHttpActionResult ConsultarTiposGrupo([FromBody] PermisoDto Permiso)
        {
            try
            {
                accesosNegocio = new AccesosNegocio();
                List<ObjetoGenericoDto> resp = accesosNegocio.ConsultaTiposGrupo();

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
        /// Método que consulta la lista de selección de tipos de permiso.
        /// </summary>
        /// <returns>Tipos de menú</returns>
        /// Autor:          fmartinez
        /// Fecha Creación: 12-03-2019
        [HttpPost]
        [Route("consultarTiposPermiso")]
        [ResponseType(typeof(Mensaje))]
        public IHttpActionResult ConsultarTiposPermiso([FromBody] PermisoDto Permiso)
        {
            try
            {
                accesosNegocio = new AccesosNegocio();
                List<ObjetoGenericoDto> resp = accesosNegocio.ConsultaTipoPermiso();

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
        /// Método que consulta la estructura de menú lateral.
        /// </summary>
        /// <returns>Resultado de la operación</returns>
        /// Autor:          fmartinez
        /// Fecha Creación: 04-03-2019
        [HttpPost]
        [Route("consultarMenuLateral")]
        [ResponseType(typeof(Mensaje))]
        public IHttpActionResult ConsultarMenuLateral([FromBody] PermisoDto Permiso)
        {
            try
            {
                accesosNegocio = new AccesosNegocio();
                List<MenuLateralDto> menuLateral = accesosNegocio.ConsultaMenuLateral();

                return Content(HttpStatusCode.OK, new Mensaje() { codigoRespuesta = Catalogo.OK, mensajeRespuesta = "", objetoRespuesta = menuLateral });
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
    }
}