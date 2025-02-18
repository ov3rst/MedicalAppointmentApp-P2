﻿using MedicalAppointment.Domain.Base;
using System.Linq.Expressions;

namespace MedicalAppointment.Domain.Repository
{
    /// <summary>
    /// Interfaz que deben heredar todos los repositorios.
    /// </summary>
    /// <typeparam name="TEntity">Entidad</typeparam>
    /// <typeparam name="TType">El tipo de dato del primary key para realizarla consulta.</typeparam>
    public interface IBaseRepository<TEntity, TType> where TEntity : class
    {
        Task<OperationResult> GetEntityByIdAsync(TType id);
        Task<OperationResult> UpdateEntityAsync(TEntity entity);
        Task<OperationResult> SaveEntityAsync(TEntity entity);
        Task<OperationResult> RemoveEntityAsync(TEntity entity);
        Task<OperationResult> GetAllAsync();
        Task<OperationResult> GetAllAsync(Expression<Func<TEntity, bool>> filter);
        Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> filter);
    }
}
