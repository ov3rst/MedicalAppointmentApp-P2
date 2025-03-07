using MedicalAppointment.Api.Controllers.Base;
using MedicalAppointment.Application.Contracts_Interfaces_.Users;
using MedicalAppointment.Application.DTOs.UsersDTOs.Users;
using Microsoft.AspNetCore.Mvc;

namespace MedicalAppointment.Api.Controllers.UsersControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseController<SaveUserDTO, UpdateUserDTO, RemoveUserDTO, int>
    {
        private readonly IUserService _service;

        public UserController(IUserService service) : base(service)
        {
            _service = service;
        }
    }
}
