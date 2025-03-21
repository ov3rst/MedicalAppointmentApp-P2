using MedicalAppointment.Application.Contracts_Interfaces_;
using MedicalAppointment.Domain.Base;

namespace MedicalAppointment.Infraestructure
{
    public class AppHttpClient : IAppHttpClient
    {
        private readonly HttpClient _client;

        public AppHttpClient(IHttpClientFactory clientFactory)
        {
            _client = clientFactory.CreateClient("AppClient");
        }

        public async Task<OperationResult> GetAsync(string route)
        {
            OperationResult result = new();

            var response = await _client.GetAsync(route);

            if (response.IsSuccessStatusCode)
            {
                //result = await response.Content.ReadFromJsonAsync();
            }
        }

        public Task<OperationResult> PostAsync(string route)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult> PutAsync(string route)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult> DeleteAsync(string route)
        {
            throw new NotImplementedException();
        }
    }
}
