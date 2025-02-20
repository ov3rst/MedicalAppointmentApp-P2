using MedicalAppointment.Domain.Base;
using MedicalAppointment.Domain.Entities.System;

namespace MedicalAppointment.Persistence.Validations.System
{
    public class RolesValidations
    {
        public static OperationResult ValidateRole(Roles entity, bool validateID = false)
        {
            OperationResult result = BaseValidations.ValidateEntity(entity);
            if (!result.Success) return result;

            if (validateID)
            {
                result = BaseValidations.ValidateId(entity.Id, "RoleId");
                if (!result.Success) return result;
            }

            result = BaseValidations.ValidateString(entity.RoleName);
            if (!result.Success) return result;

            return result;
        }
    }
}
