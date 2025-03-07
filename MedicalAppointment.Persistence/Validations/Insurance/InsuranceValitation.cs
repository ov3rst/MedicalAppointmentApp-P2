using MedicalAppointment.Domain.Base;
using MedicalAppointment.Domain.Entities.Insurance;

namespace MedicalAppointment.Persistence.Validations.Insurance
{
    public class InsuranceValitation
    {
        public static OperationResult ValidateInsurance(InsuranceProvider entity, bool validateID = false)
        {
            OperationResult result = BaseValidations.ValidateEntity(entity);
            if (!result.Success) return result;

            if (validateID)
            {
                result = BaseValidations.ValidateId(entity.Id, "InsuranceId");
                if (!result.Success) return result;
            }

            result = BaseValidations.ValidateString(entity.Name, 100);
            if (!result.Success) return result;

            result = BaseValidations.ValidateLength(entity.Website!, 255);
            if (!result.Success) return result;

            result = BaseValidations.ValidatePhone(entity.ContactNumber);
            if (!result.Success) return result;

            result = BaseValidations.ValidateEmail(entity.Email);
            if (!result.Success) return result;

            result = BaseValidations.ValidateId(entity.NetworkTypeId, "NetworkTypeId");
            if (!result.Success) return result;

            return result;
        }
    }
}
