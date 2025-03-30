using MedicalAppointment.Application.Contracts_Interfaces_;
using MedicalAppointment.Domain.Base;
using System.Net.Http.Json;

namespace MedicalAppointment.Infraestructure
{
    public class AppHttpClient : IAppHttpClient
    {
        private readonly HttpClient _client;

        public AppHttpClient(IHttpClientFactory clientFactory)
        {
            _client = clientFactory.CreateClient("AppClient");
        }

        public async Task<OperationResult> GetResourseAsync(string route)
        {
            OperationResult? result = new();

            var response = await _client.GetAsync(route);

            if (response.IsSuccessStatusCode)
                result = await response.Content.ReadFromJsonAsync<OperationResult>();
            else
            {
                result.Success = false;
                result.Message = "Ocurrio un error al obtener los datos";
            }

            return result!;
        }

        public async Task<OperationResult> PostResourseAsync(string route, object data)
        {
            OperationResult? result = new();

            var response = await _client.PostAsJsonAsync(route, data);
            if (response.IsSuccessStatusCode)
                result = await response.Content.ReadFromJsonAsync<OperationResult>();
            else
            {
                result.Success = false;
                result.Message = "Ocurrio un error al guardar los datos";
            }

            return result!;
        }

        public async Task<OperationResult> PutResourseAsync(string route, object data)
        {
            OperationResult? result = new();

            var response = await _client.PutAsJsonAsync(route, data);
            if (response.IsSuccessStatusCode)
                result = await response.Content.ReadFromJsonAsync<OperationResult>();
            else
            {
                result.Success = false;
                result.Message = "Ocurrio un error al editar los datos";
            }

            return result!;
        }

        public async Task<OperationResult> DeleteResourseAsync(string route, int data)
        {
            OperationResult? result = new();

            var response = await _client.DeleteAsync($"{route}/{data}");
            if (response.IsSuccessStatusCode)
                result = await response.Content.ReadFromJsonAsync<OperationResult>();
            else
            {
                result.Success = false;
                result.Message = "Ocurrio un error al guardar los datos";
            }

            return result!;
        }
    }
}