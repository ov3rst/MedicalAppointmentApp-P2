using MedicalAppointment.Api.Controllers.Base;
using MedicalAppointment.Domain.Entities.Users;
using MedicalAppointment.Persistence.Interfaces.UsersRepositories;
using Microsoft.AspNetCore.Mvc;

namespace MedicalAppointment.Api.Controllers.UsersControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : BaseController<Patient, int>
    {
        private readonly IPatientRepository _repository;

        public PatientController(IPatientRepository repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
