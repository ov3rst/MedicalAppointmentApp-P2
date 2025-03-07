using MedicalAppointment.Application.Contracts_Interfaces_.System;
using MedicalAppointment.Application.DTOs.SystemDTOs.Roles;
using MedicalAppointment.Application.Services.AppointmentsServices;
using MedicalAppointment.Domain.Base;
using MedicalAppointment.Domain.Entities.System;
using MedicalAppointment.Persistence.Interfaces.SystemRepositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace MedicalAppointment.Application.Services.SystemServices
{
    public class RolesService : IRolesService
    {
        private readonly IRolesRepository _repository;
        private readonly ILogger<AppointmentsService> _logger;
        private readonly IConfiguration _configuration;

        public RolesService(IRolesRepository repository, ILogger<AppointmentsService> logger, IConfiguration configuration)
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

                if (!result.Success) throw new Exception(_configuration["ErrorRolesRepository:GetAllAsync"]);
            }
            catch (Exception ex)
            {
                _logger.LogError(result.Message, ex.ToString());
            }

            return result;
        }

        public async Task<OperationResult> GetById(int id) => await _repository.GetEntityByIdAsync(id);

        public async Task<OperationResult> Remove(int id) => await _repository.RemoveEntityAsync(id);

        public async Task<OperationResult> Save(SaveRolesDTO data)
        {
            OperationResult result = new();

            try
            {
                Roles role = new()
                {
                    RoleName = data.RoleName,
                    CreatedAt = data.ChangeDate,
                    IsActive = data.IsActive,
                };

                result = await _repository.SaveEntityAsync(role);

                if (!result.Success) throw new Exception(_configuration["ErrorRolesRepository:SaveEntityAsync"]);
            }
            catch (Exception ex)
            {
                _logger.LogError(result.Message, ex.ToString());
            }

            return result;
        }

        public async Task<OperationResult> Update(UpdateRolesDTO data)
        {
            OperationResult result = new();

            try
            {
                Roles role = new()
                {
                    Id = data.RoleId,
                    RoleName = data.RoleName,
                    UpdatedAt = data.ChangeDate,
                    IsActive = data.IsActive,
                };

                result = await _repository.UpdateEntityAsync(role);

                if (!result.Success) throw new Exception(_configuration["ErrorRolesRepository:UpdateEntityAsync"]);
            }
            catch (Exception ex)
            {
                _logger.LogError(result.Message, ex.ToString());
            }

            return result;
        }
    }
}
