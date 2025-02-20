using MedicalAppointment.Domain.Base;
using MedicalAppointment.Domain.Entities.Medical;

namespace MedicalAppointment.Persistence.Validations.Medical
{
    public class MedicalRecordsValidations
    {
        public static OperationResult ValidateMedicalRecord(MedicalRecords entity, bool validateID = false)
        {
            OperationResult result = BaseValidations.ValidateEntity(entity);
            if (!result.Success) return result;

            if (validateID)
            {
                result = BaseValidations.ValidateId(entity.Id, "InsuranceId");
                if (!result.Success) return result;
            }

            result = BaseValidations.ValidateId(entity.PatientID, "PacienteId");
            if (!result.Success) return result;

            result = BaseValidations.ValidateId(entity.DoctorID, "DoctorId");
            if (!result.Success) return result;

            result = BaseValidations.ValidateString(entity.Diagnosis);
            if (!result.Success) return result;

            result = BaseValidations.ValidateString(entity.Treatment);
            if (!result.Success) return result;

            if (entity.DateOfVisit <= DateTime.Now)
            {
                result.Success = false;
                result.Message = "Fecha y hora invalidas para visitas";
            }

            return result;
        }
    }
}
