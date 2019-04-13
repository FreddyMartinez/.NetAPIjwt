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
        private AccesosRepositorio accesosRepositorio;
        public AccesosRepositorio AccesosRepositorio
        {
            get
            {
                if (this.accesosRepositorio == null)
                    this.accesosRepositorio = new AccesosRepositorio();
                return accesosRepositorio;
            }
        }

        private UsuariosRepositorio usuariosRepositorio;
        public UsuariosRepositorio UsuariosRepositorio
        {
            get
            {
                if (this.usuariosRepositorio == null)
                    this.usuariosRepositorio = new UsuariosRepositorio();
                return usuariosRepositorio;
            }
        }

        private EmpresasRepositorio empresasRepositorio;
        public EmpresasRepositorio EmpresasRepositorio
        {
            get
            {
                if (this.empresasRepositorio == null)
                    this.empresasRepositorio = new EmpresasRepositorio();
                return empresasRepositorio;
            }
        }

        private ClienteRepositorio clienteRepositorio;
        public ClienteRepositorio ClienteRepositorio
        {
            get
            {
                if (this.clienteRepositorio == null)
                    this.clienteRepositorio = new ClienteRepositorio();
                return clienteRepositorio;
            }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
