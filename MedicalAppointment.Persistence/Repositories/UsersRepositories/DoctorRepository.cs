using MedicalAppointment.Domain.Base;
using MedicalAppointment.Domain.Entities.Users;
using MedicalAppointment.Domain.SecurityInterfaces;
using MedicalAppointment.Model.UserModels;
using MedicalAppointment.Persistence.Base;
using MedicalAppointment.Persistence.Context;
using MedicalAppointment.Persistence.Interfaces.UsersRepositories;
using MedicalAppointment.Persistence.Validations;
using MedicalAppointment.Persistence.Validations.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Linq.Expressions;

namespace MedicalAppointment.Persistence.Repositories.UsersRepositories
{
    public class DoctorRepository : BaseRepository<Doctor, int>, IDoctorRepository
    {
        private readonly AppointmentDbContext _context;
        private readonly ILoggerService<DoctorRepository> _logger;
        private readonly IConfiguration _configuration;

        public DoctorRepository(AppointmentDbContext context,
                                               ILoggerService<DoctorRepository> logger,
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
                result.Data = await (from doctor in _context.Doctors
                                     join specialty in _context.Specialties on doctor.SpecialtyID equals specialty.Id
                                     join user in _context.Users on doctor.Id equals user.Id
                                     join availability in _context.AvailabilityModes on doctor.AvailabilityModeId equals availability.Id
                                     select new GetDoctorModel
                                     {
                                         DoctorId = doctor.Id,
                                         FirstName = user.FirstName,
                                         LastName = user.LastName,
                                         Email = user.Email,
                                         PhoneNumber = doctor.PhoneNumber,
                                         SpecialtyID = specialty.Id,
                                         SpecialtyName = specialty.SpecialtyName,
                                         LicenseNumber = doctor.LicenseNumber,
                                         YearsOfExperience = doctor.YearsOfExperience,
                                         Education = doctor.Education,
                                         Bio = doctor.Bio,
                                         ConsultationFee = doctor.ConsultationFee,
                                         ClinicAddress = doctor.ClinicAddress,
                                         AvailabilityModeId = doctor.AvailabilityModeId,
                                         AvailabilityModes = availability.AvailabilityMode,
                                         LicenseExpirationDate = doctor.LicenseExpirationDate
                                     }).ToListAsync();
                result.Message = "Entidades encontradas";
                _logger.LogInformation(result.Message);
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = this._configuration["ErrorDoctorRepository:GetAllAsync"];
                _logger.LogError(result.Message!, ex);
            }

            return result;
        }

        public async override Task<OperationResult> GetAllAsync(Expression<Func<Doctor, bool>> filter)
        {
            OperationResult result = new OperationResult();

            try
            {
                result.Data = await (from doctor in _context.Doctors.Where(filter)
                                     join specialty in _context.Specialties on doctor.SpecialtyID equals specialty.Id
                                     join user in _context.Users on doctor.Id equals user.Id
                                     join availability in _context.AvailabilityModes on doctor.AvailabilityModeId equals availability.Id
                                     select new GetDoctorModel
                                     {
                                         DoctorId = doctor.Id,
                                         FirstName = user.FirstName,
                                         LastName = user.LastName,
                                         Email = user.Email,
                                         PhoneNumber = doctor.PhoneNumber,
                                         SpecialtyID = specialty.Id,
                                         SpecialtyName = specialty.SpecialtyName,
                                         LicenseNumber = doctor.LicenseNumber,
                                         YearsOfExperience = doctor.YearsOfExperience,
                                         Education = doctor.Education,
                                         Bio = doctor.Bio,
                                         ConsultationFee = doctor.ConsultationFee,
                                         ClinicAddress = doctor.ClinicAddress,
                                         AvailabilityModeId = doctor.AvailabilityModeId,
                                         AvailabilityModes = availability.AvailabilityMode,
                                         LicenseExpirationDate = doctor.LicenseExpirationDate
                                     }).ToListAsync();

                result.Message = "Entidades encontradas";
                _logger.LogInformation(result.Message);
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = this._configuration["ErrorDoctorRepository:GetAllAsync"];
                _logger.LogError(result.Message!, ex);
            }

            return result;
        }

        public async Task<OperationResult> GetDoctorBySpecialty(int specialtyId)
        {
            OperationResult result = BaseValidations.ValidateId(specialtyId);

            try
            {
                result.Data = await (from doctor in _context.Doctors
                                     join specialty in _context.Specialties on doctor.SpecialtyID equals specialty.Id
                                     join user in _context.Users on doctor.Id equals user.Id
                                     join availability in _context.AvailabilityModes on doctor.AvailabilityModeId equals availability.Id
                                     where doctor.SpecialtyID == specialtyId
                                     select new GetDoctorModel
                                     {
                                         DoctorId = doctor.Id,
                                         FirstName = user.FirstName,
                                         LastName = user.LastName,
                                         Email = user.Email,
                                         PhoneNumber = doctor.PhoneNumber,
                                         SpecialtyID = specialty.Id,
                                         SpecialtyName = specialty.SpecialtyName,
                                         LicenseNumber = doctor.LicenseNumber,
                                         YearsOfExperience = doctor.YearsOfExperience,
                                         Education = doctor.Education,
                                         Bio = doctor.Bio,
                                         ConsultationFee = doctor.ConsultationFee,
                                         ClinicAddress = doctor.ClinicAddress,
                                         AvailabilityModeId = doctor.AvailabilityModeId,
                                         AvailabilityModes = availability.AvailabilityMode,
                                         LicenseExpirationDate = doctor.LicenseExpirationDate
                                     }).ToListAsync();

                result.Message = "Los doctores han sido encontrados";
                _logger.LogInformation(result.Message);
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = this._configuration["ErrorDoctorRepository:GetDoctorBySpecialty"];
                _logger.LogError(result.Message!, ex);
            }

            return result;
        }

        public async override Task<OperationResult> GetEntityByIdAsync(int id)
        {
            OperationResult result = BaseValidations.ValidateId(id);

            try
            {
                result.Data = await (from doctor in _context.Doctors
                                     join specialty in _context.Specialties on doctor.SpecialtyID equals specialty.Id
                                     join user in _context.Users on doctor.Id equals user.Id
                                     join availability in _context.AvailabilityModes on doctor.AvailabilityModeId equals availability.Id
                                     where doctor.Id == id
                                     select new GetDoctorModel
                                     {
                                         DoctorId = doctor.Id,
                                         FirstName = user.FirstName,
                                         LastName = user.LastName,
                                         Email = user.Email,
                                         PhoneNumber = doctor.PhoneNumber,
                                         SpecialtyID = specialty.Id,
                                         SpecialtyName = specialty.SpecialtyName,
                                         LicenseNumber = doctor.LicenseNumber,
                                         YearsOfExperience = doctor.YearsOfExperience,
                                         Education = doctor.Education,
                                         Bio = doctor.Bio,
                                         ConsultationFee = doctor.ConsultationFee,
                                         ClinicAddress = doctor.ClinicAddress,
                                         AvailabilityModeId = doctor.AvailabilityModeId,
                                         AvailabilityModes = availability.AvailabilityMode,
                                         LicenseExpirationDate = doctor.LicenseExpirationDate
                                     }).FirstOrDefaultAsync();
                result.Message = "Se ha encontrado la entidad";
                _logger.LogInformation(result.Message);
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = this._configuration["ErrorDoctorRepository:SaveEntityAsync"];
                _logger.LogError(result.Message!, ex);
            }

            return result;
        }

        public async override Task<OperationResult> SaveEntityAsync(Doctor entity)
        {
            OperationResult result = DoctorValidations.ValidateDoctor(entity);

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
                    result.Message = this._configuration["ErrorDoctorRepository:SaveEntityAsync"];
                    _logger.LogError(result.Message!, ex);
                }
            }

            return result;
        }

        public async override Task<OperationResult> UpdateEntityAsync(Doctor entity)
        {
            OperationResult result = DoctorValidations.ValidateDoctor(entity, true);

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
                    result.Message = this._configuration["ErrorDoctorRepository:UpdateEntityAsync"];
                    _logger.LogError(result.Message!, ex);
                }
            }

            return result;
        }

        public async override Task<OperationResult> RemoveEntityAsync(int id)
        {
            OperationResult result = BaseValidations.ValidateId(id);

            if (result.Success)
            {
                try
                {
                    result = await base.RemoveEntityAsync(id);
                    _logger.LogInformation(result.Message!);
                }
                catch (Exception ex)
                {
                    result.Success = false;
                    result.Message = this._configuration["ErrorDoctorRepository:RemoveEntityAsync"];
                    _logger.LogError(result.Message!, ex);
                }
            }

            return result;
        }
    }
}
