using MedicalAppointment.Application.Contracts_Interfaces_.Insurance;
using MedicalAppointment.Application.DTOs.InsuranceDTOs.NetwrokTypes;
using MedicalAppointment.Application.Services.AppointmentsServices;
using MedicalAppointment.Domain.Base;
using MedicalAppointment.Domain.Entities.Insurance;
using MedicalAppointment.Persistence.Interfaces.InsuranceRepositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace MedicalAppointment.Application.Services.InsuranceServices
{
    public class NetworkTypeService : INetworkTypeService
    {
        private readonly INetworkTypeRepository _repository;
        private readonly ILogger<AppointmentsService> _logger;
        private readonly IConfiguration _configuration;

        public NetworkTypeService(INetworkTypeRepository repository, ILogger<AppointmentsService> logger, IConfiguration configuration)
        {
            _repository = repository;
            _logger = logger;
            _configuration = configuration;
        }

        public async Task<OperationResult> GetAll()
        {
            OperationResult result = new();

            try
            {
                result = await _repository.GetAllAsync();

                if (!result.Success) throw new Exception(_configuration["ErrorNetworkType:GetAllAsync"]);
            }
            catch (Exception ex)
            {
                _logger.LogError(result.Message, ex.ToString());
            }

            return result;
        }

        public async Task<OperationResult> GetById(int id)
        {
            OperationResult result = new();

            try
            {
                result = await _repository.GetEntityByIdAsync(id);

                if (!result.Success) throw new Exception(_configuration["ErrorNetworkType:GetEntityByIdAsync"]);
            }
            catch (Exception ex)
            {
                _logger.LogError(result.Message, ex.ToString());
            }

            return result;
        }

        public async Task<OperationResult> Save(SaveNetworkTypeDTO data)
        {
            OperationResult result = new();

            try
            {
                NetworkType network = new()
                {
                    Name = data.Name,
                    Description = data.Description,
                    CreatedAt = data.ChangeDate,
                    IsActive = data.IsActive,
                };

                result = await _repository.SaveEntityAsync(network);

                if (!result.Success) throw new Exception(_configuration["ErrorNetworkType:SaveEntityAsync"]);
            }
            catch (Exception ex)
            {
                _logger.LogError(result.Message, ex.ToString());
            }

            return result;
        }

        public async Task<OperationResult> Update(UpdateNetworkTypeDTO data)
        {
            OperationResult result = new();

            try
            {
                NetworkType network = new()
                {
                    Id = data.NetworkId,
                    Name = data.Name,
                    Description = data.Description,
                    UpdatedAt = data.ChangeDate,
                    IsActive = data.IsActive,
                };

                result = await _repository.SaveEntityAsync(network);

                if (!result.Success) throw new Exception(_configuration["ErrorNetworkType:SaveEntityAsync"]);
            }
            catch (Exception ex)
            {
                _logger.LogError(result.Message, ex.ToString());
            }

            return result;
        }

        public async Task<OperationResult> Remove(int id)
        {
            OperationResult result = new();

            try
            {
                result = await _repository.RemoveEntityAsync(id);
                if (!result.Success) throw new Exception(_configuration["ErrorNetworkType:GetAllAsync"]);
            }
            catch (Exception ex)
            {
                _logger.LogError(result.Message, ex.ToString());
            }

            return result;
        }
    }
}
