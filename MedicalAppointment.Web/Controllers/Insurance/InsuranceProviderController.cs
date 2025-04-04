using MedicalAppointment.Application.Contracts_Interfaces_;
using MedicalAppointment.Web.Controllers.Base;
using MedicalAppointment.Web.Models.InsuranceModels;

namespace MedicalAppointment.Web.Controllers.Insurance
{
    public class InsuranceProviderController(IAppHttpClient client) : BaseController<InsuranceProviderModel>(client, "InsuranceProvider")
    {
        private readonly IAppHttpClient _client = client;
    }
}
