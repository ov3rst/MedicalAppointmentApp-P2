using MedicalAppointment.Api.Controllers.Base;
using MedicalAppointment.Application.Contracts_Interfaces_.Users;
using MedicalAppointment.Application.DTOs.UsersDTOs.Doctors;
using Microsoft.AspNetCore.Mvc;

namespace MedicalAppointment.Api.Controllers.UsersControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : BaseController<SaveDoctorDTO, UpdateDoctorDTO, RemoveDoctorDTO, int>
    {
        private readonly IDoctorService _service;

        public DoctorController(IDoctorService service) : base(service)
        {
            _service = service;
        }

        [HttpGet("specialtyId")]
        public async Task<IActionResult> GetDoctorBySpecialty([FromQuery] int specialtyId)
        {
            var result = await _service.GetDoctorBySpecialty(specialtyId);
            return Ok(result);
        }
    }
}
