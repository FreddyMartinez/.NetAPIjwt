using System;
using System.Data;
using SistemaPOS.DAL.Base;
using SistemaPOS.Dto.Modelos;
using System.Collections.Generic;

namespace ProyectoPOS.BLL
{
    public class AccesosNegocio
    {
        public UsuarioDto IngresoAplitativo(string usuario, string clave)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                DataTable tblUsuario = uow.AccesosRepositorio.IngresoAplitativo(usuario, clave);
                if(tblUsuario.Rows.Count > 0)
                {
                    if (tblUsuario.Rows[0][0].ToString() == "-1")
                    {
                        throw new Exception(tblUsuario.Rows[0]["Descripcion"].ToString());
                    }
                    else
                    {
                        UsuarioDto usr = new UsuarioDto();
                        usr.usuario = usuario;
                        usr.documento = tblUsuario.Rows[0]["documento"].ToString();
                        usr.nombre = tblUsuario.Rows[0]["nombre"].ToString();
                        usr.rol = Convert.ToInt32(tblUsuario.Rows[0]["id_rol"].ToString());
                        usr.nombreRol = tblUsuario.Rows[0]["rol"].ToString();
                        return usr;
                    }
                }
                else
                {
                    throw new Exception("No se encontraron datos para el usuario.");
                }
            }
        }

        public bool ValidaUsuario(string usuario, string clave)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                return uow.AccesosRepositorio.ValidaUsuario(usuario, clave);
            }
        }

        public List<MenuDto> ConsultarMenu()
        {
            using(UnitOfWork uow = new UnitOfWork())
            {
                MenuDto menu = new MenuDto(-1, "", "", "", "", true);
                DataTable tblMenu = uow.AccesosRepositorio.CrudMenu("C", menu);
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
                DataTable tblMenu = uow.AccesosRepositorio.CrudMenu(trans, menu);
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
                DataTable tblMenu = uow.AccesosRepositorio.CrudGrupo("C", menu);
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
                DataTable tblMenu = uow.AccesosRepositorio.CrudGrupo(trans, grupo);
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
                DataTable tblPermiso = uow.AccesosRepositorio.CrudPermiso("C", Permiso);
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
                DataTable tblPermiso = uow.AccesosRepositorio.CrudPermiso(trans, Permiso);
                if (tblPermiso.Rows[0]["ID"].ToString() != "1")
                {
                    throw new Exception(tblPermiso.Rows[0]["Mensaje"].ToString());
                }
                return tblPermiso.Rows[0]["Mensaje"].ToString();
            }
        }

        public List<ObjetoGenericoDto> ConsultaTiposMenu()
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                DataTable tblTipoMenu = uow.AccesosRepositorio.ConsultaTipoMenu("DESARROLLADOR");
                return MapeaObjetoGenerico(tblTipoMenu);
            }
        }

        public List<ObjetoGenericoDto> ConsultaTiposGrupo()
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                DataTable tblTipoGrupo = uow.AccesosRepositorio.ConsultaTipoGrupo("DESARROLLADOR");
                return MapeaObjetoGenerico(tblTipoGrupo);
            }
        }

        public List<ObjetoGenericoDto> ConsultaTipoPermiso()
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                DataTable tblTipoPermiso = uow.AccesosRepositorio.ConsultaTipoPermiso("DESARROLLADOR");
                return MapeaObjetoGenerico(tblTipoPermiso);
            }
        }

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

        public List<MenuLateralDto> ConsultaMenuLateral()
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                List<MenuLateralDto> listaMenu = new List<MenuLateralDto>();
                DataTable tblPermiso = uow.AccesosRepositorio.ConsultaMenuLateral("DESARROLLADOR");
                MenuLateralDto menuTemp;
                GrupoMenuLateralDto grupoTemp;
                PermisoMenuLateralDto permisoTemp;

                foreach(DataRow dr in tblPermiso.Rows)
                {
                    permisoTemp = new PermisoMenuLateralDto(dr);
                    
                    if(listaMenu.Exists(menu=> menu.id == Convert.ToInt32(dr["ID_MENU"].ToString()))){
                        if(listaMenu.Find(menu => menu.id == Convert.ToInt32(dr["ID_MENU"].ToString())).grupos.Exists(grupo => grupo.id == Convert.ToInt32(dr["ID_GRUPO"].ToString())))
                        {
                            listaMenu.Find(menu => menu.id == Convert.ToInt32(dr["ID_MENU"].ToString())).grupos.Find(grupo => grupo.id == Convert.ToInt32(dr["ID_GRUPO"].ToString())).permisos.Add(permisoTemp);
                        }
                        else
                        {
                            grupoTemp = new GrupoMenuLateralDto(dr);
                            grupoTemp.permisos.Add(permisoTemp);
                            listaMenu.Find(menu => menu.id == Convert.ToInt32(dr["ID_MENU"].ToString())).grupos.Add(grupoTemp);
                        }
                    }
                    else
                    {
                        grupoTemp = new GrupoMenuLateralDto(dr);
                        grupoTemp.permisos.Add(permisoTemp);
                        menuTemp = new MenuLateralDto(dr);
                        menuTemp.grupos.Add(grupoTemp);
                        listaMenu.Add(menuTemp);
                    }
                }

                return listaMenu;
            }
        }
    }
}
