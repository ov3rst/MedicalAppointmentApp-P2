using MedicalAppointment.Application.Contracts_Interfaces_;
using MedicalAppointment.Web.Controllers.Base;
using MedicalAppointment.Web.Models.SystemModels;

namespace MedicalAppointment.Web.Controllers.System
{
    public class StatusController(IAppHttpClient client) : BaseController<StatusModel>(client, "Status")
    {
    }
}
