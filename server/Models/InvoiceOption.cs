namespace Invoices.WebApi.Models
{
    public class InvoiceOption
    {
        public int InvoiceTypeCode { get; set; }

        public string InvoiceTypeDescription { get; set; }

        public int CategoryId { get; set; }

        public string CategoryDescription { get; set; }

        public int SubCategoryId { get; set; }

        public string SubCategoryDescription { get; set; }
    }
}