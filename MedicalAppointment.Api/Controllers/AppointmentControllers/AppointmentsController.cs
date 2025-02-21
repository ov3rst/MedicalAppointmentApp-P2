using MedicalAppointment.Api.Controllers.Base;
using MedicalAppointment.Domain.Entities.Appointments;
using MedicalAppointment.Persistence.Interfaces.AppointmentsRepositories;
using Microsoft.AspNetCore.Mvc;

namespace MedicalAppointment.Api.Controllers.AppointmentControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentsController : BaseController<Appointments, int>
    {
        private readonly IAppointmentsRepository _repository;

        public AppointmentsController(IAppointmentsRepository repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
