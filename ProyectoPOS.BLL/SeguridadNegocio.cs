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
    }
}
