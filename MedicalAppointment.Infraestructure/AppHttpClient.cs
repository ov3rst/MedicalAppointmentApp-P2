using MedicalAppointment.Application.Contracts_Interfaces_;
using MedicalAppointment.Domain.Base;
using System.Net.Http.Json;
using System.Text.Json;

namespace MedicalAppointment.Infraestructure
{
    public class AppHttpClient(IHttpClientFactory clientFactory) : IAppHttpClient
    {
        private readonly HttpClient _client = clientFactory.CreateClient("AppClient");

        /// <summary>
        /// Método que resuelve peticiones "GET"
        /// </summary>
        /// <typeparam name="T">Es el tipo de modelo al que deserializar los datos</typeparam>
        /// <param name="route">Es la ruta a la cual se hara la peticion "GET"</param>
        /// <returns>devuelve un operation result</returns>
        public async Task<OperationResult> GetResourseAsync<T>(string route)
        {
            OperationResult? result = new();

            var response = await _client.GetAsync(route);

            if (response.IsSuccessStatusCode)
            {
                result = await response.Content.ReadFromJsonAsync<OperationResult>();
                var res = JsonSerializer.Deserialize<T>(result!.Data);
                result.Data = res;
            }
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
    }
}