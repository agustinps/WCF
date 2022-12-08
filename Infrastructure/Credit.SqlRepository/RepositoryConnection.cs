using System.Configuration;

namespace Infrastructure.Credit.SqlRepository
{
    public class Repositoryconnection
    {
        public static string GetConnString()
        {
            return ConfigurationManager.ConnectionStrings["CreditosDB"].ToString();
        }
    }
}
