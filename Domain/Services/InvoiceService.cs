using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public Invoice Get(DateTime date)
        {
            return _invoiceRepository.Get(date);
        }

        public bool Deactivate(DateTime createdAt, DateTime deactiveAt)
        {
            const int maxAffectedRows = 1;
            var result = _invoiceRepository.Deactivate(createdAt, deactiveAt);

            return result == maxAffectedRows;
        }
    }
}
