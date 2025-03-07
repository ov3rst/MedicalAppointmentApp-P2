using MedicalAppointment.Api.Controllers.Base;
using MedicalAppointment.Application.Contracts_Interfaces_.Insurance;
using MedicalAppointment.Application.DTOs.InsuranceDTOs.NetwrokTypes;
using Microsoft.AspNetCore.Mvc;

namespace MedicalAppointment.Api.Controllers.InsuranceControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NetworkTypeController : BaseController<SaveNetworkTypeDTO, UpdateNetworkTypeDTO, RemoveNetworkTypeDTO, int>
    {
        private readonly INetworkTypeService _service;

        public NetworkTypeController(INetworkTypeService service) : base(service)
        {
            _service = service;
        }
    }
}
