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
                    menuTemp = new MenuDto(dr);
                    listMenu.Add(menuTemp);
                }
                return listMenu;
            }
        }
    }
}
