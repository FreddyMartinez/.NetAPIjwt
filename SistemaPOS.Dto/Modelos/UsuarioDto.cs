using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaPOS.Dto.Modelos
{
    public class UsuarioDto
    {
        public string usuario { get; set; }
        public string documento { get; set; }
        public int tipoDocumento { get; set; }
        public string nombre { get; set; }
        public string apellidos { get; set; }
        public string email { get; set; }
        public string telefono { get; set; }
        public string clave { get; set; }
        public int rol { get; set; }
        public string nombreRol { get; set; }
        public int cliente { get; set; }
        public bool activo { get; set; }

        public UsuarioDto(){}

        public UsuarioDto(string _usuario, string _documento, int _tipoDocumento, string _nombres, string _apellidos, string _correo, string _telefono, string _clave, int _rol, int _cliente, bool _activo)
        {
            usuario = _usuario;
            documento = _documento;
            tipoDocumento = _tipoDocumento;
            nombre = _nombres;
            apellidos = _apellidos;
            email = _correo;
            telefono = _telefono;
            clave = _clave;
            rol = _rol;
            cliente = _cliente;
            activo = _activo;
        }

        public UsuarioDto(DataRow dr)
        {
            usuario = dr["USUARIO"].ToString();
            documento = dr["DOCUMENTO"].ToString();
            tipoDocumento = Convert.ToInt32(dr["id_tipo_documento"].ToString());
            nombre = dr["NOMBRES"].ToString();
            apellidos = dr["APELLIDOS"].ToString();
            email = dr["EMAIL"].ToString();
            telefono = dr["TEL_CONTACTO"].ToString();
            clave = dr["PASSWORD"].ToString();
            rol = Convert.ToInt32(dr["ID_ROL"].ToString());
            cliente = Convert.ToInt32(dr["ID_CLIENTE"].ToString());
            activo = Convert.ToBoolean(dr["activo"].ToString());
        }
    }
}
