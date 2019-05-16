using SistemaPOS.DAL.Base;
using SistemaPOS.Dto.Modelos;
using System;
using System.Collections.Generic;
using System.Data;

namespace ProyectoPOS.BLL
{
    public class EmpresasNegocio
    {
        #region empresa    
        public string CreaModificaEmpresa(string trans, EmpresaDto empresa)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                DataTable tblRol = uow.EmpresasRepositorio.CrudEmpresa(trans, empresa);
                if (tblRol.Rows[0]["ID"].ToString() != "1")
                {
                    throw new Exception(tblRol.Rows[0]["Mensaje"].ToString());
                }
                return tblRol.Rows[0]["Mensaje"].ToString();
            }
        }

        public List<EmpresaDto> ConsultarEmpresa(ObjetoGenericoDto usuario)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                EmpresaDto empresa = new EmpresaDto(-1, usuario.llave, "", "", "", "", "", "", true, usuario.valor);
                DataTable tblRol = uow.EmpresasRepositorio.CrudEmpresa("C", empresa);
                List<EmpresaDto> listEmpresas = new List<EmpresaDto>();
                EmpresaDto ClienteTemp;
                foreach (DataRow dr in tblRol.Rows)
                {
                    ClienteTemp = new EmpresaDto(dr);
                    listEmpresas.Add(ClienteTemp);
                }
                return listEmpresas;
            }
        }

        #endregion
        #region SucursalEmpresa
        public string CreaModificaSucursalEmpresa(string trans, SucursalEmpresaDto sucursalEmpresa)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                DataTable tblRol = uow.EmpresasRepositorio.CrudSucursalEmpresa(trans, sucursalEmpresa);
                if (tblRol.Rows[0]["ID"].ToString() != "1")
                {
                    throw new Exception(tblRol.Rows[0]["Mensaje"].ToString());
                }
                return tblRol.Rows[0]["Mensaje"].ToString();
            }
        }

        public List<SucursalEmpresaDto> ConsultarSucursal(ObjetoGenericoDto empresa)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                SucursalEmpresaDto sucursal = new SucursalEmpresaDto (-1, -1, empresa.llave, "", "", "", "", "", "", "", "", true, empresa.valor);
                DataTable tblRol = uow.EmpresasRepositorio.CrudSucursalEmpresa("C", sucursal);
                List<SucursalEmpresaDto> listSucursal = new List<SucursalEmpresaDto>();
                SucursalEmpresaDto SucursalTemp;
                foreach (DataRow dr in tblRol.Rows)
                {
                    SucursalTemp = new SucursalEmpresaDto(dr);
                    listSucursal.Add(SucursalTemp);
                }
                return listSucursal;
            }
        }

        #endregion

        #region lookups
        private List<ObjetoGenericoDto> MapeaObjetoGenerico(DataTable tbl)
        {
            List<ObjetoGenericoDto> listaTipoGrupo = new List<ObjetoGenericoDto>();
            ObjetoGenericoDto temp;
            foreach (DataRow dr in tbl.Rows)
            {
                temp = new ObjetoGenericoDto(dr);
                listaTipoGrupo.Add(temp);
            }
            return listaTipoGrupo;
        }

        public List<ObjetoGenericoDto> ConsultaTipoSucursal()
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                DataTable tblTipoSucursal = uow.EmpresasRepositorio.ConsultaTipoSucursal();
                return MapeaObjetoGenerico(tblTipoSucursal);
            }
        }

        public List<ObjetoGenericoDto> ConsultarEmpresasCliente( string idCliente)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                DataTable tblEmpresaCliente = uow.EmpresasRepositorio.ConsultarEmpresasCliente(idCliente);
                return MapeaObjetoGenerico(tblEmpresaCliente);
            }
        }
        
        #endregion
    }
}
