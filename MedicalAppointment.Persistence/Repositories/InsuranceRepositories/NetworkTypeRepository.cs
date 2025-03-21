using MedicalAppointment.Domain.Base;
using MedicalAppointment.Domain.Entities.Insurance;
using MedicalAppointment.Domain.SecurityInterfaces;
using MedicalAppointment.Model.InsuranceModels;
using MedicalAppointment.Persistence.Base;
using MedicalAppointment.Persistence.Context;
using MedicalAppointment.Persistence.Interfaces.InsuranceRepositories;
using MedicalAppointment.Persistence.Validations.Insurance;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace MedicalAppointment.Persistence.Repositories.InsuranceRepositories
{
    public class NetworkTypeRepository : BaseRepository<NetworkType, int>, INetworkTypeRepository
    {
        private readonly AppointmentDbContext _context;
        private readonly ILoggerService<NetworkTypeRepository> _logger;
        private readonly IConfiguration _configuration;

        public NetworkTypeRepository(AppointmentDbContext context,
                                                          ILoggerService<NetworkTypeRepository> logger,
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
                result.Data = await (from net in _context.NetworkType
                                     select new GetNetworkTypeModel
                                     {
                                         NetworkId = net.Id,
                                         Name = net.Name,
                                         Description = net.Description,
                                     }).FirstOrDefaultAsync();

                result.Message = "Las entidades han sido encontradas";
                _logger.LogInformation(result.Message);
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = _configuration["ErrorNetworkTypeRepository:GetAllAsync"];
                _logger.LogError(result.Message!, ex);

            }

            return result;
        }

        public async override Task<OperationResult> SaveEntityAsync(NetworkType entity)
        {
            OperationResult result = NetworkValidations.ValidateNetwork(entity);

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
                    result.Message = this._configuration["ErrorNetworkTypeRepository:SaveEntityAsync"];
                    _logger.LogError(result.Message!, ex);
                }
            }

            return result;
        }

        public async override Task<OperationResult> UpdateEntityAsync(NetworkType entity)
        {
            OperationResult result = NetworkValidations.ValidateNetwork(entity, true);

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
                    result.Message = this._configuration["ErrorNetworkTypeRepository:UpdateEntityAsync"];
                    _logger.LogError(result.Message!, ex);
                }
            }

            return result;
        }
    }
}
