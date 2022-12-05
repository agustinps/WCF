using Credit.Contract;
using Credit.Domain;
using Credit.SqlRepository;
using System.Collections.Generic;

namespace Credit.Implementation
{
    public class ClientService : IClientService
    {
        public IEnumerable<Client> GetAllclients()
        {
            using (var repository = new ClientRepository())            
                return repository.GetAllClients();            
        }

        public Client GetClient(string DocumentNumber)
        {
            using (var repository = new ClientRepository())
                return repository.GetClient(DocumentNumber);
        }
    }
}
