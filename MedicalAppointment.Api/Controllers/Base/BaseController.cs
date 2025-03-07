using MedicalAppointment.Application.Base;
using Microsoft.AspNetCore.Mvc;

namespace MedicalAppointment.Api.Controllers.Base
{
    public abstract class BaseController<TDtoSave, TDtoUpdate, TDtoRemove, TType> : ControllerBase where TDtoSave : class where TDtoUpdate : class where TDtoRemove : class
    {
        private readonly IBaseService<TDtoSave, TDtoUpdate, TDtoRemove, TType> _service;

        protected BaseController(IBaseService<TDtoSave, TDtoUpdate, TDtoRemove, TType> service)
        {
            _service = service;
        }

        [HttpGet("GetAllEntities")]
        public virtual async Task<IActionResult> GetAllAsync()
        {
            var result = await _service.GetAll();
            if (result is null || !result.Success) return NotFound(result);

            return Ok(result);
        }

        [HttpGet("GetEntityById")]
        public virtual async Task<IActionResult> GetByIdAsync(TType id)
        {
            var result = await _service.GetById(id);
            if (result is null || !result.Success) return NotFound(result);
            return Ok(result);
        }

        [HttpPost("SaveEntity")]
        public virtual async Task<IActionResult> SaveAsync(TDtoSave entity)
        {
            var result = await _service.Save(entity);
            if (result is null || !result.Success) return BadRequest(result);
            return Ok(result);
        }

        [HttpPut("UpdateEntity")]
        public virtual async Task<IActionResult> UpdateAsync(TDtoUpdate entity)
        {
            var result = await _service.Update(entity);
            if (result is null || !result.Success) return BadRequest(result);
            return Ok(result);
        }

        [HttpDelete("RemoveEntity")]
        public async Task<IActionResult> RemoveAsync(TType id)
        {
            var result = await _service.Remove(id);
            if (result is null || !result.Success) return BadRequest(result);
            return Ok(result);
        }
    }
}
