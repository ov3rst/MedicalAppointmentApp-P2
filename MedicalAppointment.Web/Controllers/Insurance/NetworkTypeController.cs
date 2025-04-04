using MedicalAppointment.Application.Contracts_Interfaces_;
using MedicalAppointment.Web.Controllers.Base;
using MedicalAppointment.Web.Models.InsuranceModels;

namespace MedicalAppointment.Web.Controllers.Insurance
{
    public class NetworkTypeController(IAppHttpClient client) : BaseController<NetworkTypeModel>(client, "NetworkType")
    {
        private readonly IAppHttpClient _client = client;
    }
}
