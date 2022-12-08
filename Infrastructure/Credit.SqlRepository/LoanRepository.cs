using Dapper;
using Domain.Credit.Domain;
using Domain.Credit.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Infrastructure.Credit.SqlRepository
{
    public class LoanRepository : ILoanRepository, IDisposable
    {

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public Loan CreateLoan(Loan loan)
        {            
            using (IDbConnection con = new SqlConnection(Repositoryconnection.GetConnString()))
            {
                con.Open();
                var parametros = new DynamicParameters();
                parametros.Add("IdLoan", loan.IdCredito, DbType.Int32, ParameterDirection.Output);
                parametros.Add("ClientId", loan.IdCliente);
                parametros.Add("Mount", loan.Cantidad);
                parametros.Add("Commission", loan.Comision);
                parametros.Add("PaymentDay", loan.DiaDePago);
                parametros.Add("Date", loan.Fecha);
                parametros.Add("Rate", loan.TasaInteres);
                parametros.Add("CreditType", loan.TipoCredito);                
                var result = con.ExecuteScalar("dbo.sp_Crear_Prestamo", param: parametros, commandType: CommandType.StoredProcedure);
                var pIdLoan = parametros.Get<Int32>("IdLoan");

                loan.IdCredito = pIdLoan;
                return loan;
            }
        }

        public bool DeleteLoan(string loanId)
        {
            using (IDbConnection con = new SqlConnection(Repositoryconnection.GetConnString()))
            {
                con.Open();
                var parametros = new DynamicParameters();
                parametros.Add("IdCredito", loanId);
                var result = con.Execute("dbo.sp_Eliminar_Prestamo", param: parametros, commandType: CommandType.StoredProcedure);                
                return result > 0;
            }
        }


        public IEnumerable<Loan> GetAllLoans()
        {
            using (var con = new SqlConnection(Repositoryconnection.GetConnString()))
            {
                con.Open();
               return con.Query<Loan>("dbo.sp_Listar_Prestamos", commandType: CommandType.StoredProcedure);                
            }
        }

        public Loan UpdateLoan(Loan loan)
        {
            using (IDbConnection con = new SqlConnection(Repositoryconnection.GetConnString()))
            {
                con.Open();
                var parametros = new DynamicParameters();
                parametros.Add("IdLoan", loan.IdCredito);
                parametros.Add("ClientId", loan.IdCliente);
                parametros.Add("Mount", loan.Cantidad);
                parametros.Add("Commission", loan.Comision);
                parametros.Add("PaymentDay", loan.DiaDePago);
                parametros.Add("Date", loan.Fecha);
                parametros.Add("Rate", loan.TasaInteres);
                parametros.Add("CreditType", loan.TipoCredito);
                
                var result = con.Execute("dbo.sp_Actualizar_Prestamo", param: parametros, commandType: CommandType.StoredProcedure);
                
                return result > 0 ? loan : new Loan();
            }
        }
    }
}
