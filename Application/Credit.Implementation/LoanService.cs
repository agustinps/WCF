using Application.Credit.Contract;
using Domain.Credit.Domain;
using Infrastructure.Credit.SqlRepository;
using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace Application.Credit.Implementation
{
    public class LoanService : ILoanService
    {
        public Loan CreateLoan(Loan loan)
        {
            try
            {
                using (var repository = new LoanRepository())
                    return repository.CreateLoan(loan);
            }
            catch (Exception)
            {
                throw new FaultException<Error>(new Error() { ErrorCode = "1001", Description = "Excepción administrada por el servicio", Message = "Mensaje de error personalizado CreateLoan" });
            }
        }

        public bool DeleteLoan(string loanId)
        {
            try
            {
                using (var repository = new LoanRepository())
                    return repository.DeleteLoan(loanId);
            }
            catch (Exception)
            {
                throw new FaultException<Error>(new Error() { ErrorCode = "1001", Description = "Excepción administrada por el servicio", Message = "Mensaje de error personalizado DeleteLoan" });
            }
        }        

        public IEnumerable<Loan> GetAllLoans()
        {
            try
            {
                using (var repository = new LoanRepository())
                    return repository.GetAllLoans();
            }
            catch (Exception)
            {
                throw new FaultException<Error>(new Error() { ErrorCode = "1001", Description = "Excepción administrada por el servicio", Message = "Mensaje de error personalizado GetAllLoans" });
            }
        }

        public Loan UpdateLoan(Loan loan)
        {
            try
            {
                using (var repository = new LoanRepository())
                    return repository.UpdateLoan(loan);
            }
            catch (Exception)
            {
                throw new FaultException<Error>(new Error() { ErrorCode = "1001", Description = "Excepción administrada por el servicio", Message = "Mensaje de error personalizado UpdateLoan" });
            }
        }

        
    }
}
