using MedicalAppointment.Api.Controllers.Base;
using MedicalAppointment.Application.Contracts_Interfaces_.Medical;
using MedicalAppointment.Application.DTOs.MedicalDTOs.Specialties;
using Microsoft.AspNetCore.Mvc;

namespace MedicalAppointment.Api.Controllers.MedicalControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpecialtiesController : BaseController<SaveSpecialtiesDTO, UpdateSpecialtiesDTO, RemoveSpecialtiesDTO, short>
    {
        private readonly ISpecialtiesService _service;

        public SpecialtiesController(ISpecialtiesService service) : base(service)
        {
            _service = service;
        }
    }
}
