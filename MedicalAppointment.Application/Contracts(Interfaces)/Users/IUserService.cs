using MedicalAppointment.Application.Base;
using MedicalAppointment.Application.DTOs.UsersDTOs.Users;

namespace MedicalAppointment.Application.Contracts_Interfaces_.Users
{
    public interface IUserService : IBaseService<SaveUserDTO, UpdateUserDTO, RemoveUserDTO, int>
    {
    }
}
