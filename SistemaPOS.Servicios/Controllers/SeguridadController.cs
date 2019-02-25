using System;
using System.Net;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.Cors;
using SistemaPOS.Dto.Excepciones;
using SistemaPOS.Dto.Mensajes;
using ProyectoPOS.BLL;

namespace SistemaPOS.Servicios.Controllers
{
    /// <summary>
    /// Clase que da el acceso a los servicios de consulta, registro y modificación de datos de seguridad.
    /// </summary>
    /// <remarks>
    /// Autor:          Freddy Martínez
    /// Fecha Creación: 14/02/2019
    /// </remarks>
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("Seguridad")]
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
        /// <param></param>
        /// <returns>Lista de menú</returns>
        /// Autor:          fmartinez
        /// Fecha Creación: 16-02-2019
        [HttpGet]
        [Route("consultarMenu")]
        [ResponseType(typeof(Mensaje))]
        public IHttpActionResult ConsultarCentroDistribucion()
        {
            try
            {
                seguridadNegocio = new SeguridadNegocio();
                string res = seguridadNegocio.ConsultarMenu();

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