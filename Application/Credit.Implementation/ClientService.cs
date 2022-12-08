using Application.Credit.Contract;
using Domain.Credit.Domain;
using Infrastructure.Credit.SqlRepository;
using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace Application.Credit.Implementation
{
    public class ClientService : IClientService
    {
        public IEnumerable<Client> GetAllclients()
        {
            try
            {
                using (var repository = new ClientRepository())
                    return repository.GetAllClients();
            }
            catch (Exception)
            {
                throw new FaultException<Error>(new Error() { ErrorCode = "1001", Description = "Excepción administrada por el servicio", Message = "Mensaje de error personalizado GetAllclients" });
            }
        }

        public Client GetClient(string DocumentNumber)
        {
            try
            {
                using (var repository = new ClientRepository())
                return repository.GetClient(DocumentNumber);
            }
            catch (Exception)
            {
                throw new FaultException<Error>(new Error() { ErrorCode = "1002", Description = "Excepción administrada por el servicio", Message = "Mensaje de error personalizado en GetClient" });
            }
        }
    }
}
