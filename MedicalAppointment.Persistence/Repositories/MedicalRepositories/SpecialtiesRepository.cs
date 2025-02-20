using MedicalAppointment.Domain.Base;
using MedicalAppointment.Domain.Entities.Medical;
using MedicalAppointment.Model.MedicalModels;
using MedicalAppointment.Persistence.Base;
using MedicalAppointment.Persistence.Context;
using MedicalAppointment.Persistence.Interfaces.MedicalRepositories;
using MedicalAppointment.Persistence.Repositories.AppointmentsRepositories;
using MedicalAppointment.Persistence.Validations.Medical;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace MedicalAppointment.Persistence.Repositories.MedicalRepositories
{
    public class SpecialtiesRepository : BaseRepository<Specialties, short>, ISpecialtiesRepository
    {

        private readonly AppointmentDbContext _context;
        private readonly ILogger<AppointmentsRepository> _logger;
        private readonly IConfiguration _configuration;

        public SpecialtiesRepository(AppointmentDbContext context,
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
            if (result.Success)
            {
                try
                {
                    result.Data = await (from specialty in _context.Specialties
                                         select new GetSpecialtiesModel
                                         {
                                             SpecialtyId = specialty.Id,
                                             SpecialtyName = specialty.SpecialtyName
                                         }).ToListAsync();


                    result.Message = "Las entidades han sido encontradas";
                }
                catch (Exception ex)
                {
                    result.Success = false;
                    result.Message = _configuration["ErrorSpecialtiesRepository:GetAllAsync"];
                    _logger.LogError(result.Message, ex.ToString());

                }
            }
            return result;
        }

        public async override Task<OperationResult> SaveEntityAsync(Specialties entity)
        {
            OperationResult result = SpecialtiesValidations.ValidateSpecialties(entity);

            if (result.Success)
            {
                try
                {
                    result = await base.SaveEntityAsync(entity);
                }
                catch (Exception ex)
                {
                    result.Success = false;
                    result.Message = this._configuration["ErrorSpecialtiesRepository:SaveEntityAsync"];
                    _logger.LogError(result.Message, ex.ToString());
                }
            }

            return result;
        }

        public async override Task<OperationResult> UpdateEntityAsync(Specialties entity)
        {
            OperationResult result = SpecialtiesValidations.ValidateSpecialties(entity, true);

            if (result.Success)
            {
                try
                {
                    result = await base.UpdateEntityAsync(entity);
                }
                catch (Exception ex)
                {
                    result.Success = false;
                    result.Message = this._configuration["ErrorSpecialtiesRepository:UpdateEntityAsync"];
                    _logger.LogError(result.Message, ex.ToString());
                }
            }

            return result;
        }

        public async override Task<OperationResult> RemoveEntityAsync(Specialties entity)
        {
            OperationResult result = SpecialtiesValidations.ValidateSpecialties(entity, true);

            if (result.Success)
            {
                try
                {
                    result = await base.RemoveEntityAsync(entity);
                }
                catch (Exception ex)
                {
                    result.Success = false;
                    result.Message = this._configuration["ErrorSpecialtiesRepository:RemoveEntityAsync"];
                    _logger.LogError(result.Message, ex.ToString());
                }
            }

            return result;
        }
    }
}
