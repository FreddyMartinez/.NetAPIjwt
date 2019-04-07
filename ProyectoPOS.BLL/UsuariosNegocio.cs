using SistemaPOS.DAL.Base;
using SistemaPOS.Dto.Modelos;
using System;
using System.Collections.Generic;
using System.Data;

namespace ProyectoPOS.BLL
{
    public class UsuariosNegocio
    {
        #region Perfil
        public List<PerfilDto> ConsultarPerfil()
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                PerfilDto perfil = new PerfilDto(-1, "", "", -1, true);
                DataTable tblPerfil = uow.UsuariosRepositorio.CrudPerfil("C", perfil);
                List<PerfilDto> listPerfil = new List<PerfilDto>();
                PerfilDto PerfilTemp;
                foreach (DataRow dr in tblPerfil.Rows)
                {
                    PerfilTemp = new PerfilDto(dr);
                    listPerfil.Add(PerfilTemp);
                }
                return listPerfil;
            }
        }

        public string CreaModificaPerfil(string trans, PerfilDto perfil)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                DataTable tblPerfil = uow.UsuariosRepositorio.CrudPerfil(trans, perfil);
                if (tblPerfil.Rows[0]["ID"].ToString() != "1")
                {
                    throw new Exception(tblPerfil.Rows[0]["Mensaje"].ToString());
                }
                return tblPerfil.Rows[0]["Mensaje"].ToString();
            }
        }

        public List<PermisoPerfilDto> ConsultarPermisoPerfil(int idPerfil)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                PermisoPerfilDto permisoPerfil = new PermisoPerfilDto(idPerfil, -1, true);
                DataTable tblPermisoPerfil = uow.UsuariosRepositorio.CrudPermisosPerfil("C", permisoPerfil);
                List<PermisoPerfilDto> listPermisoPerfil = new List<PermisoPerfilDto>();
                PermisoPerfilDto permisoPerfilTemp;
                foreach (DataRow dr in tblPermisoPerfil.Rows)
                {
                    permisoPerfilTemp = new PermisoPerfilDto(dr);
                    permisoPerfilTemp.idPerfil = idPerfil;
                    listPermisoPerfil.Add(permisoPerfilTemp);
                }
                return listPermisoPerfil;
            }
        }

        public string CreaModificaPermisoPerfil(string trans, PermisoPerfilDto permisoPerfil)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                DataTable tblPermisoPerfil = uow.UsuariosRepositorio.CrudPermisosPerfil(trans, permisoPerfil);
                if (tblPermisoPerfil.Rows[0]["ID"].ToString() != "1")
                {
                    throw new Exception(tblPermisoPerfil.Rows[0]["Mensaje"].ToString());
                }
                return tblPermisoPerfil.Rows[0]["Mensaje"].ToString();
            }
        }
        #endregion
        
        public List<RolDto> ConsultarRol()
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                RolDto rol = new RolDto(-1, "", "", -1, true);
                DataTable tblRol = uow.UsuariosRepositorio.CrudRol("C", rol);
                List<RolDto> listRol = new List<RolDto>();
                RolDto RolTemp;
                foreach (DataRow dr in tblRol.Rows)
                {
                    RolTemp = new RolDto(dr);
                    listRol.Add(RolTemp);
                }
                return listRol;
            }
        }

        public string CreaModificaRol(string trans, RolDto rol)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                DataTable tblRol = uow.UsuariosRepositorio.CrudRol(trans, rol);
                if (tblRol.Rows[0]["ID"].ToString() != "1")
                {
                    throw new Exception(tblRol.Rows[0]["Mensaje"].ToString());
                }
                return tblRol.Rows[0]["Mensaje"].ToString();
            }
        }

        public List<PerfilRolDto> ConsultarPerfilesRol(int rol)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                PerfilRolDto permisosRol = new PerfilRolDto(rol, -1, true);
                DataTable tblRol = uow.UsuariosRepositorio.CrudPerfilRol("C", permisosRol);
                List<PerfilRolDto> listRol = new List<PerfilRolDto>();
                PerfilRolDto perfilRolTemp;
                foreach (DataRow dr in tblRol.Rows)
                {
                    perfilRolTemp = new PerfilRolDto(dr);
                    perfilRolTemp.idRol = rol;
                    listRol.Add(perfilRolTemp);
                }
                return listRol;
            }
        }

        public string CreaModificaPerfilRol(string trans, PerfilRolDto rol)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                DataTable tblRol = uow.UsuariosRepositorio.CrudPerfilRol(trans, rol);
                if (tblRol.Rows[0]["ID"].ToString() != "1")
                {
                    throw new Exception(tblRol.Rows[0]["Mensaje"].ToString());
                }
                return tblRol.Rows[0]["Mensaje"].ToString();
            }
        }

        public List<UsuarioDto> ConsultarUsuarios()
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                UsuarioDto usuario = new UsuarioDto("", "", -1, "", "", "", "", "", -1, -1, true);
                DataTable tblRol = uow.UsuariosRepositorio.CrudUsuarios("C", usuario);
                List<UsuarioDto> listRol = new List<UsuarioDto>();
                UsuarioDto perfilRolTemp;
                foreach (DataRow dr in tblRol.Rows)
                {
                    perfilRolTemp = new UsuarioDto(dr);
                    listRol.Add(perfilRolTemp);
                }
                return listRol;
            }
        }

        public string CreaModificaUsuario(string trans, UsuarioDto usuario)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                DataTable tblRol = uow.UsuariosRepositorio.CrudUsuarios(trans, usuario);
                if (tblRol.Rows[0]["ID"].ToString() != "1")
                {
                    throw new Exception(tblRol.Rows[0]["Mensaje"].ToString());
                }
                return tblRol.Rows[0]["Mensaje"].ToString();
            }
        }

        public string CambiarClave(UsuarioDto usuario)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                DataTable tblRol = uow.UsuariosRepositorio.CambiarClave(usuario);
                if (tblRol.Rows[0]["ID"].ToString() != "1")
                {
                    throw new Exception(tblRol.Rows[0]["Mensaje"].ToString());
                }
                return tblRol.Rows[0]["Mensaje"].ToString();
            }
        }


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

        public List<ObjetoGenericoDto> ConsultaClientes()
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                DataTable tblClientes = uow.UsuariosRepositorio.ConsultaClientes("DESARROLLADOR");
                return MapeaObjetoGenerico(tblClientes);
            }
        }

        public List<ObjetoGenericoDto> ConsultarTiposRol()
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                DataTable tblTipoMenu = uow.UsuariosRepositorio.ConsultarTiposRol("DESARROLLADOR");
                return MapeaObjetoGenerico(tblTipoMenu);
            }
        }

        public List<ObjetoGenericoDto> ConsultarTiposDocumento()
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                DataTable tblTipoMenu = uow.UsuariosRepositorio.ConsultarTiposDocumento("DESARROLLADOR");
                return MapeaObjetoGenerico(tblTipoMenu);
            }
        }
        #endregion
    }
}
