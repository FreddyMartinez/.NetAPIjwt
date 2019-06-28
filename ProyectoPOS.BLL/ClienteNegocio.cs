using SistemaPOS.DAL.Base;
using SistemaPOS.Dto.Modelos;
using System;
using System.Collections.Generic;
using System.Data;

namespace ProyectoPOS.BLL
{
    public class ClienteNegocio
    {
        #region Cliente    
        public List<ClienteDto> ConsultarClientes(string usuario)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                ClienteDto cliente = new ClienteDto(-1, "", "", -1, "", "", "", "", "", -1, -1, true, usuario,"","","","","","");
                DataTable tblRol = uow.ClienteRepositorio.CrudCliente("C", cliente);
                List<ClienteDto> listClientes = new List<ClienteDto>();
                ClienteDto ClienteTemp;
                foreach (DataRow dr in tblRol.Rows)
                {
                    ClienteTemp = new ClienteDto(dr);
                    listClientes.Add(ClienteTemp);
                }
                return listClientes;
            }
        }

        public string CreaModificaCliente(string trans, ClienteDto cliente)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                if (trans == "I")
                {
                    cliente.idCliente = -1;
                }
                cliente.barrio = "-1";
                DataTable tblRol = uow.ClienteRepositorio.CrudCliente(trans, cliente);
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

        public List<ObjetoGenericoDto> ConsultaTipoDocumento()
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                DataTable tblTipoSucursal = uow.ClienteRepositorio.ConsultaTipoDocumento();
                return MapeaObjetoGenerico(tblTipoSucursal);
            }
        }

        public List<ObjetoGenericoDto> ConsultarClientePrincipal()
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                DataTable tblEmpresaCliente = uow.ClienteRepositorio.ConsultarClientePrincipal();
                return MapeaObjetoGenerico(tblEmpresaCliente);
            }
        }

        public List<ObjetoGenericoDto> ConsultarClienteReferido()
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                DataTable tblEmpresaCliente = uow.ClienteRepositorio.ConsultarClienteReferidor();
                return MapeaObjetoGenerico(tblEmpresaCliente);
            }
        }

        #endregion
    }
}
