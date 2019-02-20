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
                DataTable tblMenu = uow.SeguridadRepositorio.ConsultarMenu();
                List<MenuDto> listMenu = new List<MenuDto>();
                MenuDto menuTemp;
                foreach (DataRow dr in tblMenu.Rows)
                {
                    menuTemp = new MenuDto();
                    menuTemp.id = Convert.ToInt32(dr["id_menu"].ToString());
                    menuTemp.nombre = dr["nombre"].ToString();
                    menuTemp.tag = dr["tag"].ToString();
                    menuTemp.descripcion = dr["descripcion"].ToString();
                    menuTemp.icono = dr["ruta_icono"].ToString();
                    menuTemp.activo = Convert.ToBoolean(dr["activo"].ToString());
                    listMenu.Add(menuTemp);
                }
                return listMenu;
            }
        }
    }
}
