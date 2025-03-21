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

            result = BaseValidations.ValidateString(entity.Name, length: 100);
            if (!result.Success) return result;

            result = BaseValidations.ValidatePhone(entity.ContactNumber);
            if (!result.Success) return result;

            result = BaseValidations.ValidateEmail(entity.Email);
            if (!result.Success) return result;

            result = BaseValidations.ValidateUrl(entity.Website!, allowedToBeEmpty: true);
            if (!result.Success) return result;

            result = BaseValidations.ValidateOnlyLetterAndNumber(entity.Address);
            if (!result.Success) return result;

            result = BaseValidations.ValidateString(entity.City!, length: 100, allowedToBeEmpty: true);
            if (!result.Success) return result;

            result = BaseValidations.ValidateString(entity.State!, length: 100, allowedToBeEmpty: true);
            if (!result.Success) return result;

            result = BaseValidations.ValidateString(entity.Country!, length: 100, allowedToBeEmpty: true);
            if (!result.Success) return result;

            result = BaseValidations.ValidateString(entity.ZipCode!, length: 10, allowedToBeEmpty: true);
            if (!result.Success) return result;

            result = BaseValidations.ValidateString(entity.CoverageDetails);
            if (!result.Success) return result;

            result = BaseValidations.ValidateId(entity.NetworkTypeId, "NetworkTypeId");
            if (!result.Success) return result;

            result = BaseValidations.ValidateString(entity.LogoUrl!, 255, allowedToBeEmpty: true);
            if (!result.Success) return result;

            result = BaseValidations.ValidatePhone(entity.CustomerSupportContact!, allowedToBeEmpty: true);
            if (!result.Success) return result;

            result = BaseValidations.ValidateString(entity.AcceptedRegions!, 255, allowedToBeEmpty: true);
            if (!result.Success) return result;

            return result;
        }
    }
}
