using MedicalAppointment.Api.Controllers.Base;
using MedicalAppointment.Domain.Entities.Insurance;
using MedicalAppointment.Persistence.Interfaces.InsuranceRepositories;
using Microsoft.AspNetCore.Mvc;

namespace MedicalAppointment.Api.Controllers.InsuranceControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InsuranceProviderController : BaseController<InsuranceProvider, int>
    {
        private readonly IInsuranceProviderRepository _repository;

        public InsuranceProviderController(IInsuranceProviderRepository repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
