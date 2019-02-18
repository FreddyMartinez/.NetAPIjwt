using SistemaPOS.DAL.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaPOS.DAL.Base
{
    public class UnitOfWork : IDisposable
    {
        private SeguridadRepositorio seguridadRepositorio;
        public SeguridadRepositorio SeguridadRepositorio
        {
            get
            {
                if (this.seguridadRepositorio == null)
                    this.seguridadRepositorio = new SeguridadRepositorio();
                return seguridadRepositorio;
            }
        }
        
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
