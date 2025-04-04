using MedicalAppointment.Application.Contracts_Interfaces_;
using MedicalAppointment.Web.Controllers.Base;
using MedicalAppointment.Web.Models.MedicalModels;

namespace MedicalAppointment.Web.Controllers.Medical
{
    public class AvailabilityModesController(IAppHttpClient client) : BaseController<AvailabilityModesModel>(client, "AvailabilityModes")
    {
        private readonly IAppHttpClient _client = client;
    }
}
