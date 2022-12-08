using Domain.Credit.Domain;
using System.Collections.Generic;
using System.ComponentModel;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace Application.Credit.Contract
{
    [ServiceContract]
    public interface ILoanService
    {
        [OperationContract]        
        [Description("Servicio REST que lista todos los prestamos")]
        [FaultContract(typeof(Error))]
        //Para soportar REST
        [WebGet(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "/ListarPrestamos")]
        IEnumerable<Loan> GetAllLoans();

        [OperationContract]
        [Description("Servicio REST que permite crear un prestamo")]
        [FaultContract(typeof(Error))]
        //Para soportar REST
        [WebInvoke(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "/CrearPrestamo", Method = "POST")]
        Loan CreateLoan(Loan loan);

        [OperationContract]
        [Description("Servicio REST permite actualizar un prestamo")]
        [FaultContract(typeof(Error))]
        //Para soportar REST
        [WebInvoke(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "/ActualizarPrestamo", Method = "PUT")]
        Loan UpdateLoan(Loan loan);

        [OperationContract]
        [Description("Servicio REST que permite eliminar un prestamo")]
        [FaultContract(typeof(Error))]
        //Para soportar REST
        [WebInvoke(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "/EliminarPrestamo/{loanId}", Method = "DELETE")]
        bool DeleteLoan(string loanId);

    }
}
