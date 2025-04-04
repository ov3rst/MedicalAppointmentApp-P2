using MedicalAppointment.Application.Contracts_Interfaces_;
using MedicalAppointment.Web.Controllers.Base;
using MedicalAppointment.Web.Models.UsersModels;

namespace MedicalAppointment.Web.Controllers.Users
{
    public class DoctorController(IAppHttpClient client) : BaseController<DoctorModel>(client, "Doctor")
    {
    }
}
