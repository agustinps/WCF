using Domain.Credit.Domain;
using System.Collections.Generic;

namespace Domain.Credit.Repository
{    
    public interface ILoanRepository
    {        
        IEnumerable<Loan> GetAllLoans();

        Loan CreateLoan(Loan loan);

        Loan UpdateLoan(Loan loan);

        bool DeleteLoan(string loanId);
    }
}
