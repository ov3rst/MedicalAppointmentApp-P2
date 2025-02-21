using MedicalAppointment.Api.Controllers.Base;
using MedicalAppointment.Domain.Entities.Appointments;
using MedicalAppointment.Persistence.Interfaces.AppointmentsRepositories;
using Microsoft.AspNetCore.Mvc;

namespace MedicalAppointment.Api.Controllers.AppointmentControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorAvailabilityController : BaseController<DoctorAvailability, int>
    {
        private readonly IDoctorAvailabilityRepository _repository;

        public DoctorAvailabilityController(IDoctorAvailabilityRepository repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
