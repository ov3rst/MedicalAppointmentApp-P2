﻿using MedicalAppointment.Domain.Base;
using MedicalAppointment.Domain.Entities.System;
using MedicalAppointment.Model.SystemModels;
using MedicalAppointment.Persistence.Base;
using MedicalAppointment.Persistence.Context;
using MedicalAppointment.Persistence.Interfaces.SystemRepositories;
using MedicalAppointment.Persistence.Repositories.AppointmentsRepositories;
using MedicalAppointment.Persistence.Validations.System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace MedicalAppointment.Persistence.Repositories.SystemRepositories
{
    public class RolesRepository : BaseRepository<Roles, int>, IRolesRepository
    {
        private readonly AppointmentDbContext _context;
        private readonly ILogger<AppointmentsRepository> _logger;
        private readonly IConfiguration _configuration;

        public RolesRepository(AppointmentDbContext context,
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
                    result.Data = await (from role in _context.Roles
                                         select new GetRoleModel
                                         {
                                             RoleId = role.Id,
                                             RoleName = role.RoleName
                                         }).ToListAsync();

                    result.Message = "Las entidades han sido encontradas";
                }
                catch (Exception ex)
                {
                    result.Success = false;
                    result.Message = _configuration["ErrorInsuranceRepository:GetAllAsync"];
                    _logger.LogError(result.Message, ex.ToString());

                }
            }
            return result;
        }

        public async override Task<OperationResult> SaveEntityAsync(Roles entity)
        {
            OperationResult result = RolesValidations.ValidateRole(entity);

            if (result.Success)
            {
                try
                {
                    result = await base.SaveEntityAsync(entity);
                }
                catch (Exception ex)
                {
                    result.Success = false;
                    result.Message = this._configuration["ErrorRolesRepository:SaveEntityAsync"];
                    _logger.LogError(result.Message, ex.ToString());
                }
            }

            return result;
        }

        public async override Task<OperationResult> UpdateEntityAsync(Roles entity)
        {
            OperationResult result = RolesValidations.ValidateRole(entity, true);

            if (result.Success)
            {
                try
                {
                    result = await base.UpdateEntityAsync(entity);
                }
                catch (Exception ex)
                {
                    result.Success = false;
                    result.Message = this._configuration["ErrorRolesRepository:UpdateEntityAsync"];
                    _logger.LogError(result.Message, ex.ToString());
                }
            }

            return result;
        }
    }
}
