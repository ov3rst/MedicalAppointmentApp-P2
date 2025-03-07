using MedicalAppointment.Api.Controllers.Base;
using MedicalAppointment.Application.Contracts_Interfaces_.Medical;
using MedicalAppointment.Application.DTOs.MedicalDTOs.AvailabilityModes;
using Microsoft.AspNetCore.Mvc;

namespace MedicalAppointment.Api.Controllers.MedicalControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AvailabilityModesController : BaseController<SaveAvailabilityModesDTO, UpdateAvailabilityModesDTO, RemoveAvailabilityModesDTO, short>
    {
        private readonly IAvailabilityModesService _service;

        public AvailabilityModesController(IAvailabilityModesService service) : base(service)
        {
            _service = service;
        }
    }
}
