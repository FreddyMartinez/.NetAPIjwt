using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaPOS.DAL.Base
{
    public interface IRepositorio
    {
        DataTable EjecutaSentencia(string tag, string usuario, string parametros);
    }
}
