using Invoices.WebApi.Models;

namespace Invoices.WebApi.Repo
{
    public interface IInvoiceOptionRepo
    {
        public IEnumerable<InvoiceOption> GetInvoiceOptions();
        public IEnumerable<InvoiceOption> GetInvoiceOptions(int invoiceTypeCode, int categoryId);
    }
}
