using MedicalAppointment.Domain.Base;
using MedicalAppointment.Domain.Entities.Appointments;
using MedicalAppointment.Persistence.Base;
using MedicalAppointment.Persistence.Context;
using MedicalAppointment.Persistence.Interfaces.AppointmentsRepositories;
using MedicalAppointment.Persistence.Validations.Appointments;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace MedicalAppointment.Persistence.Repositories.AppointmentsRepositories
{
    public class DoctorAvailabilityRepository : BaseRepository<DoctorAvailability, int>, IDoctorAvailabilityRepository
    {
        private readonly AppointmentDbContext _dbContext;
        private readonly ILogger<AppointmentsRepository> _logger;
        private readonly IConfiguration _configuration;

        public DoctorAvailabilityRepository(AppointmentDbContext context,
                                                          ILogger<AppointmentsRepository> logger,
                                                          IConfiguration configuration) : base(context)
        {
            _dbContext = context;
            _logger = logger;
            _configuration = configuration;
        }

        public override async Task<OperationResult> SaveEntityAsync(DoctorAvailability entity)
        {
            OperationResult result = DoctorAvailabilityValidation.ValidateAvailability(entity);

            if (result.Success)
            {
                try
                {
                    await base.SaveEntityAsync(entity);
                }
                catch (Exception ex)
                {
                    result.Success = false;
                    result.Message = this._configuration["ErrorDoctorAvailabilityRepository:SaveEntityAsync"];
                    _logger.LogError(result.Message, ex.ToString());
                }
            }

            return result;
        }

        public async override Task<OperationResult> UpdateEntityAsync(DoctorAvailability entity)
        {
            OperationResult result = DoctorAvailabilityValidation.ValidateAvailability(entity, true);

            if (result.Success)
            {
                try
                {
                    await base.UpdateEntityAsync(entity);
                }
                catch (Exception ex)
                {
                    result.Success = false;
                    result.Message = this._configuration["ErrorDoctorAvailabilityRepository:UpdateEntityAsync"];
                    _logger.LogError(result.Message, ex.ToString());
                }
            }

            return result;
        }
    }
}
