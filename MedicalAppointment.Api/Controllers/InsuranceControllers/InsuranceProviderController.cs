using MedicalAppointment.Api.Controllers.Base;
using MedicalAppointment.Application.Contracts_Interfaces_.Insurance;
using MedicalAppointment.Application.DTOs.InsuranceDTOs.InsuranceProvider;
using Microsoft.AspNetCore.Mvc;

namespace MedicalAppointment.Api.Controllers.InsuranceControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InsuranceProviderController : BaseController<SaveInsuranceProviderDTO, UpdateInsuranceProviderDTO, RemoveInsuranceProviderDTO, int>
    {
        private readonly IInsuranceProviderService _service;

        public InsuranceProviderController(IInsuranceProviderService service) : base(service)
        {
            _service = service;
        }
    }
}
