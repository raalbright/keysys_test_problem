using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;

namespace Invoices.WebApi.Tests
{
    public class InvoiceOptionIntergrationTest
    {
        private HttpClient _httpClient;

        public InvoiceOptionIntergrationTest()
        {
            var application = new WebApplicationFactory<Program>()
                .WithWebHostBuilder(builder =>
                {
                    builder.ConfigureServices(services => { });
                });

            _httpClient = application.CreateClient();
        }
        
        [Fact]
        public async Task Get()
        {
            var response = await _httpClient.GetAsync("/api/invoiceoption");
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
