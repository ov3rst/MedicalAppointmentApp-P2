using MedicalAppointment.Api.Controllers.Base;
using MedicalAppointment.Application.Contracts_Interfaces_.System;
using MedicalAppointment.Application.DTOs.SystemDTOs.Roles;
using Microsoft.AspNetCore.Mvc;

namespace MedicalAppointment.Api.Controllers.SystemControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : BaseController<SaveRolesDTO, UpdateRolesDTO, RemoveRolesDTO, int>
    {
        private readonly IRolesService _service;

        public RolesController(IRolesService service) : base(service)
        {
            _service = service;
        }
    }
}
