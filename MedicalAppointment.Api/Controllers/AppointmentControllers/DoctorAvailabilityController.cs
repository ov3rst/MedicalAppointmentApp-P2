using MedicalAppointment.Api.Controllers.Base;
using MedicalAppointment.Application.Contracts_Interfaces_.Appointments;
using MedicalAppointment.Application.DTOs.AppointmentsDTOs.DoctorAvailability;
using Microsoft.AspNetCore.Mvc;

namespace MedicalAppointment.Api.Controllers.AppointmentControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorAvailabilityController : BaseController<SaveDoctorAvailabilityDTO, UpdateDoctorAvailabilityDTO, RemoveDoctorAvailabilityDTO, int>
    {
        private readonly IDoctorAvailabilityService _service;

        public DoctorAvailabilityController(IDoctorAvailabilityService service) : base(service)
        {
            _service = service;
        }
    }
}
