using MedicalAppointment.Domain.Base;
using MedicalAppointment.Domain.Entities.Medical;

namespace MedicalAppointment.Persistence.Validations.Medical
{
    public class AvailabilityModesValitations
    {
        public static OperationResult ValidateAvailabilityModes(AvailabilityModes entity, bool validateID = false)
        {
            OperationResult result = BaseValidations.ValidateEntity(entity);
            if (!result.Success) return result;

            if (validateID)
            {
                result = BaseValidations.ValidateId(entity.Id, "AvailabilityModes");
                if (!result.Success) return result;
            }

            result = BaseValidations.ValidateString(entity.AvailabilityMode!);
            if (!result.Success) return result;

            return result;
        }
    }
}
