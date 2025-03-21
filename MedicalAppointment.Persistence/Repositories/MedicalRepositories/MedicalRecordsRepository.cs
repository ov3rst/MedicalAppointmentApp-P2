using MedicalAppointment.Domain.Base;
using MedicalAppointment.Domain.Entities.Medical;
using MedicalAppointment.Domain.SecurityInterfaces;
using MedicalAppointment.Model.MedicalModels;
using MedicalAppointment.Persistence.Base;
using MedicalAppointment.Persistence.Context;
using MedicalAppointment.Persistence.Interfaces.MedicalRepositories;
using MedicalAppointment.Persistence.Validations;
using MedicalAppointment.Persistence.Validations.Medical;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace MedicalAppointment.Persistence.Repositories.MedicalRepositories
{
    public class MedicalRecordsRepository : BaseRepository<MedicalRecords, int>, IMedicalRecordsRepository
    {
        private readonly AppointmentDbContext _context;
        private readonly ILoggerService<MedicalRecordsRepository> _logger;
        private readonly IConfiguration _configuration;

        public MedicalRecordsRepository(AppointmentDbContext context,
                                                          ILoggerService<MedicalRecordsRepository> logger,
                                                          IConfiguration configuration) : base(context)
        {
            _context = context;
            _logger = logger;
            _configuration = configuration;
        }

        public async Task<OperationResult> GetMedicalRecordsByPacientId(int patientId)
        {
            OperationResult result = BaseValidations.ValidateId(patientId);

            if (result.Success)
            {
                try
                {
                    result.Data = await (from record in _context.MedicalRecords
                                         where record.Id == patientId
                                         select new GetRecordModel
                                         {
                                             RecordId = record.Id,
                                             Diagnosis = record.Diagnosis,
                                             Treatment = record.Treatment,
                                             DateOfVisit = record.DateOfVisit,
                                         }).FirstOrDefaultAsync();

                    result.Message = "El record ha sido encontrado";
                    _logger.LogInformation(result.Message);
                }
                catch (Exception ex)
                {
                    result.Success = false;
                    result.Message = this._configuration["ErrorMedicalRecordsRepository:GetMedicalRecordsByPacientId"];
                    _logger.LogError(result.Message!, ex);
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
                    _logger.LogInformation(result.Message);
                }
                catch (Exception ex)
                {
                    result.Success = false;
                    result.Message = this._configuration["ErrorMedicalRecordsRepository:GetEntityByIdAsync"];
                    _logger.LogError(result.Message!, ex);
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
                    _logger.LogInformation(result.Message!);
                }
                catch (Exception ex)
                {
                    result.Success = false;
                    result.Message = this._configuration["ErrorMedicalRecordsRepository:SaveEntityAsync"];
                    _logger.LogError(result.Message!, ex);
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
                    _logger.LogInformation(result.Message!);
                }
                catch (Exception ex)
                {
                    result.Success = false;
                    result.Message = this._configuration["ErrorMedicalRecordsRepository:UpdateEntityAsync"];
                    _logger.LogError(result.Message!, ex);
                }
            }

            return result;
        }
    }
}
