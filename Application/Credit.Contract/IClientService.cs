using Domain.Credit.Domain;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace Application.Credit.Contract
{
    [ServiceContract]
    public interface IClientService
    {
        [OperationContract]
        [FaultContract(typeof(Error))]
        //Para soportar REST
        [WebGet(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "/ObtenerCliente/{DocumentNumber}")]
        Client GetClient(string DocumentNumber);

        [OperationContract]
        [FaultContract(typeof(Error))]
        //Para soportar REST
        [WebGet(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "/ListarClientes")]
        IEnumerable<Client> GetAllclients();
    }
}
