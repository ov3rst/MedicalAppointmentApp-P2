using MedicalAppointment.Api.Controllers.Base;
using MedicalAppointment.Domain.Entities.Users;
using MedicalAppointment.Persistence.Interfaces.UsersRepositories;
using Microsoft.AspNetCore.Mvc;

namespace MedicalAppointment.Api.Controllers.UsersControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : BaseController<Doctor, int>
    {
        private readonly IDoctorRepository _repository;

        public DoctorController(IDoctorRepository repository) : base(repository)
        {
            _repository = repository;
        }

        [HttpGet("specialtyId")]
        public async Task<IActionResult> GetDoctorBySpecialty([FromQuery] int specialtyId)
        {
            var result = await _repository.GetDoctorBySpecialty(specialtyId);
            return Ok(result);
        }
    }
}
