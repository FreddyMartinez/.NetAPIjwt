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
    [RoutePrefix("SeguridadPOS")]
    public class SeguridadController : ApiController
    {
        SeguridadNegocio seguridadNegocio;

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
                string version = "1.0.0";
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
                seguridadNegocio = new SeguridadNegocio();
                List<MenuDto> res = seguridadNegocio.ConsultarMenu();

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
                seguridadNegocio = new SeguridadNegocio();
                string res = seguridadNegocio.CreaModificaMenu("I", menu);

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
        /// <returns>Lista de menú</returns>
        /// Autor:          fmartinez
        /// Fecha Creación: 25-02-2019
        [HttpPost]
        [Route("modificarMenu")]
        [ResponseType(typeof(Mensaje))]
        public IHttpActionResult ModificarMenu([FromBody] MenuDto menu)
        {
            try
            {
                seguridadNegocio = new SeguridadNegocio();
                string res = seguridadNegocio.CreaModificaMenu("U", menu);

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
        /// <returns>Lista de menú</returns>
        /// Autor:          fmartinez
        /// Fecha Creación: 25-02-2019
        [HttpPost]
        [Route("eliminarMenu")]
        [ResponseType(typeof(Mensaje))]
        public IHttpActionResult EliminarMenu([FromBody] MenuDto menu)
        {
            try
            {
                seguridadNegocio = new SeguridadNegocio();
                string res = seguridadNegocio.CreaModificaMenu("D", menu);

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