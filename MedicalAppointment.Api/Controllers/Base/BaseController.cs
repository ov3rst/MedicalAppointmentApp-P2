using MedicalAppointment.Domain.Repository;
using Microsoft.AspNetCore.Mvc;

namespace MedicalAppointment.Api.Controllers.Base
{
    public abstract class BaseController<TEntity, TType> : ControllerBase, IBaseController<TEntity, TType> where TEntity : class
    {
        private readonly IBaseRepository<TEntity, TType> _repository;

        protected BaseController(IBaseRepository<TEntity, TType> repository)
        {
            _repository = repository;
        }

        [HttpGet("GetAllEntities")]
        public virtual async Task<IActionResult> GetAllAsync()
        {
            var result = await _repository.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("GetEntityById")]
        public virtual async Task<IActionResult> GetByIdAsync(TType id)
        {
            var result = await _repository.GetEntityByIdAsync(id);
            return Ok(result);
        }

        [HttpPost("SaveEntity")]
        public virtual async Task<IActionResult> SaveAsync(TEntity entity)
        {
            var result = await _repository.SaveEntityAsync(entity);
            return Ok(result);
        }

        [HttpPut("UpdateEntity")]
        public virtual async Task<IActionResult> UpdateAsync(TEntity entity)
        {
            var result = await _repository.UpdateEntityAsync(entity);
            return Ok(result);
        }

        [HttpPut("RemoveEntity")]
        public async Task<IActionResult> RemoveAsync(TType id)
        {
            throw new NotImplementedException();
        }
    }
}
