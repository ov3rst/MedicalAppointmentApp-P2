using MedicalAppointment.Domain.Base;
using MedicalAppointment.Domain.Entities.Appointments;

namespace MedicalAppointment.Persistence.Validations.Appointments
{
    public class DoctorAvailabilityValidation
    {
        public static OperationResult ValidateAvailability(DoctorAvailability entity, bool validateID = false)
        {
            OperationResult result = new OperationResult();

            if (entity is null)
            {
                result.Success = false;
                result.Message = "La entidad no puede ser nula";
                return result;
            }

            if (validateID && entity.Id <= 0)
            {
                result.Success = false;
                result.Message = "El id no puede ser menor o igual a 0";
                return result;
            }

            if (entity!.DoctorID <= 0)
            {
                result.Success = false;
                result.Message = "El doctor no debe ser nulo";
                return result;
            }

            if (entity.AvailableDate < DateOnly.FromDateTime(DateTime.Now))
            {
                result.Success = false;
                result.Message = "La fecha no puede ser anterior a la actual";
                return result;
            }

            if (entity.StartTime < TimeOnly.FromDateTime(DateTime.Now))
            {
                result.Success = false;
                result.Message = "La hora no puede ser anterior ni igual a la hora actual";
                return result;
            }

            if (entity.EndTime <= TimeOnly.FromDateTime(DateTime.Now))
            {
                result.Success = false;
                result.Message = "La hora no puede ser anterior ni igual a la hora actual";
                return result;
            }

            return result;
        }
    }
}
