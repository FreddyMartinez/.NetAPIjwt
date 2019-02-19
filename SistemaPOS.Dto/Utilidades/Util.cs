using System.Configuration;

namespace SistemaPOS.Dto.Utilidades
{
    public class Util
    {
        public static string ObtenerCadenaConexion(string sNombre)
        {
            return ConfigurationManager.ConnectionStrings[sNombre].ConnectionString;
        }
    }
}
