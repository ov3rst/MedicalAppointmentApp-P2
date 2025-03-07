using MedicalAppointment.Application.Contracts_Interfaces_.Medical;
using MedicalAppointment.Application.DTOs.MedicalDTOs.Specialties;
using MedicalAppointment.Application.Services.AppointmentsServices;
using MedicalAppointment.Domain.Base;
using MedicalAppointment.Domain.Entities.Medical;
using MedicalAppointment.Persistence.Interfaces.MedicalRepositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace MedicalAppointment.Application.Services.MedicalServices
{
    public class SpecialtiesService : ISpecialtiesService
    {
        private readonly ISpecialtiesRepository _repository;
        private readonly ILogger<AppointmentsService> _logger;
        private readonly IConfiguration _configuration;

        public SpecialtiesService(ISpecialtiesRepository repository, ILogger<AppointmentsService> logger, IConfiguration configuration)
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

                if (!result.Success) throw new Exception(_configuration["ErrorSpecialtiesRepository:GetAllAsync"]);
            }
            catch (Exception ex)
            {
                _logger.LogError(result.Message, ex.ToString());
            }

            return result;
        }

        public async Task<OperationResult> GetById(short id) => await _repository.GetEntityByIdAsync(id);

        public async Task<OperationResult> Save(SaveSpecialtiesDTO data)
        {
            OperationResult result = new();

            try
            {
                Specialties specialty = new()
                {
                    SpecialtyName = data.SpecialtyName,
                    CreatedAt = data.ChangeDate,
                    IsActive = data.IsActive,
                };

                result = await _repository.SaveEntityAsync(specialty);

                if (!result.Success) throw new Exception(_configuration["ErrorSpecialtiesRepository:SaveEntityAsync"]);
            }
            catch (Exception ex)
            {
                _logger.LogError(result.Message, ex.ToString());
            }

            return result;
        }

        public async Task<OperationResult> Update(UpdateSpecialtiesDTO data)
        {
            OperationResult result = new();

            try
            {
                Specialties specialty = new()
                {
                    Id = data.SpecialtyId,
                    SpecialtyName = data.SpecialtyName,
                    CreatedAt = data.ChangeDate,
                    IsActive = data.IsActive,
                };

                result = await _repository.UpdateEntityAsync(specialty);

                if (!result.Success) throw new Exception(_configuration["ErrorSpecialtiesRepository:UpdateEntityAsync"]);
            }
            catch (Exception ex)
            {
                _logger.LogError(result.Message, ex.ToString());
            }

            return result;
        }

        public async Task<OperationResult> Remove(short id)
        {
            OperationResult result = new();

            try
            {
                result = await _repository.RemoveEntityAsync(id);

                if (!result.Success) throw new Exception(_configuration["ErrorSpecialtiesRepository:RemoveEntityAsync"]);
            }
            catch (Exception ex)
            {
                _logger.LogError(result.Message, ex.ToString());
            }

            return result;
        }
    }
}
