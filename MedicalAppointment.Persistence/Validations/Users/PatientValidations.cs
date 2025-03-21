using MedicalAppointment.Domain.Base;
using MedicalAppointment.Domain.Entities.Users;

namespace MedicalAppointment.Persistence.Validations.Users
{
    public class PatientValidations
    {
        public static OperationResult ValidatePatient(Patient entity, bool validateID = false)
        {
            OperationResult result = BaseValidations.ValidateEntity(entity);
            if (!result.Success) return result;

            if (validateID)
            {
                result = BaseValidations.ValidateId(entity.Id, "PatientId");
                if (!result.Success) return result;
            }

            result = BaseValidations.ValidateDate(BaseValidations.ToDateTime(entity.DateOfBirth));
            if (!result.Success) return result;

            result = BaseValidations.ValidateString(entity.Address, length: 255);
            if (!result.Success) return result;

            result = BaseValidations.ValidateString(entity.EmergencyContactName, length: 100);
            if (!result.Success) return result;

            result = BaseValidations.ValidateString(entity.Allergies);
            if (!result.Success) return result;

            result = BaseValidations.ValidatePhone(entity.PhoneNumber);
            if (!result.Success) return result;

            result = BaseValidations.ValidatePhone(entity.EmergencyContactPhone);
            if (!result.Success) return result;

            result = BaseValidations.ValidateId(entity.InsuranceProviderId, "InsuranceProviderId");
            if (!result.Success) return result;

            return result;
        }
    }
}
