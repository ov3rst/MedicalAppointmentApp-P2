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
                result = BaseValidations.ValidateId(entity.Id, "InsuranceId");
                if (!result.Success) return result;
            }

            result = BaseValidations.ValidateString(entity.EmergencyContactName);
            if (!result.Success) return result;

            result = BaseValidations.ValidateString(entity.Allergies);
            if (!result.Success) return result;

            result = BaseValidations.ValidatePhone(entity.PhoneNumber);
            if (!result.Success) return result;

            result = BaseValidations.ValidateId(entity.InsuranceProviderId, "InsuranceProviderId");
            if (!result.Success) return result;

            return result;
        }

        /*public DateOnly DateOfBirth { get; set; }
        public char Gender { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string EmergencyContactName { get; set; }
        public string EmergencyContactPhone { get; set; }
        public string BloodType { get; set; }
        public string Allergies { get; set; }
        public int InsuranceProviderId { get; set; }*/
    }
}
