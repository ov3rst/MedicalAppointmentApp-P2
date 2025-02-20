using MedicalAppointment.Domain.Base;
using MedicalAppointment.Domain.Entities.Users;
using MedicalAppointment.Model.UserModels;
using MedicalAppointment.Persistence.Base;
using MedicalAppointment.Persistence.Context;
using MedicalAppointment.Persistence.Interfaces.UsersRepositories;
using MedicalAppointment.Persistence.Repositories.AppointmentsRepositories;
using MedicalAppointment.Persistence.Validations;
using MedicalAppointment.Persistence.Validations.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Linq.Expressions;

namespace MedicalAppointment.Persistence.Repositories.UsersRepositories
{
    public class PatientRepository : BaseRepository<Patient, int>, IPatientRepository
    {
        private readonly AppointmentDbContext _context;
        private readonly ILogger<AppointmentsRepository> _logger;
        private readonly IConfiguration _configuration;

        public PatientRepository(AppointmentDbContext context,
                                               ILogger<AppointmentsRepository> logger,
                                               IConfiguration configuration) : base(context)
        {
            _context = context;
            _logger = logger;
            _configuration = configuration;
        }

        public async override Task<OperationResult> GetAllAsync()
        {
            OperationResult result = new OperationResult();

            try
            {
                result.Data = await (from patient in _context.Patients
                                     join user in _context.Users on patient.Id equals user.Id
                                     join insurance in _context.InsuranceProvider on patient.InsuranceProviderId equals insurance.Id
                                     select new GetPatientModel
                                     {
                                         PatientId = patient.Id,
                                         FirstName = user.FirstName,
                                         LastName = user.LastName,
                                         Email = user.Email,
                                         DateOfBirth = patient.DateOfBirth,
                                         Gender = patient.Gender,
                                         PhoneNumber = patient.PhoneNumber,
                                         Address = patient.Address,
                                         EmergencyContactName = patient.EmergencyContactName,
                                         EmergencyContactPhone = patient.EmergencyContactPhone,
                                         BloodType = patient.BloodType,
                                         Allergies = patient.Allergies,
                                         InsuranceProviderId = insurance.Id,
                                         InsuranceName = insurance.Name,
                                         CoverageDetails = insurance.CoverageDetails,
                                         MaxCoverageAmount = insurance.MaxCoverageAmount,
                                     }).ToListAsync();
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = this._configuration["ErrorPatientRepository:GetAllAsync"];
                _logger.LogError(result.Message, ex.ToString());
            }

            return result;
        }

        public async override Task<OperationResult> GetAllAsync(Expression<Func<Patient, bool>> filter)
        {
            OperationResult result = new OperationResult();

            try
            {
                result.Data = await (from patient in _context.Patients.Where(filter)
                                     join user in _context.Users on patient.Id equals user.Id
                                     join insurance in _context.InsuranceProvider on patient.InsuranceProviderId equals insurance.Id
                                     select new GetPatientModel
                                     {
                                         PatientId = patient.Id,
                                         FirstName = user.FirstName,
                                         LastName = user.LastName,
                                         Email = user.Email,
                                         DateOfBirth = patient.DateOfBirth,
                                         Gender = patient.Gender,
                                         PhoneNumber = patient.PhoneNumber,
                                         Address = patient.Address,
                                         EmergencyContactName = patient.EmergencyContactName,
                                         EmergencyContactPhone = patient.EmergencyContactPhone,
                                         BloodType = patient.BloodType,
                                         Allergies = patient.Allergies,
                                         InsuranceProviderId = insurance.Id,
                                         InsuranceName = insurance.Name,
                                         CoverageDetails = insurance.CoverageDetails,
                                         MaxCoverageAmount = insurance.MaxCoverageAmount,
                                     }).ToListAsync();
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = this._configuration["ErrorPatientRepository:GetAllAsync"];
                _logger.LogError(result.Message, ex.ToString());
            }

            return result;
        }

        public async override Task<OperationResult> GetEntityByIdAsync(int id)
        {
            OperationResult result = BaseValidations.ValidateId(id);

            try
            {
                result.Data = await (from patient in _context.Patients
                                     join user in _context.Users on patient.Id equals user.Id
                                     join insurance in _context.InsuranceProvider on patient.InsuranceProviderId equals insurance.Id
                                     where patient.Id == id
                                     select new GetPatientModel
                                     {
                                         PatientId = patient.Id,
                                         FirstName = user.FirstName,
                                         LastName = user.LastName,
                                         Email = user.Email,
                                         DateOfBirth = patient.DateOfBirth,
                                         Gender = patient.Gender,
                                         PhoneNumber = patient.PhoneNumber,
                                         Address = patient.Address,
                                         EmergencyContactName = patient.EmergencyContactName,
                                         EmergencyContactPhone = patient.EmergencyContactPhone,
                                         BloodType = patient.BloodType,
                                         Allergies = patient.Allergies,
                                         InsuranceProviderId = insurance.Id,
                                         InsuranceName = insurance.Name,
                                         CoverageDetails = insurance.CoverageDetails,
                                         MaxCoverageAmount = insurance.MaxCoverageAmount,
                                     }).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = this._configuration["ErrorPatientRepository:GetEntityByIdAsync"];
                _logger.LogError(result.Message, ex.ToString());
            }

            return result;
        }

        public async override Task<OperationResult> SaveEntityAsync(Patient entity)
        {
            OperationResult result = PatientValidations.ValidatePatient(entity);

            if (result.Success)
            {
                try
                {
                    result = await base.SaveEntityAsync(entity);
                }
                catch (Exception ex)
                {
                    result.Success = false;
                    result.Message = this._configuration["ErrorPatientRepository:SaveEntityAsync"];
                    _logger.LogError(result.Message, ex.ToString());
                }
            }

            return result;
        }

        public async override Task<OperationResult> UpdateEntityAsync(Patient entity)
        {
            OperationResult result = PatientValidations.ValidatePatient(entity);

            if (result.Success)
            {
                try
                {
                    result = await base.UpdateEntityAsync(entity);
                }
                catch (Exception ex)
                {
                    result.Success = false;
                    result.Message = this._configuration["ErrorPatientRepository:UpdateEntityAsync"];
                    _logger.LogError(result.Message, ex.ToString());
                }
            }

            return result;
        }

        public async override Task<OperationResult> RemoveEntityAsync(Patient entity)
        {
            OperationResult result = PatientValidations.ValidatePatient(entity);

            if (result.Success)
            {
                try
                {
                    result = await base.RemoveEntityAsync(entity);
                }
                catch (Exception ex)
                {
                    result.Success = false;
                    result.Message = this._configuration["ErrorPatientRepository:RemoveEntityAsync"];
                    _logger.LogError(result.Message, ex.ToString());
                }
            }

            return result;
        }
    }
}
