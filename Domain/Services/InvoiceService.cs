using Domain.Entities;
using Domain.Interfaces;
using System.Collections.Generic;

namespace Domain.Services
{
    public class InvoiceService
    {

        private readonly IInvoiceRepository _invoiceRepository;

        public InvoiceService(IInvoiceRepository invoiceRepository)
        {
            _invoiceRepository = invoiceRepository;
        }

        public List<Invoice> GetAll()
        {
            return _invoiceRepository.GetAll();
        }

        public bool Insert(Invoice invoice)
        {
            const int maxAffectedRows = 1;
            var result = _invoiceRepository.Insert(invoice);

            return result == maxAffectedRows;
        }

        public Invoice Get(int id)
        {
            return _invoiceRepository.Get(id);
        }

        public bool Deactivate(int id)
        {
            const int maxAffectedRows = 1;
            var result = _invoiceRepository.Deactivate(id);

            return result == maxAffectedRows;
        }
    }
}
