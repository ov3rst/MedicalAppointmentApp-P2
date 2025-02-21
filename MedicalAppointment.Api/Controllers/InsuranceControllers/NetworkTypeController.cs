using MedicalAppointment.Api.Controllers.Base;
using MedicalAppointment.Domain.Entities.Insurance;
using MedicalAppointment.Persistence.Interfaces.InsuranceRepositories;
using Microsoft.AspNetCore.Mvc;

namespace MedicalAppointment.Api.Controllers.InsuranceControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NetworkTypeController : BaseController<NetworkType, int>
    {
        private readonly INetworkTypeRepository _repository;

        public NetworkTypeController(INetworkTypeRepository repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
