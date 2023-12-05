using OrderDelayAnnouncement.Application.Commands;
using System.Net.Http.Json;

namespace OrderDelayAnnouncement.API.Tests.Integration
{
    public class VendorControllerIntegrationTests : IClassFixture<TestingWebAppFactory<Program>>
    {
        private readonly HttpClient _client;

        public VendorControllerIntegrationTests(TestingWebAppFactory<Program> factory)
            => _client = factory.CreateClient();

        [Fact]
        public async Task Create_WhenCalled_Returns_Number()
        {
            var model = new CreateVendorCommand { Name = "Motahari"};

            var response = await _client.PostAsJsonAsync("api/v1/Vendor/Create", model);

            var result = await response.Content.ReadAsStringAsync();

            var isNumeric = int.TryParse(result, out _);

            Assert.True(isNumeric);
          
        }
    }
    
}