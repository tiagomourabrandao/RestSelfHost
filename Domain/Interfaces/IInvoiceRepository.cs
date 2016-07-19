using Domain.Entities;
using System.Collections.Generic;

namespace Domain.Interfaces
{
    public interface IInvoiceRepository
    {
        List<Invoice> GetAll();

        int Insert(Invoice invoice);

        Invoice Get(int id);

        int Deactivate(int id);
    }
}
