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

            result = BaseValidations.ValidateString(entity.Name);
            if (!result.Success) return result;

            result = BaseValidations.ValidatePhone(entity.ContactNumber);
            if (!result.Success) return result;

            result = BaseValidations.ValidateEmail(entity.Email);
            if (!result.Success) return result;

            result = BaseValidations.ValidateNumber(entity.ZipCode!);
            if (!result.Success) return result;

            result = BaseValidations.ValidateId(entity.NetworkTypeId, "NetworkTypeId");
            if (!result.Success) return result;

            return result;
        }

        /*
         public string Name { get; set; }
        public string ContactNumber { get; set; }
        public string Email { get; set; }
        public string? Website { get; set; }
        public string Address { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? Country { get; set; }
        public string? ZipCode { get; set; }
        public string CoverageDetails { get; set; }
        public string? LogoUrl { get; set; }
        public bool IsPreferred { get; set; }
        public int NetworkTypeId { get; set; }
        public string? CustomerSupportContact { get; set; }
        public string? AcceptedRegions { get; set; }
        public decimal? MaxCoverageAmount { get; set; }
         */
    }
}
