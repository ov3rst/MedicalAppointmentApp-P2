using MedicalAppointment.Application.Contracts_Interfaces_;
using MedicalAppointment.Web.Controllers.Base;
using MedicalAppointment.Web.Models.MedicalModels;

namespace MedicalAppointment.Web.Controllers.Medical
{
    public class SpecialtiesController(IAppHttpClient client) : BaseController<SpecialtiesModel>(client, "Specialties")
    {
        private readonly IAppHttpClient _client = client;
    }
}
