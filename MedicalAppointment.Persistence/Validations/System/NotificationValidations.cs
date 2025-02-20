using MedicalAppointment.Domain.Base;
using MedicalAppointment.Domain.Entities.System;

namespace MedicalAppointment.Persistence.Validations.System
{
    public class NotificationValidations
    {
        public static OperationResult ValidateNotification(Notification entity, bool validateID = false)
        {
            OperationResult result = BaseValidations.ValidateEntity(entity);
            if (!result.Success) return result;

            result = BaseValidations.ValidateId(entity.UserId, "UserId");
            if (!result.Success) return result;

            result = BaseValidations.ValidateString(entity.Message);
            if (!result.Success) return result;

            return result;
        }
    }
}
