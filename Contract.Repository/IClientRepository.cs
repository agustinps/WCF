using Credit.Domain;
using System.Collections.Generic;

namespace Contract.Repository
{
    public interface IClientRepository
    {
        Client GetClient(string DocumentNumber);
        IEnumerable<Client> GetAllClients();
    }
}
