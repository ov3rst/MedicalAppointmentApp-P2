using MedicalAppointment.Api.Controllers.Base;
using MedicalAppointment.Application.Contracts_Interfaces_.System;
using MedicalAppointment.Application.DTOs.SystemDTOs.Status;
using Microsoft.AspNetCore.Mvc;

namespace MedicalAppointment.Api.Controllers.SystemControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusController : BaseController<SaveStatusDTO, UpdateStatusDTO, RemoveStatusDTO, int>
    {
        private readonly IStatusService _service;

        public StatusController(IStatusService service) : base(service)
        {
            _service = service;
        }
    }
}
