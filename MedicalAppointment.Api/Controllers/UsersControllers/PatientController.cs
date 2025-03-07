using MedicalAppointment.Api.Controllers.Base;
using MedicalAppointment.Application.Contracts_Interfaces_.Users;
using MedicalAppointment.Application.DTOs.UsersDTOs.Patients;
using Microsoft.AspNetCore.Mvc;

namespace MedicalAppointment.Api.Controllers.UsersControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : BaseController<SavePatientDTO, UpdatePatientDTO, RemovePatientDTO, int>
    {
        private readonly IPatientService _service;

        public PatientController(IPatientService service) : base(service)
        {
            _service = service;
        }
    }
}
