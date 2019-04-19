using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaPOS.Dto.Modelos
{
    public class EmpresaDto
    {
        public int idEmpresa { get; set; }
        public int idCliente { get; set; }
        public string nombre { get; set; }
        public string nit { get; set; }
        public string digitoVerificacion { get; set; }
        public string contacto { get; set; }
        public string telefonoContacto { get; set; }
        public string emailContacto { get; set; }
        public bool activo { get; set; }
        public string usuario { get; set; }

        public EmpresaDto(){}

        public EmpresaDto(int _idEmpresa, int _idCliente, string _nombre, string _nit, string _digitoVerificacion,  
                          string _contacto, string _telefonoContacto, string _emailContacto, bool _activo, string _usuario)
        {
            idEmpresa = _idEmpresa;
            idCliente = _idCliente;
            nombre = _nombre;
            nit = _nit;
            digitoVerificacion = _digitoVerificacion;
            contacto = _contacto;
            telefonoContacto = _telefonoContacto;
            emailContacto = _emailContacto;
            activo = _activo;
            usuario = _usuario;

        }

        public EmpresaDto(DataRow dr)
        {
         
            idEmpresa = Convert.ToInt32(dr["id_Empresa"].ToString());
            idCliente = Convert.ToInt32(dr["id_Cliente"].ToString());
            nombre = dr["nombre"].ToString();
            nit = dr["nit"].ToString();
            digitoVerificacion = dr["digito_verificacion"].ToString();
            contacto = dr["contacto"].ToString(); 
            telefonoContacto = dr["telefono_contacto"].ToString(); 
            emailContacto = dr["email_contacto"].ToString();

        }
    }
}
