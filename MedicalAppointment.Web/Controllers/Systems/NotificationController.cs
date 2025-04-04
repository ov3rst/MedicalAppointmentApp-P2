using MedicalAppointment.Application.Contracts_Interfaces_;
using MedicalAppointment.Web.Controllers.Base;
using MedicalAppointment.Web.Models.SystemModels;

namespace MedicalAppointment.Web.Controllers.System
{
    public class NotificationController(IAppHttpClient client) : BaseController<NotificationModel>(client, "Notification")
    {
    }
}
