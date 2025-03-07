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

namespace MedicalAppointment.Persistence.Repositories.UsersRepositories
{
    public class UserRepository : BaseRepository<User, int>, IUserRepository
    {
        private readonly AppointmentDbContext _context;
        private readonly ILogger<AppointmentsRepository> _logger;
        private readonly IConfiguration _configuration;

        public UserRepository(AppointmentDbContext context,
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
                result.Data = await (from user in _context.Users
                                     join role in _context.Roles on user.RoleID equals role.Id
                                     select new GetUserModel
                                     {
                                         UserId = user.Id,
                                         FirstName = user.FirstName,
                                         LastName = user.LastName,
                                         Email = user.Email,
                                         RoleID = role.Id,
                                         RoleName = role.RoleName
                                     }).ToListAsync();

                result.Message = "Usuarios encontrados";
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = this._configuration["ErrorUserRepository:GetAllAsync"];
                _logger.LogError(result.Message, ex.ToString());
            }

            return result;
        }

        public async override Task<OperationResult> GetEntityByIdAsync(int id)
        {
            OperationResult result = BaseValidations.ValidateId(id);

            try
            {
                result.Data = await (from user in _context.Users
                                     join role in _context.Roles on user.RoleID equals role.Id
                                     where user.Id == id
                                     select new GetUserModel
                                     {
                                         UserId = user.Id,
                                         FirstName = user.FirstName,
                                         LastName = user.LastName,
                                         Email = user.Email,
                                         RoleID = role.Id,
                                         RoleName = role.RoleName
                                     }).FirstOrDefaultAsync();

                if (result.Data is null) throw new Exception();

                result.Message = "Usuario encontrado";
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = this._configuration["ErrorUserRepository:GetEntityByIdAsync"];
                _logger.LogError(result.Message, ex.ToString());
            }

            return result;
        }

        public async override Task<OperationResult> SaveEntityAsync(User entity)
        {
            OperationResult result = UsersValidations.ValidateUser(entity);

            if (result.Success)
            {
                try
                {
                    result = await base.SaveEntityAsync(entity);
                }
                catch (Exception ex)
                {
                    result.Success = false;
                    result.Message = this._configuration["ErrorUserRepository:SaveEntityAsync"];
                    _logger.LogError(result.Message, ex.ToString());
                }
            }

            return result;
        }

        public async override Task<OperationResult> UpdateEntityAsync(User entity)
        {
            OperationResult result = UsersValidations.ValidateUser(entity);

            if (result.Success)
            {
                try
                {
                    result = await base.UpdateEntityAsync(entity);
                }
                catch (Exception ex)
                {
                    result.Success = false;
                    result.Message = this._configuration["ErrorUserRepository:UpdateEntityAsync"];
                    _logger.LogError(result.Message, ex.ToString());
                }
            }

            return result;
        }

        // Este metodo hay que hacerle un arreglo, si se borra un usuario hay que ver si es doctor o paciente, y desactivar esos datos tambien
        public async override Task<OperationResult> RemoveEntityAsync(int id)
        {
            OperationResult result = BaseValidations.ValidateId(id);

            if (result.Success)
            {
                try
                {
                    result = await base.RemoveEntityAsync(id);
                }
                catch (Exception ex)
                {
                    result.Success = false;
                    result.Message = this._configuration["ErrorUserRepository:RemoveEntityAsync "];
                    _logger.LogError(result.Message, ex.ToString());
                }
            }

            return result;
        }
    }
}
