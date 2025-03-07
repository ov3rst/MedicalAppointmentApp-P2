using MedicalAppointment.Domain.Base;
using MedicalAppointment.Domain.Entities.Appointments;

namespace MedicalAppointment.Persistence.Validations.Appointments
{
    public class DoctorAvailabilityValidation
    {
        public static OperationResult ValidateAvailability(DoctorAvailability entity, bool validateID = false)
        {
            OperationResult result = new();

            if (entity is null)
            {
                result.Success = false;
                result.Message = "La entidad no puede ser nula";
                return result;
            }

            if (validateID)
            {
                result = BaseValidations.ValidateId(entity.Id, "DoctorAvailabilityId");
                if (!result.Success) return result;
            }

            result = BaseValidations.ValidateId(entity.DoctorID, "DoctorAvailabilityId");
            if (!result.Success) return result;

            result = BaseValidations.ValidateDate(BaseValidations.ToDateTime(entity.AvailableDate));
            if (!result.Success) return result;

            result = BaseValidations.ValidateTime(entity.StartTime);
            if (!result.Success) return result;

            result = BaseValidations.ValidateTime(entity.EndTime);
            if (!result.Success) return result;

            return result;
        }
    }
}
