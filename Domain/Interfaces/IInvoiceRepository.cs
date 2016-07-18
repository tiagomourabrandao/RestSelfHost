using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IInvoiceRepository
    {
        List<Invoice> GetAll();

        int Insert(Invoice invoice);

        Invoice Get(int id);

        int Deactivate(DateTime createdAt);
    }
}
