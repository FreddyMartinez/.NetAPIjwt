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

        //public string CambiarClave(UsuarioDto usuario)
        //{
        //    using (UnitOfWork uow = new UnitOfWork())
        //    {
        //        DataTable tblRol = uow.UsuariosRepositorio.CambiarClave(usuario);
        //        if (tblRol.Rows[0]["ID"].ToString() != "1")
        //        {
        //            throw new Exception(tblRol.Rows[0]["Mensaje"].ToString());
        //        }
        //        return tblRol.Rows[0]["Mensaje"].ToString();
        //    }
        //}

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
