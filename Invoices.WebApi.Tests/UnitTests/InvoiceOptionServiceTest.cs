using Moq;
using Invoices.WebApi.Models;
using Invoices.WebApi.Repo;

namespace Invoices.WebApi.Tests.UnitTests
{
    public class InvoiceOptionServiceTest
    {
        private readonly InvoiceOptionService _service;
        private readonly Mock<IInvoiceOptionRepo> _repo = new Mock<IInvoiceOptionRepo>();

        public InvoiceOptionServiceTest()
        {
            _service = new(_repo.Object);
        }


        [Fact]
        public void GetInvoiceOptions_Returns_All_Invoices()
        {
            var expected = new List<InvoiceOption>()
            {
                new InvoiceOption() { InvoiceTypeCode = 807,  InvoiceTypeDescription = "Foreclosure Services - Judicial",  CategoryId = 1,  CategoryDescription = "Attorney Fees",  SubCategoryId = 127,  SubCategoryDescription = "Abandonment" },
                new InvoiceOption() { InvoiceTypeCode = 808,  InvoiceTypeDescription = "Foreclosure Services - Non-Judicial",  CategoryId = 1,  CategoryDescription = "Attorney Fees",  SubCategoryId = 127,  SubCategoryDescription = "Abandonment" },
                new InvoiceOption() { InvoiceTypeCode = 807,  InvoiceTypeDescription = "Foreclosure Services - Judicial",  CategoryId = 4,  CategoryDescription = "Service Costs",  SubCategoryId = 55,  SubCategoryDescription = "Abandonment Posting" },
                new InvoiceOption() { InvoiceTypeCode = 808,  InvoiceTypeDescription = "Foreclosure Services - Non-Judicial",  CategoryId = 4,  CategoryDescription = "Service Costs",  SubCategoryId = 55,  SubCategoryDescription = "Abandonment Posting" },
                new InvoiceOption() { InvoiceTypeCode = 807,  InvoiceTypeDescription = "Foreclosure Services - Judicial",  CategoryId = 7,  CategoryDescription = "Misc Costs",  SubCategoryId = 30,  SubCategoryDescription = "Abstractor's Complaint Review" }

            };
            _repo.Setup(o => o.GetInvoiceOptions()).Returns(expected);

            var actual = _service.GetInvoiceOptions();
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetInvoiceOptions_Returns_Matching_Invoices()
        {
            var expected = new List<InvoiceOption>()
            {
                new InvoiceOption() { InvoiceTypeCode = 807,  InvoiceTypeDescription = "Foreclosure Services - Judicial",  CategoryId = 1,  CategoryDescription = "Attorney Fees",  SubCategoryId = 127,  SubCategoryDescription = "Abandonment" },
                new InvoiceOption() { InvoiceTypeCode = 807,  InvoiceTypeDescription = "Foreclosure Services - Judicial",  CategoryId = 1,  CategoryDescription = "Attorney Fees",  SubCategoryId = 155,  SubCategoryDescription = "Addt'l Fee for Service by Publication" },
                new InvoiceOption() { InvoiceTypeCode = 807,  InvoiceTypeDescription = "Foreclosure Services - Judicial",  CategoryId = 1,  CategoryDescription = "Attorney Fees",  SubCategoryId = 157,  SubCategoryDescription = "Addt'l Fees for Third Party Sale" },
            };
            
            _repo.Setup(o => o.GetInvoiceOptions(It.IsAny<int>(), It.IsAny<int>())).Returns(expected);

            var actual = _service.GetInvoiceOptions(807, 1);
            Assert.Equal(actual, expected);
        }

        [Fact]
        public void GetInvoiceOptions_Returns_Empty_List_When_No_Matching_Invoices()
        {
            var expected = new List<InvoiceOption>() { };
            _repo.Setup(o => o.GetInvoiceOptions(It.IsAny<int>(), It.IsAny<int>())).Returns(expected);

            var actual = _service.GetInvoiceOptions(808, 1);
            Assert.Equal(actual, expected);
        }
    }
}
