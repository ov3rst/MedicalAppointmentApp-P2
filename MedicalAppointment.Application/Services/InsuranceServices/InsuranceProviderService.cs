using MedicalAppointment.Application.Contracts_Interfaces_.Insurance;
using MedicalAppointment.Application.DTOs.InsuranceDTOs.InsuranceProvider;
using MedicalAppointment.Application.Services.AppointmentsServices;
using MedicalAppointment.Domain.Base;
using MedicalAppointment.Domain.Entities.Insurance;
using MedicalAppointment.Persistence.Interfaces.InsuranceRepositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace MedicalAppointment.Application.Services.InsuranceServices
{
    public class InsuranceProviderService : IInsuranceProviderService
    {
        private readonly IInsuranceProviderRepository _repository;
        private readonly ILogger<AppointmentsService> _logger;
        private readonly IConfiguration _configuration;

        public InsuranceProviderService(IInsuranceProviderRepository repository, ILogger<AppointmentsService> logger, IConfiguration configuration)
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

                if (!result.Success) throw new Exception(_configuration["ErrorInsuranceRepository:GetAllAsync"]);
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

                if (!result.Success) throw new Exception(_configuration["ErrorInsuranceRepository:GetEntityByIdAsync"]);
            }
            catch (Exception ex)
            {
                _logger.LogError(result.Message, ex.ToString());
            }

            return result;
        }

        public async Task<OperationResult> Save(SaveInsuranceProviderDTO data)
        {
            OperationResult result = new();

            try
            {
                InsuranceProvider insurance = new()
                {
                    Name = data.Name,
                    ContactNumber = data.ContactNumber,
                    Email = data.Email,
                    Website = data.Website,
                    Address = data.Address,
                    City = data.City,
                    State = data.State,
                    Country = data.Country,
                    ZipCode = data.ZipCode,
                    CoverageDetails = data.CoverageDetails,
                    LogoUrl = data.LogoUrl,
                    IsPreferred = data.IsPreferred,
                    NetworkTypeId = data.NetworkTypeId,
                    CustomerSupportContact = data.CustomerSupportContact,
                    AcceptedRegions = data.AcceptedRegions,
                    MaxCoverageAmount = data.MaxCoverageAmount,
                    CreatedAt = data.ChangeDate,
                    IsActive = data.IsActive,
                };

                result = await _repository.SaveEntityAsync(insurance);

                if (!result.Success) throw new Exception(_configuration["ErrorInsuranceRepository:SaveEntityAsync"]);
            }
            catch (Exception ex)
            {
                _logger.LogError(result.Message, ex.ToString());
            }

            return result;
        }

        public async Task<OperationResult> Update(UpdateInsuranceProviderDTO data)
        {
            OperationResult result = new();

            try
            {
                InsuranceProvider insurance = new()
                {
                    Id = data.InsuranceId,
                    Name = data.Name,
                    ContactNumber = data.ContactNumber,
                    Email = data.Email,
                    Website = data.Website,
                    Address = data.Address,
                    City = data.City,
                    State = data.State,
                    Country = data.Country,
                    ZipCode = data.ZipCode,
                    CoverageDetails = data.CoverageDetails,
                    LogoUrl = data.LogoUrl,
                    IsPreferred = data.IsPreferred,
                    NetworkTypeId = data.NetworkTypeId,
                    CustomerSupportContact = data.CustomerSupportContact,
                    AcceptedRegions = data.AcceptedRegions,
                    MaxCoverageAmount = data.MaxCoverageAmount,
                    UpdatedAt = data.ChangeDate,
                    IsActive = data.IsActive,
                };

                result = await _repository.SaveEntityAsync(insurance);

                if (!result.Success) throw new Exception(_configuration["ErrorInsuranceRepository:UpdateEntityAsync"]);
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
                if (!result.Success) throw new Exception(_configuration["ErrorInsuranceRepository:RemoveEntityAsync"]);
            }
            catch (Exception ex)
            {
                _logger.LogError(result.Message, ex.ToString());
            }

            return result;
        }
    }
}
