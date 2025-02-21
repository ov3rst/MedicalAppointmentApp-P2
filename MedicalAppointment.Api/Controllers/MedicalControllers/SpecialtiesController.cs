using MedicalAppointment.Api.Controllers.Base;
using MedicalAppointment.Domain.Entities.Medical;
using MedicalAppointment.Persistence.Interfaces.MedicalRepositories;
using Microsoft.AspNetCore.Mvc;

namespace MedicalAppointment.Api.Controllers.MedicalControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpecialtiesController : BaseController<Specialties, short>
    {
        private readonly ISpecialtiesRepository _repository;

        public SpecialtiesController(ISpecialtiesRepository repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
