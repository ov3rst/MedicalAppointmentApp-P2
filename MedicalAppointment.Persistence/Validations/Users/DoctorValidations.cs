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
            result = BaseValidations.ValidateId(entity.SpecialtyID, "SpecialtyId");
            if (!result.Success) return result;

            result = BaseValidations.ValidateId((int)entity.AvailabilityModeId!, "AvailabilityModeId", allowedToBeEmpty: true);
            if (!result.Success) return result;

            result = BaseValidations.ValidateString(entity.LicenseNumber, length: 50);
            if (!result.Success) return result;

            result = BaseValidations.ValidatePhone(entity.PhoneNumber);
            if (!result.Success) return result;

            result = BaseValidations.ValidateNumber(entity.YearsOfExperience);
            if (!result.Success) return result;

            result = BaseValidations.ValidateString(entity.Education);
            if (!result.Success) return result;

            result = BaseValidations.ValidateString(entity.Bio!, allowedToBeEmpty: true);
            if (!result.Success) return result;

            result = BaseValidations.ValidateDecimal(entity.ConsultationFee, allowedToBeEmpty: true);
            if (!result.Success) return result;

            result = BaseValidations.ValidateString(entity.ClinicAddress!, length: 255, allowedToBeEmpty: true);
            if (!result.Success) return result;

            result = BaseValidations.ValidateDate(BaseValidations.ToDateTime(entity.LicenseExpirationDate));
            if (!result.Success) return result;

            return result;
        }
    }
}
