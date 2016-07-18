using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain.Interfaces;
using Moq;
using Domain.Entities;
using System.Collections.Generic;
using Domain.Services;
using System;

namespace RestSelfHostTest
{
    [TestClass]
    public class ServiceTest
    {

        [TestMethod]
        public void MustReturnList()
        {

            List<Invoice> listInvoice = new List<Invoice>();

            listInvoice.Add(new Invoice { Id = 1 });
            listInvoice.Add(new Invoice { Id = 2 });
            listInvoice.Add(new Invoice { Id = 3 });
            listInvoice.Add(new Invoice { Id = 4 });

            var expected = listInvoice;

            var invoiceRepositoryMock = new Mock<IInvoiceRepository>();
            invoiceRepositoryMock.Setup(x => x.GetAll()).Returns(() => listInvoice);


            var invoiceService = new InvoiceService(invoiceRepositoryMock.Object);
            var actual = invoiceService.GetAll();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void MustInsertInvoice() {

            const int maxAffectedRows = 1;
            var expected = true;

            var invoiceRepositoryMock = new Mock<IInvoiceRepository>();
            invoiceRepositoryMock.Setup(x => x.Insert(It.IsAny<Invoice>())).Returns(() => maxAffectedRows);

            var invoice = new Invoice { Id = 1 };

            var invoiceService = new InvoiceService(invoiceRepositoryMock.Object);
            var actual = invoiceService.Insert(invoice);

            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void MustReturnInvoice() {
            var expected = new Invoice { Id = 1 };

            var invoiceRepositoryMock = new Mock<IInvoiceRepository>();
            invoiceRepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(() => expected);

            var invoiceService = new InvoiceService(invoiceRepositoryMock.Object);
            var actual = invoiceService.Get(1);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void MustDeactivateInvoice() {

            const int maxAffectedRows = 1;
            var expected = true;

            var invoiceRepositoryMock = new Mock<IInvoiceRepository>();
            invoiceRepositoryMock.Setup(x => x.Deactivate(It.IsAny<DateTime>())).Returns(() => maxAffectedRows);

            var invoiceService = new InvoiceService(invoiceRepositoryMock.Object);

            var actual = invoiceService.Deactivate(new DateTime(2016, 3, 31));

            Assert.AreEqual(expected, actual);

        }

    }
}
