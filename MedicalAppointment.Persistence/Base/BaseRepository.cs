using MedicalAppointment.Domain.Base;
using MedicalAppointment.Domain.Repository;
using MedicalAppointment.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace MedicalAppointment.Persistence.Base
{
    public abstract class BaseRepository<TEntity, TType> : IBaseRepository<TEntity, TType> where TEntity : class
    {
        private readonly AppointmentDbContext _appointmentDbContext;
        private DbSet<TEntity> entity;

        protected BaseRepository(AppointmentDbContext appointmentDbContext)
        {
            _appointmentDbContext = appointmentDbContext;
            entity = _appointmentDbContext.Set<TEntity>();
        }

        public virtual async Task<OperationResult> ExistsAsync(Expression<Func<TEntity, bool>> filter)
        {
            OperationResult result = new();
            try
            {
                result.Data = await this.entity.AnyAsync(filter);
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"Ocurrió el error {ex.Message} verificando si existe el registro.";
            }

            return result;
        }

        public virtual async Task<OperationResult> GetAllAsync()
        {
            OperationResult result = new();
            try
            {
                result.Data = await this.entity.ToListAsync();
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"Ocurrió el error {ex.Message} obteniendo los datos.";
            }

            return result;
        }

        public virtual async Task<OperationResult> GetAllAsync(Expression<Func<TEntity, bool>> filter)
        {
            OperationResult result = new();
            try
            {
                result.Data = await this.entity.Where(filter).ToListAsync();
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"Ocurrió el error {ex.Message} obteniendo los datos.";
            }

            return result;
        }

        public virtual async Task<OperationResult> GetEntityByIdAsync(TType id)
        {
            OperationResult result = new();
            try
            {
                result.Data = await this.entity.FindAsync(id);
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"Ocurrió el error {ex.Message} obteniendo los datos.";
            }

            return result;
        }

        public virtual async Task<OperationResult> SaveEntityAsync(TEntity entity)
        {
            OperationResult result = new();
            try
            {
                await this.entity.AddAsync(entity);
                await _appointmentDbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"Ocurrió el error {ex.Message} obteniendo los datos.";
            }

            return result;
        }

        public virtual async Task<OperationResult> UpdateEntityAsync(TEntity entity)
        {
            OperationResult result = new();
            try
            {
                this.entity.Update(entity);
                await _appointmentDbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"Ocurrió el error {ex.Message} obteniendo los datos.";
            }

            return result;
        }

        public virtual async Task<OperationResult> DeleteEntityAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
