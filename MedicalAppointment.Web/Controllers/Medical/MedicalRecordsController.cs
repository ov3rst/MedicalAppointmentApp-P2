using MedicalAppointment.Application.Contracts_Interfaces_;
using MedicalAppointment.Web.Controllers.Base;
using MedicalAppointment.Web.Models.MedicalModels;

namespace MedicalAppointment.Web.Controllers.Medical
{
    public class MedicalRecordsController(IAppHttpClient client) : BaseController<MedicalRecordsModel>(client, "MedicalRecords")
    {
        private readonly IAppHttpClient _client = client;
    }
}
