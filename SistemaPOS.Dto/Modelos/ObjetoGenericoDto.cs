using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaPOS.Dto.Modelos
{
    public class ObjetoGenericoDto
    {
        public int llave { get; set; }
        public string valor { get; set; }

        public ObjetoGenericoDto(){}
        public ObjetoGenericoDto(DataRow dr)
        {
            llave = Convert.ToInt32(dr["ID"].ToString());
            valor = dr["DESCRIPCION"].ToString();
        }
    }
}
