using MedicalAppointment.Domain.Base;
using MedicalAppointment.Domain.Repository;
using MedicalAppointment.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Reflection;

namespace MedicalAppointment.Persistence.Base
{
    public abstract class BaseRepository<TEntity, TType> : IBaseRepository<TEntity, TType> where TEntity : class
    {
        private readonly AppointmentDbContext _appointmentDbContext;

        private DbSet<TEntity> Entity { get; set; }

        protected BaseRepository(AppointmentDbContext appointmentDbContext)
        {
            _appointmentDbContext = appointmentDbContext;
            Entity = _appointmentDbContext.Set<TEntity>();
        }

        public virtual async Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> filter) => await Entity.AnyAsync(filter);

        public virtual async Task<OperationResult> GetAllAsync()
        {
            OperationResult result = new OperationResult();

            try
            {
                result.Data = await Entity.ToListAsync();
                result.Message = "Entidades encontradas";
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"Hubo el error ->{ex.Message}, al listar las entidades";
            }

            return result;
        }
        public virtual async Task<OperationResult> GetAllAsync(Expression<Func<TEntity, bool>> filter)
        {
            OperationResult result = new();
            try
            {
                result.Data = await this.Entity.Where(filter).ToListAsync();
                result.Message = "Entidades encontradas";
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"Ocurrió el error {ex.Message}, obteniendo los datos.";
            }

            return result;
        }

        public virtual async Task<OperationResult> GetEntityByIdAsync(TType id)
        {
            OperationResult result = new OperationResult();
            try
            {
                result.Data = await Entity.FindAsync(id);
                result.Message = "Se ha encotrado la entidad";
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"Ocurrio el error ->{ex.Message} al encontrar la entidad -> ";
            }
            return result;
        }

        public virtual async Task<OperationResult> SaveEntityAsync(TEntity entity)
        {
            OperationResult result = new();
            try
            {
                await this.Entity.AddAsync(entity);
                await _appointmentDbContext.SaveChangesAsync();
                result.Message = "Entidad guardada correctamente";
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
                this.Entity.Update(entity);
                var entry = _appointmentDbContext.Entry(entity);
                if (entry.Metadata.FindProperty("CreatedAt") != null)
                {
                    entry.Property("CreatedAt").IsModified = false;
                }
                await _appointmentDbContext.SaveChangesAsync();
                result.Message = "Entidad actualizada correctamente";
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"Ocurrió el error {ex.Message} obteniendo los datos.";
            }

            return result;
        }

        public virtual async Task<OperationResult> RemoveEntityAsync(TType id)
        {
            OperationResult result = new();

            try
            {
                var entity = await Entity.FindAsync(id);
                if (entity is null)
                {
                    result.Success = false;
                    result.Message = "Entidad no encontrada";
                    return result;
                }

                Type type = entity!.GetType();
                PropertyInfo activeInfo = type.GetProperty("IsActive")!;

                if (activeInfo is null)
                {
                    result.Success = false;
                    result.Message = "Esta entidad no se puede remover";
                    return result;
                }

                PropertyInfo updateInfo = type.GetProperty("UpdatedAt")!;
                activeInfo.SetValue(entity, false);
                updateInfo.SetValue(entity, DateTime.UtcNow);

                Entity.Update(entity);
                await _appointmentDbContext.SaveChangesAsync();
                result.Message = "Entidad removida correctamente";
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"Ocurrio el error {ex.Message} eliminando la entidad";
            }
            return result;
        }
    }
}
