using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaPOS.Dto.Modelos
{
    public class MenuLateralDto
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string icono { get; set; }
        public List<GrupoMenuLateralDto> grupos { get; set; }

        public MenuLateralDto(){}
        public MenuLateralDto(DataRow dr)
        {
            id = Convert.ToInt32(dr["ID_MENU"].ToString());
            nombre = dr["MENU"].ToString();
            icono = dr["RUTA_ICONO_MENU"].ToString();
            grupos = new List<GrupoMenuLateralDto>();
        }
    }

    public class GrupoMenuLateralDto
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public List<PermisoMenuLateralDto> permisos { get; set; }

        public GrupoMenuLateralDto(){}
        public GrupoMenuLateralDto(DataRow dr)
        {
            id = Convert.ToInt32(dr["ID_GRUPO"].ToString());
            nombre = dr["GRUPO"].ToString();
            permisos = new List<PermisoMenuLateralDto>();
        }
    }

    public class PermisoMenuLateralDto
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string ruta { get; set; }

        public PermisoMenuLateralDto(){}

        public PermisoMenuLateralDto(DataRow dr)
        {
            id = Convert.ToInt32(dr["ID_PERMISO"].ToString());
            nombre = dr["PERMISO"].ToString();
            ruta = dr["RUTA_PERMISO"].ToString();
        }
    }
}
