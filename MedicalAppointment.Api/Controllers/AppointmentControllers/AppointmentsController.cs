using MedicalAppointment.Api.Controllers.Base;
using MedicalAppointment.Application.Contracts_Interfaces_.Appointments;
using MedicalAppointment.Application.DTOs.AppointmentsDTOs.Appointments;
using Microsoft.AspNetCore.Mvc;

namespace MedicalAppointment.Api.Controllers.AppointmentControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentsController : BaseController<SaveAppointmentDTO, UpdateAppointmentDTO, RemoveAppointmentDTO, int>
    {
        private readonly IAppointmentService _service;

        public AppointmentsController(IAppointmentService service) : base(service)
        {
            _service = service;
        }
    }
}
