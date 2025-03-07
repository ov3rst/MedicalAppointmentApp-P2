using MedicalAppointment.Application.Contracts_Interfaces_.Users;
using MedicalAppointment.Application.DTOs.UsersDTOs.Users;
using MedicalAppointment.Application.Services.AppointmentsServices;
using MedicalAppointment.Domain.Base;
using MedicalAppointment.Domain.Entities.Users;
using MedicalAppointment.Persistence.Interfaces.UsersRepositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace MedicalAppointment.Application.Services.UsersServices
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        private readonly ILogger<AppointmentsService> _logger;
        private readonly IConfiguration _configuration;

        public UserService(IUserRepository repository, ILogger<AppointmentsService> logger, IConfiguration configuration)
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
                if (!result.Success) throw new Exception(_configuration["ErrorUserRepository:GetAllAsync"]);
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
                if (!result.Success) throw new Exception(_configuration["ErrorUserRepository:GetEntityByIdAsync"]);
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
                if (!result.Success) throw new Exception(_configuration["ErrorUserRepository:RemoveEntityAsync"]);
            }
            catch (Exception ex)
            {
                _logger.LogError(result.Message, ex.ToString());
            }

            return result;
        }

        public async Task<OperationResult> Save(SaveUserDTO data)
        {
            OperationResult result = new();

            try
            {
                User user = new()
                {
                    FirstName = data.FirstName!,
                    LastName = data.LastName!,
                    Email = data.Email!,
                    Password = data.Password!,
                    RoleID = data.RoleID,
                    CreatedAt = data.ChangeDate,
                    IsActive = data.IsActive,
                };

                result = await _repository.SaveEntityAsync(user);
                if (!result.Success) throw new Exception(_configuration["ErrorUserRepository:SaveEntityAsync"]);
            }
            catch (Exception ex)
            {
                _logger.LogError(result.Message, ex.ToString());
            }

            return result;
        }

        public async Task<OperationResult> Update(UpdateUserDTO data)
        {
            OperationResult result = new();

            try
            {
                User user = new()
                {
                    Id = data.UserId,
                    FirstName = data.FirstName!,
                    LastName = data.LastName!,
                    Email = data.Email!,
                    Password = data.Password!,
                    RoleID = data.RoleID,
                    UpdatedAt = data.ChangeDate,
                    IsActive = data.IsActive,
                };

                result = await _repository.UpdateEntityAsync(user);
                if (!result.Success) throw new Exception(_configuration["ErrorUserRepository:UpdateEntityAsync"]);
            }
            catch (Exception ex)
            {
                _logger.LogError(result.Message, ex.ToString());
            }

            return result;
        }
    }
}
