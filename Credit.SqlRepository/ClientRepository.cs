using Contract.Repository;
using Credit.Domain;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Credit.SqlRepository
{
    public class ClientRepository : IClientRepository, IDisposable
    {
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public IEnumerable<Client> GetAllClients()
        {
            using (var con = new SqlConnection(ConexionRepositorio.ObtenerCadenaConexion()))
            {
                con.Open();                                
                return con.Query<Client>("sp_Listar_Clientes", commandType: CommandType.StoredProcedure);                
            }
        }

        public Client GetClient(string documentNumber)
        {
            using(var con = new SqlConnection(ConexionRepositorio.ObtenerCadenaConexion()))
            {
                con.Open();
                var parameters = new DynamicParameters();
                parameters.Add("pDocumento", documentNumber);
                return con.QuerySingle<Client>("sp_Obtener_Cliente", param: parameters, commandType: CommandType.StoredProcedure);                
            }
        }
    }
}
