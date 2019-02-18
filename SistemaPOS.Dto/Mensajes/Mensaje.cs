using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaPOS.Dto.Mensajes
{
    public class Mensaje
    {
        //[JsonProperty(PropertyName = "codigoRespuesta")]
        public string codigoRespuesta { get; set; }

        //[JsonProperty(PropertyName = "mensajeRespuesta")]
        public string mensajeRespuesta { get; set; }

        //[JsonProperty(PropertyName = "objetoRespuesta")]
        public Object objetoRespuesta { get; set; }
    }
}
