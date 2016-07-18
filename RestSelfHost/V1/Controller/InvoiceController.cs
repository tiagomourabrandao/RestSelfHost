using Domain.Entities;
using Domain.Interfaces;
using Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RestSelfHost.Controller.V1
{
    public class InvoiceController : ApiController
    {

        private readonly InvoiceService _invoiceService;



        public InvoiceController(IInvoiceRepository invoiceRepository)
        {
            _invoiceService = new InvoiceService(invoiceRepository);
        }

        public IHttpActionResult Get()
        {
            var invoices = _invoiceService.GetAll();
            if (invoices.Any())
                return Ok(invoices);
            else
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
        }
        public IHttpActionResult Get(int id)
        {
            var invoice = _invoiceService.Get(id);
            if (invoice != null)
                return Ok(invoice);
            else
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
        }

        public IHttpActionResult Put(int id, bool status)
        {
            return ResponseMessage(new HttpResponseMessage(HttpStatusCode.MethodNotAllowed));
        }

        public IHttpActionResult Post(Invoice invoice)
        {

            if (ModelState.IsValid)
            {
                if (_invoiceService.Insert(invoice))
                    return Ok("Invoice Created!");
                else
                    return InternalServerError(new Exception("We had a problem to insert your invoice. Please, try again later"));
            }
            else
                return BadRequest("Invalid Data!");
        }

        public IHttpActionResult Delete(DateTime dateActivate)
        {
            var isDeactivated = _invoiceService.Deactivate(dateActivate);
            if (isDeactivated)
                return Ok("Invoice Deactivated!");
            else
                return InternalServerError(new Exception("We had a problem to deactive your invoice. Please, try again later"));
        }

    }
}
