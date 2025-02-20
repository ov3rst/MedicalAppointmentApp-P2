using MedicalAppointment.Domain.Base;
using MedicalAppointment.Domain.Entities.Medical;

namespace MedicalAppointment.Persistence.Validations.Medical
{
    public class SpecialtiesValidations
    {
        public static OperationResult ValidateSpecialties(Specialties entity, bool validateID = false)
        {
            OperationResult result = BaseValidations.ValidateEntity(entity);
            if (!result.Success) return result;

            if (validateID)
            {
                result = BaseValidations.ValidateId(entity.Id, "SpecialtyId");
                if (!result.Success) return result;
            }

            result = BaseValidations.ValidateString(entity.SpecialtyName);
            if (!result.Success) return result;

            return result;
        }
    }
}
