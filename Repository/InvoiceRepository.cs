using Domain.Interfaces;
using System;
using System.Collections.Generic;
using Domain.Entities;
using System.Data.SqlClient;
using Dapper;
using System.Linq;

namespace Repository
{
    public class InvoiceRepository : IInvoiceRepository
    {

        private readonly string _connectionString;

        public InvoiceRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public int Deactivate(DateTime CreatedAt, DateTime DeactiveAt)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {

                var result = connection.Execute("UPDATE Invoice SET DeactiveAt = @DeactiveAt WHERE id = @CreatedAt", new { DeactiveAt, CreatedAt });
                connection.Close();

                return result;
            };
        }

        public Invoice Get(DateTime CreatedAt)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString)) {

                var invoice = connection.Query<Invoice>("SELECT * FROM Invoice WHERE CreatedAt = @CreatedAt", new { CreatedAt }).FirstOrDefault();

                return invoice;
            };
        }

        public List<Invoice> GetAll()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {

                var invoiceList = connection.Query<Invoice>("SELECT * FROM Invoice").ToList();
                connection.Close();

                return invoiceList;
            };
        }

        public int Insert(Invoice invoice)
        {
            int result;
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {

                result = connection.Execute(@"INSERT INTO Invoice
                                               (CreatedAt,ReferenceMonth,ReferenceYear,Document,Description,Amount,IsActive)
                                         VALUES
                                               (@CreatedAt,@ReferenceMonth,@ReferenceYear,@Document,@Description, @Amount, @IsActive)",
                                            new
                                            {
                                                invoice.CreatedAt,
                                                invoice.ReferenceMonth,
                                                invoice.ReferenceYear,
                                                invoice.Document,
                                                invoice.Description,
                                                invoice.Amount,
                                                invoice.IsActive
                                            });

                connection.Close();

                return result;
            };
        }
    }
}
