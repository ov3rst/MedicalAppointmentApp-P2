using MedicalAppointment.Domain.Base;
using MedicalAppointment.Domain.Entities.Medical;
using MedicalAppointment.Model.MedicalModels;
using MedicalAppointment.Persistence.Base;
using MedicalAppointment.Persistence.Context;
using MedicalAppointment.Persistence.Interfaces.MedicalRepositories;
using MedicalAppointment.Persistence.Repositories.AppointmentsRepositories;
using MedicalAppointment.Persistence.Validations;
using MedicalAppointment.Persistence.Validations.Medical;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace MedicalAppointment.Persistence.Repositories.MedicalRepositories
{
    public class MedicalRecordsRepository : BaseRepository<MedicalRecords, int>, IMedicalRecordsRepository
    {
        private readonly AppointmentDbContext _context;
        private readonly ILogger<AppointmentsRepository> _logger;
        private readonly IConfiguration _configuration;

        public MedicalRecordsRepository(AppointmentDbContext context,
                                                          ILogger<AppointmentsRepository> logger,
                                                          IConfiguration configuration) : base(context)
        {
            _context = context;
            _logger = logger;
            _configuration = configuration;
        }

        public async Task<OperationResult> GetMedicalRecordsByPacientId(int pacientId)
        {
            OperationResult result = BaseValidations.ValidateId(pacientId);

            if (result.Success)
            {
                try
                {
                    result.Data = await (from record in _context.MedicalRecords
                                         where record.Id == pacientId
                                         select new GetRecordModel
                                         {
                                             RecordId = record.Id,
                                             Diagnosis = record.Diagnosis,
                                             Treatment = record.Treatment,
                                             DateOfVisit = record.DateOfVisit,
                                         }).FirstOrDefaultAsync();

                    result.Message = "El record ha sido encontrado";
                }
                catch (Exception ex)
                {
                    result.Success = false;
                    result.Message = this._configuration["ErrorMedicalRecordsRepository:GetMedicalRecordsByPacientId"];
                    _logger.LogError(result.Message, ex.ToString());
                }
            }

            return result;
        }

        public async override Task<OperationResult> GetEntityByIdAsync(int id)
        {
            OperationResult result = BaseValidations.ValidateId(id);

            if (result.Success)
            {
                try
                {
                    result.Data = await (from record in _context.MedicalRecords
                                         where record.Id == id
                                         select new GetRecordModel
                                         {
                                             RecordId = record.Id,
                                             Diagnosis = record.Diagnosis,
                                             Treatment = record.Treatment,
                                             DateOfVisit = record.DateOfVisit,
                                         }).FirstOrDefaultAsync();

                    result.Message = "El record ha sido encontrado";
                }
                catch (Exception ex)
                {
                    result.Success = false;
                    result.Message = this._configuration["ErrorMedicalRecordsRepository:GetEntityByIdAsync"];
                    _logger.LogError(result.Message, ex.ToString());
                }
            }

            return result;
        }

        public async override Task<OperationResult> SaveEntityAsync(MedicalRecords entity)
        {
            OperationResult result = MedicalRecordsValidations.ValidateMedicalRecord(entity);

            if (result.Success)
            {
                try
                {
                    result = await base.SaveEntityAsync(entity);
                }
                catch (Exception ex)
                {
                    result.Success = false;
                    result.Message = this._configuration["ErrorMedicalRecordsRepository:SaveEntityAsync"];
                    _logger.LogError(result.Message, ex.ToString());
                }
            }

            return result;
        }

        public async override Task<OperationResult> UpdateEntityAsync(MedicalRecords entity)
        {
            OperationResult result = MedicalRecordsValidations.ValidateMedicalRecord(entity, true);

            if (result.Success)
            {
                try
                {
                    result = await base.UpdateEntityAsync(entity);
                }
                catch (Exception ex)
                {
                    result.Success = false;
                    result.Message = this._configuration["ErrorMedicalRecordsRepository:UpdateEntityAsync"];
                    _logger.LogError(result.Message, ex.ToString());
                }
            }

            return result;
        }
    }
}
