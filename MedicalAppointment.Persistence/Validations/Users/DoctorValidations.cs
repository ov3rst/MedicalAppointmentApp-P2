using MedicalAppointment.Domain.Base;
using MedicalAppointment.Domain.Entities.Users;

namespace MedicalAppointment.Persistence.Validations.Users
{
    public class DoctorValidations
    {
        public static OperationResult ValidateDoctor(Doctor entity, bool validateID = false)
        {
            OperationResult result = BaseValidations.ValidateEntity(entity);
            if (!result.Success) return result;

            if (validateID)
            {
                result = BaseValidations.ValidateId(entity.Id, "DoctorId");
                if (!result.Success) return result;
            }
            result = BaseValidations.ValidateId(entity.SpecialtyID, "DoctorId");
            if (!result.Success) return result;

            result = BaseValidations.ValidateId(entity.AvailabilityModeId, "PatientId");
            if (!result.Success) return result;

            result = BaseValidations.ValidatePhone(entity.PhoneNumber);
            if (!result.Success) return result;

            result = BaseValidations.ValidatePhone(entity.PhoneNumber);
            if (!result.Success) return result;

            result = BaseValidations.ValidateNumber(entity.YearsOfExperience);
            if (!result.Success) return result;

            return result;
        }
    }
}
