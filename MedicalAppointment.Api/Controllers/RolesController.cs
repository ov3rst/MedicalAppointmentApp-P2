using MedicalAppointment.Domain.Entities.System;
using MedicalAppointment.Persistence.Interfaces.SystemRepositories;
using Microsoft.AspNetCore.Mvc;

namespace MedicalAppointment.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly IRolesRepository _rolesRepository;

        public RolesController(IRolesRepository rolesRepository)
        {
            _rolesRepository = rolesRepository;
        }

        [HttpGet("GetRoles")]
        public async Task<IActionResult> Get()
        {
            var roles = await _rolesRepository.GetAllAsync();
            return Ok(roles);
        }

        [HttpGet("GetRoleById")]
        public async Task<IActionResult> Get(int id)
        {
            var role = await _rolesRepository.GetEntityByIdAsync(id);
            return Ok(role);
        }

        [HttpPost("SaveRole")]
        public async Task<IActionResult> Post([FromBody] Roles role)
        {
            var result = await _rolesRepository.SaveEntityAsync(role);
            return Ok(result);
        }

        [HttpPut("UpdateRole")]
        public async Task<IActionResult> Put([FromBody] Roles role)
        {
            var result = await _rolesRepository.UpdateEntityAsync(role);
            return Ok(result);
        }

        [HttpPut("RemoveRole")]
        public async Task<IActionResult> Delete([FromBody] Roles role)
        {
            var result = await _rolesRepository.RemoveEntityAsync(role);
            return Ok(result);
        }
    }
}
