using MedicalAppointment.Domain.Base;
using MedicalAppointment.Domain.Entities.Appointments;
using MedicalAppointment.Model.AppointmentsModels;
using MedicalAppointment.Persistence.Base;
using MedicalAppointment.Persistence.Context;
using MedicalAppointment.Persistence.Interfaces.AppointmentsRepositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace MedicalAppointment.Persistence.Repositories.AppointmentsRepositories
{
    public class AppointmentsRepository : BaseRepository<Appointments, int>, IAppointmentsRepository
    {
        private readonly AppointmentDbContext _context;
        private readonly ILogger<AppointmentsRepository> _logger;
        private readonly IConfiguration _configuration;

        public AppointmentsRepository(AppointmentDbContext context,
                                                          ILogger<AppointmentsRepository> logger,
                                                          IConfiguration configuration) : base(context)
        {
            _context = context;
            _logger = logger;
            _configuration = configuration;
        }

        public override async Task<OperationResult> SaveEntityAsync(Appointments entity)
        {
            OperationResult result = AppointmentValidations.ValidateAppointment(entity);

            if (result.Success)
            {
                try
                {
                    result = await base.SaveEntityAsync(entity);
                }
                catch (Exception ex)
                {
                    result.Success = false;
                    result.Message = this._configuration["ErrorAppointmentsRepository:SaveEntityAsync"];
                    _logger.LogError(result.Message, ex.ToString());
                }
            }

            return result;
        }

        public async override Task<OperationResult> UpdateEntityAsync(Appointments entity)
        {
            OperationResult result = AppointmentValidations.ValidateAppointment(entity, true);

            if (result.Success)
            {
                try
                {
                    result = await base.UpdateEntityAsync(entity);
                }
                catch (Exception ex)
                {
                    result.Success = false;
                    result.Message = this._configuration["ErrorAppointmentsRepository:UpdateEntityAsync"];
                    _logger.LogError(result.Message, ex.ToString());
                }
            }

            return result;
        }

        public override async Task<OperationResult> RemoveEntityAsync(Appointments entity)
        {
            OperationResult result = AppointmentValidations.ValidateAppointment(entity, true);

            if (result.Success)
            {
                try
                {
                    result = await base.RemoveEntityAsync(entity);
                }
                catch (Exception ex)
                {
                    result.Success = false;
                    result.Message = this._configuration["ErrorAppointmentsRepository:RemoveEntityAsync"];
                    _logger.LogError(result.Message, ex.ToString());
                }
            }

            return result;
        }

        public override async Task<OperationResult> GetEntityByIdAsync(int id)
        {
            OperationResult result = Validations.BaseValidations.ValidateId(id);
            if (result.Success)
            {
                try
                {
                    result.Data = await (from appo in _context.Appointments
                                         where appo.Id == id
                                         select new AppointmentModel
                                         {
                                             AppointmentId = appo.Id,
                                             DoctorID = appo.DoctorID,
                                             PatientID = appo.PatientID,
                                             StatusID = appo.StatusID,
                                             AppointmentDate = appo.AppointmentDate,
                                         }).FirstOrDefaultAsync();

                    result.Message = "La entidad ha sido encontrada";
                }
                catch (Exception ex)
                {
                    result.Success = false;
                    result.Message = _configuration["ErrorAppointmentsRepository:GetEntityByIdAsync"];
                    _logger.LogError(result.Message, ex.ToString());

                }
            }

            return result;
        }

        public override async Task<OperationResult> GetAllAsync()
        {
            OperationResult result = new();

            try
            {
                result.Data = await (from appo in _context.Appointments
                                     select new AppointmentModel
                                     {
                                         AppointmentId = appo.Id,
                                         DoctorID = appo.DoctorID,
                                         PatientID = appo.PatientID,
                                         StatusID = appo.StatusID,
                                         AppointmentDate = appo.AppointmentDate,
                                     }).ToListAsync();

                result.Message = "Entidades listadas con exito";
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = _configuration["ErrorAppointmentsRepository:GetAllAsync"];
                _logger.LogError(result.Message, ex.ToString());
            }

            return result;
        }
    }
}
