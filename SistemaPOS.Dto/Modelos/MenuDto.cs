
using System;
using System.Data;

namespace SistemaPOS.Dto.Modelos
{
    public class MenuDto
    {
        public int id { get; set; }
        public string tag { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public string icono { get; set; }
        public bool activo { get; set; }

        public MenuDto() {}

        public MenuDto(DataRow dr)
        {
            id = Convert.ToInt32(dr["id_menu"].ToString());
            nombre = dr["nombre"].ToString();
            tag = dr["tag"].ToString();
            descripcion = dr["descripcion"].ToString();
            icono = dr["ruta_icono"].ToString();
            activo = Convert.ToBoolean(dr["activo"].ToString());
        }
    }
}
