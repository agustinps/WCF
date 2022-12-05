using System.Configuration;

namespace Credit.SqlRepository
{
    public class ConexionRepositorio
    {
        public static string ObtenerCadenaConexion()
        {
            return ConfigurationManager.ConnectionStrings["CreditosDB"].ToString();
        }
    }
}
