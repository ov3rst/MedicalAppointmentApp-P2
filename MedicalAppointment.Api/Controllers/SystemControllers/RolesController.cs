using MedicalAppointment.Api.Controllers.Base;
using MedicalAppointment.Domain.Entities.System;
using MedicalAppointment.Persistence.Interfaces.SystemRepositories;
using Microsoft.AspNetCore.Mvc;

namespace MedicalAppointment.Api.Controllers.SystemControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : BaseController<Roles, int>
    {
        private readonly IRolesRepository _rolesRepository;

        public RolesController(IRolesRepository rolesRepository) : base(rolesRepository)
        {
            _rolesRepository = rolesRepository;
        }
    }
}
