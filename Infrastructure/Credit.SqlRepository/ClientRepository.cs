using Dapper;
using Domain.Credit.Domain;
using Domain.Credit.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Infrastructure.Credit.SqlRepository
{
    public class ClientRepository : IClientRepository, IDisposable
    {
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public IEnumerable<Client> GetAllClients()
        {
            using (var con = new SqlConnection(Repositoryconnection.GetConnString()))
            {
                con.Open();                                
                return con.Query<Client>("sp_Listar_Clientes", commandType: CommandType.StoredProcedure);                
            }
        }

        public Client GetClient(string documentNumber)
        {
            using(var con = new SqlConnection(Repositoryconnection.GetConnString()))
            {
                con.Open();
                var parameters = new DynamicParameters();
                parameters.Add("pDocumento", documentNumber);
                return con.QuerySingle<Client>("sp_Obtener_Cliente", param: parameters, commandType: CommandType.StoredProcedure);                
            }
        }
    }
}
