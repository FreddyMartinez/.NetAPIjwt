using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaPOS.Dto.Modelos
{
    public class ClienteDto
    {

        public int idCliente { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public int tipoDocumento { get; set; }
        public string documento { get; set; }
        public string email { get; set; }
        public string telefono { get; set; }
        public string direccion { get; set; }
        public string barrio { get; set; }
        public int clientePrincipal { get; set; }
        public int clienteReferidor { get; set; }
        public bool activo { get; set; }
        public string usuario { get; set; }
        public string fechaCreacion { get; set; }
        public string usrModificacion { get; set; }
        public string fechaModificacion { get; set; }
        public string tipoDocumentoDes { get; set; }
        public string nombreClientePrincipal { get; set; }
        public string nombreClientereferido { get; set; }


        public ClienteDto(){}

        public ClienteDto(int _idCliente, string _nombre, string _apellido, int _tipoDocumento, string _documento, string _email, string _telefono, string _direccion, 
                          string _barrio,  int _clientePrincipal, int _clienteReferidor, bool _activo, string _usuario, string _fechaCreacion, string _usrModificacion,
                          string _fechaModificacion, string _tipoDocumentoDes, string _nombreClientePrincipal, string _nombreClientereferido)
        {
            
            idCliente = _idCliente;
            nombre = _nombre;
            apellido = _apellido;
            tipoDocumento = _tipoDocumento;
            documento = _documento;
            email = _email;
            telefono = _telefono;
            direccion = _direccion;
            barrio = _barrio;
            clientePrincipal = _clientePrincipal;
            clienteReferidor = _clienteReferidor;
            activo = _activo;
            usuario = _usuario;
            fechaCreacion = _fechaCreacion;
            usrModificacion = _usrModificacion;
            fechaModificacion = _fechaModificacion;
            tipoDocumentoDes = _tipoDocumentoDes;
            nombreClientePrincipal = _nombreClientePrincipal;
            nombreClientereferido = _nombreClientereferido;


        }

        public ClienteDto(DataRow dr)
        {
            idCliente = Convert.ToInt32(dr["id_cliente"].ToString());
            nombre = dr["nombres"].ToString();
            apellido = dr["apellidos"].ToString();
            tipoDocumento = Convert.ToInt32(dr["id_tipo_documento"].ToString());
            documento = dr["documento"].ToString();
            email = dr["email"].ToString();
            telefono = dr["telefono"].ToString();
            direccion = dr["direccion"].ToString();
            barrio = dr["id_barrio"].ToString();
            clientePrincipal = Convert.ToInt32(dr["id_cliente_principal"].ToString());
            clienteReferidor = Convert.ToInt32(dr["id_cliente_referidor"].ToString());
            activo = Convert.ToBoolean(dr["activo"].ToString());
            usuario = dr["usr_creacion"].ToString();
            fechaCreacion = dr["fecha_creacion"].ToString();
            usrModificacion = dr["usr_modificacion"].ToString();
            fechaModificacion = dr["fecha_modificacion"].ToString();
            tipoDocumentoDes = dr["tipo_documento"].ToString();
            nombreClientePrincipal = dr["cliente_principal"].ToString();
            nombreClientereferido = dr["cliente_referidor"].ToString();
        }
    }
}
