using Domain.Credit.Domain;
using System.Collections.Generic;

namespace Domain.Credit.Repository
{
    public interface IClientRepository
    {
        Client GetClient(string DocumentNumber);
        IEnumerable<Client> GetAllClients();
    }
}
