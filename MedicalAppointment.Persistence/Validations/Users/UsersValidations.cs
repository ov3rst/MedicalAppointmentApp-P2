using MedicalAppointment.Domain.Base;
using MedicalAppointment.Domain.Entities.Users;

namespace MedicalAppointment.Persistence.Validations.Users
{
    public class UsersValidations
    {
        public static OperationResult ValidateUser(User entity, bool validateID = false)
        {
            OperationResult result = BaseValidations.ValidateEntity(entity);
            if (!result.Success) return result;

            if (validateID)
            {
                result = BaseValidations.ValidateId(entity.Id, "InsuranceId");
                if (!result.Success) return result;
            }

            return result;
        }
    }
}
