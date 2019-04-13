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
    [RoutePrefix("Cliente")]
    public class ClieneteController: ApiController
    {
        ClienteNegocio clienteNegocio;


        /// <summary>
        /// metodo que permite agregar un nuevo cliente
        /// </summary>
        /// <returns>cliente</returns>
        /// Autor:          aalamo
        /// Fecha Creación: 13-04-2019
        [HttpPost]
        [Route("crearCliente")]
        [ResponseType(typeof(Mensaje))]
        public IHttpActionResult CrearEmpresa ([FromBody] ClienteDto cliente)
        {
            try
            {
                clienteNegocio = new ClienteNegocio();
                string res = clienteNegocio.CreaModificaCliente("I", cliente);

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
        /// metodo que permite editar un registro de clientes
        /// </summary>
        /// <returns>SucursalEmpresas</returns>
        /// Autor:          aalmao
        /// Fecha Creación: 13-04-2019
        [HttpPost]
        [Route("EditarCliente")]
        [ResponseType(typeof(Mensaje))]
        public IHttpActionResult EditarCliente([FromBody] ClienteDto cliente)
        {
            try
            {
                clienteNegocio = new ClienteNegocio();
                string res = clienteNegocio.CreaModificaCliente("U", cliente);

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
        /// Método que consulta la lista de los tipos de documentos
        /// </summary>
        /// <returns>Lista de documento</returns>
        /// Autor:          aalamo
        /// Fecha Creación: 12-04-2019
        [HttpPost]
        [Route("consultaTipoDocumento")]
        [ResponseType(typeof(Mensaje))]
        public IHttpActionResult ConsultaTipoDocumento()
        {
            try
            {
                clienteNegocio = new ClienteNegocio();
                List<ObjetoGenericoDto> res = clienteNegocio.ConsultaTipoDocumento();

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
        /// Método que consulta la lista de los cientes 
        /// </summary>
        /// <returns>Lista de sucursales</returns>
        /// Autor:          aalamo
        /// Fecha Creación: 12-04-2019
        [HttpPost]
        [Route("consultarClientePrincipal")]
        [ResponseType(typeof(Mensaje))]
        public IHttpActionResult ConsultarClientePrincipal()
        {
            try
            {
                clienteNegocio = new ClienteNegocio();
                List<ObjetoGenericoDto> res = clienteNegocio.ConsultarClientePrincipal();

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
        /// Método que consulta la lista de los clientes referidos
        /// </summary>
        /// <returns>Lista de sucursales</returns>
        /// Autor:          aalamo
        /// Fecha Creación: 12-04-2019
        [HttpPost]
        [Route("consultarClienteReferido")]
        [ResponseType(typeof(Mensaje))]
        public IHttpActionResult ConsultarClienteReferido()
        {
            try
            {
                clienteNegocio = new ClienteNegocio();
                List<ObjetoGenericoDto> res = clienteNegocio.ConsultarClienteReferido();

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