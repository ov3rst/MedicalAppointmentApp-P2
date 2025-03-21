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
    public class AvailabilityModesRepository : BaseRepository<AvailabilityModes, short>, IAvailabilityModesRepository
    {
        private readonly AppointmentDbContext _context;
        private readonly ILoggerService<AvailabilityModesRepository> _logger;
        private readonly IConfiguration _configuration;

        public AvailabilityModesRepository(AppointmentDbContext context,
                                                          ILoggerService<AvailabilityModesRepository> logger,
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
                result.Data = await (from mode in _context.AvailabilityModes
                                     select new GetAvailabilitiesModesModel
                                     {
                                         AvailabilityId = mode.Id,
                                         AvailabilityMode = mode.AvailabilityMode
                                     }).ToListAsync();

                result.Message = "Las entidades han sido encontradas";
                _logger.LogInformation(result.Message);
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = _configuration["ErrorAvailabilityModesRepository:GetAllAsync"];
                _logger.LogError(result.Message!, ex);

            }

            return result;
        }

        public async override Task<OperationResult> SaveEntityAsync(AvailabilityModes entity)
        {
            OperationResult result = AvailabilityModesValitations.ValidateAvailabilityModes(entity);

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
                    result.Message = this._configuration["ErrorAvailabilityModesRepository:SaveEntityAsync"];
                    _logger.LogError(result.Message!, ex);
                }
            }

            return result;
        }

        public async override Task<OperationResult> UpdateEntityAsync(AvailabilityModes entity)
        {
            OperationResult result = AvailabilityModesValitations.ValidateAvailabilityModes(entity, true);

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
                    result.Message = this._configuration["ErrorAvailabilityModesRepository:UpdateEntityAsync"];
                    _logger.LogError(result.Message!, ex);
                }
            }

            return result;
        }

        public async override Task<OperationResult> RemoveEntityAsync(short id)
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
                    result.Message = this._configuration["ErrorAvailabilityModesRepository:RemoveEntityAsync"];
                    _logger.LogError(result.Message!, ex);
                }
            }

            return result;
        }
    }
}
