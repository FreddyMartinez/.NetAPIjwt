using SistemaPOS.DAL.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPOS.BLL
{
    public class SeguridadNegocio
    {
        public string ConsultarMenu()
        {
            using(UnitOfWork uow = new UnitOfWork())
            {
                return uow.SeguridadRepositorio.ConsultarMenu();
            }
        }
    }
}
