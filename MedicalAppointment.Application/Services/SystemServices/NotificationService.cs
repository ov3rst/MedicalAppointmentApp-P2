using MedicalAppointment.Application.Contracts_Interfaces_.System;
using MedicalAppointment.Application.DTOs.SystemDTOs.Notification;
using MedicalAppointment.Application.Services.AppointmentsServices;
using MedicalAppointment.Domain.Base;
using MedicalAppointment.Domain.Entities.System;
using MedicalAppointment.Persistence.Interfaces.SystemRepositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace MedicalAppointment.Application.Services.SystemServices
{
    public class NotificationService : INotificationService
    {
        private readonly INotificationRepository _repository;
        private readonly ILogger<AppointmentsService> _logger;
        private readonly IConfiguration _configuration;

        public NotificationService(INotificationRepository repository, ILogger<AppointmentsService> logger, IConfiguration configuration)
        {
            _repository = repository;
            _logger = logger;
            _configuration = configuration;
        }

        public async Task<OperationResult> GetAll() => await _repository.GetAllAsync();

        public async Task<OperationResult> GetById(int id) => await _repository.GetEntityByIdAsync(id);

        public async Task<OperationResult> Save(SaveNotificationDTO data)
        {
            OperationResult result = new();

            try
            {
                Notification notification = new()
                {
                    UserId = data.UserId,
                    Message = data.Message,
                    SendAt = data.SendAt,
                };

                result = await _repository.SaveEntityAsync(notification);

                if (!result.Success) throw new Exception(_configuration["ErrorNotificationRepository:SaveEntityAsync"]);
            }
            catch (Exception ex)
            {
                _logger.LogError(result.Message, ex.ToString());
            }

            return result;
        }

        public async Task<OperationResult> Update(UpdateNotificationDTO data)
        {
            OperationResult result = new();

            try
            {
                Notification notification = new()
                {
                    Id = data.NotificationId,
                    Message = data.Message,
                    SendAt = data.SendAt,
                };

                result = await _repository.SaveEntityAsync(notification);

                if (!result.Success) throw new Exception(result.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(result.Message, ex.ToString());
            }

            return result;
        }

        public async Task<OperationResult> Remove(int id) => await _repository.RemoveEntityAsync(id);
    }
}
