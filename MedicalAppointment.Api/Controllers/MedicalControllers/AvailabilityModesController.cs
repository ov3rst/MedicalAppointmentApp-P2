using MedicalAppointment.Api.Controllers.Base;
using MedicalAppointment.Domain.Entities.Medical;
using MedicalAppointment.Persistence.Interfaces.MedicalRepositories;
using Microsoft.AspNetCore.Mvc;

namespace MedicalAppointment.Api.Controllers.MedicalControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AvailabilityModesController : BaseController<AvailabilityModes, short>
    {
        private readonly IAvailabilityModesRepository _repository;

        public AvailabilityModesController(IAvailabilityModesRepository repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
