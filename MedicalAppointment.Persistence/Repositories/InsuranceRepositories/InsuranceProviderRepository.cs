using MedicalAppointment.Domain.Base;
using MedicalAppointment.Domain.Entities.Insurance;
using MedicalAppointment.Domain.SecurityInterfaces;
using MedicalAppointment.Model.InsuranceModels;
using MedicalAppointment.Persistence.Base;
using MedicalAppointment.Persistence.Context;
using MedicalAppointment.Persistence.Interfaces.InsuranceRepositories;
using MedicalAppointment.Persistence.Validations;
using MedicalAppointment.Persistence.Validations.Insurance;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace MedicalAppointment.Persistence.Repositories.InsuranceRepositories
{
    public class InsuranceProviderRepository : BaseRepository<InsuranceProvider, int>, IInsuranceProviderRepository
    {
        private readonly AppointmentDbContext _context;
        private readonly ILoggerService<InsuranceProviderRepository> _logger;
        private readonly IConfiguration _configuration;

        public InsuranceProviderRepository(AppointmentDbContext context,
                                                          ILoggerService<InsuranceProviderRepository> logger,
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
                    result.Data = await (from insurance in _context.InsuranceProvider
                                         join network in _context.NetworkType on insurance.NetworkTypeId equals network.Id
                                         where insurance.IsActive
                                         select new GetInsuranceByIdModel
                                         {
                                             InsuranceId = insurance.Id,
                                             InsuranceName = insurance.Name,
                                             ContactNumber = insurance.ContactNumber,
                                             Email = insurance.Email,
                                             Website = insurance.Website,
                                             Address = insurance.Address,
                                             City = insurance.City,
                                             State = insurance.State,
                                             Country = insurance.Country,
                                             ZipCode = insurance.ZipCode,
                                             CoverageDetails = insurance.CoverageDetails,
                                             LogoUrl = insurance.LogoUrl,
                                             IsPreferred = insurance.IsPreferred,
                                             NetworkTypeId = network.Id,
                                             NetworkName = network.Name,
                                             NetworkDescription = network.Description,

                                         }).ToListAsync();

                    result.Message = "Las entidades han sido encontradas";
                    _logger.LogInformation(result.Message);
                }
                catch (Exception ex)
                {
                    result.Success = false;
                    result.Message = _configuration["ErrorInsuranceRepository:GetAllAsync"];
                    _logger.LogError(result.Message!, ex);

                }
            }
            return result;
        }

        public override async Task<OperationResult> GetEntityByIdAsync(int id)
        {
            OperationResult result = BaseValidations.ValidateId(id);
            if (result.Success)
            {
                try
                {
                    result.Data = await (from insurance in _context.InsuranceProvider
                                         join network in _context.NetworkType on insurance.NetworkTypeId equals network.Id
                                         where insurance.Id == id
                                         select new GetInsuranceByIdModel
                                         {
                                             InsuranceId = insurance.Id,
                                             InsuranceName = insurance.Name,
                                             ContactNumber = insurance.ContactNumber,
                                             Email = insurance.Email,
                                             Website = insurance.Website,
                                             Address = insurance.Address,
                                             City = insurance.City,
                                             State = insurance.State,
                                             Country = insurance.Country,
                                             ZipCode = insurance.ZipCode,
                                             CoverageDetails = insurance.CoverageDetails,
                                             LogoUrl = insurance.LogoUrl,
                                             IsPreferred = insurance.IsPreferred,
                                             NetworkTypeId = network.Id,
                                             NetworkName = network.Name,
                                             NetworkDescription = network.Description,

                                         }).FirstOrDefaultAsync();

                    result.Message = "La entidad ha sido encontrada";
                    _logger.LogInformation(result.Message);
                }
                catch (Exception ex)
                {
                    result.Success = false;
                    result.Message = _configuration["ErrorInsuranceRepository:GetEntityByIdAsync"];
                    _logger.LogError(result.Message!, ex);

                }
            }

            return result;
        }

        public async override Task<OperationResult> SaveEntityAsync(InsuranceProvider entity)
        {
            OperationResult result = InsuranceValitation.ValidateInsurance(entity);

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
                    result.Message = this._configuration["ErrorInsuranceRepository:SaveEntityAsync"];
                    _logger.LogError(result.Message!, ex);
                }
            }

            return result;
        }

        public async override Task<OperationResult> UpdateEntityAsync(InsuranceProvider entity)
        {
            OperationResult result = InsuranceValitation.ValidateInsurance(entity, true);

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
                    result.Message = this._configuration["ErrorInsuranceRepository:UpdateEntityAsync"];
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
                    result.Message = this._configuration["ErrorInsuranceRepository:RemoveEntityAsync"];
                    _logger.LogError(result.Message!, ex);
                }
            }

            return result;
        }
    }
}
