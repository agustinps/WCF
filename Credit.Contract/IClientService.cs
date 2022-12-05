using Credit.Domain;
using System.Collections.Generic;
using System.ServiceModel;

namespace Credit.Contract
{
    [ServiceContract]
    public interface IClientService
    {
        [OperationContract]
        Client GetClient(string DocumentNumber);
        [OperationContract]
        IEnumerable<Client> GetAllclients();
    }
}
