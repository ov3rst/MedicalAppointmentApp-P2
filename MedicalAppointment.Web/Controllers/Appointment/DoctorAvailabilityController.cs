using MedicalAppointment.Application.Contracts_Interfaces_;
using MedicalAppointment.Web.Controllers.Base;
using MedicalAppointment.Web.Models.AppointmentsModels;

namespace MedicalAppointment.Web.Controllers.Appointment
{
    public class DoctorAvailabilityController(IAppHttpClient client) : BaseController<DoctorAvailabilityModel>(client, "DoctorAvailability")
    {
        private readonly IAppHttpClient _client = client;
    }
}
