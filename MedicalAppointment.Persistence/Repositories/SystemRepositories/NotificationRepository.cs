using MedicalAppointment.Domain.Base;
using MedicalAppointment.Domain.Entities.System;
using MedicalAppointment.Domain.SecurityInterfaces;
using MedicalAppointment.Persistence.Base;
using MedicalAppointment.Persistence.Context;
using MedicalAppointment.Persistence.Interfaces.SystemRepositories;
using MedicalAppointment.Persistence.Validations.System;
using Microsoft.Extensions.Configuration;

namespace MedicalAppointment.Persistence.Repositories.SystemRepositories
{
    public class NotificationRepository : BaseRepository<Notification, int>, INotificationRepository
    {
        private readonly AppointmentDbContext _context;
        private readonly ILoggerService<NotificationRepository> _logger;
        private readonly IConfiguration _configuration;

        public NotificationRepository(AppointmentDbContext context,
                                                          ILoggerService<NotificationRepository> logger,
                                                          IConfiguration configuration) : base(context)
        {
            _context = context;
            _logger = logger;
            _configuration = configuration;
        }

        public async override Task<OperationResult> SaveEntityAsync(Notification entity)
        {
            OperationResult result = NotificationValidations.ValidateNotification(entity);

            if (result.Success)
            {
                try
                {
                    result = await base.SaveEntityAsync(entity);
                    _logger.LogInformation(result.Message!);
                }
                catch (Exception ex)
                {
                    result.Success = false;
                    result.Message = this._configuration["ErrorNotificationRepository:SaveEntityAsync"];
                    _logger.LogError(result.Message!, ex);
                }
            }

            return result;
        }
    }
}
