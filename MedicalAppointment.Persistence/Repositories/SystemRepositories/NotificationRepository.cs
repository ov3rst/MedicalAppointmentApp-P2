using MedicalAppointment.Domain.Base;
using MedicalAppointment.Domain.Entities.System;
using MedicalAppointment.Persistence.Base;
using MedicalAppointment.Persistence.Context;
using MedicalAppointment.Persistence.Interfaces.SystemRepositories;
using MedicalAppointment.Persistence.Repositories.AppointmentsRepositories;
using MedicalAppointment.Persistence.Validations.System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace MedicalAppointment.Persistence.Repositories.SystemRepositories
{
    public class NotificationRepository : BaseRepository<Notification, int>, INotificationRepository
    {
        private readonly AppointmentDbContext _context;
        private readonly ILogger<AppointmentsRepository> _logger;
        private readonly IConfiguration _configuration;

        public NotificationRepository(AppointmentDbContext context,
                                                          ILogger<AppointmentsRepository> logger,
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
                }
                catch (Exception ex)
                {
                    result.Success = false;
                    result.Message = this._configuration["ErrorNotificationRepository:SaveEntityAsync"];
                    _logger.LogError(result.Message, ex.ToString());
                }
            }

            return result;
        }
    }
}
