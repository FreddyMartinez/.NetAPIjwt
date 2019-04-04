using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaPOS.Dto.Modelos
{
    public class PermisoPerfilDto
    {
        public int idPerfil { get; set; }
        public int idPermiso { get; set; }
        public string nombrePermiso { get; set; }
        public bool activo { get; set; }

        public PermisoPerfilDto(){}
        public PermisoPerfilDto(DataRow dr)
        {
            idPermiso = Convert.ToInt32(dr["id_permiso"].ToString());
            nombrePermiso = dr["permiso"].ToString();
            activo = Convert.ToBoolean(dr["permiso_activo"].ToString()=="1");
        }
        public PermisoPerfilDto(int _idPerfil, int _idPermiso, bool _activo)
        {
            idPerfil = _idPerfil;
            idPermiso = _idPermiso;
            activo = _activo;
        }
    }
}
