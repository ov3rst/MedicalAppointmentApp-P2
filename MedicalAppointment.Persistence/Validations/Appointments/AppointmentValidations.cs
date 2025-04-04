﻿using MedicalAppointment.Domain.Base;
using MedicalAppointment.Persistence.Validations;

namespace MedicalAppointment.Domain.Entities.Appointments
{
    public class AppointmentValidations
    {
        public static OperationResult ValidateAppointment(Appointments entity, bool validateID = false)
        {
            OperationResult result = BaseValidations.ValidateEntity(entity);
            if (!result.Success) return result;

            if (validateID)
            {
                result = BaseValidations.ValidateId(entity.Id, "AppointmentId");
                if (!result.Success) return result;
            }

            result = BaseValidations.ValidateId(entity.PatientID, "PatientId");
            if (!result.Success) return result;

            result = BaseValidations.ValidateId(entity.DoctorID, "DoctorId");
            if (!result.Success) return result;

            result = BaseValidations.ValidateId(entity.StatusID, "StatusId");
            if (!result.Success) return result;

            result = BaseValidations.ValidateDate(entity.AppointmentDate);
            if (!result.Success) return result;

            return result;
        }
    }
}
