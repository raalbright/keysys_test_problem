using Invoices.WebApi.Models;
using Invoices.WebApi.Repo;
using Invoices.WebApi.Services;

public class InvoiceOptionService : IInvoiceOptionService
{
    private readonly IInvoiceOptionRepo _repo;
    public InvoiceOptionService(IInvoiceOptionRepo repo)
    {
        _repo = repo;
    }
    public IEnumerable<InvoiceOption> GetInvoiceOptions()
    {
        return _repo.GetInvoiceOptions();
    }
    public IEnumerable<InvoiceOption> GetInvoiceOptions(int invoiceTypeCode, int categoryId)
    {
        return _repo.GetInvoiceOptions(invoiceTypeCode, categoryId);
    }
}