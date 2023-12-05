using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using OrderDelayAnnouncement.Domain.Contracts;
using OrderDelayAnnouncement.Domain.Settings;

namespace OrderDelayAnnouncement.Infrastructure.ThirdParty
{
    public class TripEstimateService : ITripEstimateService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private string _url;

        public TripEstimateService(IHttpClientFactory httpClientFactory , IOptions<AppSetting> option)
        {
            _httpClientFactory = httpClientFactory;
            _url = option.Value.EstimateUrl;
        }

        public async Task<int> GetEstimate()
        {
            var client = _httpClientFactory.CreateClient();
            var httpResponse = await client.GetAsync(new Uri(_url));
            var result = await httpResponse.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<TripEstimateResult>(result);

            return data.Estimate;
        }
    }
}
