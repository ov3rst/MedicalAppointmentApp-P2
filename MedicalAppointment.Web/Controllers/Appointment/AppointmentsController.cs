using MedicalAppointment.Application.Contracts_Interfaces_;
using MedicalAppointment.Model.AppointmentsModels;
using MedicalAppointment.Web.Controllers.Base;

namespace MedicalAppointment.Web.Controllers.Appointment
{
    public class AppointmentsController(IAppHttpClient client) : BaseController<AppointmentModel>(client, "Appointments")
    {
        private readonly IAppHttpClient _client = client;
    }
}
