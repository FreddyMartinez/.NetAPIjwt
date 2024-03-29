﻿using ProyectoPOS.BLL;
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
    [RoutePrefix("Empresas")]
    public class EmpresasController: ApiController
    {
        EmpresasNegocio empresasNegocio;


        /// <summary>
        /// metodo que permite agregar una nueva empreasa
        /// </summary>
        /// <returns>Empresas</returns>
        /// Autor:          fmartinez
        /// Fecha Creación: 13-04-2019
        [HttpPost]
        [Route("crearEmpresa")]
        [ResponseType(typeof(Mensaje))]
        public IHttpActionResult CrearEmpresa ([FromBody] EmpresaDto empresa)
        {
            try
            {
                empresasNegocio = new EmpresasNegocio();
                string res = empresasNegocio.CreaModificaEmpresa("I", empresa);

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
        /// metodo que permite editar una empreasa
        /// </summary>
        /// <returns>Empresas</returns>
        /// Autor:          aalmao
        /// Fecha Creación: 13-04-2019
        [HttpPost]
        [Route("editarEmpresa")]
        [ResponseType(typeof(Mensaje))]
        public IHttpActionResult EditarEmpresa([FromBody] EmpresaDto empresa)
        {
            try
            {
                empresasNegocio = new EmpresasNegocio();
                string res = empresasNegocio.CreaModificaEmpresa("U", empresa);

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
        /// metodo que permite eliminar una empreasa
        /// </summary>
        /// <returns>Empresas</returns>
        /// Autor:          aalmao
        /// Fecha Creación: 13-04-2019
        [HttpPost]
        [Route("eliminarEmpresa")]
        [ResponseType(typeof(Mensaje))]
        public IHttpActionResult EliminarEmpresa([FromBody] EmpresaDto empresa)
        {
            try
            {
                empresasNegocio = new EmpresasNegocio();
                string res = empresasNegocio.CreaModificaEmpresa("D", empresa);

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
        /// metodo que permite consultar una empresa
        /// </summary>
        /// <returns>Empresa</returns>
        /// Autor:          aalamo
        /// Fecha Creación: 13-04-2019
        [HttpPost]
        [Route("consultarEmpresas")]
        [ResponseType(typeof(Mensaje))]
        public IHttpActionResult ConsultarEmpresa([FromBody] ObjetoGenericoDto usuario)
        {
            try
            {
                empresasNegocio = new EmpresasNegocio();
                List<EmpresaDto> res = empresasNegocio.ConsultarEmpresa(usuario);

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
        /// metodo que permite crear un registro de sucursal-empresa
        /// </summary>
        /// <returns>SucursalEmpresas</returns>
        /// Autor:          aalmao
        /// Fecha Creación: 13-04-2019
        [HttpPost]
        [Route("crearSucursalEmpresa")]
        [ResponseType(typeof(Mensaje))]
        public IHttpActionResult CrearSucursalEmpresa([FromBody] SucursalEmpresaDto sucursalEmpresa)
        {
            try
            {
                empresasNegocio = new EmpresasNegocio();
                string res = empresasNegocio.CreaModificaSucursalEmpresa("I", sucursalEmpresa);

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
        /// metodo que permite editar un registro de sucursal-empresa
        /// </summary>
        /// <returns>SucursalEmpresas</returns>
        /// Autor:          aalmao
        /// Fecha Creación: 13-04-2019
        [HttpPost]
        [Route("editarSucursalEmpresa")]
        [ResponseType(typeof(Mensaje))]
        public IHttpActionResult EditarSucursalEmpresa([FromBody] SucursalEmpresaDto sucursalEmpresa)
        {
            try
            {
                empresasNegocio = new EmpresasNegocio();
                string res = empresasNegocio.CreaModificaSucursalEmpresa("U", sucursalEmpresa);

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
        /// metodo que permite consultar una las sucursales de una empresa
        /// </summary>
        /// <returns>SucursalEmpresa</returns>
        /// Autor:          aalamo
        /// Fecha Creación: 20-04-2019
        [HttpPost]
        [Route("consultarSucursalEmpresas")]
        [ResponseType(typeof(Mensaje))]
        public IHttpActionResult ConsultarSucursalEmpresa([FromBody] ObjetoGenericoDto usuario)
        {
            try
            {
                empresasNegocio = new EmpresasNegocio();
                List<SucursalEmpresaDto> res = empresasNegocio.ConsultarSucursal(usuario);

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
        /// Método que consulta la lista de los tipos de sucursales
        /// </summary>
        /// <returns>Lista de sucursales</returns>
        /// Autor:          aalamo
        /// Fecha Creación: 12-04-2019
        [HttpPost]
        [Route("consultarTipoSucursal")]
        [ResponseType(typeof(Mensaje))]
        public IHttpActionResult ConsultarTipoSucursal()
        {
            try
            {
                empresasNegocio = new EmpresasNegocio();
                List<ObjetoGenericoDto> res = empresasNegocio.ConsultaTipoSucursal();

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
        /// metodo que permite eliminar una sucursal
        /// </summary>
        /// <returns>Empresas</returns>
        /// Autor:          aalmao
        /// Fecha Creación: 20-04-2019
        [HttpPost]
        [Route("eliminarSucursalEmpresa")]
        [ResponseType(typeof(Mensaje))]
        public IHttpActionResult EliminarSucursalEmpresa([FromBody] SucursalEmpresaDto Sucursalempresa)
        {
            try
            {
                empresasNegocio = new EmpresasNegocio();
                string res = empresasNegocio.CreaModificaSucursalEmpresa("D", Sucursalempresa);

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
        /// Método que consulta la lista de los tipos de sucursales
        /// </summary>
        /// <returns>Lista de sucursales</returns>
        /// Autor:          aalamo
        /// Fecha Creación: 12-04-2019
        [HttpPost]
        [Route("consultarEmpresasCliente")]
        [ResponseType(typeof(Mensaje))]
        public IHttpActionResult ConsultarEmpresasCliente([FromBody] ParametroConsultaDto idCliente)
        {
            try
            {
                empresasNegocio = new EmpresasNegocio();
                List<ObjetoGenericoDto> res = empresasNegocio.ConsultarEmpresasCliente(idCliente.parametro);

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