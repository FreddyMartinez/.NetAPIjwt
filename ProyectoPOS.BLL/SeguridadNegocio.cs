using System;
using System.Data;
using SistemaPOS.DAL.Base;
using SistemaPOS.Dto.Modelos;
using System.Collections.Generic;

namespace ProyectoPOS.BLL
{
    public class SeguridadNegocio
    {
        public List<MenuDto> ConsultarMenu()
        {
            using(UnitOfWork uow = new UnitOfWork())
            {
                MenuDto menu = new MenuDto(-1, "", "", "", "", true);
                DataTable tblMenu = uow.SeguridadRepositorio.CrudMenu("C", menu);
                List<MenuDto> listMenu = new List<MenuDto>();
                MenuDto menuTemp;
                foreach (DataRow dr in tblMenu.Rows)
                {
                    menuTemp = new MenuDto(dr);
                    listMenu.Add(menuTemp);
                }
                return listMenu;
            }
        }

        public string CreaModificaMenu(string trans, MenuDto menu)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                DataTable tblMenu = uow.SeguridadRepositorio.CrudMenu(trans, menu);
                if (tblMenu.Rows[0]["ID"].ToString() != "1")
                {
                    throw new Exception(tblMenu.Rows[0]["Mensaje"].ToString());
                }
                return tblMenu.Rows[0]["Mensaje"].ToString();
            }
        }

        public List<GrupoDto> ConsultarGrupo()
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                GrupoDto menu = new GrupoDto(-1, "", "", "", "", true);
                DataTable tblMenu = uow.SeguridadRepositorio.CrudGrupo("C", menu);
                List<GrupoDto> listMenu = new List<GrupoDto>();
                GrupoDto menuTemp;
                foreach (DataRow dr in tblMenu.Rows)
                {
                    menuTemp = new GrupoDto(dr);
                    listMenu.Add(menuTemp);
                }
                return listMenu;
            }
        }

        public string CreaModificaGrupo(string trans, GrupoDto grupo)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                DataTable tblMenu = uow.SeguridadRepositorio.CrudGrupo(trans, grupo);
                if (tblMenu.Rows[0]["ID"].ToString() != "1")
                {
                    throw new Exception(tblMenu.Rows[0]["Mensaje"].ToString());
                }
                return tblMenu.Rows[0]["Mensaje"].ToString();
            }
        }

        public List<PermisoDto> ConsultarPermiso()
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                PermisoDto Permiso = new PermisoDto(-1, -1, "", -1, "", "", "", "", -1, true);
                DataTable tblPermiso = uow.SeguridadRepositorio.CrudPermiso("C", Permiso);
                List<PermisoDto> listPermiso = new List<PermisoDto>();
                PermisoDto PermisoTemp;
                foreach (DataRow dr in tblPermiso.Rows)
                {
                    PermisoTemp = new PermisoDto(dr);
                    listPermiso.Add(PermisoTemp);
                }
                return listPermiso;
            }
        }

        public string CreaModificaPermiso(string trans, PermisoDto Permiso)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                DataTable tblPermiso = uow.SeguridadRepositorio.CrudPermiso(trans, Permiso);
                if (tblPermiso.Rows[0]["ID"].ToString() != "1")
                {
                    throw new Exception(tblPermiso.Rows[0]["Mensaje"].ToString());
                }
                return tblPermiso.Rows[0]["Mensaje"].ToString();
            }
        }
    }
}
