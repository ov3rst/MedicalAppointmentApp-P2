using MedicalAppointment.Api.Controllers.Base;
using MedicalAppointment.Domain.Entities.Users;
using MedicalAppointment.Persistence.Interfaces.UsersRepositories;
using Microsoft.AspNetCore.Mvc;

namespace MedicalAppointment.Api.Controllers.UsersControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseController<User, int>
    {
        private readonly IUserRepository _repository;

        public UserController(IUserRepository repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
