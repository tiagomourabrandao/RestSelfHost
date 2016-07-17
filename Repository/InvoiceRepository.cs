using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Domain.Entities;

namespace Repository
{
    public class InvoiceRepository : IInvoiceRepository
    {
        public int Deactivate(int id)
        {
            throw new NotImplementedException();
        }

        public Invoice Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<Invoice> GetAll()
        {
            throw new NotImplementedException();
        }

        public int Insert(Invoice invoice)
        {
            throw new NotImplementedException();
        }
    }
}
