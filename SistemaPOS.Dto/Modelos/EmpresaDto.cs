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
        public string direccion { get; set; }
        public string barrio { get; set; }
        public string telefono { get; set; }
        public string email { get; set; }
        public string contacto { get; set; }
        public string telefonoContacto { get; set; }
        public string emailContacto { get; set; }
        public bool activo { get; set; }
        public string usuario { get; set; }

        public EmpresaDto(){}

        public EmpresaDto(int _idEmpresa, int _idCliente, string _nombre, string _nit, string _digitoVerificacion, string _direccion, 
                          string _barrio, string _telefono, string _email, string _contacto, string _telefonoContacto, string _emailContacto, 
                          bool _activo, string _usuario)
        {
            idEmpresa = _idEmpresa;
            idCliente = _idCliente;
            nombre = _nombre;
            nit = _nit;
            digitoVerificacion = _digitoVerificacion;
            direccion = _direccion;
            barrio = _barrio;
            telefono = _telefono;
            email = _email;
            contacto = _contacto;
            telefonoContacto = _telefonoContacto;
            emailContacto = _emailContacto;
            activo = _activo;
            usuario = _usuario;

        }

        public EmpresaDto(DataRow dr)
        {
            usuario = dr["USUARIO"].ToString();

        }
    }
}
