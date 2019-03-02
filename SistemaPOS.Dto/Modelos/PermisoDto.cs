using System;
using System.Data;

namespace SistemaPOS.Dto.Modelos
{
    public class PermisoDto
    {
        public int id { get; set; }
        public int idTipo { get; set; }
        public string tag { get; set; }
        public int idInterno { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public string ruta { get; set; }
        public string icono { get; set; }
        public int idGrupo { get; set; }
        public bool activo { get; set; }

        public PermisoDto() { }

        public PermisoDto(int _id, int _idTipo, string _tag, int _idInterno, string _nombre, string _descripcion, string _ruta, string _icono, int _idGrupo, bool _activo)
        {
            id = _id;
            idTipo = _idTipo;
            tag = _tag;
            idInterno = _idInterno;
            nombre = _nombre;
            descripcion = _descripcion;
            ruta = _ruta;
            icono = _icono;
            idGrupo = _idGrupo;
            activo = _activo;
        }

        public PermisoDto(DataRow dr)
        {
            id = Convert.ToInt32(dr["id_permiso"].ToString());
            idTipo = Convert.ToInt32(dr["id_tipo_permiso"].ToString());
            nombre = dr["nombre"].ToString();
            idInterno = Convert.ToInt32(dr["id_interno"].ToString());
            tag = dr["tag"].ToString();
            descripcion = dr["descripcion"].ToString();
            ruta = dr["ruta"].ToString();
            icono = dr["ruta_icono"].ToString();
            idGrupo = Convert.ToInt32(dr["id_grupo"].ToString());
            activo = Convert.ToBoolean(dr["activo"].ToString());
        }
    }
}
