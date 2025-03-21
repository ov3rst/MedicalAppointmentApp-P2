﻿using MedicalAppointment.Domain.Base;
using MedicalAppointment.Domain.Entities.Insurance;

namespace MedicalAppointment.Persistence.Validations.Insurance
{
    public class NetworkValidations
    {
        public static OperationResult ValidateNetwork(NetworkType entity, bool validateID = false)
        {
            OperationResult result = BaseValidations.ValidateEntity(entity);
            if (!result.Success) return result;

            if (validateID)
            {
                result = BaseValidations.ValidateId(entity.Id, "InsuranceId");
                if (!result.Success) return result;
            }

            result = BaseValidations.ValidateString(entity.Name, length: 50);
            if (!result.Success) return result;

            result = BaseValidations.ValidateString(entity.Description!, length: 255, allowedToBeEmpty: true);
            if (!result.Success) return result;

            return result;
        }
    }
}
