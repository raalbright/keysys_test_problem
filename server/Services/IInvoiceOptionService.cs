using Invoices.WebApi.Models;

namespace Invoices.WebApi.Services
{
    public interface IInvoiceOptionService
    {
        public IEnumerable<InvoiceOption> GetInvoiceOptions();
        public IEnumerable<InvoiceOption> GetInvoiceOptions(int invoiceTypeCode, int categoryId);
    }
}
