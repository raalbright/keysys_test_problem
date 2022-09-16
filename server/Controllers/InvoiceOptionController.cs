using Microsoft.AspNetCore.Mvc;

using Invoices.WebApi.Services;

namespace Invoices.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InvoiceOptionController : ControllerBase
    {
        private readonly IInvoiceOptionService _service;
        public InvoiceOptionController(IInvoiceOptionService service)
        {
            _service = service;
        }

        [HttpGet(Name = "GetInvoiceOptions")]
        public IActionResult GetInvoiceOptions()
        {
            return Ok(_service.GetInvoiceOptions());
        }

        [HttpGet("{invoiceTypeCode}/{categoryId}", Name = "GetInvoiceOptionsWithParams")]
        public IActionResult GetInvoiceOptionsWithParams([FromRoute] int invoiceTypeCode, [FromRoute] int categoryId)
        {
            return Ok(_service.GetInvoiceOptions(invoiceTypeCode, categoryId));
        }
    }
}