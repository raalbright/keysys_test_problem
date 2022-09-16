using Invoices.WebApi.Controllers;
using Invoices.WebApi.Models;
using Invoices.WebApi.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Invoices.WebApi.Tests.UnitTests
{
    public class InvoiceOptionControllerTest
    {
        private readonly InvoiceOptionController _controller;
        private readonly Mock<IInvoiceOptionService> _service = new Mock<IInvoiceOptionService>();

        public InvoiceOptionControllerTest()
        {
            _controller = new(_service.Object);
        }

        [Fact]
        public void GetInvoiceOptions_Returns_All_Invoices_With_200StatusCode()
        {
            var expected = new List<InvoiceOption>()
            {
                new InvoiceOption() { InvoiceTypeCode = 807,  InvoiceTypeDescription = "Foreclosure Services - Judicial",  CategoryId = 1,  CategoryDescription = "Attorney Fees",  SubCategoryId = 127,  SubCategoryDescription = "Abandonment" },
                new InvoiceOption() { InvoiceTypeCode = 808,  InvoiceTypeDescription = "Foreclosure Services - Non-Judicial",  CategoryId = 1,  CategoryDescription = "Attorney Fees",  SubCategoryId = 127,  SubCategoryDescription = "Abandonment" },
                new InvoiceOption() { InvoiceTypeCode = 807,  InvoiceTypeDescription = "Foreclosure Services - Judicial",  CategoryId = 4,  CategoryDescription = "Service Costs",  SubCategoryId = 55,  SubCategoryDescription = "Abandonment Posting" },
                new InvoiceOption() { InvoiceTypeCode = 808,  InvoiceTypeDescription = "Foreclosure Services - Non-Judicial",  CategoryId = 4,  CategoryDescription = "Service Costs",  SubCategoryId = 55,  SubCategoryDescription = "Abandonment Posting" },
                new InvoiceOption() { InvoiceTypeCode = 807,  InvoiceTypeDescription = "Foreclosure Services - Judicial",  CategoryId = 7,  CategoryDescription = "Misc Costs",  SubCategoryId = 30,  SubCategoryDescription = "Abstractor's Complaint Review" }

            };
            _service.Setup(o => o.GetInvoiceOptions()).Returns(expected);

            var res = Assert.IsType<OkObjectResult>(_controller.GetInvoiceOptions());
            var actual = res.Value;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetInvoiceOptions_Returns_Matching_Invoices_With_200StatusCode()
        {
            var expected = new List<InvoiceOption>()
            {
                new InvoiceOption() { InvoiceTypeCode = 807,  InvoiceTypeDescription = "Foreclosure Services - Judicial",  CategoryId = 1,  CategoryDescription = "Attorney Fees",  SubCategoryId = 127,  SubCategoryDescription = "Abandonment" },
                new InvoiceOption() { InvoiceTypeCode = 807,  InvoiceTypeDescription = "Foreclosure Services - Judicial",  CategoryId = 1,  CategoryDescription = "Attorney Fees",  SubCategoryId = 155,  SubCategoryDescription = "Addt'l Fee for Service by Publication" },
                new InvoiceOption() { InvoiceTypeCode = 807,  InvoiceTypeDescription = "Foreclosure Services - Judicial",  CategoryId = 1,  CategoryDescription = "Attorney Fees",  SubCategoryId = 157,  SubCategoryDescription = "Addt'l Fees for Third Party Sale" },
            };
            _service.Setup(o => o.GetInvoiceOptions(It.IsAny<int>(), It.IsAny<int>())).Returns(expected);

            var res = Assert.IsType<OkObjectResult>(_controller.GetInvoiceOptionsWithParams(807, 1));
            var actual = res.Value;
            Assert.Equal(actual, expected);
        }

        [Fact]
        public void GetInvoiceOptions_Returns_Empty_List_When_No_Matching_Invoices_With_200StatusCode()
        {
            var expected = new List<InvoiceOption>() { };
            _service.Setup(o => o.GetInvoiceOptions(It.IsAny<int>(), It.IsAny<int>())).Returns(expected);

            var res = Assert.IsType<OkObjectResult>(_controller.GetInvoiceOptionsWithParams(808, 1));
            var actual = res.Value;
            Assert.Equal(actual, expected);
        }

    }
}