using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaPOS.Dto.Modelos
{
    public class PerfilRolDto
    {
        public int idRol { get; set; }
        public int idPerfil { get; set; }
        public string nombrePerfil { get; set; }
        public bool activo { get; set; }
        
        public PerfilRolDto() { }
        public PerfilRolDto(DataRow dr)
        {
            idPerfil = Convert.ToInt32(dr["id_perfil"].ToString());
            nombrePerfil = dr["perfil"].ToString();
            activo = Convert.ToBoolean(dr["rol_activo"].ToString() == "1");
        }
        public PerfilRolDto(int _idRol, int _idPerfil, bool _activo)
        {
            idRol = _idRol;
            idPerfil = _idPerfil;
            activo = _activo;
        }
    }
}
