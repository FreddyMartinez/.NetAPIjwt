using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaPOS.Dto.Modelos
{
    public class PerfilDto
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public int idCliente { get; set; }
        public bool activo { get; set; }

        public PerfilDto(){}
        public PerfilDto(DataRow dr)
        {
            id = Convert.ToInt32(dr["id_perfil"].ToString());
            nombre = dr["nombre"].ToString();
            descripcion = dr["descripcion"].ToString();
            idCliente = Convert.ToInt32(dr["id_cliente"].ToString());
            activo = Convert.ToBoolean(dr["activo"].ToString());
        }
        public PerfilDto(int _id, string _nombre, string _descripcion, int _idCliente, bool _activo)
        {
            id = _id;
            nombre = _nombre;
            descripcion = _descripcion;
            idCliente = _idCliente;
            activo = _activo;
        }
    }
}
